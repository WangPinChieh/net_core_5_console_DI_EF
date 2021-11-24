// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
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
            var entity = new Student
            {
                LastName = "Wang",
                FirstMidName = "Jay",
                Children = new List<StudentFirstChild>
                {
                    new()
                    {
                        Children = new List<StudentSecondChild>
                        {
                            new()
                        }
                    }
                }
            };
            schoolContext.Students.Add(entity);
            schoolContext.SaveChanges();
            Console.WriteLine($"StudentId: {entity.ID}");
            break;
        case '3':
            var student = await schoolContext.Students.FirstOrDefaultAsync(m => m.LastName == "Wang");
            schoolContext.Students.Remove(student);
            schoolContext.Students.Add(new Student
            {
                LastName = "Shao",
                FirstMidName = "Yvonne",
                Children = new List<StudentFirstChild>
                {
                    new()
                    {
                        Children = new List<StudentSecondChild>
                        {
                            new()
                        }
                    }
                }
            });
            // Console.Write("Name: ");
            // student.FirstMidName = Console.ReadLine();
            schoolContext.SaveChanges();
            break;
        case '4':

            var student1 = await schoolContext.Students.FirstOrDefaultAsync(m => m.LastName == "Wang");
            student1.Children.Add(new StudentFirstChild()
            );
            schoolContext.SaveChanges();
            break;
    }
}