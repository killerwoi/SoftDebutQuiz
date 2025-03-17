using System.Text.Json.Serialization;

namespace FrontEnd.Model.Response
{
    public class DepartmentGetResponseModel
    {
        [JsonPropertyName("depNo")]
        public string? DepNo { get; set; }

        [JsonPropertyName("depName")]
        public string? DepName { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }
    }
}
