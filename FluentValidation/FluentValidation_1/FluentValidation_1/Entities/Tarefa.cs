using FluentValidation_1.Enums;

namespace FluentValidation_1.Entities;

public class Tarefa
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataLimite { get; private set; }
    public StatusTarefa Status { get; private set; }

    public Tarefa(int id, string titulo, string descricao, DateTime dataCriacao, DateTime? dataLimite, StatusTarefa status)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        DataLimite = dataLimite;
        Status = status;
    }

    public void SetStatus(StatusTarefa newStatus)
        => Status = newStatus;
}