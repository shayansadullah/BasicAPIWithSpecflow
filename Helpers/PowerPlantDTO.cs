using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Highlight.API.Tests.Helpers
{
        public class CityDTO
        {
            public string value { get; set; }
        }

        public class LocationDTO
        {
            public CityDTO city { get; set; }
            public int zip { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class item
        {
            public string name { get; set; }
            public LocationDTO location { get; set; }
        }

        public class PowerPlantsDTO : List<item> { }
}
