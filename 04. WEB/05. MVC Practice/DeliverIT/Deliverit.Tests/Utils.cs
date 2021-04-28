using Deliverit.Models;
using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Deliverit.Tests
{
    public class Utils
    {
        public static DbContextOptions<DeliveritDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<DeliveritDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static DeliveritDbContext GetFakeDatabase(string databaseName)
        {
            var context = new DeliveritDbContext(GetOptions(databaseName));

            context.Addresses.AddRange(GetAddresses());
            context.Cities.AddRange(GetCities());
            context.Countries.AddRange(GetCountries());
            context.Customers.AddRange(GetCustomers());
            context.Employees.AddRange(GetEmployees());
            context.Warehouses.AddRange(GetWarehouses());
            context.Parcels.AddRange(GetParcels());
            context.Shipments.AddRange(GetShipments());
            context.Categories.AddRange(GetCategories());
            context.Statuses.AddRange(GetStatuses());

            context.SaveChanges();

            return context;
        }

        public static ICollection<Address> GetAddresses()
        {
            return new List<Address>()
            {
                new Address()
                {
                   Id = Guid.Parse("36049406-10ba-499d-916b-063422046239"),
                   CreatedOn = DateTime.UtcNow,
                   StreetName = "Ramon Berenguer El Vell 1",
                   CityId = Guid.Parse("e99abf10-63e9-4212-9053-87cb1d80763e")
                },

                new Address()
                {
                   Id = Guid.Parse("ac2fee3a-f76e-4d94-aa42-d85b4bb45299"),
                   CreatedOn = DateTime.UtcNow,
                   StreetName = "Zeughofstraße 20",
                   CityId = Guid.Parse("e422b2de-f54d-4a4e-9259-0f3f4033f93d")
                },

                new Address()
                {
                   Id = Guid.Parse("b1347388-583d-4324-870a-e487e61ef483"),
                   CreatedOn = DateTime.UtcNow,
                   StreetName = "Rue La Boetie 7",
                   CityId = Guid.Parse("7fdbb1a0-9f76-4b63-aab4-901c61591336")
                },

                new Address()
                {
                   Id = Guid.Parse("97fa423a-a144-4d67-97f5-4211c2758dc5"),
                   CreatedOn = DateTime.UtcNow,
                   StreetName = "Liepkalnio 117",
                   CityId = Guid.Parse("8bf95d78-e5ac-495d-ab67-14b60f644b70")
                },

                new Address()
                {
                   Id = Guid.Parse("5fd8c18f-6885-488e-af8c-ff06901a7d37"),
                   CreatedOn = DateTime.UtcNow,
                   StreetName = "Gran Via De Les Corts Catalanes 105",
                   CityId = Guid.Parse("e99abf10-63e9-4212-9053-87cb1d80763e")
                },

                new Address()
                {
                   Id = Guid.Parse("da703902-00bc-47da-b950-4fa730494d4e"),
                   CreatedOn = DateTime.UtcNow,
                   StreetName = "Passatge De Bocabella 11",
                   CityId = Guid.Parse("e99abf10-63e9-4212-9053-87cb1d80763e")
                }
            };
        }
        public static ICollection<City> GetCities()
        {
            return new List<City>()
            {
                new City()
                {
                    Id = Guid.Parse("e99abf10-63e9-4212-9053-87cb1d80763e"),
                    CreatedOn = DateTime.UtcNow,
                    Name = "Barcelona",
                    CountryId = Guid.Parse("2a84fe90-6605-4052-8a49-e7251af05754")
                },

                new City()
                {
                    Id = Guid.Parse("e422b2de-f54d-4a4e-9259-0f3f4033f93d"),
                    CreatedOn = DateTime.UtcNow,
                    Name = "Berlin",
                    CountryId = Guid.Parse("afbcad66-1a0a-49f2-9e9c-2c61ded8ae08")
                },

                new City()
                {
                   Id = Guid.Parse("7fdbb1a0-9f76-4b63-aab4-901c61591336"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Paris",
                   CountryId = Guid.Parse("72ec653b-aeb1-42fc-bcd1-153f005b1cd4")
                },

                new City()
                {
                   Id = Guid.Parse("8bf95d78-e5ac-495d-ab67-14b60f644b70"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Vilnius",
                   CountryId = Guid.Parse("c4b3bb07-585f-412b-9f5f-f423928015d4")
                }
            };
        }
        public static ICollection<Country> GetCountries()
        {
            return new List<Country>()
            {
                new Country()
                {
                   Id = Guid.Parse("2a84fe90-6605-4052-8a49-e7251af05754"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Spain"
                },

                new Country()
                {
                   Id = Guid.Parse("afbcad66-1a0a-49f2-9e9c-2c61ded8ae08"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Germany"
                },

                new Country()
                {
                   Id = Guid.Parse("72ec653b-aeb1-42fc-bcd1-153f005b1cd4"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "France"
                },

                new Country ()
                {
                   Id = Guid.Parse("c4b3bb07-585f-412b-9f5f-f423928015d4"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Lithuania"
                }
            };
        }
        public static ICollection<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                   Id = Guid.Parse("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1"),
                   CreatedOn = DateTime.UtcNow,
                   FirstName = "Isabelle",
                   LastName = "Huppert",
                   Email = "isabelle.huppert@gmail.com",
                   AddressId = Guid.Parse("b1347388-583d-4324-870a-e487e61ef483")
                },

                new Customer()
                {
                   Id = Guid.Parse("5adb06fe-fca4-4347-b1ea-118c55e17331"),
                   CreatedOn = DateTime.UtcNow,
                   FirstName = "Lukas",
                   LastName = "Petrauskas",
                   Email = "lukas.petr@gmail.com",
                   AddressId = Guid.Parse("97fa423a-a144-4d67-97f5-4211c2758dc5")
                }
            };
        }
        public static ICollection<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee() // Admin
                {
                   Id = Guid.Parse("e9a6b4e2-073b-4ebc-a248-a8d71d426174"),
                   CreatedOn = DateTime.UtcNow,
                   FirstName = "Antonio",
                   LastName = "Recio",
                   Email = "admin@deliverit.com",
                   AddressId = Guid.Parse("da703902-00bc-47da-b950-4fa730494d4e")
                },

                new Employee()
                {
                   Id = Guid.Parse("d2c26c93-d589-4b05-850b-fbf21c59c84d"),
                   CreatedOn = DateTime.UtcNow,
                   FirstName = "Fermin",
                   LastName = "Trujillo",
                   Email = "fer.trujillo@deliverit.com",
                   AddressId = Guid.Parse("5fd8c18f-6885-488e-af8c-ff06901a7d37")
                },

                new Employee()
                {
                   Id = Guid.Parse("facdefb9-19df-42b3-9d3d-6524076e152f"),
                   CreatedOn = DateTime.UtcNow,
                   FirstName = "Amador",
                   LastName = "Rivas",
                   Email = "a.rivas@deliverit.com",
                   AddressId = Guid.Parse("da703902-00bc-47da-b950-4fa730494d4e")
                }
            };
        }
        public static ICollection<Warehouse> GetWarehouses()
        {
            return new List<Warehouse>()
            {
                new Warehouse()
                {
                   Id = Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba"),
                   CreatedOn = DateTime.UtcNow,
                   AddressId = Guid.Parse("36049406-10ba-499d-916b-063422046239")
                },

                new Warehouse()
                {
                   Id = Guid.Parse("988a4201-8c55-42fc-b2a6-e08d1abe6693"),
                   CreatedOn = DateTime.UtcNow,
                   AddressId = Guid.Parse("ac2fee3a-f76e-4d94-aa42-d85b4bb45299")
                }
            };
        }
        public static ICollection<Parcel> GetParcels()
        {
            return new List<Parcel>()
            {
                new Parcel()
                {
                   Id = Guid.Parse("198457ae-236c-4592-90af-3ca2302a8737"),
                   CreatedOn = DateTime.UtcNow,
                   Weight = 10,
                   CategoryId = Guid.Parse("72280df2-7d81-4ec6-936a-51e19aabf7ff"),
                   CustomerId = Guid.Parse("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1"),
                   EmployeeId = Guid.Parse("d2c26c93-d589-4b05-850b-fbf21c59c84d"),
                   ShipmentId = Guid.Parse("e2a2c29b-b7f4-458a-9cde-4a70717607c8")
                },

                new Parcel()
                {
                   Id = Guid.Parse("28ae32a1-10a4-4aef-b262-3baaa1102753"),
                   CreatedOn = DateTime.UtcNow,
                   Weight = 5,
                   CategoryId = Guid.Parse("1db0c76c-ab76-4105-be89-3af983f6f137"),
                   CustomerId = Guid.Parse("5adb06fe-fca4-4347-b1ea-118c55e17331"),
                   EmployeeId = Guid.Parse("facdefb9-19df-42b3-9d3d-6524076e152f"),
                   ShipmentId = Guid.Parse("ce465c59-4866-4905-bdbd-943a26f59fdd ")
                }
            };
        }
        public static ICollection<Shipment> GetShipments()
        {
            return new List<Shipment>()
            {
                new Shipment()
                {
                   Id = Guid.Parse("ce465c59-4866-4905-bdbd-943a26f59fdd"),
                   CreatedOn = DateTime.UtcNow,
                   DepartureDate = DateTime.UtcNow,
                   ArrivalDate = DateTime.UtcNow.AddDays(7),
                   StatusId = Guid.Parse("917f8117-d392-4f64-81fb-48415f80f77e"),
                   WarehouseId = Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba")
                },

                new Shipment()
                {
                   Id = Guid.Parse("e2a2c29b-b7f4-458a-9cde-4a70717607c8"),
                   CreatedOn = DateTime.UtcNow,
                   DepartureDate = DateTime.UtcNow,
                   ArrivalDate = DateTime.UtcNow.AddDays(5),
                   StatusId = Guid.Parse("84568d3c-04df-47c3-9ad8-216b1d664166"),
                   WarehouseId = Guid.Parse("988a4201-8c55-42fc-b2a6-e08d1abe6693")
                }
            };
        }
        public static ICollection<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                   Id = Guid.Parse("1db0c76c-ab76-4105-be89-3af983f6f137"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Electronics"
                },

                new Category()
                {
                   Id = Guid.Parse("df79ccb6-1f56-41da-9f8f-df2f92a468bb"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Clothing"
                },

                new Category()
                {
                   Id = Guid.Parse("7aeb290e-3592-4128-a77a-1a6db6fd81f5"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Medical"
                },

                new Category()
                {
                   Id = Guid.Parse("72280df2-7d81-4ec6-936a-51e19aabf7ff"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "Books"
                }
            };
        }
        public static ICollection<Status> GetStatuses()
        {
            return new List<Status>()
            {
                new Status()
                {
                   Id = Guid.Parse("917f8117-d392-4f64-81fb-48415f80f77e"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "preparing"
                },

                new Status()
                {
                   Id = Guid.Parse("858ac364-d94f-414c-bbea-a0f5b8679b3d"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "on the way"
                },

                new Status()
                {
                   Id = Guid.Parse("84568d3c-04df-47c3-9ad8-216b1d664166"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "completed"
                },

                new Status()
                {
                   Id = Guid.Parse("b31754e2-82fc-4862-ad20-9331a87537eb"),
                   CreatedOn = DateTime.UtcNow,
                   Name = "canceled"
                }
            };
        }
    }
}
