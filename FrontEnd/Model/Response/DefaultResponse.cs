using System.Text.Json.Serialization;

namespace FrontEnd.Model.Response
{
    public class DefaultResponse<T>
    {
        [JsonPropertyName("result")]
        public bool Result { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
