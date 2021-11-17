// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var host = Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
{
    services.AddDbContext<SchoolContext>(options =>
        options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
}).Build();

var schoolContext = host.Services.GetService<SchoolContext>();
while (true)
{
    Console.Write("Control Key: ");
    var key = Console.ReadKey();
    Console.WriteLine("");
    switch (key.KeyChar)
    {
        case '1':
            schoolContext.Database.EnsureDeleted();
            schoolContext.Database.EnsureCreated();
            schoolContext.SaveChanges();
            break;
        case '2':
            schoolContext.Students.Add(new Student
            {
                LastName = "Wang",
                FirstMidName = "Jay"
            });
            schoolContext.SaveChanges();
            break;
        case '3':
            var student = schoolContext.Students.FirstOrDefault(m => m.LastName == "Wang");
            Console.Write("Name: ");
            student.FirstMidName = Console.ReadLine();
            schoolContext.SaveChanges();
            break;
    }
}
