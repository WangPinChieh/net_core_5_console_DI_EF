using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("tblTemplateItem")]
    public class TemplateItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<FeatureMapping> FeatureMappings  { get; set; }
    }
}