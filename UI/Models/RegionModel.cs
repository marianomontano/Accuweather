using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace UI.Models
{
    [DebuggerDisplay("{value}", Name = "{EnglishName}")]
    public class RegionModel
    {
        public string ID { get; set; }
        public string EnglishName { get; set; }
    }
}
