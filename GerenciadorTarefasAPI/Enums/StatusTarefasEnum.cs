using System.Text.Json.Serialization;

namespace GerenciadorTarefasAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusTarefasEnum
    {
        Pendente,
        EmAndamento,
        Concluida
    }
}
