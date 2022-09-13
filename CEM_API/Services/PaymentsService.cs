using CEM_API.Data.DTOs;

namespace CEM_API.Services
{
    public class PaymentsService
    {
        public PaymentsService(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public async Task<Payment> Create(PaymentsDTO pdto, string createdBy)
        {
            var payment = new Payment()
            {
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = createdBy,
                Status = pdto.Status,
                OffenseCode = pdto.OffenseCode,
                FineCode = pdto.FineCode,
                PaymentType = pdto.PaymentType,
                Uuid = Guid.NewGuid().ToString()
            };

            Context.Payments.Add(payment);
            await Context.SaveChangesAsync();

            return payment;
        }

        public async Task<Payment> Update(int id, PaymentsDTO pdto, string createdBy)
        {
            var payment = await Context.Payments.FindAsync(id);

            if (payment == null) return null!;

            payment.UpdatedAt = DateTimeOffset.Now;
            payment.UpdatedBy = createdBy;
            payment.Status = pdto.Status;
            payment.OffenseCode = pdto.OffenseCode;
            payment.FineCode = pdto.FineCode;
            payment.PaymentType = pdto.PaymentType;

            Context.Entry(payment).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return payment;
        }

        public async Task<Payment> Delete(int id, string createdBy)
        {
            var payment = await Context.Payments.FindAsync(id);

            if (payment == null) return null!;

            payment.DeletedBy = createdBy;
            payment.DeletedAt = DateTimeOffset.Now;

            Context.Payments.Remove(payment);
            await Context.SaveChangesAsync();

            return payment;
        }

        public async Task<Payment> Get(int id) => await Context.Payments.FindAsync(id);
        public async Task<IEnumerable<Payment>> Get() => await Context.Payments.ToListAsync();
    }
}
