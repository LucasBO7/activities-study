namespace ReportProcessor.Entities;

public class SolicitacaoRelatorio
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public DateTime? ProcessedTime { get; set; }

}

internal static class List
{
    public static List<SolicitacaoRelatorio> relatorios = new();
}