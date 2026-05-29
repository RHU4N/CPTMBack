using CPTMBack.Application.ViewModels;
using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblPrincipais.RT_EFLUENTEAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RT_EFLUENTEController : ControllerBase
    {
        private readonly IRT_EFLUENTERepository _attachmentRepository;
        private readonly ILogger<RT_EFLUENTEController> _logger;
        private const long MaxFileSize = 10 * 1024 * 1024; // 10 MB

        public RT_EFLUENTEController(
            IRT_EFLUENTERepository attachmentRepository,
            ILogger<RT_EFLUENTEController> logger)
        {
            _attachmentRepository = attachmentRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get all attachments
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var attachments = _attachmentRepository.GetAll();

                if (!attachments.Any())
                {
                    return Ok(new { dados = attachments, total = 0 });
                }

                var dtos = attachments.Select(a => MapToDTO(a)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} attachments");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving attachments: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar anexos", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get attachment by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var attachment = _attachmentRepository.Get(id);

                if (attachment == null)
                {
                    return NotFound(new { mensagem = "Anexo não encontrado" });
                }

                var dto = MapToDTO(attachment);

                _logger.LogInformation($"? Retrieved attachment: {id}");

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving attachment: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar anexo", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get attachments by efluente ID
        /// </summary>
        [HttpGet("efluente/{relObjectId}")]
        public IActionResult GetByEfluenteId(string relObjectId)
        {
            try
            {
                var attachments = _attachmentRepository.GetAll()
                    .Where(a => a.relObjectId == relObjectId)
                    .ToList();

                var dtos = attachments.Select(a => MapToDTO(a)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} attachments for efluente {relObjectId}");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving attachments by efluente: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar anexos", erro = ex.Message });
            }
        }

        /// <summary>
        /// Upload attachment/image
        /// </summary>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadAttachment([FromForm] string relObjectId, [FromForm] IFormFile file)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(relObjectId))
                {
                    return BadRequest(new { mensagem = "ID do efluente é obrigatório" });
                }

                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { mensagem = "Arquivo não fornecido" });
                }

                // Validate file size
                if (file.Length > MaxFileSize)
                {
                    return BadRequest(new { mensagem = $"Arquivo muito grande. Tamanho máximo: {MaxFileSize / (1024 * 1024)} MB" });
                }

                // Validate file type
                var allowedContentTypes = new[] 
                { 
                    "image/jpeg", 
                    "image/png", 
                    "image/gif", 
                    "image/webp",
                    "application/pdf",
                    "application/msword",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                };

                if (!allowedContentTypes.Contains(file.ContentType.ToLower()))
                {
                    return BadRequest(new { mensagem = "Tipo de arquivo não permitido" });
                }

                // Convert file to byte array
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();

                // Create attachment
                var attachment = new RT_EFLUENTE(
                    attachmentId: 0, // Will be auto-generated by database
                    relObjectId: relObjectId,
                    contentType: file.ContentType,
                    attName: file.FileName,
                    dataSize: (int?)file.Length,
                    data: fileBytes
                );

                _attachmentRepository.Add(attachment);

                _logger.LogInformation($"? File uploaded: {file.FileName} ({file.Length} bytes)");

                return Ok(new
                {
                    sucesso = true,
                    mensagem = "Arquivo enviado com sucesso",
                    dados = new
                    {
                        attachmentId = attachment.attachmentId,
                        attName = attachment.attName,
                        contentType = attachment.contentType,
                        dataSize = attachment.dataSize
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error uploading file: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao enviar arquivo", erro = ex.Message });
            }
        }

        /// <summary>
        /// Download attachment/image
        /// </summary>
        [HttpGet("download/{id}")]
        public IActionResult DownloadAttachment(int id)
        {
            try
            {
                var attachment = _attachmentRepository.Get(id);

                if (attachment == null)
                {
                    return NotFound(new { mensagem = "Anexo não encontrado" });
                }

                if (attachment.data == null || attachment.data.Length == 0)
                {
                    return BadRequest(new { mensagem = "Arquivo não contém dados" });
                }

                _logger.LogInformation($"? File downloaded: {attachment.attName}");

                return File(attachment.data, attachment.contentType ?? "application/octet-stream", attachment.attName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error downloading file: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao baixar arquivo", erro = ex.Message });
            }
        }

        /// <summary>
        /// Delete attachment
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteAttachment(int id)
        {
            try
            {
                var attachment = _attachmentRepository.Get(id);

                if (attachment == null)
                {
                    return NotFound(new { mensagem = "Anexo não encontrado" });
                }

                _attachmentRepository.Delete(id);

                _logger.LogInformation($"? Attachment deleted: {id}");

                return Ok(new { mensagem = "Anexo deletado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error deleting attachment: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao deletar anexo", erro = ex.Message });
            }
        }

        // ===== HELPER METHODS =====

        private RT_EFLUENTEDTO MapToDTO(RT_EFLUENTE attachment)
        {
            return new RT_EFLUENTEDTO
            {
                attachmentId = attachment.attachmentId,
                relObjectId = attachment.relObjectId,
                contentType = attachment.contentType,
                attName = attachment.attName,
                dataSize = attachment.dataSize ?? 0,
                data = attachment.data ?? Array.Empty<byte>()
            };
        }
    }
}
