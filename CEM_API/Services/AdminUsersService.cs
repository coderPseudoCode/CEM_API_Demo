using Microsoft.EntityFrameworkCore;

namespace CEM_API.Services
{
    public class AdminUsersService
    {
        public AdminUsersService(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public async Task<IEnumerable<AdminUser>> Get() => await Context.AdminUsers.ToListAsync();
        public async Task<AdminUser> Get(string uid)
        {
            var admin = await Context.AdminUsers.FindAsync(uid);

            if (admin == null)
            {
                admin = await Context.AdminUsers.FirstOrDefaultAsync(a => a.Email!.Equals(uid));

                if (admin == null)
                {
                    admin = await Context.AdminUsers.FirstOrDefaultAsync(a => a.UserPhone!.Equals(uid));
                }
            }

            return admin!;
        }
        

        public string HashPassword(string password)
        {
            var byts = Encoding.UTF8.GetBytes(password);

            return Convert.ToBase64String(byts);
        }
    }
}
