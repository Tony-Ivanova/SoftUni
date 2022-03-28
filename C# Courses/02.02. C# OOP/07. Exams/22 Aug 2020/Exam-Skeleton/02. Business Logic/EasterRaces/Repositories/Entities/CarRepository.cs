using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private HashSet<ICar> cars;

        public CarRepository()
        {
            cars = new HashSet<ICar>();
        }

        public void Add(ICar model)
        {
            cars.Add(model);   
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return cars;
        }

        public ICar GetByName(string name)
        {
            return cars.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
             return cars.Remove(model);
        }
    }
}
