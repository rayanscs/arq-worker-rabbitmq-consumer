namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Http
{
    public sealed class Notification
    {
        public Notification(string codigo, string titulo, string mensagem)
        {
            Codigo = codigo;
            Titulo = titulo;
            Mensagem = mensagem;
        }

        public string Codigo { get; private set; }
        public string Titulo { get; private set; }
        public string Mensagem { get; private set; }
    }
}
