using Fitness.Model.DBContext;
using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model.DBContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<FitnessDB>    // DropCreateDatabaseAlways OR CreateDatabaseIfNotExists
    {
        List<LanseType> lanse_types;

        protected override void Seed(FitnessDB context)
        {
            //base:Seed(context);
            this.AddRoles(context);
            this.AddUsers(context);
            this.AddLanseTypes(context);
            this.AddLanses(context);
            this.AddEntryes(context);
        }

        private void AddRoles(FitnessDB context)
        {
            context.Role.Add(new Role { Id = 0,     StringId = "admin",         Name = "Admin",         Description = "No admin description."           });
            context.Role.Add(new Role { Id = 1,     StringId = "receptionist",  Name = "Receptionist",  Description = "No receptionist description."    });
            context.Role.Add(new Role { Id = 2,     StringId = "client",        Name = "Client",        Description = "No client description."          });
        }

        private void AddUsers(FitnessDB context)
        {
            context.User.Add(new User { Id = 0, Barcode = "1508930965252523109412047", FirstName = "Andrea-Edina", LastName = "Fabian", BirthDate = new DateTime(1997, 1, 1), Email = "andi@mail", Password = "andi".GetHashCode().ToString(), PhoneNumber = "0000000000", Image = "profile_0.png", Address = "Address0", OtherInformations = "Other\ninformations",   RegistrationDate = new DateTime(2019, 5, 15),  Active = true, Role = "admin"        });
            context.User.Add(new User { Id = 1, Barcode = "1508930965252523109412047", FirstName = "Janos", LastName = "Mille", BirthDate = new DateTime(1997, 4, 24) ,Email = "mj@mail", Password = "mj".GetHashCode().ToString(), PhoneNumber = "0744793412", Image = "profile_1.png",         Address = "Address1", OtherInformations = "Other\ninformations",   RegistrationDate = new DateTime(2019, 5, 16),  Active = true, Role = "admin"        });
            context.User.Add(new User { Id = 2, Barcode = "0986508930965252523109415", FirstName = "I am", LastName = "Guest",   BirthDate = new DateTime(2019, 3, 2), Email = "rec@mail", Password = "rec".GetHashCode().ToString(), PhoneNumber = "0123456789", Image = "null",         Address = "Address2", OtherInformations = "Other\ninformations",   RegistrationDate = new DateTime(2019, 5, 17),  Active = true, Role = "receptionist" });

            context.User.Add(new User { Id = 3, Barcode = "8630969412020309525203024", FirstName = "Peter", LastName = "Kali",  BirthDate = new DateTime(2011, 1, 23), Email = "nomail3@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456003", Image = "null", Address = "Address3", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 1, 11), Role = "client", Active = true });
            context.User.Add(new User { Id = 4, Barcode = "5231097109563471099467021", FirstName = "Alex", LastName = "Nemes",  BirthDate = new DateTime(2012, 4, 04), Email = "nomail4@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456004", Image = "null", Address = "Address4", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 2, 12), Role = "client", Active = true });
            context.User.Add(new User { Id = 5, Barcode = "6508652525231094130952523", FirstName = "Ingrid", LastName = "Orosz",BirthDate = new DateTime(2013, 3, 15), Email = "nomail5@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456005", Image = "null", Address = "Address5", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 3, 13), Role = "client", Active = true });
            context.User.Add(new User { Id = 6, Barcode = "3290523865734556409232349", FirstName = "Fred", LastName = "Mark",   BirthDate = new DateTime(2014, 3, 05), Email = "nomail6@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456006", Image = "null", Address = "Address6", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 4, 14), Role = "client", Active = true });
            context.User.Add(new User { Id = 7, Barcode = "5291462049126401294612108", FirstName = "Breda", LastName = "Yap",   BirthDate = new DateTime(2015, 3, 15), Email = "nomail7@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456007", Image = "null", Address = "Address7", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 5, 15), Role = "client", Active = true });
            context.User.Add(new User { Id = 8, Barcode = "5291462049126401294612000", FirstName = "Inactive", LastName = "One",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
        }

        private void AddLanseTypes(FitnessDB context)
        {
            lanse_types = new List<LanseType>();
            lanse_types.Add(new LanseType { Id = 0, Name = "Best Week",       ActiveDays = "1111111", ActivePerDay = 1, ActiveHoursPerDay = 24, Price = 10,     Active = true, Description="Weekly Lanse" } );
            lanse_types.Add(new LanseType { Id = 1, Name = "Amazing Month",   ActiveDays = "1111100", ActivePerDay = 1, ActiveHoursPerDay = 24, Price = 100,    Active = true, Description="Month Lanse" } );
            lanse_types.Add(new LanseType { Id = 2, Name = "Custom #1",       ActiveDays = "0000011", ActivePerDay = 1, ActiveHoursPerDay = 1,  Price = 3,      Active = true, Description="Custom One #1" } );
            lanse_types.Add(new LanseType { Id = 3, Name = "Custom #2",       ActiveDays = "1000111", ActivePerDay = 2, ActiveHoursPerDay = 24, Price = 25,     Active = true, Description="Custom One #2" } );
            lanse_types.Add(new LanseType { Id = 3, Name = "Custom #3",       ActiveDays = "1010101", ActivePerDay = 1, ActiveHoursPerDay = 24, Price = 25,     Active = false, Description="Under Testing" } );
            foreach(LanseType lt in lanse_types )
            {
                context.LanseType.Add( lt );
            }

        }

        private void AddLanses(FitnessDB context)
        {
            List<Lanse> lanses = new List<Lanse>();
                                                     /*Type = ... Is working ???      */
            lanses.Add(new Lanse { Id = 0, TypeId = 0, Type = lanse_types.ElementAt(0),  UserId = 0, Price = 10, StartDate = new DateTime(2019,01,03), EndDate = new DateTime(2019,05,03), Active = true } );
            lanses.Add(new Lanse { Id = 1, TypeId = 2, Type = lanse_types.ElementAt(2),  UserId = 0, Price = 25, StartDate = new DateTime(2019,02,04), EndDate = new DateTime(2019,06,04), Active = true } );
            lanses.Add(new Lanse { Id = 2, TypeId = 3, Type = lanse_types.ElementAt(3),  UserId = 0, Price = 5, StartDate = new DateTime(2019,03,05), EndDate = new DateTime(2019,08,05), Active = true } );
            lanses.Add(new Lanse { Id = 3, TypeId = 0, Type = lanse_types.ElementAt(0),  UserId = 1, Price = 9, StartDate = new DateTime(2019,04,06), EndDate = new DateTime(2019,08,06), Active = true } );
            lanses.Add(new Lanse { Id = 4, TypeId = 3, Type = lanse_types.ElementAt(3),  UserId = 1, Price = 3, StartDate = new DateTime(2019,05,07), EndDate = new DateTime(2019,10,07), Active = false } );
            lanses.Add(new Lanse { Id = 5, TypeId = 2, Type = lanse_types.ElementAt(2),  UserId = 2, Price = 12, StartDate = new DateTime(2019,06,08), EndDate = new DateTime(2019,11,08), Active = true } );
            lanses.Add(new Lanse { Id = 6, TypeId = 3, Type = lanse_types.ElementAt(3),  UserId = 3, Price = 30, StartDate = new DateTime(2019,07,09), EndDate = new DateTime(2019,12,09), Active = true } );
            foreach(Lanse l in lanses )
            {
                context.Lanse.Add( l );
            }
        }

        private void AddEntryes(FitnessDB context)
        {
            context.Entry.Add(new Entry { Id = 0, LanseId = 6, Lanse = null, ReceptionistId = 2, Date = new DateTime(2019,12,10) });
            context.Entry.Add(new Entry { Id = 1, LanseId = 6, Lanse = null, ReceptionistId = 2, Date = new DateTime(2019,12,11) });
            context.Entry.Add(new Entry { Id = 2, LanseId = 6, Lanse = null, ReceptionistId = 2, Date = new DateTime(2019,12,12) });
            context.Entry.Add(new Entry { Id = 3, LanseId = 6, Lanse = null, ReceptionistId = 2, Date = new DateTime(2019,12,13) });
        }

    }
}
