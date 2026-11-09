using HotelLib.model;
using HotelLib.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoEntityFrameworkApp
{
    public class dbworker
    {

        public void Start()
        {
            HotelRepo repo = new HotelRepo();

            var hotels = repo.GetAll();
            foreach (var hotel in hotels)
            {
                Console.WriteLine(hotel);
            }

            Hotel hotel1 = new Hotel { Name = "Peters Hote", Address = "denne vej 3" };
            Hotel nytHotel = repo.Add(hotel1);
            Console.WriteLine(nytHotel);
        }
    }
}
