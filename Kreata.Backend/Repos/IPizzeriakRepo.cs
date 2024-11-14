using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;

namespace Kreata.Backend.Repos
{
    public interface IPizzeriakRepo
    {
        Task<List<Pizzeriak>> GetAll();
        Task<Pizzeriak?> GetBy(Guid id);
        Task<ControllerResponse> UpdatePizzeriakAsync(Student student);
        Task<ControllerResponse> UpdatePizzeriakAsync(Pizzeriak entity);
    }
}
