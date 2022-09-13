using CEM_API.Data.DTOs;

namespace CEM_API.Services
{
    public class DefaultersService
    {
        public DefaultersService(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public async Task<Defaulter> Create(DefaultersDTO ddto, string createdBy)
        {
            var defaulter = new Defaulter()
            {
                AdditionalInfo = ddto.AdditionalInfo,
                Address = ddto.Address,
                Category = ddto.Category,
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = createdBy,
                Name = ddto.Name,
                NoOfOffence = ddto.NoOfOffence,
                PhotoPath = ddto.PhotoPath,
                PhoneNumber = ddto.PhoneNumber,
                Status = ddto.Status,
                Uuid = Guid.NewGuid().ToString()
            };

            Context.Defaulters.Add(defaulter);
            await Context.SaveChangesAsync();

            return defaulter;
        }

        public async Task<Defaulter> Update(int id, DefaultersDTO ddto, string createdBy)
        {
            var defaulter = await Context.Defaulters.FindAsync(id);

            if (defaulter == null) return null!;

            defaulter.AdditionalInfo = ddto.AdditionalInfo;
            defaulter.Address = ddto.Address;
            defaulter.Category = ddto.Category;
            defaulter.UpdatedAt = DateTimeOffset.Now;
            defaulter.UpdatedBy = createdBy;
            defaulter.Name = ddto.Name;
            defaulter.NoOfOffence = ddto.NoOfOffence;
            defaulter.PhotoPath = ddto.PhotoPath;
            defaulter.PhoneNumber = ddto.PhoneNumber;
            defaulter.Status = ddto.Status;

            Context.Entry(defaulter).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return defaulter;
        }
        
        public async Task<Defaulter> Delete(int id, string createdBy)
        {
            var defaulter = await Context.Defaulters.FindAsync(id);

            if (defaulter == null) return null!;

            defaulter.DeletedBy = createdBy;
            defaulter.DeletedAt = DateTimeOffset.Now;

            Context.Defaulters.Remove(defaulter);
            await Context.SaveChangesAsync();

            return defaulter;
        }

        public async Task<Defaulter> Get(int id) => await Context.Defaulters.FindAsync(id);
        public async Task<IEnumerable<Defaulter>> Get() => await Context.Defaulters.ToListAsync();
    }
}
