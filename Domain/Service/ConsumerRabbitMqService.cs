using ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Service
{
    public class ConsumerRabbitMqService : IConsumerRabbitMqService
    {
        public async Task<bool> ProcessarMensagem(string mensagemRecebida)
        {
            bool processado = false;

            try
            {
                // Caso tudo esteja processado como deveria, processado = true;
                return processado;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
