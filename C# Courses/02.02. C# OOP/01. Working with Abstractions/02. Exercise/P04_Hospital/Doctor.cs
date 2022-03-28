namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Patients = new List<Patient>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Patient> Patients { get; set; }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }

        public string GetPatients()
        {
            return String.Join(Environment.NewLine, Patients.Select(p => p.Name).OrderBy(p => p));
        }
    }
}
