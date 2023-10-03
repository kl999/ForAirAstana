using ForAirAstana.Database;
using ForAirAstana.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

var optionsBuilder = new DbContextOptionsBuilder<AirAstanaDbContext>();
optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=SSPI;Database=AirAstanaDB");

using var ctxt = new AirAstanaDbContext(optionsBuilder.Options);

ctxt.Database.EnsureDeleted();
ctxt.Database.EnsureCreated();

var moderatorRole = ctxt.Roles.FirstOrDefault(i => i.Code == "Moderator");
var userRole = ctxt.Roles.FirstOrDefault(i => i.Code == "User");

ctxt.Users.Add(new User { Username = "user", Password = ComputeSHA256("123"), Role = userRole! });
ctxt.Users.Add(new User { Username = "moderator", Password = ComputeSHA256("456"), Role = moderatorRole! });

ctxt.SaveChanges();

Console.WriteLine("End");

static string ComputeSHA256(string s)
{
    string hash = String.Empty;

    // Инициализировать хеш-объект SHA256
    using (SHA256 sha256 = SHA256.Create())
    {
        // Вычислить хэш заданной строки
        byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

        // Преобразование массива байтов в строковый формат
        foreach (byte b in hashValue)
        {
            hash += $"{b:X2}";
        }
    }

    return hash;
}
