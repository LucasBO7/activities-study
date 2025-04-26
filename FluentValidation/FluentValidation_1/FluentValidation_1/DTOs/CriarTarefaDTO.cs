namespace FluentValidation_1.DTOs;

public class CriarTarefaDTO
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime? DataLimite { get; set; }
}