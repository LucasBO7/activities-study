using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ReportProcessor.Bus.Interfaces;
using ReportProcessor.Entities;

namespace ReportProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        [HttpGet("solicit-relatory")]
        public async Task<IActionResult> PostRelatorio(string name, IPublishBus bus, CancellationToken ct = default)
        {
            try
            {
                var solicitacao = new SolicitacaoRelatorio()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Status = "Pendente",
                    ProcessedTime = null
                };

                // Salvando no banco (simulação)
                List.relatorios.Add(solicitacao);

                // Cria uma requisição
                RelatorioSolicitadoEvent eventRequest = new(solicitacao.Id, solicitacao.Name);

                // Publica a requisição no evento
                await bus.PublishAsync(eventRequest, ct);

                // Retorna (não é esperado o resultado/retorno da requisição publicada no evento)
                return Ok(solicitacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all")]
        public IActionResult GetAllRelatorios()
        {
            try
            {
                return Ok(List.relatorios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
