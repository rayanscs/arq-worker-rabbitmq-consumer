using System.ComponentModel;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Utils
{
    public static class EnumMethods
    {
        /// <summary>
        /// Recupera a descrição do enumerador definida no atributo DescriptionAttribute
        /// </summary>
        /// <param name="pEnumerador">Enumerador de origem</param>
        /// <returns>Retorna a DESCRIÇÃO do enumerador</returns>
        public static string GetDescription(this Enum pEnumerador)
        {

            if (pEnumerador == null)
                return null;

            var field = pEnumerador.GetType().GetField(pEnumerador.ToString());

            if (field == null)
                return null;

            var descricaoValue = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            // Se não há atributo Description, retorna o texto do próprio Enum.
            if (descricaoValue == null)
                return pEnumerador.ToString();

            return descricaoValue.Description;
        }

        public static T GetValueFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
        }
    }
}
