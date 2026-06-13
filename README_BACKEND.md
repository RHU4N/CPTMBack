# README — Backend CPTM API

**Autores:** Leonardo Torres, Mauricio Maio, Rhuan Santana, Vitor Bastos

---

## Visão Geral

API RESTful para o sistema de inspeção ambiental da CPTM (Companhia Paulista de Trens Metropolitanos). Gerencia o Formulário de Dados de Campo (FDC) para efluentes, com autenticação JWT, controle de acesso por perfil, logs de auditoria, upload de fotos e persistência em Oracle XE.

---

## Arquitetura

```
CPTMBack/
├── Controllers/          # Endpoints REST (Auth, PT_EFLUENTE, RT_EFLUENTE, Dominio, TB_USUARIO, Log)
├── Domain/
│   ├── DTOs/             # Data Transfer Objects de entrada
│   ├── Model/            # Entidades EF Core (TB_*, RT_*, PT_*, LOG_*)
│   └── Repositories/     # Interfaces de repositório
├── Infrastructure/
│   ├── Data/             # DbContext (OracleDbContext) e migrations
│   └── Repositories/     # Implementações dos repositórios
├── Services/             # JwtTokenService, lógica de negócio
├── Application/
│   └── ViewModels/       # ViewModels de entrada (Login, TrocaSenha, etc.)
├── Dockerfile
└── docker-compose.yml    # 3 serviços: oracle, api, frontend
```

### Fluxo de Requisição

```
Browser → nginx:8080 → [SPA Vue]
Browser → API:5000  → AuthController / PT_EFLUENTEController / ...
                     → OracleDbContext (EF Core)
                     → Oracle XE:1521 (container cptm_oracle)
```

---

## Stack Tecnológica

| Componente | Tecnologia |
|---|---|
| Runtime | .NET 9 (ASP.NET Core) |
| ORM | Entity Framework Core 9 |
| Banco de dados | Oracle XE 21 (gvenzl/oracle-xe:21-slim) |
| Driver Oracle | Oracle.EntityFrameworkCore 9.23.x |
| Autenticação | JWT Bearer (System.IdentityModel.Tokens.Jwt 8.x) |
| Hash de senhas | ASP.NET Identity PasswordHasher |
| Documentação | Swagger/OpenAPI (Swashbuckle 6.9) |
| Containerização | Docker + Docker Compose |

---

## Controllers e Endpoints

### AuthController — `/api/Auth`

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| POST | `/api/Auth/login` | Anônimo | Login com `dsLogin`/`dsSenha`. Retorna JWT + `primeiroAcesso` |
| POST | `/api/Auth/register` | Anônimo | Cadastro de usuário (sem validação de força de senha) |
| POST | `/api/Auth/refresh` | Bearer | Renova token JWT |

**Resposta de login bem-sucedido:**
```json
{
  "sucesso": true,
  "token": "<jwt>",
  "idPerfil": 1,
  "primeiroAcesso": false
}
```

**Erros:** `400 Bad Request` (campos obrigatórios) · `401 Unauthorized` (credenciais inválidas, usuário inativo)

---

### PT_EFLUENTEController — `/api/PT_EFLUENTE`

| Método | Rota | Perfil | Descrição |
|---|---|---|---|
| GET | `/api/PT_EFLUENTE` | Admin/Operador | Lista inspeções (operador vê apenas as próprias) |
| GET | `/api/PT_EFLUENTE/{id}` | Admin/Operador | Detalhe de inspeção |
| POST | `/api/PT_EFLUENTE` | Admin/Operador | Cria inspeção (campo obrigatório: `pkCdMeioAmbienteCptm`) |
| PUT | `/api/PT_EFLUENTE/{id}` | Admin/Operador | Atualiza inspeção |
| DELETE | `/api/PT_EFLUENTE/{id}` | Admin | Remove inspeção |

**Logs gerados:** `CRIACAO_INSPECAO` (POST) · `ATUALIZACAO_INSPECAO` (PUT)

---

### RT_EFLUENTEController — `/api/RT_EFLUENTE`

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| POST | `/api/RT_EFLUENTE/upload` | Bearer | Upload de foto (multipart/form-data: `relObjectId` + `file`) |
| GET | `/api/RT_EFLUENTE/efluente/{relObjectId}` | Bearer | Lista fotos de uma inspeção |
| GET | `/api/RT_EFLUENTE/download/{id}` | Bearer | Download de foto por ID |

Fotos são persistidas como BLOB na tabela `RT_EFLUENTE` (campo `DATA`).

---

### DominioController — `/api/dominio`

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| GET | `/api/dominio/municipios` | Anônimo | Lista municípios |
| GET | `/api/dominio/linhas` | Anônimo | Lista linhas CPTM |
| GET | `/api/dominio/{tipo}` | Anônimo | Lista domínio por tipo |
| POST | `/api/dominio/{tipo}` | Admin | Cria item `{ descricao: "..." }` |
| PUT | `/api/dominio/{tipo}/{id}` | Admin | Atualiza item |
| DELETE | `/api/dominio/{tipo}/{id}` | Admin | Remove item |

---

### TB_USUARIOController — `/api/TB_USUARIO`

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| GET | `/api/TB_USUARIO` | Admin | Lista usuários |
| POST | `/api/TB_USUARIO` | Admin | Cria usuário com senha temporária |
| PUT | `/api/TB_USUARIO/{id}` | Admin | Atualiza usuário |
| DELETE | `/api/TB_USUARIO/{id}` | Admin | Remove usuário |
| POST | `/api/TB_USUARIO/trocar-senha` | Bearer | Troca de senha `{ dsSenhaAtual, dsNovaSenha, dsNovaSenhaConfirm }` |

**Política de senha (RNF14):** mínimo 8 caracteres · minúscula · maiúscula · dígito · especial. Aplicada no `trocar-senha` e criação de usuário via admin.

---

### LogController — `/api/log`

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| GET | `/api/log/acoes` | Admin | Lista TB_LOG_ACAO |
| POST | `/api/log/sincronizacoes` | Bearer | Registra sincronização `{ dsStatus, dsMensagem }` |
| GET | `/api/log/sincronizacoes` | Admin | Lista TB_LOG_SINCRONIZACAO |

---

## JWT e Autenticação

```csharp
// Configuração no Program.cs
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Jwt:Issuer"],       // cptm-api
            ValidAudience = config["Jwt:Audience"],   // cptm-web
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]))
        };
    });
```

**Perfis (Claims `role`):**
- `1` = `admin` — acesso total
- `2` = `operador` — acesso restrito às próprias inspeções

---

## Docker

### Serviços

| Container | Imagem | Portas | Health |
|---|---|---|---|
| `cptm_oracle` | gvenzl/oracle-xe:21-slim | 1522→1521, 5500→5500 | sqlplus CPTM login |
| `cptm_api` | Dockerfile (multi-stage) | 5000→5000 | depends_on oracle healthy |
| `cptm_frontend` | ../CPTMFront/Dockerfile | 8080→80 | depends_on api |

### Inicialização

```bash
# Clonar e configurar variáveis de ambiente
cp .env.example .env
# Editar .env: ORACLE_PASSWORD, JWT_SECRET_KEY

# Subir todos os serviços
docker compose up -d

# Acompanhar logs
docker compose logs -f api

# Verificar saúde
docker compose ps
```

A API aplica migrations automaticamente na inicialização com retry loop (aguarda Oracle ficar disponível).

---

## Variáveis de Ambiente

| Variável | Descrição | Obrigatória |
|---|---|---|
| `ORACLE_PASSWORD` | Senha do usuário Oracle CPTM | Sim |
| `JWT_SECRET_KEY` | Chave de assinatura JWT (≥ 32 chars) | Sim |
| `Jwt__Issuer` | Issuer do token (padrão: `cptm-api`) | Não |
| `Jwt__Audience` | Audience do token (padrão: `cptm-web`) | Não |
| `Jwt__ExpiresMinutes` | Validade do token em minutos (padrão: `120`) | Não |
| `Cors__AllowedOrigins__0` | Origem permitida no CORS | Não |
| `ConnectionStrings__LocalConnection` | String de conexão Oracle completa | Sim |

---

## Desenvolvimento Local

### Pré-requisitos

- .NET 9 SDK
- Oracle XE 21 (via Docker) ou acesso a instância existente
- Variável `ConnectionStrings:LocalConnection` configurada

```bash
# Subir somente o Oracle
docker compose up oracle -d

# Rodar API em modo desenvolvimento
cd CPTMBack
dotnet run

# Build Release
dotnet build -c Release

# Migrations
dotnet ef migrations add NomeMigration
dotnet ef database update
```

---

## Deploy em Produção (Azure)

1. Criar Azure Container Registry (ACR)
2. Build e push das imagens:
   ```bash
   docker build -t <acr>.azurecr.io/cptm-api:latest .
   docker push <acr>.azurecr.io/cptm-api:latest
   ```
3. Provisionar Azure Database for Oracle ou Oracle Cloud
4. Configurar App Service / Container Instances com variáveis de ambiente
5. Configurar CORS para o domínio de produção do frontend

---

## Tabelas Principais

| Tabela | Descrição |
|---|---|
| `TB_USUARIO` | Usuários do sistema |
| `PT_EFLUENTE` | Inspeções de efluente (FDC) |
| `RT_EFLUENTE` | Fotos das inspeções (BLOB) |
| `TB_LOG_ACAO` | Log de ações do usuário |
| `TB_LOG_SINCRONIZACAO` | Log de sincronizações offline |
| `TB_DOMINIO_*` | Tabelas de domínio (municípios, linhas, origens, etc.) |
