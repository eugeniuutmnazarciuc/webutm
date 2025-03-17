using System.Data.Entity;
using HVAC.Domain.Models;

namespace HVAC.Domain.Models
{
    /// <summary>
    /// Класс контекста базы данных Entity Framework
    /// </summary>
    public class HvacDbContext : DbContext
    {
        public HvacDbContext() : base("name=HvacDbConnection")
        {
            // Initializer для базы данных при необходимости
            // Database.SetInitializer<HvacDbContext>(new CreateDatabaseIfNotExists<HvacDbContext>());
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<HvacSystem> HvacSystems { get; set; }
        public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ServiceRequestPart> ServiceRequestParts { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Настройка связей и ограничений
            
            // Связь Customer - HvacSystem (один ко многим)
            modelBuilder.Entity<HvacSystem>()
                .HasRequired(s => s.Customer)
                .WithMany(c => c.HvacSystems)
                .HasForeignKey(s => s.CustomerId)
                .WillCascadeOnDelete(false);
                
            // Связь HvacSystem - Equipment (один ко многим)
            modelBuilder.Entity<Equipment>()
                .HasRequired(e => e.HvacSystem)
                .WithMany(s => s.Equipment)
                .HasForeignKey(e => e.HvacSystemId)
                .WillCascadeOnDelete(false);
                
            // Связь ServiceRequest - Customer (один ко многим)
            modelBuilder.Entity<ServiceRequest>()
                .HasRequired(sr => sr.Customer)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(sr => sr.CustomerId)
                .WillCascadeOnDelete(false);
                
            // Связь ServiceRequest - Technician (один ко многим, опционально)
            modelBuilder.Entity<ServiceRequest>()
                .HasOptional(sr => sr.Technician)
                .WithMany(t => t.ServiceRequests)
                .HasForeignKey(sr => sr.TechnicianId)
                .WillCascadeOnDelete(false);
                
            // Связь ServiceRequest - HvacSystem (один ко многим, опционально)
            modelBuilder.Entity<ServiceRequest>()
                .HasOptional(sr => sr.HvacSystem)
                .WithMany(s => s.ServiceRequests)
                .HasForeignKey(sr => sr.HvacSystemId)
                .WillCascadeOnDelete(false);
                
            // Связь ServiceRequest - Equipment (один ко многим, опционально)
            modelBuilder.Entity<ServiceRequest>()
                .HasOptional(sr => sr.Equipment)
                .WithMany(e => e.ServiceRequests)
                .HasForeignKey(sr => sr.EquipmentId)
                .WillCascadeOnDelete(false);
                
            // Связь MaintenanceSchedule - HvacSystem (один ко многим)
            modelBuilder.Entity<MaintenanceSchedule>()
                .HasRequired(ms => ms.HvacSystem)
                .WithMany(s => s.MaintenanceSchedules)
                .HasForeignKey(ms => ms.HvacSystemId)
                .WillCascadeOnDelete(false);
                
            // Связь MaintenanceSchedule - Equipment (один ко многим, опционально)
            modelBuilder.Entity<MaintenanceSchedule>()
                .HasOptional(ms => ms.Equipment)
                .WithMany(e => e.MaintenanceSchedules)
                .HasForeignKey(ms => ms.EquipmentId)
                .WillCascadeOnDelete(false);
                
            // Связь MaintenanceSchedule - Technician (один ко многим, опционально)
            modelBuilder.Entity<MaintenanceSchedule>()
                .HasOptional(ms => ms.Technician)
                .WithMany(t => t.MaintenanceSchedules)
                .HasForeignKey(ms => ms.TechnicianId)
                .WillCascadeOnDelete(false);
                
            // Связь многие-ко-многим между ServiceRequest и Part через ServiceRequestPart
            modelBuilder.Entity<ServiceRequestPart>()
                .HasRequired(srp => srp.ServiceRequest)
                .WithMany(sr => sr.ServiceRequestParts)
                .HasForeignKey(srp => srp.ServiceRequestId)
                .WillCascadeOnDelete(false);
                
            modelBuilder.Entity<ServiceRequestPart>()
                .HasRequired(srp => srp.Part)
                .WithMany(p => p.ServiceRequestParts)
                .HasForeignKey(srp => srp.PartId)
                .WillCascadeOnDelete(false);
                
            base.OnModelCreating(modelBuilder);
        }
    }
} 