using FluentValidation_1.DTOs;
using FluentValidation_1.Entities;
using FluentValidation_1.Enums;
using FluentValidation_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    private readonly TarefaService _tarefaService;

    public TarefasController(TarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> ObterTodasTarefas()
    {
        return Ok(_tarefaService.ObterTodasTarefas());
    }

    [HttpGet("{id}")]
    public ActionResult<Tarefa> ObterTarefaPorId(int id)
    {
        var tarefa = _tarefaService.ObterTarefaPorId(id);

        if (tarefa == null)
            return NotFound();

        return Ok(tarefa);
    }

    [HttpPost]
    public ActionResult<Tarefa> CriarTarefa(CriarTarefaDTO dto)
    {
        var novaTarefa = _tarefaService.CriarTarefa(dto);

        return CreatedAtAction(
            nameof(ObterTarefaPorId),
            new { id = novaTarefa.Id },
            novaTarefa
        );
    }

    [HttpPatch("{id}/status")]
    public ActionResult<Tarefa> AtualizarStatus(int id, [FromBody] StatusTarefa novoStatus)
    {
        var tarefaAtualizada = _tarefaService.AtualizarStatus(id, novoStatus);

        if (tarefaAtualizada == null)
            return NotFound();

        return Ok(tarefaAtualizada);
    }

    [HttpDelete("{id}")]
    public ActionResult ExcluirTarefa(int id)
    {
        var sucesso = _tarefaService.ExcluirTarefa(id);

        return sucesso ? NoContent() : NotFound();
    }

}