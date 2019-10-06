using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistrationWebAPI.Models;

namespace UserRegistrationWebAPI
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UserDBContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Name = "User 1",
                        Email = "user1@mail.com",
                        Gender = "Female",
                        RegisteredDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        EventDate = "Day 1",
                        AdditionalRequest = "Test1"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "User 2",
                        Email = "user2@mail.com",
                        Gender = "Male",
                        RegisteredDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        EventDate = "Day 1,Day 2",
                        AdditionalRequest = "Test1"
                    },

                      new User
                      {
                          Id = 3,
                          Name = "User 3",
                          Email = "user3@mail.com",
                          Gender = "Male",
                          RegisteredDate = DateTime.Now.ToString("dd/MM/yyyy"),
                          EventDate = "Day 3",
                          AdditionalRequest = "Test1"
                      }

                );
                context.SaveChanges();
            }
        }
    }
}
