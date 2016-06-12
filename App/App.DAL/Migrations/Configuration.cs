namespace App.DAL.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<App.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            if(!context.Priorities.ToList().Any())
            {
                context.Priorities.Add(new Priority
                {
                    Name = "Low",
                    CreatedBy = 0,
                    Created = DateTime.Now,
                    UpdatedBy = 0,
                    Updated = DateTime.Now
                });

                context.Priorities.Add(new Priority
                {
                    Name = "Mid",
                    CreatedBy = 0,
                    Created = DateTime.Now,
                    UpdatedBy = 0,
                    Updated = DateTime.Now
                });

                context.Priorities.Add(new Priority
                {
                    Name = "High",
                    CreatedBy = 0,
                    Created = DateTime.Now,
                    UpdatedBy = 0,
                    Updated = DateTime.Now
                });

                context.Priorities.Add(new Priority
                {
                    Name = "Very High",
                    CreatedBy = 0,
                    Created = DateTime.Now,
                    UpdatedBy = 0,
                    Updated = DateTime.Now
                });
            }

            if (!context.Status.ToList().Any())
            {
                context.Status.Add(new Status
                {
                    Name = "Pending",
                    CreatedBy = 0,
                    Created = DateTime.Now,
                    UpdatedBy = 0,
                    Updated = DateTime.Now
                });

                context.Status.Add(new Status
                {
                    Name = "Accepted",
                    CreatedBy = 0,
                    Created = DateTime.Now,
                    UpdatedBy = 0,
                    Updated = DateTime.Now
                });

                context.Status.Add(new Status
                {
                    Name = "Canceled",
                    CreatedBy = 0,
                    Created = DateTime.Now,
                    UpdatedBy = 0,
                    Updated = DateTime.Now
                });

                context.SaveChanges();
            }
        }
    }
}
