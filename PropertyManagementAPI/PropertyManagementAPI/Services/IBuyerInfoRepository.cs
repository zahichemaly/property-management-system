using PropertyManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Services
{
    public interface IBuyerInfoRepository
    {
        bool BuyerExists(int id);
        bool ApartmentExists(int id);
        IEnumerable<Buyer> GetBuyers();
        Buyer GetBuyer(int id);
        IEnumerable<Apartment> GetApartments(int id);
        Apartment GetApartment(int buyerId, int apartmentId);
        Apartment FindApartment(int apartmentId);
        void BuyApartment(int buyerId, Apartment apartment);
        bool Save();
    }
}
