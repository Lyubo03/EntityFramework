namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    using P01_HospitalDatabase.Data;
    public class StartUp
    {
        public static void Main()
        {
            var context = new HospitalDbContext();
            context.Database.Migrate();
        }
    }
}