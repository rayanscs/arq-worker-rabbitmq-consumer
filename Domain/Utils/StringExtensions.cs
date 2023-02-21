using ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Http;
using System.Text;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Utils
{
    public static class StringExtensions
    {
        public static string ConcatMensagemErros(IReadOnlyCollection<Notification> notifications)
        {

            StringBuilder notificacaoString = new StringBuilder();

            foreach (var notification in notifications)
            {
                var mensagemErro = $@" | {notification.Mensagem}";
                notificacaoString.Append(mensagemErro);
            }

            var notificacaoCompleta = notificacaoString.ToString();
            return notificacaoCompleta;
        }

    }
}
