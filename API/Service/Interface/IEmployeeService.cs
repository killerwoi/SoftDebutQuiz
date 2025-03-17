using API.Model.Request;
using API.Model.Response;

namespace API.Service.Interface
{
    public interface IEmployeeService
    {
        Task<DefaultResponse<List<EmployeeGetResponseModel>>> GetEmployee();
        Task<DefaultResponse<object>> AddEmployee(EmployeeAddRequestModel payload);
        Task<DefaultResponse<object>> UpdateEmployee(EmployeeUpdateRequestModel payload);
        Task<DefaultResponse<object>> DeleteEmployee(EmployeeDeleteRequestModel payload);
    }
}
