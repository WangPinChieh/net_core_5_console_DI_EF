using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public abstract class ICommon
    {
        public Guid Id { get; set; }
        public List<FeatureMapping> FeatureMappings { get; set; }
    }
}