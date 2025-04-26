using FluentValidation_1.DTOs;
using FluentValidation_1.Entities;
using FluentValidation_1.Enums;

namespace FluentValidation_1.Services;

public class TarefaService
{
    private static List<Tarefa> _tarefas = [];
    private static int _proximoId = 1;

    public List<Tarefa> ObterTodasTarefas() => _tarefas;
    public Tarefa ObterTarefaPorId(int id)
        => _tarefas.FirstOrDefault(t => t.Id == id);

    public Tarefa CriarTarefa(CriarTarefaDTO dto)
    {
        Tarefa novaTarefa = new
        (
            _proximoId++,
            dto.Titulo,
            dto.Descricao,
            DateTime.Now,
            dto.DataLimite,
            Enums.StatusTarefa.Pendente
        );

        _tarefas.Add(novaTarefa);
        return novaTarefa;
    }

    public Tarefa AtualizarStatus(int id, StatusTarefa novoStatus)
    {
        Tarefa tarefa = ObterTarefaPorId(id);

        if (tarefa != null)
            tarefa.SetStatus(novoStatus);

        return tarefa;
    }

    public bool ExcluirTarefa(int id)
    {
        var tarefa = ObterTarefaPorId(id);
        if (tarefa != null)
        {
            _tarefas.Remove(tarefa);
            return true;
        }
        return false;
    }

}