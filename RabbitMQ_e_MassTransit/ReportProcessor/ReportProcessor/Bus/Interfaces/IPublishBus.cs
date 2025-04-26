namespace ReportProcessor.Bus.Interfaces;
public interface IPublishBus
{
    /// <summary>
    /// Publica uma Mensagem (requisição) ao evento
    /// </summary>
    /// <typeparam name="T">Tipo da mensagem (genérico)</typeparam>
    /// <param name="message">Mensagem a ser publicada</param>
    /// <returns></returns>
    Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
}
