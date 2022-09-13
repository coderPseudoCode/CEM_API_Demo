using CEM_API.Data.DTOs;

namespace CEM_API.Services
{
    public class FinesService
    {
        public FinesService(AppDbContext context)
        {
            Context = context;
        }

        private string GetRandomFineCode()
        {
            var rnd = new Random();
            var randsUpper = "ABCDEFGIHIJKLMNOPQRSTUVWXYZ";
            var randsLower = randsUpper.ToLower();
            var randsNums = "123456789";
            var rands = string.Format("{0}{2}{1}", randsUpper, randsUpper.ToLower(), randsNums);
            string rand = string.Empty;
            for(int i = 0; i < 6; i++)
            {
                rand += rands[rnd.Next(rands.Length)];
            }

            return rand;
        }

        public AppDbContext Context { get; }

        public async Task<Fine> Create(FinesDTO fdto, string createdBy)
        {
            var fine = new Fine()
            {
                AdditionalInfo = fdto.AdditionalInfo,
                Category = fdto.Category,
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = createdBy,
                PhoneNumber = fdto.PhoneNumber,
                Status = fdto.Status,
                Uuid = Guid.NewGuid().ToString(),
                OffenseCode = fdto.OffenseCode,
                Fine1 = fdto.Fine1,
                FineCode = GetRandomFineCode()
            };

            Context.Fines.Add(fine);
            await Context.SaveChangesAsync();

            return fine;
        }

        public async Task<Fine> Update(int id, FinesDTO fdto, string createdBy)
        {
            var fine = await Context.Fines.FindAsync(id);

            if (fine == null) return null!;

            fine.AdditionalInfo = fdto.AdditionalInfo;
            fine.Category = fdto.Category;
            fine.UpdatedAt = DateTimeOffset.Now;
            fine.UpdatedBy = createdBy;
            fine.PhoneNumber = fdto.PhoneNumber;
            fine.Status = fdto.Status;
            fine.OffenseCode = fdto.OffenseCode;
            fine.Fine1 = fdto.Fine1;

            Context.Entry(fine).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return fine;
        }

        public async Task<Fine> Delete(int id, string createdBy)
        {
            var fine = await Context.Fines.FindAsync(id);

            if (fine == null) return null!;

            fine.DeletedBy = createdBy;
            fine.DeletedAt = DateTimeOffset.Now;

            Context.Fines.Remove(fine);
            await Context.SaveChangesAsync();

            return fine;
        }

        public async Task<Fine> Get(int id) => await Context.Fines.FindAsync(id);
        public async Task<IEnumerable<Fine>> Get() => await Context.Fines.ToListAsync();
    }
}
