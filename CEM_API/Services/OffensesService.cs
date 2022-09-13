using CEM_API.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CEM_API.Services
{
    public class OffensesService
    {
        public OffensesService(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        private string OffenceCode {
            get{
                var count = Context.Offenses.Count();
                var lastId = Context.Offenses.Max(x => x.Id);

                int code = lastId < 1 ? count + 1 : lastId + 1;

                return string.Format("OPT-{0}", code);
            }
        }

        public async Task<Offense> Create(OffensesDTO odto, string createdBy)
        {
            var offense = new Offense()
            {
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = createdBy,
                Name = odto.Name,
                Fine = odto.Fine,
                Institution = odto.Institution,
                Status = odto.Status,
                Uuid = Guid.NewGuid().ToString(),
                Code = OffenceCode
            };

            Context.Offenses.Add(offense);
            await Context.SaveChangesAsync();

            return offense;
        }

        public async Task<Offense> Update(int id, OffensesDTO odto, string createdBy)
        {
            var offense = await Context.Offenses.FindAsync(id);

            if (offense == null) return null!;

            offense.UpdatedAt = DateTimeOffset.Now;
            offense.UpdatedBy = createdBy;
            offense.Name = odto.Name;
            offense.Fine = odto.Fine;
            offense.Institution = odto.Institution;
            offense.Status = odto.Status;

            Context.Entry(offense).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return offense;
        }

        public async Task<Offense> Delete(int id, string createdBy)
        {
            var offense = await Context.Offenses.FindAsync(id);

            if (offense == null) return null!;

            offense.DeletedBy = createdBy;
            offense.DeletedAt = DateTimeOffset.Now;

            Context.Offenses.Remove(offense);
            await Context.SaveChangesAsync();

            return offense;
        }

        public async Task<Offense> Get(int id) => await Context.Offenses.FindAsync(id);
        public async Task<IEnumerable<Offense>> Get() => await Context.Offenses.ToListAsync();
    }
}
