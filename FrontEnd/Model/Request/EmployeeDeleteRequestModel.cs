using System.Text.Json.Serialization;

namespace FrontEnd.Model.Request
{
    public class EmployeeDeleteRequestModel
    {
        [JsonPropertyName("empNum")]
        public string? EmpNum { get; set; }
    }
}
