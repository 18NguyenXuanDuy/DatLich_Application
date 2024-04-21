using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatLich.Models
{
    public partial class DLKB : DbContext
    {
        public DLKB()
            : base("name=DLKB")
        {
        }

        public virtual DbSet<AppointmentSchedule> AppointmentSchedule { get; set; }
        public virtual DbSet<AppointmentSchedule_1> AppointmentSchedule_1 { get; set; }
        public virtual DbSet<Comment_Customer> Comment_Customer { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Dentist> Dentist { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<HistoryChanges> HistoryChanges { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<MedicalHistory> MedicalHistory { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicine> PrescriptionMedicine { get; set; }
        public virtual DbSet<Service_Customer> Service_Customer { get; set; }
        public virtual DbSet<ShiftWork> ShiftWork { get; set; }
        public virtual DbSet<ShiftWork_Appoint> ShiftWork_Appoint { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentSchedule>()
                .Property(e => e.AppointmentSchedule_Date)
                .IsUnicode(false);

            modelBuilder.Entity<AppointmentSchedule_1>()
                .Property(e => e.Customer_Email)
                .IsUnicode(false);

            modelBuilder.Entity<AppointmentSchedule_1>()
                .Property(e => e.Customer_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<AppointmentSchedule_1>()
                .Property(e => e.AppointmentSchedule_Date)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.Dentist_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Employee_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MedicalHistory>()
                .Property(e => e.MedicalHistory_Date)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalHistory>()
                .Property(e => e.MedicalHistory_Symptoms)
                .IsUnicode(false);

            modelBuilder.Entity<MedicalHistory>()
                .Property(e => e.MedicalHistory_Diagnosis)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Medicine_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Medicine>()
                .HasMany(e => e.PrescriptionMedicine)
                .WithRequired(e => e.Medicine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.Prescription_Date)
                .IsUnicode(false);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.Prescription_Symptom)
                .IsUnicode(false);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.Prescription_Diagnostic)
                .IsUnicode(false);

            modelBuilder.Entity<Prescription>()
                .HasMany(e => e.PrescriptionMedicine)
                .WithRequired(e => e.Prescription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrescriptionMedicine>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Service_Customer>()
                .Property(e => e.ServiceCustomer_Price)
                .HasPrecision(19, 4);
        }
    }
}
