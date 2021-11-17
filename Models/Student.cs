using System;

namespace ConsoleApp1.Models
{
    public class Student
    {
        public Guid ID { get; set; } 
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}