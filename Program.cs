using CPTMBack.Infraestrutura;
using CPTMBack.Infraestrutura.Repositories;
using CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblPrincipais.RT_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_SINCRONIZACAOAggregate;
using CPTMBack.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ===== CONFIGURATION =====
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["SecretKey"] ?? Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? "your_super_secret_jwt_key_here_min_32_characters";
var issuer = jwtSettings["Issuer"] ?? Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "CPTMBackend";
var audience = jwtSettings["Audience"] ?? Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "CPTMApp";

// ===== DATABASE CONFIGURATION =====
var connectionString = ResolveConnectionString(builder.Configuration);

// Test Oracle connection
if (!CanOpenOracleConnection(connectionString))
{
    Console.WriteLine("?? Warning: Could not connect to Oracle. Will retry on startup...");
}

builder.Services.AddDbContext<ConnectContext>(options =>
    options.UseOracle(connectionString)
);

// ===== CORS CONFIGURATION =====
var allowedOrigins = new[] 
{
    "http://localhost:5173",
    "http://localhost:4173",
    "https://localhost:5173",
    "https://localhost:4173",
    "http://localhost:3000",
    "http://localhost:4200"
};

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// ===== JWT AUTHENTICATION =====
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// ===== PASSWORD HASHER =====
builder.Services.AddScoped<IPasswordHasher<TB_USUARIO>, PasswordHasher<TB_USUARIO>>();

// ===== JWT SERVICE =====
builder.Services.AddScoped<IJwtTokenService>(sp => 
    new JwtTokenService(secretKey, issuer, audience)
);

// ===== REPOSITORIES INJECTION =====
builder.Services.AddScoped<IPT_EFLUENTERepository, PT_EFLUENTERepository>();
builder.Services.AddScoped<IRT_EFLUENTERepository, RT_EFLUENTERepository>();
builder.Services.AddScoped<ITB_USUARIORepository, TB_USUARIORepository>();
builder.Services.AddScoped<ITB_PERFIL_USUARIORepository, TB_PERFIL_USUARIORepository>();
builder.Services.AddScoped<ITB_MUNICIPIORepository, TB_MUNICIPIORepository>();
builder.Services.AddScoped<ITB_LINHA_CPTMRepository, TB_LINHA_CPTMRepository>();
builder.Services.AddScoped<ITB_VIA_CPTMRepository, TB_VIA_CPTMRepository>();
builder.Services.AddScoped<ITB_STATUS_DESVIO_AMBIENTALRepository, TB_STATUS_DESVIO_AMBIENTALRepository>();
builder.Services.AddScoped<ITB_STATUS_REGISTRORepository, TB_STATUS_REGISTRORepository>();
builder.Services.AddScoped<ITB_DEPTO_MEIO_AMBIENTERepository, TB_DEPTO_MEIO_AMBIENTERepository>();
builder.Services.AddScoped<ITB_TIPO_EFLUENTERepository, TB_TIPO_EFLUENTERepository>();
builder.Services.AddScoped<ITB_TRECHO_SENTIDORepository, TB_TRECHO_SENTIDORepository>();
builder.Services.AddScoped<ITB_LOG_ACAORepository, TB_LOG_ACAORepository>();
builder.Services.AddScoped<ITB_LOG_SINCRONIZACAORepository, TB_LOG_SINCRONIZACAORepository>();

// ===== CONTROLLERS & API =====
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ===== SWAGGER CONFIGURATION =====
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===== AUTOMATIC MIGRATIONS & SEED =====
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ConnectContext>();
    var passwordHasher = services.GetRequiredService<IPasswordHasher<TB_USUARIO>>();

    try
    {
        // Run migrations
        context.Database.Migrate();
        Console.WriteLine("? Migrations applied successfully");

        // Seed default users if none exist
        if (!context.TB_USUARIO.Any())
        {
            var adminUser = new TB_USUARIO(
                idUsuario: 1,
                nmUsuario: "Administrador",
                dsLogin: "admin",
                dsSenhaHash: "",
                idPerfil: 1,
                dsEmail: "admin@cptm.gov.br",
                flAtivo: true
            );

            adminUser.UpdatePassword(passwordHasher.HashPassword(adminUser, "admin123"));
            context.TB_USUARIO.Add(adminUser);

            var operadorUser = new TB_USUARIO(
                idUsuario: 2,
                nmUsuario: "Operador Campo",
                dsLogin: "operador",
                dsSenhaHash: "",
                idPerfil: 2,
                dsEmail: "operador@cptm.gov.br",
                flAtivo: true
            );

            operadorUser.UpdatePassword(passwordHasher.HashPassword(operadorUser, "operador123"));
            context.TB_USUARIO.Add(operadorUser);

            context.SaveChanges();
            Console.WriteLine("? Seed users created successfully");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"? Error during migration/seed: {ex.Message}");
    }
}

// ===== MIDDLEWARE =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// ===== HELPER FUNCTIONS =====

/// <summary>
/// Resolve connection string from environment or config
/// </summary>
static string ResolveConnectionString(IConfiguration configuration)
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
    
    // Try to get from environment variables first (Docker)
    var host = Environment.GetEnvironmentVariable("ORACLE_HOST") ?? "localhost";
    var port = Environment.GetEnvironmentVariable("ORACLE_PORT") ?? "1521";
    var sid = Environment.GetEnvironmentVariable("ORACLE_SID") ?? "XEPDB1";
    var user = Environment.GetEnvironmentVariable("ORACLE_USER") ?? "CPTM";
    var password = Environment.GetEnvironmentVariable("ORACLE_PASSWORD") ?? "root";

    var envConnectionString = $"Data Source={host}:{port}/{sid};User ID={user};Password={password};";

    // If env vars set, use them
    if (host != "localhost" || user != "CPTM")
    {
        Console.WriteLine("?? Using Oracle connection from environment variables");
        return envConnectionString;
    }

    // Otherwise use from appsettings
    var configConnectionString = configuration.GetConnectionString("LocalConnection");
    if (!string.IsNullOrEmpty(configConnectionString))
    {
        Console.WriteLine("?? Using Oracle connection from appsettings.json");
        return configConnectionString;
    }

    // Fallback to environment variables
    Console.WriteLine("?? Using Oracle connection from environment variables (fallback)");
    return envConnectionString;
}

/// <summary>
/// Test if Oracle connection can be opened
/// </summary>
static bool CanOpenOracleConnection(string connectionString)
{
    try
    {
        using var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(connectionString);
        connection.Open();
        connection.Close();
        Console.WriteLine("? Oracle connection successful");
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"?? Oracle connection failed: {ex.Message}");
        return false;
    }
}
