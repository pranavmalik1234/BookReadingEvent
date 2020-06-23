namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.Domains;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Database.BufferOverflowContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.Database.BufferOverflowContext context)
        {
            //  This method will be called after migrating to the latest version.

            
        }
    }
}
