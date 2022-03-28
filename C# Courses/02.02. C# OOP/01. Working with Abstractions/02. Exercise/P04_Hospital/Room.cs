namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;

    public class Room
    {
        public Room(int id)
        {
            Id = id;
            Patients = new List<Patient>();
        }
        public List<Patient> Patients { get; set; }
        public int Id { get; set; }

        public void AddPatient(Patient patient)
        {
            if (Patients.Count >= 3)
            {
                throw new Exception();
            }

            this.Patients.Add(patient);
        }
    }
}