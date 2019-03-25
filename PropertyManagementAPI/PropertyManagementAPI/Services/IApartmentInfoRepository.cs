using PropertyManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Services
{
    public interface IApartmentInfoRepository
    {
        bool ApartmentExists(int id);
        IEnumerable<Apartment> GetApartments();
        Apartment GetApartment(int id);
        void AddApartment(Apartment apartment);
        void DeleteApartment(Apartment apartment);
        bool Save();
    }
}
