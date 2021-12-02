using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("tblPlatform")]
    public class Platform : Feature
    {
        public string Name { get; set; }
    }
}