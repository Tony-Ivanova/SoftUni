namespace P01_HospitalDatabase
{
    using P01_HospitalDatabase.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var db = new HospitalContext();
            db.Database.EnsureCreated();
        }
    }
}
