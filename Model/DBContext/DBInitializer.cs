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
    public class DBInitializer : DropCreateDatabaseAlways<FitnessDB>
    {

        protected override void Seed(FitnessDB context)
        {
            //base:Seed(context);
            this.AddUsers(context);
            this.AddLanseTypes(context);
            this.AddLanses(context);
            this.AddEntryes(context);
        }

        private void AddUsers(FitnessDB context)
        {
            context.User.Add(new User { Id = 1, Barcode = "test-barcode", FirstName = "Janos", LastName = "Mille", BirthDate = new DateTime(1997, 4, 24), Email = "millejanos31@gmail.com", Password = "0123".GetHashCode().ToString(), PhoneNumber = "0744793412", Image = "null", Role = "admin" });
            context.User.Add(new User { Id = 2, Barcode = "test-barcode", FirstName = "Iam", LastName = "Guest", BirthDate = new DateTime(2019, 3, 2), Email = "user@mail.com", Password = "user".GetHashCode().ToString(), PhoneNumber = "0123456789", Image = "null", Role = "receptionist" });

            context.User.Add(new User { Id = 3, Barcode = "test-barcode", FirstName = "FName3", LastName = "LName3", BirthDate = new DateTime(2019, 1, 3), Email = "nomail3@mail.com", Password = "no_password", PhoneNumber = "0123456003", Image = "null", Role = "client" });
            context.User.Add(new User { Id = 4, Barcode = "test-barcode", FirstName = "FName4", LastName = "LName4", BirthDate = new DateTime(2019, 4, 4), Email = "nomail4@mail.com", Password = "no_password", PhoneNumber = "0123456004", Image = "null", Role = "client" });
            context.User.Add(new User { Id = 5, Barcode = "test-barcode", FirstName = "FName5", LastName = "LName5", BirthDate = new DateTime(2019, 3, 5), Email = "nomail5@mail.com", Password = "no_password", PhoneNumber = "0123456005", Image = "null", Role = "client" });
            context.User.Add(new User { Id = 6, Barcode = "test-barcode", FirstName = "FName6", LastName = "LName6", BirthDate = new DateTime(2019, 3, 5), Email = "nomail6@mail.com", Password = "no_password", PhoneNumber = "0123456006", Image = "null", Role = "client" });
            context.User.Add(new User { Id = 7, Barcode = "test-barcode", FirstName = "FName7", LastName = "LName7", BirthDate = new DateTime(2019, 3, 5), Email = "nomail7@mail.com", Password = "no_password", PhoneNumber = "0123456007", Image = "null", Role = "client" });

        }

        private void AddLanseTypes(FitnessDB context)
        {

        }

        private void AddLanses(FitnessDB context)
        {

        }

        private void AddEntryes(FitnessDB context)
        {

        }

    }
}
