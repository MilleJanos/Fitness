namespace Fitness.Model.DBContext
{
    using System.Data.Entity;
    using Fitness.Model;

    public class FitnessDB : DbContext
    {

        public FitnessDB() : base("name=FitnessDB")
        {

        }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Lanse> Lanse { get; set; }

        public virtual DbSet<LanseType> LanseType { get; set; }

        public virtual DbSet<Entry> Entry { get; set; }

    }
}
