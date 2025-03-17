using System.Text.Json.Serialization;

namespace API.Model.Request
{
    public class EmployeeDeleteRequestModel
    {
        [JsonPropertyName("empNum")]
        public string? EmpNum { get; set; }
    }
}
