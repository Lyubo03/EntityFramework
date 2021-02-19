namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Medicament;
    public class Medicament 
    {
        public int MedicamentId { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public ICollection<PatientMedicament> Perscription { get; set; } = new  HashSet<PatientMedicament>();
    }
}