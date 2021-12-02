// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1;
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
        case '5':
            var myTasks = new MyTasks();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var task1 = myTasks.Calculate(3000);
            var task2 = myTasks.Calculate(2000);
            var result1 = await task1;
            var result2 = await task2;
            stopwatch.Stop();
            Console.WriteLine(result1 + " ; " + result2 + " ; " + stopwatch.ElapsedMilliseconds);
            break;
        case '6':
            var myTasksa = new MyTasks();
            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            var taskA = myTasksa.Calculate(3000);
            var taskB = myTasksa.Calculate(2000);
            var results = await Task.WhenAll(taskA, taskB);
            stopwatch2.Stop();
            Console.WriteLine(results[0] + " ; " + results[1] + " ; " + stopwatch2.ElapsedMilliseconds);
            break;
        case '7':
            var supportedItem = new SupportedItem
            {
                Name = "HDD",
            };
            var templateItem = new TemplateItem
            {
                Name = "EM27"
            };
            var platform = new Platform
            {
                Name = "NB"
            };


            schoolContext.Platforms.Add(platform);
            schoolContext.SupportedItems.Add(supportedItem);
            schoolContext.TemplateItems.Add(templateItem);
            schoolContext.FeatureMappings.Add(new FeatureMapping
            {
                FeatureItem = supportedItem,
                TemplateItem = templateItem,
            });
            schoolContext.FeatureMappings.Add(new FeatureMapping
            {
                FeatureItem = platform,
                TemplateItem = templateItem,
            });
            schoolContext.SaveChanges();


            break;
    }
}