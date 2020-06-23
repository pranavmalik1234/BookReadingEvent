using DataAccessLayer.Domains;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccessLayer.Database
{
    public class BufferOverflowContext : DbContext
    {
        //Constructor to give name to DataBase
        public BufferOverflowContext() : base("BufferOverflowContextData")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<LikeDislike> LikeDislikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
