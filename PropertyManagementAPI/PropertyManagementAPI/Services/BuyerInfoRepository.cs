using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyManagementAPI.Entities;

namespace PropertyManagementAPI.Services
{
    public class BuyerInfoRepository : IBuyerInfoRepository
    {
        private DbInfoContext _context;
        public BuyerInfoRepository(DbInfoContext context)
        {
            _context = context;
        }
        // Checks if the Buyer exists already
        public bool BuyerExists(int id)
        {
            return _context.Buyers.Any(x => x.Id == id);
        }
        public bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(x => x.Id == id);
        }
        public Buyer GetBuyer(int id)
        {
            return _context.Buyers.Include(x => x.OwnedApartments)
                    .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Buyer> GetBuyers()
        {
            return _context.Buyers.Include(x => x.OwnedApartments)
                    .OrderBy(x => x.FullName).ToList();
        }

        public Apartment GetApartment(int buyerId, int apartmentId)
        {
            var apartments = _context.Apartments.Where(x => x.BuyerId == buyerId);
            return apartments.Where(x => x.Id == apartmentId).FirstOrDefault();
        }

        public IEnumerable<Apartment> GetApartments(int id)
        {
            return _context.Apartments.Where(x => x.BuyerId == id).ToList();
        }
        public Apartment FindApartment(int apartmentId)
        {
            return _context.Apartments.Where(x => x.Id == apartmentId).FirstOrDefault();
        }

        public void BuyApartment(int buyerId, Apartment apartment)
        {
            var buyer = GetBuyer(buyerId);
            buyer.OwnedApartments.Add(apartment);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
