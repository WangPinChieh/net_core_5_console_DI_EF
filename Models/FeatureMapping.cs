using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("tblFeatureMapping")]
    public class FeatureMapping
    {
        public Guid FeatureId { get; set; }
        public Feature FeatureItem { get; set; }
        public Guid TemplateItemId { get; set; }
        public TemplateItem TemplateItem { get; set; }
    }
}