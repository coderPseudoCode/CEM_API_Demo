using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CEM_API.Data.Models;

namespace CEM_API.Data
{
    public partial class AppDbContext : DbContext
    {
        /*public AppDbContext()
        {
        }*/

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public virtual DbSet<AllPayment> AllPayments { get; set; } = null!;
        public virtual DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public virtual DbSet<Defaulter> Defaulters { get; set; } = null!;
        public virtual DbSet<Fine> Fines { get; set; } = null!;
        public virtual DbSet<Offense> Offenses { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RptDefaulter> RptDefaulters { get; set; } = null!;
        public virtual DbSet<TblCountry> TblCountries { get; set; } = null!;
        public virtual DbSet<TblModule> TblModules { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblRolePermission> TblRolePermissions { get; set; } = null!;
        public virtual DbSet<TblSetting> TblSettings { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblUserLog> TblUserLogs { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<VwDefaulter> VwDefaulters { get; set; } = null!;
        public virtual DbSet<VwDefaulters1> VwDefaulters1s { get; set; } = null!;
        public virtual DbSet<VwPayment> VwPayments { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAB-DSKT-001;Initial Catalog=DB_A628C1_cems;Integrated Security=true;Pooling=false");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Users_1");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.DateofBirth)
                    .HasMaxLength(110)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate()-(8000))");

                entity.Property(e => e.Department)
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastupdateBy)
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(450)
                    .IsUnicode(false)
                    .HasColumnName("LName");

                entity.Property(e => e.Logby)
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.Logtime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Supervisor)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhoto)
                    .IsUnicode(false)
                    .HasColumnName("User_Photo")
                    .HasDefaultValueSql("('User_Photo/man.png')");
            });

            modelBuilder.Entity<AllPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("All_Payments");

                entity.Property(e => e.Collector).HasMaxLength(255);

                entity.Property(e => e.Defaulter).HasMaxLength(255);

                entity.Property(e => e.OffenseCode)
                    .HasMaxLength(255)
                    .HasColumnName("Offense_Code");

                entity.Property(e => e.PaymentDate).HasColumnName("Payment_Date");
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("audit_logs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(255)
                    .HasColumnName("content_type");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.Data)
                    .HasMaxLength(255)
                    .HasColumnName("data");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(255)
                    .HasColumnName("ip_address");

                entity.Property(e => e.Method)
                    .HasMaxLength(255)
                    .HasColumnName("method");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(255)
                    .HasColumnName("session_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .HasColumnName("user");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(255)
                    .HasColumnName("user_agent");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<Defaulter>(entity =>
            {
                entity.ToTable("defaulters");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(255)
                    .HasColumnName("additional_info");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .HasColumnName("category");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NoOfOffence).HasColumnName("no_of_offence");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(255)
                    .HasColumnName("photo_path");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.ToTable("fines");

                entity.HasIndex(e => e.FineCode, "UQ__fines__89502BD7D3B3320F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(255)
                    .HasColumnName("additional_info");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .HasColumnName("category");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.Fine1).HasColumnName("fine");

                entity.Property(e => e.FineCode)
                    .HasMaxLength(255)
                    .HasColumnName("fine_code");

                entity.Property(e => e.OffenseCode)
                    .HasMaxLength(255)
                    .HasColumnName("offense_code");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<Offense>(entity =>
            {
                entity.ToTable("offenses");

                entity.HasIndex(e => e.Code, "UQ__offenses__357D4CF933072E10")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.Fine).HasColumnName("fine");

                entity.Property(e => e.Institution)
                    .HasMaxLength(255)
                    .HasColumnName("institution");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.FineCode)
                    .HasMaxLength(255)
                    .HasColumnName("fine_code");

                entity.Property(e => e.OffenseCode)
                    .HasMaxLength(255)
                    .HasColumnName("offense_code");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(255)
                    .HasColumnName("payment_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.RoleName, "UQ__roles__783254B155F51CD5")
                    .IsUnique();

                entity.HasIndex(e => e.LoweredRoleName, "UQ__roles__D380AF78117E0D4D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Group)
                    .HasMaxLength(50)
                    .HasColumnName("group")
                    .HasDefaultValueSql("('Customers')");

                entity.Property(e => e.LoweredRoleName)
                    .HasMaxLength(50)
                    .HasColumnName("lowered_role_name");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<RptDefaulter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("rptDefaulters");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Fine).HasColumnName("fine");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NoOfOffence).HasColumnName("no_of_offence");

                entity.Property(e => e.OffenseCode)
                    .HasMaxLength(255)
                    .HasColumnName("offense_code");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.ToTable("tblCountry");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<TblModule>(entity =>
            {
                entity.ToTable("tblModule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModuleName).HasMaxLength(512);

                entity.Property(e => e.PageIcon).HasMaxLength(50);

                entity.Property(e => e.PageSlug).HasMaxLength(512);

                entity.Property(e => e.PageUrl).HasMaxLength(512);

                entity.Property(e => e.ParentModuleId).HasColumnName("ParentModuleID");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tblRole");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblRolePermission>(entity =>
            {
                entity.ToTable("tblRolePermission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TblRolePermissions)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_UserPermission_ModuleMast");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblRolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tblRolePermission_tblRole");
            });

            modelBuilder.Entity<TblSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_settings");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Footermsg).HasMaxLength(250);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LogBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Logtime).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.VatRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Vatregistration)
                    .HasMaxLength(450)
                    .IsUnicode(false)
                    .HasColumnName("VATRegistration");

                entity.Property(e => e.WebAddress)
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUser");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(512);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(512);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Password).HasMaxLength(512);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PhotoPath).HasMaxLength(512);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<TblUserLog>(entity =>
            {
                entity.ToTable("tblUserLog");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(50)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(1024);

                entity.Property(e => e.MoreInfo).HasMaxLength(1024);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblUserLog_tblUser");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(255)
                    .HasColumnName("additional_info");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .HasColumnName("category");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NoOfOffence).HasColumnName("no_of_offence");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(255)
                    .HasColumnName("photo_path");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.LoweredEmail, "UQ__users__783A5AA5B7A83CCA")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__users__AB6E6164DA03CEE0")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .HasColumnName("branch");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("first_name");

                entity.Property(e => e.FirstTimeLogin).HasColumnName("first_time_login");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("last_name");

                entity.Property(e => e.LoweredEmail)
                    .HasMaxLength(100)
                    .HasColumnName("lowered_email");

                entity.Property(e => e.LoweredUsername)
                    .HasMaxLength(100)
                    .HasColumnName("lowered_username");

                entity.Property(e => e.OtherNames)
                    .HasMaxLength(250)
                    .HasColumnName("other_names");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Rand)
                    .HasMaxLength(100)
                    .HasColumnName("rand");

                entity.Property(e => e.Salt)
                    .HasMaxLength(100)
                    .HasColumnName("salt");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 =Active 2 =inactive");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_roles");

                entity.HasIndex(e => e.UserRefer, "UQ__user_rol__535EB74C81A848A5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("created_by");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(255)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.RoleRefer).HasColumnName("role_refer");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UserRefer).HasColumnName("user_refer");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<VwDefaulter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwDefaulters");

                entity.Property(e => e.Total).HasColumnName("TOTAL");
            });

            modelBuilder.Entity<VwDefaulters1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwDefaulters1");

                entity.Property(e => e.Total).HasColumnName("TOTAL");
            });

            modelBuilder.Entity<VwPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPayment");

                entity.Property(e => e.Fine).HasColumnName("fine");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(255)
                    .HasColumnName("payment_type");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
