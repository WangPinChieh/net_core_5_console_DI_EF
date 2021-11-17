using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; } = Guid.NewGuid();
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}