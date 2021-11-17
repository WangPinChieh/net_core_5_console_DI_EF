// See https://aka.ms/new-console-template for more information

using System;
using ConsoleApp1.Data;
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
schoolContext.Database.EnsureCreated();
schoolContext.SaveChanges();

Console.WriteLine("Hello, World!");