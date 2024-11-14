using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class PizzeriakRepo : IPizzeriakRepo
    {

        private readonly KretaInMemoryContext _dbContext;

        public PizzeriakRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Pizzeriak>> GetAll()
        {
            return await _dbContext.Pizzeriaks.ToListAsync();
        }

        public async Task<Pizzeriak?> GetBy(Guid id)
        {
            return await _dbContext.Pizzeriaks.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<ControllerResponse> UpdatePizzeriakAsync(Pizzeriak pizzeriak)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(pizzeriak).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(PizzeriakRepo)} osztály, {nameof(UpdatePizzeriakAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{pizzeriak} frissítése nem sikerült!");
            }
            return response;
        }

        public Task<ControllerResponse> UpdatePizzeriakAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
