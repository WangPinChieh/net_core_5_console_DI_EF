using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("tblSupportedItem")]
    public class SupportedItem : ICommon
    {
        public string Name { get; set; }
    }
}