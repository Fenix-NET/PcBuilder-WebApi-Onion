using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shared.RequestFeatures
{
    public class CatalogParameters : RequestParameters
    {
        public CatalogParameters()
        {
            //Sort = "Id";
        }
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = int.MaxValue;
        //public int CategoryId { get; set; }
        public List<string>? Manufacturer { get; set; }
        public List<string>? Model { get; set; }
        public List<string>? GpuProc { get; set; }
        public List<string>? PowerUsage { get; set; }
        public List<string>? VideoMemorySize { get; set; }
        public List<string>? VideoMemoryType { get; set; }
        public List<string>? SearchTerm { get; set; }
        public List<string>? CoreCount { get; set; }
        public List<string>? Frequency { get; set; }
        public List<string>? Socket { get; set; }

        public bool ValidPriceRange => MinPrice <= MaxPrice;
    }
}
