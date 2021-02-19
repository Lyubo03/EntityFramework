namespace P01_HospitalDatabase.Data
{
    public class DataValidation
    {
        public static class Patient
        {
            public const int MaxNameLength = 50;
            public const int EmailMaxLength = 80;
            public const int AddressMaxLength = 250;
        }
        public static class Visitation
        {
            public const int MaxCommentLength = 250;
        }
        public static class Diagnose
        {
            public const int MaxNameLength = 50;
            public const int MaxCommentsLength = 250;
        }
        public static class Medicament
        {
            public const int MaxNameLength = 50;
        }
        public static class Doctor
        {
            public const int MaxNameLength = 50;
            public const int SpecialtyMaxLength = 100;

        }
    }
}