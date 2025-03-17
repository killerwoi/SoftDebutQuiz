using API.Model.Response;
using API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Service
{
    public class DepartmentService(DataContext dataContext) : IDepartmentService
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<DefaultResponse<List<DepartmentGetResponseModel>>> GetDepartment()
        {
            var result = from c in _dataContext.Department
                         select new DepartmentGetResponseModel
                         {
                             DepNo = c.DepNo,
                             DepName = c.DepName,
                             Location = c.Location
                         };

            var obj = await result.AsNoTracking().ToListAsync();

            return new DefaultResponse<List<DepartmentGetResponseModel>> { Result = true, Message = "", Data = obj };
        }
    }
}
