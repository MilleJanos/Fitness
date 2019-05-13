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
            // TODO
        }

        private void AddUsers(FitnessDB context)
        {
            context.User.Add(new User { Id = 1, Barcode = "test-barcode", FirstName = "FName1", LastName = "LName1", BirthDate = new DateTime(2019,4,1), Email = "nomail1@mail.com", Password = "***noPassword", PhoneNumber ="0123456789", Image="null", Role="user" });
            context.User.Add(new User { Id = 2, Barcode = "test-barcode", FirstName = "FName2", LastName = "LName2", BirthDate = new DateTime(2019,3,2), Email = "nomail2@mail.com", Password = "***noPassword", PhoneNumber ="0123456789", Image="null", Role="user" });
            context.User.Add(new User { Id = 3, Barcode = "test-barcode", FirstName = "FName3", LastName = "LName3", BirthDate = new DateTime(2019,1,3), Email = "nomail3@mail.com", Password = "***noPassword", PhoneNumber ="0123456789", Image="null", Role="user" });
            context.User.Add(new User { Id = 4, Barcode = "test-barcode", FirstName = "FName4", LastName = "LName4", BirthDate = new DateTime(2019,4,4), Email = "nomail4@mail.com", Password = "***noPassword", PhoneNumber ="0123456789", Image="null", Role="user" });
            context.User.Add(new User { Id = 5, Barcode = "test-barcode", FirstName = "FName5", LastName = "LName5", BirthDate = new DateTime(2019,3,5), Email = "nomail5@mail.com", Password = "***noPassword", PhoneNumber ="0123456789", Image="null", Role="user" });

        }

        // TODO

    }
}
