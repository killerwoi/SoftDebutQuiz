using API.Model.Response;
using API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Service
{
    public class PositionService(DataContext dataContext) : IPositionService
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<DefaultResponse<List<PositionResponseModel>>> GetPosition()
        {
            var result = from c in _dataContext.Position
                         select new PositionResponseModel
                         {
                             PositionNo = c.PositionNo,
                             PositionName = c.PositionName
                         };

            var obj = await result.AsNoTracking().ToListAsync();

            return new DefaultResponse<List<PositionResponseModel>> { Result = true, Message = "", Data = obj };
        }
    }
}
