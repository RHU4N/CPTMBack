# README — Backend CPTM API

**Autores:** Leonardo Torres, Mauricio Maia, Rhuan Santana, Vitor Bastos

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
├── Infraestrutura/
│   ├── ConnectContext.cs # DbContext (EF Core)
│   └── Repositories/     # Implementações dos repositórios
├── Services/             # JwtTokenService
├── Application/
│   └── ViewModels/       # ViewModels de entrada (Login, TrocaSenha, etc.)
├── Migrations/
├── Program.cs
├── Dockerfile
└── docker-compose.yml    # 3 serviços: oracle, api, frontend
```

### Fluxo de Requisição

```
Browser → nginx:8080 → [SPA Vue]
Browser → API:5000   → AuthController / PT_EFLUENTEController / ...
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
| Hash de senhas | ASP.NET Identity PasswordHasher (PBKDF2 com salt) |
| Documentação | Swagger/OpenAPI (Swashbuckle 6.9) |
| Containerização | Docker + Docker Compose |

---

## Start Rápido

### Docker (Recomendado)

```bash
cp .env.example .env
# Editar .env: ORACLE_PASSWORD, JWT_SECRET_KEY

docker compose up -d
# Aguarde ~30s para o Oracle inicializar
# Swagger: http://localhost:5000/swagger
# Login:   admin / admin123
```

### Local

```bash
cp .env.example .env
cp appsettings.Example.json appsettings.json
dotnet restore
dotnet run
```

---

## Credenciais Padrão

| Usuário | Login | Senha | Perfil |
|---|---|---|---|
| Admin | admin | admin123 | ADMINISTRADOR (1) |
| Operador | operador | operador123 | USUARIO_CAMPO (2) |

---

## Controllers e Endpoints

### AuthController — `/api/Auth`

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| POST | `/api/Auth/login` | Anônimo | Login com `dsLogin`/`dsSenha`. Retorna JWT + `primeiroAcesso` |
| POST | `/api/Auth/register` | Anônimo | Cadastro de usuário |
| POST | `/api/Auth/refresh` | Bearer | Renova token JWT |
| GET | `/api/Auth/me` | Bearer | Dados do usuário autenticado |

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
| GET | `/api/PT_EFLUENTE/search/by-status/{id}` | Admin/Operador | Busca por status |
| GET | `/api/PT_EFLUENTE/search/by-municipality/{id}` | Admin/Operador | Busca por município |
| POST | `/api/PT_EFLUENTE` | Admin/Operador | Cria inspeção (campo obrigatório: `pkCdMeioAmbienteCptm`) |
| PUT | `/api/PT_EFLUENTE/{id}` | Admin/Operador | Atualiza inspeção |
| DELETE | `/api/PT_EFLUENTE/{id}` | Admin | Remove inspeção |

**Logs gerados:** `CRIACAO_INSPECAO` (POST) · `ATUALIZACAO_INSPECAO` (PUT)

---

### RT_EFLUENTEController — `/api/RT_EFLUENTE` (Upload BLOB)

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| POST | `/api/RT_EFLUENTE/upload` | Bearer | Upload de foto (multipart/form-data: `relObjectId` + `file`) |
| GET | `/api/RT_EFLUENTE/efluente/{relObjectId}` | Bearer | Lista fotos de uma inspeção |
| GET | `/api/RT_EFLUENTE/download/{id}` | Bearer | Download de foto por ID |
| GET | `/api/RT_EFLUENTE` | Bearer | Lista todos os anexos |
| DELETE | `/api/RT_EFLUENTE/{id}` | Admin | Remove anexo |

Fotos são persistidas como BLOB na tabela `RT_EFLUENTE`. Tamanho máximo: 10 MB. Tipos aceitos: JPEG, PNG, GIF, WebP, PDF, Word.

```bash
# Exemplo de upload
curl -X POST http://localhost:5000/api/RT_EFLUENTE/upload \
  -H "Authorization: Bearer <token>" \
  -F "relObjectId=EFL001" \
  -F "file=@photo.jpg"

# Download
curl -X GET http://localhost:5000/api/RT_EFLUENTE/download/1 \
  -H "Authorization: Bearer <token>" \
  -o photo.jpg
```

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
| GET | `/api/TB_USUARIO/{id}` | Admin | Obter por ID |
| GET | `/api/TB_USUARIO/by-login/{login}` | Bearer | Obter por login |
| GET | `/api/TB_USUARIO/by-profile/{id}` | Admin | Listar por perfil |
| GET | `/api/TB_USUARIO/filter/active` | Admin | Usuários ativos |
| POST | `/api/TB_USUARIO` | Admin | Cria usuário com senha temporária |
| PUT | `/api/TB_USUARIO/{id}` | Admin | Atualiza usuário |
| PUT | `/api/TB_USUARIO/{id}/deactivate` | Admin | Desativa usuário |
| PUT | `/api/TB_USUARIO/{id}/activate` | Admin | Ativa usuário |
| DELETE | `/api/TB_USUARIO/{id}` | Admin | Remove usuário |
| POST | `/api/TB_USUARIO/trocar-senha` | Bearer | Troca de senha `{ dsSenhaAtual, dsNovaSenha, dsNovaSenhaConfirm }` |

**Política de senha (RNF14):** mínimo 8 caracteres, minúscula, maiúscula, dígito e especial. Aplicada no `trocar-senha` e na criação pelo admin.

---

### LogController — `/api/log`

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| GET | `/api/log/acoes` | Admin | Lista TB_LOG_ACAO |
| POST | `/api/log/sincronizacoes` | Bearer | Registra sincronização `{ dsStatus, dsMensagem }` |
| GET | `/api/log/sincronizacoes` | Admin | Lista TB_LOG_SINCRONIZACAO |

---

## JWT e Autenticação

```
Issuer:    cptm-api
Audience:  cptm-web
Algorithm: HMAC SHA256
Expiração: 120 minutos (configurável via Jwt__ExpiresMinutes)
Refresh:   POST /api/Auth/refresh
```

**Perfis (claim `role`):**
- `1` = `admin` — acesso total
- `2` = `operador` — acesso restrito às próprias inspeções

Senhas nunca armazenadas em texto plano: PBKDF2 com salt via ASP.NET Identity PasswordHasher.

---

## Docker

### Serviços

| Container | Imagem | Portas | Dependência |
|---|---|---|---|
| `cptm_oracle` | gvenzl/oracle-xe:21-slim | 1522→1521, 5500→5500 | — |
| `cptm_api` | Dockerfile (multi-stage) | 5000→5000 | oracle healthy |
| `cptm_frontend` | ../CPTMFront/Dockerfile | 8080→80 | api |

Oracle: user `CPTM`, SID `XEPDB1`. Volume `oracle_data` para persistência. A API aplica migrations automaticamente na inicialização com retry loop enquanto aguarda o Oracle ficar disponível.

### Comandos

```bash
docker compose up -d            # Iniciar todos os serviços
docker compose logs -f api      # Logs da API
docker compose logs -f oracle   # Logs do Oracle
docker compose ps               # Verificar saúde dos containers
docker compose down             # Parar
docker compose down -v          # Parar e resetar banco (PERDA DE DADOS)
```

---

## Variáveis de Ambiente

| Variável | Descrição | Obrigatória |
|---|---|---|
| `ORACLE_PASSWORD` | Senha do usuário Oracle CPTM | Sim |
| `JWT_SECRET_KEY` | Chave de assinatura JWT (mín. 32 chars) | Sim |
| `ConnectionStrings__LocalConnection` | String de conexão Oracle completa | Sim |
| `Jwt__Issuer` | Issuer do token (padrão: `cptm-api`) | Não |
| `Jwt__Audience` | Audience do token (padrão: `cptm-web`) | Não |
| `Jwt__ExpiresMinutes` | Validade do token em minutos (padrão: `120`) | Não |
| `Cors__AllowedOrigins__0` | Origem adicional permitida no CORS | Não |

Use `.env.example` como template. Nunca commitar `.env` ou `appsettings.json`.

**Arquivo `.env` de exemplo:**
```env
ORACLE_HOST=localhost
ORACLE_PORT=1521
ORACLE_SID=XEPDB1
ORACLE_USER=CPTM
ORACLE_PASSWORD=root
JWT_SECRET_KEY=your_super_secret_jwt_key_here_min_32_characters
JWT_ISSUER=cptm-api
JWT_AUDIENCE=cptm-web
ASPNETCORE_ENVIRONMENT=Development
```

---

## Desenvolvimento Local

**Pré-requisitos:** .NET 9 SDK · Oracle XE 21 (via Docker ou instância existente)

```bash
# Subir somente o Oracle
docker compose up oracle -d

# Rodar API
dotnet run

# Com auto-reload
dotnet watch run

# Build Release
dotnet build -c Release

# Migrations
dotnet ef migrations add <NomeMigration>   # Criar migration
dotnet ef migrations list                  # Listar migrations
dotnet ef database update                  # Aplicar migrations
dotnet ef database drop --force            # Resetar banco
dotnet ef migrations script               # Ver SQL gerado

# Instalar EF CLI (se necessário)
dotnet tool install --global dotnet-ef
```

---

## Deploy em Produção (Azure)

1. Criar Azure Container Registry (ACR)
2. Build e push das imagens:
   ```bash
   docker build -t <acr>.azurecr.io/cptm-api:latest .
   docker push <acr>.azurecr.io/cptm-api:latest
   ```
3. Provisionar Oracle Cloud ou Azure Database
4. Configurar App Service / Container Instances com variáveis de ambiente
5. Configurar CORS para o domínio de produção do frontend

---

## Banco de Dados — Tabelas

| Tabela | Descrição |
|---|---|
| `TB_USUARIO` | Usuários do sistema |
| `PT_EFLUENTE` | Inspeções de efluente — FDC (35+ colunas: coordenadas, observações, fotos) |
| `RT_EFLUENTE` | Fotos das inspeções (BLOB) |
| `TB_LOG_ACAO` | Log de ações do usuário |
| `TB_LOG_SINCRONIZACAO` | Log de sincronizações offline |
| `TB_PERFIL_USUARIO` | Perfis (2 registros: admin, operador) |
| `TB_STATUS_REGISTRO` | Status de registro (4 registros) |
| `TB_STATUS_DESVIO_AMBIENTAL` | Status de desvio (4 registros) |
| `TB_TIPO_EFLUENTE` | Tipos de efluente (5 registros) |
| `TB_VIA_CPTM` | Vias (2 registros) |
| `TB_LINHA_CPTM` | Linhas (7 registros) |
| `TB_DEPTO_MEIO_AMBIENTE` | Departamentos (4 registros) |
| `TB_MUNICIPIO` | Municípios |
| `TB_TRECHO_SENTIDO` | Trechos e sentidos |

**Mapeamento Oracle → C#:**

| Oracle | C# | Uso |
|---|---|---|
| VARCHAR2(n) | string | Textos curtos |
| NUMBER | int | IDs, contadores |
| NUMBER(18,8) | decimal? | Coordenadas geográficas |
| NUMBER(1) | bool | Flags (FL_ATIVO) |
| DATE/TIMESTAMP | DateTime? | Datas/horas |
| BLOB | byte[] | Imagens, arquivos |

---

## Troubleshooting

### Erro: "Cannot connect to Oracle"
```bash
docker compose logs oracle
# ou localmente:
sqlplus CPTM/root@localhost:1521/XEPDB1
# verificar listener:
lsnrctl status
```

### Erro: "ORA-00955: nome já está sendo usado"
```bash
dotnet ef database drop --force
dotnet ef database update
```

### Erro: "Port 5000 already in use"
```bash
# Parar container
docker compose down

# Ou matar processo (Linux/Mac)
lsof -i :5000 | grep LISTEN | awk '{print $2}' | xargs kill -9
```

### Erro: "JWT token invalid"
```
Fazer novo login em POST /api/Auth/login
Token expira em 120 minutos — use POST /api/Auth/refresh para renovar
```

### Migration não encontrada
```bash
dotnet tool install --global dotnet-ef
dotnet restore
dotnet ef database update
```
