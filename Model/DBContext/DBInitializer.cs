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
    public class DBInitializer : DropCreateDatabaseAlways<FitnessDB>    // DropCreateDatabaseAlways OR CreateDatabaseIfNotExists
    {
        List<LanseType> lanse_types;
        List<Lanse> lanses;
        List<User> users;

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
            context.Role.Add(new Role { Id = 0, StringId = "admin", Name = "Admin", Description = "No admin description." });
            context.Role.Add(new Role { Id = 1, StringId = "receptionist", Name = "Receptionist", Description = "No receptionist description." });
            context.Role.Add(new Role { Id = 2, StringId = "client", Name = "Client", Description = "No client description." });
        }

        private void AddUsers(FitnessDB context)
        {
            users = new List<User>();

            users.Add(new User { Id = 0,    Barcode = "1508930965252523109412047", FirstName = "Andrea-Edina", LastName = "Fabian", BirthDate = new DateTime(1997, 1, 1),    Email = "andi@mail", Password = "andi".GetHashCode().ToString(),   PhoneNumber = "0000000000",     Image = "profile_0.png",    Address = "Address0",  OtherInformations = "Other\ninformations",   RegistrationDate = new DateTime(2019, 5, 15),  Active = true, Role = "admin"        });
            users.Add(new User { Id = 1,    Barcode = "1508930965252523109412048", FirstName = "Janos", LastName = "Mille",         BirthDate = new DateTime(1997, 4, 24),   Email = "mj@mail",   Password = "mj".GetHashCode().ToString(),     PhoneNumber = "0744793412",     Image = "profile_1.png",    Address = "Address1",  OtherInformations = "Other\ninformations",   RegistrationDate = new DateTime(2019, 5, 16),  Active = true, Role = "admin"        });
            users.Add(new User { Id = 2,    Barcode = "0986508930965252523109415", FirstName = "I am", LastName = "Guest",          BirthDate = new DateTime(2019, 3, 2),    Email = "rec@mail",  Password = "rec".GetHashCode().ToString(),    PhoneNumber = "0123456789",     Image = "null",             Address = "Address2",  OtherInformations = "Other\ninformations",   RegistrationDate = new DateTime(2019, 5, 17),  Active = true, Role = "receptionist" });
                 
            users.Add(new User { Id = 3,    Barcode = "8630969412020309525203024", FirstName = "Peter", LastName = "Kali",  BirthDate = new DateTime(2011, 1, 23), Email = "nomail3@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456003", Image = "null", Address = "Address3", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 1, 11), Role = "client", Active = true });
            users.Add(new User { Id = 4,    Barcode = "5231097109563471099467021", FirstName = "Alex", LastName = "Nemes",  BirthDate = new DateTime(2012, 4, 04), Email = "nomail4@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456004", Image = "null", Address = "Address4", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 2, 12), Role = "client", Active = true });
            users.Add(new User { Id = 5,    Barcode = "6508652525231094130952523", FirstName = "Ingrid", LastName = "Orosz",BirthDate = new DateTime(2013, 3, 15), Email = "nomail5@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456005", Image = "null", Address = "Address5", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 3, 13), Role = "client", Active = true });
            users.Add(new User { Id = 6,    Barcode = "3290523865734556409232349", FirstName = "Fred", LastName = "Mark",   BirthDate = new DateTime(2014, 3, 05), Email = "nomail6@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456006", Image = "null", Address = "Address6", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 4, 14), Role = "client", Active = true });
            users.Add(new User { Id = 7,    Barcode = "5291462049126401294612108", FirstName = "Breda", LastName = "Yap",   BirthDate = new DateTime(2015, 3, 15), Email = "nomail7@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123456007", Image = "null", Address = "Address7", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 5, 15), Role = "client", Active = true });
            users.Add(new User { Id = 8,    Barcode = "5291462049126401294612000", FirstName = "Inactive", LastName = "One",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 9,    Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 10,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 11,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 12,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 13,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 14,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 15,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 16,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 17,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 18,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 19,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 20,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 21,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 22,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 23,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 24,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            users.Add(new User { Id = 25,   Barcode = "0123456789012345678901234", FirstName = "Dummy", LastName = "User",BirthDate = new DateTime(2016, 2, 11), Email = "nomail8@mail.com",   Password = "_".GetHashCode().ToString(), PhoneNumber = "0123452000", Image = "null", Address = "Address8", OtherInformations = "Other\ninformations", RegistrationDate = new DateTime(2011, 6, 16), Role = "client", Active = false });
            foreach ( User u in users )
            {
                context.User.Add(u);
            }
        }

        private void AddLanseTypes(FitnessDB context)
        {
            lanse_types = new List<LanseType>();

            lanse_types.Add(new LanseType { Id = 0,    Name = "Best Week",        ActiveTimes = 7,      ActiveDays = "1111111",     ActivePerDay = 1,     ActiveHoursPerDay = 24,     Price = 10,     Active = true,      Description="Weekly Lanse" } );
            lanse_types.Add(new LanseType { Id = 1,    Name = "Amazing Month",    ActiveTimes = 30,     ActiveDays = "1111100",     ActivePerDay = 1,     ActiveHoursPerDay = 24,     Price = 100,    Active = true,      Description="Month Lanse" } );
            lanse_types.Add(new LanseType { Id = 2,    Name = "Custom #1",        ActiveTimes = 5,      ActiveDays = "0000011",     ActivePerDay = 1,     ActiveHoursPerDay = 1,      Price = 3,      Active = true,      Description="Custom One #1" } );
            lanse_types.Add(new LanseType { Id = 3,    Name = "Custom #2",        ActiveTimes = 10,     ActiveDays = "1000111",     ActivePerDay = 2,     ActiveHoursPerDay = 24,     Price = 25,     Active = true,      Description="Custom One #2" } );
            lanse_types.Add(new LanseType { Id = 4,    Name = "Custom #3",        ActiveTimes = 14,     ActiveDays = "1010101",     ActivePerDay = 1,     ActiveHoursPerDay = 24,     Price = 25,     Active = false,     Description="Under Testing" } );

            foreach (LanseType lt in lanse_types)
            {
                context.LanseType.Add(lt);
            }

        }

        private void AddLanses(FitnessDB context)
        {
            lanses = new List<Lanse>();

            lanses.Add(new Lanse { Id = 0,     TypeId = 0,    Type = lanse_types.ElementAt(0),      RemainingTimes = 5,     UserId = 0,  User = users.ElementAt(0),  Price = 10,     StartDate = new DateTime(2019,01,03),     EndDate = new DateTime(2019,05,03),     Active = true } );
            lanses.Add(new Lanse { Id = 1,     TypeId = 2,    Type = lanse_types.ElementAt(2),      RemainingTimes = 2,     UserId = 0,  User = users.ElementAt(0),  Price = 25,     StartDate = new DateTime(2019,02,04),     EndDate = new DateTime(2019,06,04),     Active = true } );
            lanses.Add(new Lanse { Id = 2,     TypeId = 3,    Type = lanse_types.ElementAt(3),      RemainingTimes = 7,    UserId = 0,  User = users.ElementAt(0),  Price = 5,      StartDate = new DateTime(2019,03,05),     EndDate = new DateTime(2019,08,05),     Active = true } );
            lanses.Add(new Lanse { Id = 3,     TypeId = 0,    Type = lanse_types.ElementAt(0),      RemainingTimes = 7,     UserId = 1,  User = users.ElementAt(1),  Price = 9,      StartDate = new DateTime(2019,04,06),     EndDate = new DateTime(2019,08,06),     Active = true } );
            lanses.Add(new Lanse { Id = 4,     TypeId = 3,    Type = lanse_types.ElementAt(3),      RemainingTimes = 0,    UserId = 1,  User = users.ElementAt(1),  Price = 3,      StartDate = new DateTime(2019,05,07),     EndDate = new DateTime(2019,10,07),     Active = false } );
            lanses.Add(new Lanse { Id = 5,     TypeId = 2,    Type = lanse_types.ElementAt(2),      RemainingTimes = 5,     UserId = 2,  User = users.ElementAt(2),  Price = 12,     StartDate = new DateTime(2019,06,08),     EndDate = new DateTime(2019,11,08),     Active = true } );
            lanses.Add(new Lanse { Id = 6,     TypeId = 3,    Type = lanse_types.ElementAt(3),      RemainingTimes = 9,    UserId = 3,  User = users.ElementAt(3),  Price = 30,     StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = true } );
            lanses.Add(new Lanse { Id = 7,     TypeId = 2,    Type = lanse_types.ElementAt(2),      RemainingTimes = 5,     UserId = 1,  User = users.ElementAt(1),  Price = 128,    StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = true } );
            lanses.Add(new Lanse { Id = 8,     TypeId = 3,    Type = lanse_types.ElementAt(3),      RemainingTimes = 0,    UserId = 1,  User = users.ElementAt(1),  Price = 10,     StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = false } );
            lanses.Add(new Lanse { Id = 9,     TypeId = 1,    Type = lanse_types.ElementAt(1),      RemainingTimes = 22,    UserId = 1,  User = users.ElementAt(1),  Price = 9,      StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = true } );
            lanses.Add(new Lanse { Id = 10,    TypeId = 3,    Type = lanse_types.ElementAt(3),      RemainingTimes = 2,    UserId = 1,  User = users.ElementAt(1),  Price = 20,     StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = true } );
            lanses.Add(new Lanse { Id = 11,    TypeId = 3,    Type = lanse_types.ElementAt(3),      RemainingTimes = 10,    UserId = 1,  User = users.ElementAt(1),  Price = 32,     StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = false } );
            lanses.Add(new Lanse { Id = 12,    TypeId = 0,    Type = lanse_types.ElementAt(0),      RemainingTimes = 1,     UserId = 1,  User = users.ElementAt(1),  Price = 32,     StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = true } );
            lanses.Add(new Lanse { Id = 13,    TypeId = 3,    Type = lanse_types.ElementAt(3),      RemainingTimes = 8,    UserId = 1,  User = users.ElementAt(1),  Price = 74,     StartDate = new DateTime(2019,07,09),     EndDate = new DateTime(2019,12,09),     Active = false } );

            foreach (Lanse l in lanses)
            {
                context.Lanse.Add(l);
            }
        }

        private void AddEntryes(FitnessDB context)
        {
            context.Entry.Add(new Entry { Id = 0,    LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,12,10)    });
            context.Entry.Add(new Entry { Id = 1,    LanseId = 1,  Lanse = lanses.ElementAt(1),   ReceptionistId = 2,    Date = new DateTime(2019,12,11)    });
            context.Entry.Add(new Entry { Id = 2,    LanseId = 2,  Lanse = lanses.ElementAt(2),   ReceptionistId = 2,    Date = new DateTime(2019,12,12)    });
            context.Entry.Add(new Entry { Id = 3,    LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 4,    LanseId = 1,  Lanse = lanses.ElementAt(1),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 5,    LanseId = 2,  Lanse = lanses.ElementAt(2),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 6,    LanseId = 3,  Lanse = lanses.ElementAt(3),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 7,    LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 8,    LanseId = 1,  Lanse = lanses.ElementAt(1),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 9,    LanseId = 2,  Lanse = lanses.ElementAt(2),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 10,   LanseId = 1,  Lanse = lanses.ElementAt(1),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 11,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 12,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });
            context.Entry.Add(new Entry { Id = 13,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,12,13)    });

            context.Entry.Add(new Entry { Id = 14,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 15,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,7,05,00)});
            context.Entry.Add(new Entry { Id = 16,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,7,05,00)});
            context.Entry.Add(new Entry { Id = 17,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,7,05,00)});
            context.Entry.Add(new Entry { Id = 18,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,7,05,00)});
            context.Entry.Add(new Entry { Id = 19,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 20,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 21,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 22,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,8,05,00)});
            context.Entry.Add(new Entry { Id = 23,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,8,05,00)});
            context.Entry.Add(new Entry { Id = 24,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,8,05,00)});
            context.Entry.Add(new Entry { Id = 25,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,8,05,00)});
            context.Entry.Add(new Entry { Id = 26,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,12,05, 00)});
            context.Entry.Add(new Entry { Id = 27,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05, 00)});
            context.Entry.Add(new Entry { Id = 28,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,9,05, 00)});
            context.Entry.Add(new Entry { Id = 29,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,12,05, 00)});
            context.Entry.Add(new Entry { Id = 30,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 31,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 32,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,9,05,00)});
            context.Entry.Add(new Entry { Id = 33,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,9,05,00)});
            context.Entry.Add(new Entry { Id = 34,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,9,05,00)});
            context.Entry.Add(new Entry { Id = 35,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05, 00)});
            context.Entry.Add(new Entry { Id = 36,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,10,05,00)});
            context.Entry.Add(new Entry { Id = 37,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,10,05,00)});
            context.Entry.Add(new Entry { Id = 38,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,10,05,00)});
            context.Entry.Add(new Entry { Id = 39,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,10,05, 00)});
            context.Entry.Add(new Entry { Id = 40,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 41,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 42,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05, 00)});
            context.Entry.Add(new Entry { Id = 43,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,11,05,00)});
            context.Entry.Add(new Entry { Id = 44,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,11,05,00)});
            context.Entry.Add(new Entry { Id = 45,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,11,05,00)});
            context.Entry.Add(new Entry { Id = 46,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,11,05,00)});
            context.Entry.Add(new Entry { Id = 47,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,11,05,00)});
            context.Entry.Add(new Entry { Id = 48,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,15,05,00)});
            context.Entry.Add(new Entry { Id = 49,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,15,05,00)});
            context.Entry.Add(new Entry { Id = 50,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,15,05,00)});
            context.Entry.Add(new Entry { Id = 51,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,15,05,00)});
            context.Entry.Add(new Entry { Id = 52,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05,00)});
            context.Entry.Add(new Entry { Id = 53,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,18,05,00)});
            context.Entry.Add(new Entry { Id = 54,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,18,05,00)});
            context.Entry.Add(new Entry { Id = 55,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05, 00)});
            context.Entry.Add(new Entry { Id = 56,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,16,05,00)});
            context.Entry.Add(new Entry { Id = 57,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,16,05,00)});
            context.Entry.Add(new Entry { Id = 58,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,16,05, 00)});
            context.Entry.Add(new Entry { Id = 59,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,22,05,00)});
            context.Entry.Add(new Entry { Id = 60,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05, 00)});
            context.Entry.Add(new Entry { Id = 61,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,17,05, 00)});
            context.Entry.Add(new Entry { Id = 62,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05, 00)});
            context.Entry.Add(new Entry { Id = 63,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,6,05, 00)});
            context.Entry.Add(new Entry { Id = 64,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,18,20, 00)});
            context.Entry.Add(new Entry { Id = 65,   LanseId = 0,  Lanse = lanses.ElementAt(0),   ReceptionistId = 2,    Date = new DateTime(2019,05,20,23,05, 00)});
        }

    }
}
