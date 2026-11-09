using HotelLib.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLib.Repo
{
    public class HotelRepo
    {
        private readonly DBContext _db;

        public HotelRepo()
        {
            _db = new DBContext();
        }

        public List<Hotel> GetAll()
        {
            return _db.Hotels.Include(h => h.Rooms).ToList();
        }

        public Hotel Get(int id)
        {
            Hotel hotel = _db.Hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                throw new KeyNotFoundException($"Hotel with ID {id} not found.");
            }

            return hotel;
        }

        public Hotel Add(Hotel hotel)
        {
            _db.Hotels.Add(hotel);
            _db.SaveChanges();      // HUSK at gemme reultat dvs.commit

            return hotel;
        }

        public Hotel Update(Hotel hotel)
        {
            Hotel existingHotel = Get(hotel.Id); // kan kaste en exception

            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            _db.SaveChanges();
            return existingHotel;
        }

        public Hotel Delete(int id)
        {
            Hotel hotel = Get(id); // kan kaste en exception
            _db.Hotels.Remove(hotel);
            _db.SaveChanges();
            return hotel;
        }
    }
}
