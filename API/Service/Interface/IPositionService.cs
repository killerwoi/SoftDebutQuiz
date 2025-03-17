using API.Model.Response;

namespace API.Service.Interface
{
    public interface IPositionService
    {
        Task<DefaultResponse<List<PositionResponseModel>>> GetPosition();
    }
}
