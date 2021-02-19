namespace P01_HospitalDatabase.Data.Models
{
    using static DataValidation.Patient;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Patient
    {
        public int PatientId { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }
        public bool HasInsurance { get; set; }
        public ICollection<PatientMedicament> Perscription { get; set; } = new HashSet<PatientMedicament>();
        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();
        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();

    }
}