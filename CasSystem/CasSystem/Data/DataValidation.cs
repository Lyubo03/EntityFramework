namespace CasSystem.Data
{
    public class DataValidation
    {
        public static class Make
        {
            public const int MaxName = 20;
        }
        public static class Model
        {
            public const int MaxName = 30;
            public const int MaxModification = 40;
        }
        public static class Car
        {
            public const int VinLength = 30;
            public const int ColorMaxLength = 20;
        }
        public static class Customer
        {
            public const int MaxNameLength = 20;
        }
        public static class Address
        {
            public const int MaxTextLength = 50;
            public const int TownLength = 20;

        }
    }
}