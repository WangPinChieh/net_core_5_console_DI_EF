using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public class StudentFirstChild
    {
        public Guid Id { get; set; }
        
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public List<StudentSecondChild> Children { get; set; } = new List<StudentSecondChild>();
    }
}