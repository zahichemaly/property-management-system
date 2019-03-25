using PropertyManagementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI
{
    public static class DbContextExtensions
    {
        public static void EnsureSeedDataForContext(this DbInfoContext context)
        {
            if (context.Apartments.Any())
            {
                return;
            }

            var apartments = new List<Apartment>()
            {
                new Apartment()
                {
                    Title = "Zouzou Sky",
                    Address = "Tripoli",
                    NbOfRooms = 2,
                    Price = 5000
                },
                new Apartment()
                {
                    Title = "Georges Bldg.",
                    Address = "Beirut, Achrafieh",
                    NbOfRooms = 3,
                    Price = 10000
                },
                new Apartment()
                {
                    Title = "Sama Beirut Apartment 4",
                    Address = "Beirut, Achrafieh",
                    NbOfRooms = 8,
                    Price = 50000
                },
                new Apartment()
                {
                    Title = "Cloud 9 Tower",
                    Address = "Beirut, Baabda",
                    NbOfRooms = 6,
                    Price = 25000
                },
                new Apartment()
                {
                    Title = "Sky Hotel",
                    Address = "Baabda",
                    NbOfRooms = 4,
                    Price = 10000
                }
            };

            var buyers = new List<Buyer>()
            {
                new Buyer
                {
                    FullName = "John Smith",
                    Credits = 10000,
                },
                new Buyer
                {
                    FullName = "William Jones",
                    Credits = 100000,
                },
                new Buyer
                {
                    FullName = "Gordon Freeman",
                    Credits = 2000000,
                }
            };
            context.Apartments.AddRange(apartments);
            context.Buyers.AddRange(buyers);
            context.SaveChanges();
        }
    }
}
