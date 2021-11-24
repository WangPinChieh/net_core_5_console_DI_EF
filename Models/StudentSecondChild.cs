using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public class StudentSecondChild
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(StudentFirstChild))]
        public Guid StudentFirstChildId { get; set; }
    }
}