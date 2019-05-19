using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitness.Model.DBContext;
using System.Threading.Tasks;
using Fitness.Model;
using System.Data.Entity.Validation;

namespace Fitness.Logic
{
    public class FitnessController
    {
        private FitnessDB fitnessDatabase;

        public FitnessController()
        {
            this.fitnessDatabase = new FitnessDB(); 
        }

        // GETs:

        public List<User> GetUsers()
        {
            return fitnessDatabase.User.ToList();
        }

        public User GetUserByUserEmail(string userEmail)
        {
            return fitnessDatabase.User.FirstOrDefault(u => u.Email.Equals(userEmail))??null;
        }

        public User GetUserByBarcode(string barcode)
        {
            return fitnessDatabase.User.FirstOrDefault(u => u.Barcode.Equals(barcode)) ?? null;
        }

        public List<Role> GetRoles()
        {
            return fitnessDatabase.Role.ToList();
        }

        public List<Entry> GetEntryes()
        {
            return fitnessDatabase.Entry.ToList();
        }

        public List<LanseType> GetLanseTypes()
        {
            return fitnessDatabase.LanseType.ToList();
        }

        // Recepcionist are allowed to workn only with clients
        public List<Role> GetRecepcionistAllowedRoles()
        {
            return fitnessDatabase.Role.Where(r => r.StringId.Equals("client")).ToList();
        }

        public List<Lanse> GetLanses()
        { 
            return fitnessDatabase.Lanse.ToList();
        }

        public List<Lanse> GetLansesByUserId(int user_id)
        {
            return fitnessDatabase.Lanse.Where(l => l.UserId == user_id).ToList();
        }

        public void UpdateUser(int user_id, User user)
        {

            try
            {
                User result = ( from u in fitnessDatabase.User
                                where u.Id == user_id
                                select u ).SingleOrDefault();

                result.Id = user.Id;
                result.Id = user.Id;
                result.Barcode = user.Barcode;
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.BirthDate = user.BirthDate;
                result.Email = user.Email;
                result.Address = user.Address;
                result.OtherInformations = user.OtherInformations;
                result.Password = user.Password;
                result.PhoneNumber = user.PhoneNumber;
                result.Image = user.Image;
                result.Role = user.Role;
                result.RegistrationDate = user.RegistrationDate;
                result.Active = user.Active;

                fitnessDatabase.SaveChanges();

                
            }
            catch ( DbEntityValidationException e )
            {
                foreach ( var eve in e.EntityValidationErrors )
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach ( var ve in eve.ValidationErrors )
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public void InsertEntry(Entry entry)
        {
            fitnessDatabase.Entry.Add(entry);
            fitnessDatabase.SaveChanges();
        }

        public void InsertLanseType(LanseType lanse_type)
        {
            fitnessDatabase.LanseType.Add(lanse_type);
            fitnessDatabase.SaveChanges();
        }

    }
}
