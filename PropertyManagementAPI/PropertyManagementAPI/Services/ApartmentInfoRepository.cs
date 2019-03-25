using System;
using System.Collections.Generic;
using System.Linq;
using PropertyManagementAPI.Entities;
using PropertyManagementAPI.Models;

namespace PropertyManagementAPI.Services
{
    public class ApartmentInfoRepository : IApartmentInfoRepository
    {
        private DbInfoContext _context;
        public ApartmentInfoRepository(DbInfoContext context)
        {
            _context = context;
        }
        public bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(x => x.Id == id);
        }

        public Apartment GetApartment(int id)
        {
            return _context.Apartments.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Apartment> GetApartments()
        {
            return _context.Apartments.OrderByDescending(x => x.Price).ToList();
        }

        public void AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteApartment(Apartment apartment)
        {
            _context.Apartments.Remove(apartment);
        }
    }
}
