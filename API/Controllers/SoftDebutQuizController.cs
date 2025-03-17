using API.Model.Request;
using API.Model.Response;
using API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class SoftDebutQuizController(IEmployeeService employeeService, IPositionService positionService, IDepartmentService departmentService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IPositionService _positionService = positionService;
        private readonly IDepartmentService _departmentService = departmentService;

        [HttpPost]
        [Route("api/[controller]/AddEmployee")]
        public async Task<DefaultResponse<object>> AddEmployee(EmployeeAddRequestModel payload)
        {
            try
            {
                var result = await _employeeService.AddEmployee(payload);
                return result;
            }
            catch (Exception ex)
            {
                return new DefaultResponse<object> { Result = false, Message = ex.Message, Data = null };
            }
        }

        [HttpPatch]
        [Route("api/[controller]/UpdateEmployee")]
        public async Task<DefaultResponse<object>> UpdateEmployee(EmployeeUpdateRequestModel payload)
        {
            try
            {
                var result = await _employeeService.UpdateEmployee(payload);
                return result;
            }
            catch (Exception ex)
            {
                return new DefaultResponse<object> { Result = false, Message = ex.Message, Data = null };
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteEmployee")]
        public async Task<DefaultResponse<object>> DeleteEmployee(EmployeeDeleteRequestModel payload)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(payload);
                return result;
            }
            catch (Exception ex)
            {
                return new DefaultResponse<object> { Result = false, Message = ex.Message, Data = null };
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetEmployee")]
        public async Task<DefaultResponse<List<EmployeeGetResponseModel>>> GetEmployee()
        {
            try
            {
                var result = await _employeeService.GetEmployee();
                return result;
            }
            catch (Exception ex)
            {
                return new DefaultResponse<List<EmployeeGetResponseModel>> { Result = false, Message = ex.Message, Data = null };
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetDepartment")]
        public async Task<DefaultResponse<List<DepartmentGetResponseModel>>> GetDepartment()
        {
            try
            {
                var result = await _departmentService.GetDepartment();
                return result;
            }
            catch (Exception ex)
            {
                return new DefaultResponse<List<DepartmentGetResponseModel>> { Result = false, Message = ex.Message, Data = null };
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetPosition")]
        public async Task<DefaultResponse<List<PositionResponseModel>>> GetPosition()
        {
            try
            {
                var result = await _positionService.GetPosition();
                return result;
            }
            catch (Exception ex)
            {
                return new DefaultResponse<List<PositionResponseModel>> { Result = false, Message = ex.Message, Data = null };
            }
        }
    }
}
