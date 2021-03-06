﻿namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Diagnose;

    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxCommentsLength)]
        public string Comments { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}