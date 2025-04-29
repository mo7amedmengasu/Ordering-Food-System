using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Project.models
{
    public class MenuItem1
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public bool Availability { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int RestaurantID { get; set; }
    }
}
