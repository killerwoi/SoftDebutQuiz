using System.Text.Json.Serialization;

namespace FrontEnd.Model.Response
{
    public class EmployeeGetResponseModel
    {
        [JsonPropertyName("empNum")]
        public string? EmpNum { get; set; }

        [JsonPropertyName("empName")]
        public string? EmpName { get; set; }

        [JsonPropertyName("hireDate")]
        public DateOnly? HireDate { get; set; }

        [JsonPropertyName("salary")]
        public decimal Salary { get; set; }

        [JsonPropertyName("positionNo")]
        public string? PositionNo { get; set; }

        [JsonPropertyName("depNo")]
        public string? DepNo { get; set; }

        [JsonPropertyName("headNo")]
        public string? HeadNo { get; set; }
    }
}
