namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Doctor;
    public class Doctor
    {
        public int DoctorId { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(SpecialtyMaxLength)]
        public string Speciality { get; set; }
        public ICollection<Visitation> Visitations {get;set;} = new HashSet<Visitation>();
    }
}