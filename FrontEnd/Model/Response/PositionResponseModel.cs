using System.Text.Json.Serialization;

namespace FrontEnd.Model.Response
{
    public class PositionResponseModel
    {
        [JsonPropertyName("positionNo")]
        public string? PositionNo { get; set; }

        [JsonPropertyName("positionName")]
        public string? PositionName { get; set; }
    }
}
