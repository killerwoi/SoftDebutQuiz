using API.Model.Response;

namespace API.Service.Interface
{
    public interface IDepartmentService
    {
        Task<DefaultResponse<List<DepartmentGetResponseModel>>> GetDepartment();
    }
}
