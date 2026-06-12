using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TB_USUARIOController : ControllerBase
    {
        private readonly ITB_USUARIORepository _usuarioRepository;
        private readonly ITB_PERFIL_USUARIORepository _perfilRepository;
        private readonly ITB_LOG_ACAORepository _logRepository;
        private readonly IPasswordHasher<TB_USUARIO> _passwordHasher;
        private readonly ILogger<TB_USUARIOController> _logger;

        public TB_USUARIOController(
            ITB_USUARIORepository usuarioRepository,
            ITB_PERFIL_USUARIORepository perfilRepository,
            ITB_LOG_ACAORepository logRepository,
            IPasswordHasher<TB_USUARIO> passwordHasher,
            ILogger<TB_USUARIOController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
            _logRepository = logRepository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        // GET /api/TB_USUARIO
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            try
            {
                var usuarios = _usuarioRepository.GetAll().ToList();
                var perfis = _perfilRepository.GetAll().ToList();
                var dtos = usuarios.Select(u => MapToDTO(u, perfis)).ToList();

                _logger.LogInformation("Listagem de usuarios: {Count} registros", dtos.Count);
                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar usuarios");
                return BadRequest(new { mensagem = "Erro ao recuperar usuarios", erro = ex.Message });
            }
        }

        // GET /api/TB_USUARIO/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                var perfis = _perfilRepository.GetAll().ToList();
                return Ok(MapToDTO(usuario, perfis));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar usuario {Id}", id);
                return BadRequest(new { mensagem = "Erro ao recuperar usuario", erro = ex.Message });
            }
        }

        // POST /api/TB_USUARIO
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create([FromBody] CreateUsuarioDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.nmUsuario) ||
                    string.IsNullOrWhiteSpace(dto.dsLogin) ||
                    string.IsNullOrWhiteSpace(dto.dsSenha))
                    return BadRequest(new { mensagem = "Nome, login e senha sao obrigatorios" });

                var senhaErro = ValidarForcaSenha(dto.dsSenha);
                if (senhaErro != null)
                    return BadRequest(new { mensagem = senhaErro });

                var todos = _usuarioRepository.GetAll().ToList();

                if (todos.Any(u => u.dsLogin.ToLower() == dto.dsLogin.ToLower()))
                    return Conflict(new { mensagem = "Login ja cadastrado" });

                if (!string.IsNullOrWhiteSpace(dto.dsEmail) &&
                    todos.Any(u => u.dsEmail != null && u.dsEmail.ToLower() == dto.dsEmail.ToLower()))
                    return Conflict(new { mensagem = "E-mail ja cadastrado" });

                var nextId = _usuarioRepository.GetNextId();
                var senhaHash = _passwordHasher.HashPassword(null!, dto.dsSenha);

                var novoUsuario = new TB_USUARIO(
                    idUsuario: nextId,
                    nmUsuario: dto.nmUsuario,
                    dsLogin: dto.dsLogin,
                    dsSenhaHash: senhaHash,
                    idPerfil: dto.idPerfil,
                    dsEmail: dto.dsEmail,
                    flAtivo: dto.flAtivo,
                    flPrimeiroAcesso: true,
                    dtCadastro: DateTime.UtcNow,
                    dtAtualizacao: DateTime.UtcNow
                );

                _usuarioRepository.Add(novoUsuario);

                var adminId = ObterIdUsuarioLogado();
                RegistrarLog(adminId, "CRIACAO", "TB_USUARIO", nextId.ToString(), $"Admin criou usuario '{dto.dsLogin}'");

                _logger.LogInformation("Usuario criado: {Login} (ID {Id})", dto.dsLogin, nextId);

                var perfis = _perfilRepository.GetAll().ToList();
                return CreatedAtAction(nameof(GetById), new { id = nextId }, MapToDTO(novoUsuario, perfis));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuario");
                return BadRequest(new { mensagem = "Erro ao criar usuario", erro = ex.Message });
            }
        }

        // PUT /api/TB_USUARIO/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id, [FromBody] UpdateUsuarioDTO dto)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                usuario.UpdateAllInfo(dto.nmUsuario, dto.dsEmail, dto.idPerfil);
                _usuarioRepository.Update(usuario);

                var adminId = ObterIdUsuarioLogado();
                RegistrarLog(adminId, "EDICAO", "TB_USUARIO", id.ToString(), $"Admin editou usuario ID {id}");

                _logger.LogInformation("Usuario atualizado: {Id}", id);

                var perfis = _perfilRepository.GetAll().ToList();
                return Ok(new { mensagem = "Usuario atualizado com sucesso", dados = MapToDTO(usuario, perfis) });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuario {Id}", id);
                return BadRequest(new { mensagem = "Erro ao atualizar usuario", erro = ex.Message });
            }
        }

        // PATCH /api/TB_USUARIO/{id}/trocar-login
        [HttpPatch("{id}/trocar-login")]
        [Authorize(Roles = "admin")]
        public IActionResult TrocarLogin(int id, [FromBody] TrocarLoginDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.novoLogin))
                    return BadRequest(new { mensagem = "Login nao pode ser vazio" });

                var usuario = _usuarioRepository.Get(id);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                var todos = _usuarioRepository.GetAll().ToList();
                if (todos.Any(u => u.idUsuario != id && u.dsLogin.ToLower() == dto.novoLogin.ToLower()))
                    return Conflict(new { mensagem = "Login ja em uso por outro usuario" });

                usuario.UpdateProfile(usuario.nmUsuario, usuario.dsEmail, dto.novoLogin);
                _usuarioRepository.Update(usuario);

                var adminId = ObterIdUsuarioLogado();
                RegistrarLog(adminId, "TROCA_LOGIN", "TB_USUARIO", id.ToString(), $"Admin trocou login do usuario ID {id} para '{dto.novoLogin}'");
                _logger.LogInformation("Login trocado para usuario {Id}: {Login}", id, dto.novoLogin);

                var perfis = _perfilRepository.GetAll().ToList();
                return Ok(new { mensagem = "Login alterado com sucesso", dados = MapToDTO(usuario, perfis) });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao trocar login do usuario {Id}", id);
                return BadRequest(new { mensagem = "Erro ao trocar login", erro = ex.Message });
            }
        }

        // PATCH /api/TB_USUARIO/{id}/desativar
        [HttpPatch("{id}/desativar")]
        [Authorize(Roles = "admin")]
        public IActionResult Desativar(int id)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                if (!usuario.flAtivo)
                    return BadRequest(new { mensagem = "Usuario ja esta inativo" });

                usuario.SetActive(false);
                _usuarioRepository.Update(usuario);

                var adminId = ObterIdUsuarioLogado();
                RegistrarLog(adminId, "DESATIVACAO", "TB_USUARIO", id.ToString(), $"Admin desativou usuario ID {id}");

                _logger.LogInformation("Usuario desativado: {Id}", id);

                var perfis = _perfilRepository.GetAll().ToList();
                return Ok(new { mensagem = "Usuario desativado com sucesso", dados = MapToDTO(usuario, perfis) });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao desativar usuario {Id}", id);
                return BadRequest(new { mensagem = "Erro ao desativar usuario", erro = ex.Message });
            }
        }

        // PATCH /api/TB_USUARIO/{id}/reativar
        [HttpPatch("{id}/reativar")]
        [Authorize(Roles = "admin")]
        public IActionResult Reativar(int id)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                if (usuario.flAtivo)
                    return BadRequest(new { mensagem = "Usuario ja esta ativo" });

                usuario.SetActive(true);
                _usuarioRepository.Update(usuario);

                var adminId = ObterIdUsuarioLogado();
                RegistrarLog(adminId, "REATIVACAO", "TB_USUARIO", id.ToString(), $"Admin reativou usuario ID {id}");

                _logger.LogInformation("Usuario reativado: {Id}", id);

                var perfis = _perfilRepository.GetAll().ToList();
                return Ok(new { mensagem = "Usuario reativado com sucesso", dados = MapToDTO(usuario, perfis) });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao reativar usuario {Id}", id);
                return BadRequest(new { mensagem = "Erro ao reativar usuario", erro = ex.Message });
            }
        }

        // POST /api/TB_USUARIO/trocar-senha
        [HttpPost("trocar-senha")]
        public IActionResult TrocarSenha([FromBody] TrocaSenhaDTO dto)
        {
            try
            {
                var userId = ObterIdUsuarioLogado();
                if (userId == 0)
                    return Unauthorized(new { mensagem = "Token invalido" });

                var usuario = _usuarioRepository.Get(userId);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                if (!usuario.flAtivo)
                    return Unauthorized(new { mensagem = "Usuario inativo" });

                if (dto.dsNovaSenha != dto.dsNovaSenhaConfirm)
                    return BadRequest(new { mensagem = "As senhas nao conferem" });

                var senhaErro = ValidarForcaSenha(dto.dsNovaSenha);
                if (senhaErro != null)
                    return BadRequest(new { mensagem = senhaErro });

                var verificacao = _passwordHasher.VerifyHashedPassword(usuario, usuario.dsSenhaHash, dto.dsSenhaAtual);
                if (verificacao == PasswordVerificationResult.Failed)
                    return BadRequest(new { mensagem = "Senha atual incorreta" });

                var novoHash = _passwordHasher.HashPassword(usuario, dto.dsNovaSenha);
                usuario.CompleteFirstAccess(novoHash);
                _usuarioRepository.Update(usuario);

                RegistrarLog(userId, "TROCA_SENHA", "TB_USUARIO", userId.ToString(), $"Usuario ID {userId} trocou a senha");

                _logger.LogInformation("Senha trocada para usuario {Id}", userId);

                return Ok(new { mensagem = "Senha alterada com sucesso", primeiroAcesso = false });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao trocar senha");
                return BadRequest(new { mensagem = "Erro ao trocar senha", erro = ex.Message });
            }
        }

        // PATCH /api/TB_USUARIO/{id}/redefinir-senha
        [HttpPatch("{id}/redefinir-senha")]
        [Authorize(Roles = "admin")]
        public IActionResult RedefinirSenha(int id)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                var tempSenha = GerarSenhaTemporaria();
                var hash = _passwordHasher.HashPassword(usuario, tempSenha);
                usuario.ResetSenha(hash);
                _usuarioRepository.Update(usuario);

                var adminId = ObterIdUsuarioLogado();
                RegistrarLog(adminId, "RESET_SENHA", "TB_USUARIO", id.ToString(), $"Admin redefiniu senha do usuario ID {id}");
                _logger.LogInformation("Senha redefinida pelo admin para usuario {Id}", id);

                return Ok(new { mensagem = "Senha redefinida com sucesso", senhaTemporaria = tempSenha });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao redefinir senha do usuario {Id}", id);
                return BadRequest(new { mensagem = "Erro ao redefinir senha", erro = ex.Message });
            }
        }

        // PATCH /api/TB_USUARIO/meu-perfil
        [HttpPatch("meu-perfil")]
        public IActionResult AtualizarMeuPerfil([FromBody] MeuPerfilDTO dto)
        {
            try
            {
                var userId = ObterIdUsuarioLogado();
                if (userId == 0)
                    return Unauthorized(new { mensagem = "Token invalido" });

                var usuario = _usuarioRepository.Get(userId);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                if (!usuario.flAtivo)
                    return Unauthorized(new { mensagem = "Usuario inativo" });

                if (string.IsNullOrWhiteSpace(dto.nmUsuario))
                    return BadRequest(new { mensagem = "Nome nao pode ser vazio" });

                usuario.UpdateInfo(dto.nmUsuario, usuario.dsEmail);
                _usuarioRepository.Update(usuario);

                RegistrarLog(userId, "EDICAO_PERFIL", "TB_USUARIO", userId.ToString(), $"Usuario ID {userId} atualizou o proprio perfil");
                _logger.LogInformation("Perfil atualizado: usuario {Id}", userId);

                return Ok(new
                {
                    mensagem = "Perfil atualizado com sucesso",
                    nmUsuario = usuario.nmUsuario,
                    dsLogin = usuario.dsLogin,
                    dsEmail = usuario.dsEmail
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar perfil");
                return BadRequest(new { mensagem = "Erro ao atualizar perfil", erro = ex.Message });
            }
        }

        // ===== HELPERS =====

        private static string GerarSenhaTemporaria()
        {
            const string lower = "abcdefghjkmnpqrstuvwxyz";
            const string upper = "ABCDEFGHJKMNPQRSTUVWXYZ";
            const string digits = "23456789";
            const string special = "@#!$%&";
            const string all = lower + upper + digits + special;

            var rng = Random.Shared;
            var chars = new char[10];

            // Garantir pelo menos um de cada tipo (política RNF14)
            chars[0] = lower[rng.Next(lower.Length)];
            chars[1] = upper[rng.Next(upper.Length)];
            chars[2] = digits[rng.Next(digits.Length)];
            chars[3] = special[rng.Next(special.Length)];

            for (int i = 4; i < 10; i++)
                chars[i] = all[rng.Next(all.Length)];

            return new string(chars.OrderBy(_ => rng.Next()).ToArray());
        }

        // Valida política de senha forte (RNF14)
        private static string? ValidarForcaSenha(string senha)
        {
            if (senha.Length < 8)
                return "A senha deve ter no minimo 8 caracteres";
            if (!senha.Any(char.IsLower))
                return "A senha deve conter pelo menos uma letra minuscula";
            if (!senha.Any(char.IsUpper))
                return "A senha deve conter pelo menos uma letra maiuscula";
            if (!senha.Any(char.IsDigit))
                return "A senha deve conter pelo menos um numero";
            if (senha.All(c => char.IsLetterOrDigit(c)))
                return "A senha deve conter pelo menos um caractere especial (ex: @, #, !, $)";
            return null;
        }

        private int ObterIdUsuarioLogado()
        {
            var claim = User.FindFirst("sub")?.Value ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(claim, out var id) ? id : 0;
        }

        private void RegistrarLog(int idUsuario, string acao, string tabela, string? idRegistro, string descricao)
        {
            try
            {
                var logs = _logRepository.GetAll();
                var nextLogId = logs.Any() ? logs.Max(l => l.idLog) + 1 : 1;
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                var log = new TB_LOG_ACAO(
                    idLog: nextLogId,
                    idUsuario: idUsuario > 0 ? idUsuario : 0,
                    dsAcao: acao,
                    nmTabela: tabela,
                    idRegistro: idRegistro,
                    dtAcao: DateTime.UtcNow,
                    dsIp: ip
                );

                _logRepository.Add(log);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Falha ao registrar log de auditoria");
            }
        }

        private TB_USUARIODTO MapToDTO(TB_USUARIO usuario, IEnumerable<TB_PERFIL_USUARIO> perfis)
        {
            var perfil = perfis.FirstOrDefault(p => p.idPerfil == usuario.idPerfil);
            return new TB_USUARIODTO
            {
                idUsuario = usuario.idUsuario,
                nmUsuario = usuario.nmUsuario,
                dsLogin = usuario.dsLogin,
                dsEmail = usuario.dsEmail,
                idPerfil = usuario.idPerfil,
                dsPerfil = perfil?.dsPerfil ?? string.Empty,
                flAtivo = usuario.flAtivo,
                flPrimeiroAcesso = usuario.flPrimeiroAcesso,
                dtUltimaTrocaSenha = usuario.dtUltimaTrocaSenha,
                dtCadastro = usuario.dtCadastro,
                dtAtualizacao = usuario.dtAtualizacao
            };
        }
    }
}
