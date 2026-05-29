# CPTM - Sistema de Inspeção Ambiental

**Status:** ? Pronto para produção

## ?? Setup Local (Primeiro clone)

### 1?? Clonar e Configurar Ambiente

```bash
git clone <seu-repositorio>
cd CPTMBack
```

### 2?? Copiar Arquivos de Configuração

```bash
# Copiar .env
cp .env.example .env

# Copiar appsettings.json
cp appsettings.Example.json appsettings.json
```

### 3?? Editar `.env` com suas credenciais

```bash
# Linux/Mac
nano .env

# Windows
notepad .env
```

Configurar com suas credenciais Oracle:
```env
ORACLE_HOST=seu_host
ORACLE_PORT=1521
ORACLE_SID=sua_sid
ORACLE_USER=seu_usuario
ORACLE_PASSWORD=sua_senha
ASPNETCORE_ENVIRONMENT=Development
JWT_SECRET_KEY=sua_chave_jwt_secreta_aqui
```

### 4?? Editar `appsettings.json` se necessário

```json
{
  "ConnectionStrings": {
    "LocalConnection": "Data Source=seu_host:1521/sua_sid;User ID=seu_usuario;Password=sua_senha;"
  }
}
```

---

## Setup Rápido (Ambiente já configurado)

### 1?? Connection String
Editar `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "LocalConnection": "Data Source=localhost:1521/XEPDB1;User ID=CPTM;Password=root;"
  }
}
```

### 2?? Gerar Migration
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialOracleMigration
```

### 3?? Aplicar ao Banco
```bash
dotnet ef database update
```

## O que foi criado

### 16 Entities | 14 Repositories | 14 Tabelas Oracle

**Principais (2):**
- `PT_EFLUENTE` - Efluentes com 35 colunas (coordenadas, observações, fotos)
- `RT_EFLUENTE` - Anexos BLOB para imagens/arquivos

**Domínio (9):**
- `TB_PERFIL_USUARIO` (2 registros: ADMIN, USUARIO_CAMPO)
- `TB_STATUS_REGISTRO` (4 registros: ATIVO, INATIVO, PENDENTE, SINCRONIZADO)
- `TB_STATUS_DESVIO_AMBIENTAL` (4: ABERTO, EM_ANALISE, RESOLVIDO, CANCELADO)
- `TB_TIPO_EFLUENTE` (5: ESGOTO, OLEO, QUIMICO, INDUSTRIAL, AGUA_CONTAMINADA)
- `TB_VIA_CPTM` (2: VIA_1, VIA_2)
- `TB_LINHA_CPTM` (7: LINHA_7 a LINHA_13)
- `TB_DEPTO_MEIO_AMBIENTE` (4: NORTE, SUL, LESTE, OESTE)
- `TB_MUNICIPIO` (vazio)
- `TB_TRECHO_SENTIDO` (vazio)

**Sistema (3):**
- `TB_USUARIO`, `TB_LOG_ACAO`, `TB_LOG_SINCRONIZACAO`

## Seed Data

**29 registros pré-carregados:**
- TB_PERFIL_USUARIO: 2
- TB_STATUS_REGISTRO: 4
- TB_STATUS_DESVIO_AMBIENTAL: 4
- TB_TIPO_EFLUENTE: 5
- TB_VIA_CPTM: 2
- TB_LINHA_CPTM: 7
- TB_DEPTO_MEIO_AMBIENTE: 4

## Estrutura

```
CPTMBack/
??? Domain/Model/
?   ??? TblPrincipais/ (PT_EFLUENTE, RT_EFLUENTE)
?   ??? TblDominio/ (9 entities)
?   ??? TblSistema/ (TB_USUARIO, TB_LOG_*)

??? Infraestrutura/
?   ??? Repositories/ (14 interfaces + implementações)
?   ??? ConnectContext.cs (DbContext com seed data)
?   ??? Migrations/

??? Services/ (JwtTokenService)

??? Controllers/
```

## Usar Repositories

```csharp
// Injetar no Controller
private readonly IRepositoryName _repo;

public MyController(IRepositoryName repo) => _repo = repo;

// CRUD
public void Example()
{
    var item = new Entity(...);
    
    _repo.Add(item);           // Create
    var all = _repo.GetAll();  // Read All
    var one = _repo.Get("id"); // Read By ID
    _repo.Update(item);        // Update
    _repo.Delete("id");        // Delete
}
```

## Tipos de Dados

| Oracle | C# | Uso |
|--------|-----|-----|
| VARCHAR2(n) | string | Textos curtos |
| NUMBER | int | IDs, contadores |
| NUMBER(18,8) | decimal | Coordenadas geográficas |
| NUMBER(18,2) | decimal | Valores monetários |
| NUMBER(1) | bool | Flags (FL_ATIVO) |
| DATE/TIMESTAMP | DateTime | Datas/horas |
| BLOB | byte[] | Imagens, arquivos |
| NVARCHAR2(n) | string | Textos Unicode/CLOB |

## Comandos Úteis

```bash
# Listar migrations
dotnet ef migrations list

# Ver SQL gerado
dotnet ef migrations script

# Remover última migration
dotnet ef migrations remove -f

# Resetar banco (?? PERDA DE DADOS)
dotnet ef database drop --force
dotnet ef database update

# Build
dotnet build

# Executar
dotnet run
```

## Resolução de Problemas

**Erro ao conectar ao Oracle:**
- Verificar if Oracle está rodando: `lsnrctl status`
- Testar conexão: `sqlplus CPTM/root@localhost:1521/XEPDB1`

**Erro `ORA-00955: nome já está sendo usado`:**
- Banco já tem tabelas: `dotnet ef database drop --force`
- Depois: `dotnet ef database update`

**Migration não encontrada:**
- `dotnet tool install --global dotnet-ef`
- `dotnet restore`

## ?? Variáveis de Ambiente

Arquivos sensíveis **NÃO** são commitados:
- `.env` - Use `.env.example` como template
- `appsettings.json` - Use `appsettings.Example.json` como template

Nunca commitar:
- Chaves de API
- Senhas de banco
- Credenciais JWT
- Connection strings reais

## Próximos Passos

- [ ] Criar Controllers REST
- [ ] Implementar DTOs
- [ ] Adicionar autenticação JWT
- [ ] Testes unitários
- [ ] CI/CD

---

**Framework:** .NET 8 | **ORM:** EF Core 8 | **DB:** Oracle XE
**Architecture:** Clean Architecture + Repository Pattern
