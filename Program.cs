using System.Diagnostics;
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
using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ESTACAO_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_NATUREZA_PGAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_AREA_GESTORA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PROPRIETARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_SIM_NAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DRAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIV_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LOCAL_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ORIGEM_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_FONTE_GERADORAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DESTINACAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_VEICULOAggregate;
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
using Microsoft.AspNetCore.Server.Kestrel.Core;

// Garante que não há outra instância rodando antes de subir
var currentPid = Environment.ProcessId;
foreach (var proc in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName))
{
    if (proc.Id != currentPid)
    {
        Console.WriteLine($"Encerrando instância anterior (PID {proc.Id})...");
        proc.Kill(entireProcessTree: true);
        proc.WaitForExit(3000);
    }
}

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on HTTP:5000 only (disable HTTPS to avoid dev certificate issues)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // HTTP only
});

// ===== CONFIGURATION =====
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["SecretKey"] ?? "your_super_secret_jwt_key_here_min_32_characters";
var issuer = jwtSettings["Issuer"] ?? "CPTMBackend";
var audience = jwtSettings["Audience"] ?? "CPTMApp";

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
builder.Services.AddScoped<ITB_TRECHO_SENTIDORepository, TB_TRECHO_SENTIDORepository>();
builder.Services.AddScoped<ITB_ESTACAO_CPTMRepository, TB_ESTACAO_CPTMRepository>();
builder.Services.AddScoped<ITB_NATUREZA_PGARepository, TB_NATUREZA_PGARepository>();
builder.Services.AddScoped<ITB_AREA_GESTORA_CPTMRepository, TB_AREA_GESTORA_CPTMRepository>();
builder.Services.AddScoped<ITB_PROPRIETARIORepository, TB_PROPRIETARIORepository>();
builder.Services.AddScoped<ITB_SIM_NAORepository, TB_SIM_NAORepository>();
builder.Services.AddScoped<ITB_TIPO_ATIVIDADERepository, TB_TIPO_ATIVIDADERepository>();
builder.Services.AddScoped<ITB_TIPO_DRARepository, TB_TIPO_DRARepository>();
builder.Services.AddScoped<ITB_TIPO_ATIV_CPTMRepository, TB_TIPO_ATIV_CPTMRepository>();
builder.Services.AddScoped<ITB_LOCAL_ATIVIDADERepository, TB_LOCAL_ATIVIDADERepository>();
builder.Services.AddScoped<ITB_ORIGEM_EFLUENTERepository, TB_ORIGEM_EFLUENTERepository>();
builder.Services.AddScoped<ITB_FONTE_GERADORARepository, TB_FONTE_GERADORARepository>();
builder.Services.AddScoped<ITB_TIPO_DESTINACAORepository, TB_TIPO_DESTINACAORepository>();
builder.Services.AddScoped<ITB_TIPO_VEICULORepository, TB_TIPO_VEICULORepository>();
builder.Services.AddScoped<ITB_LOG_ACAORepository, TB_LOG_ACAORepository>();
builder.Services.AddScoped<ITB_LOG_SINCRONIZACAORepository, TB_LOG_SINCRONIZACAORepository>();

// ===== CONTROLLERS & API =====
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ===== SWAGGER CONFIGURATION =====
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CPTM API", Version = "v1" });

    // JWT Authentication for Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Insira o token JWT desta forma: Bearer {seu_token}"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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
            // idUsuario = 0: valor sentinela do EF Core para Oracle Identity (deixa o banco gerar o ID)
            var adminUser = new TB_USUARIO(
                idUsuario: 0,
                nmUsuario: "Administrador",
                dsLogin: "admin",
                dsSenhaHash: "",
                idPerfil: 1,
                dsEmail: "admin@cptm.gov.br",
                flAtivo: true,
                flPrimeiroAcesso: false
            );
            adminUser.UpdatePassword(passwordHasher.HashPassword(adminUser, "admin123"));
            context.TB_USUARIO.Add(adminUser);

            var operadorUser = new TB_USUARIO(
                idUsuario: 0,
                nmUsuario: "Operador Campo",
                dsLogin: "operador",
                dsSenhaHash: "",
                idPerfil: 2,
                dsEmail: "operador@cptm.gov.br",
                flAtivo: true,
                flPrimeiroAcesso: false
            );
            operadorUser.UpdatePassword(passwordHasher.HashPassword(operadorUser, "operador123"));
            context.TB_USUARIO.Add(operadorUser);

            context.SaveChanges();
            Console.WriteLine("✅ Seed users created: admin / operador");
        }
        else
        {
            Console.WriteLine($"ℹ️  TB_USUARIO already has {context.TB_USUARIO.Count()} user(s) — seed skipped");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error during migration/seed: {ex.GetType().Name}: {ex.Message}");
        if (ex.InnerException != null)
            Console.WriteLine($"   Inner: {ex.InnerException.Message}");
    }
}

// ===== MIDDLEWARE =====
// Always enable Swagger/UI (served at root) for easier local/dev access
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CPTM API v1");
    c.RoutePrefix = string.Empty; // serve UI at http://<host>/: root
});

// Do not force HTTPS redirection in local/dev to avoid redirecting to unavailable HTTPS port
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Global exception logging middleware to capture errors (especially for Swagger JSON generation)
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        // Log exception
        var logger = app.Services.GetService(typeof(ILogger<Program>)) as ILogger<Program>;
        if (logger != null)
        {
            logger.LogError(ex, "Unhandled exception processing request {Path}", context.Request.Path);
        }
        else
        {
            Console.WriteLine(ex.ToString());
        }

        // If request is for swagger JSON, return exception details to help debugging
        if (context.Request.Path.StartsWithSegments("/swagger", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(ex.ToString());
            return;
        }

        // Re-throw for other handlers (will be caught by default handlers)
        throw;
    }
});

app.Run();

// ===== HELPER FUNCTIONS =====

/// <summary>
/// Resolve connection string from environment or config
/// </summary>
static string ResolveConnectionString(IConfiguration configuration)
{
    var configConnectionString = configuration.GetConnectionString("LocalConnection");
    if (!string.IsNullOrEmpty(configConnectionString))
    {
        Console.WriteLine("?? Using Oracle connection from appsettings.json");
        return configConnectionString;
    }

    Console.WriteLine("?? Using Default Oracle connection");
    return "Data Source=localhost:1521/XEPDB1;User ID=CPTM;Password=root;";
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
