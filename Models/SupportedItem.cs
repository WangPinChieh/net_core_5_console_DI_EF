using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("tblSupportedItem")]
    public class SupportedItem : Feature
    {
        public string Name { get; set; }
    }
}