namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.RabbitMq
{
    public interface IConsumerRabbitMqService
    {
        public Task<bool> ProcessarMensagem(string mensagemRecebida);
    }
}
