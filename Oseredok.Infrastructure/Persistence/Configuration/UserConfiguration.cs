using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.Parse("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                    FirstName = "Nazar",
                    LastName = "Sachuk",
                    MiddleName = "Igorovych",
                    Email = "nazar.sachuk@gmail.com",
                    RegDate = DateTime.Now,
                    RoleId = 3,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                },
                new User //default coach
                {
                    Id = Guid.Parse("d4e69655-950b-4d87-b555-9ce087f3c79f"),
                    FirstName = "Default",
                    LastName = "Coach",
                    MiddleName = "lorem",
                    Email = "default.coach@gmail.com",
                    RegDate = DateTime.Now,
                    RoleId = 2,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                },
                new User
                {
                    Id = Guid.Parse("d4e65555-950b-4d87-b568-9ce087f34698"),
                    FirstName = "Nazar2",
                    LastName = "Sachuk2",
                    MiddleName = "Igorovych2",
                    Email = "nazar.sachuk@gmail2.com",
                    RegDate = DateTime.Now,
                    RoleId = 3,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                },
                new User
                {
                    Id = Guid.Parse("d4e96455-950b-4d87-b568-9ce087f34698"),
                    FirstName = "Nazar3",
                    LastName = "Sachuk3",
                    MiddleName = "Igorovych3",
                    Email = "nazar.sachuk@gmail3.com",
                    RegDate = DateTime.Now,
                    RoleId = 3,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                },
                new User
                {
                    Id = Guid.Parse("d4119255-950b-4d87-b568-9ce087f34698"),
                    FirstName = "Max",
                    LastName = "Smirnov",
                    MiddleName = "lorem",
                    Email = "max.smirnov@gmail.com",
                    RegDate = DateTime.Now,
                    RoleId = 2,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                },
                new User
                {
                    Id = Guid.Parse("d4119255-950b-4d87-f432-9ce087f34698"),
                    FirstName = "Masha",
                    LastName = "lorem",
                    MiddleName = "lorem",
                    Email = "masha.lorem@gmail.com",
                    RegDate = DateTime.Now,
                    RoleId = 1,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                },
                new User
                {
                    Id = Guid.Parse("d4119255-950b-4d87-f432-9ce087f39925"),
                    FirstName = "Pasha",
                    LastName = "Mamchur",
                    MiddleName = "Olexandrovych",
                    Email = "pasha.mamchur@gmail.com",
                    RegDate = DateTime.Now,
                    RoleId = 2,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                }
                );
        }
    }
}