using ForAirAstana.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var optionsBuilder = new DbContextOptionsBuilder<AirAstanaDbContext>();
optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=SSPI;Database=AirAstanaDB");

using var ctxt = new AirAstanaDbContext(optionsBuilder.Options);

ctxt.Database.EnsureDeleted();
ctxt.Database.EnsureCreated();

Console.WriteLine("End");
