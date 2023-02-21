using System.ComponentModel;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Enum
{
    public enum EEnvironment
    {
        [Description("dev")]
        Development,
        [Description("stg")]
        Staging,
        [Description("prd")]
        Production
    }
}
