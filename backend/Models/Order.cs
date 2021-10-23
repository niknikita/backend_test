using System;

namespace backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int BrandCarId { get; set; }
        public int ModelCarId { get; set;}
        public string GovernmentNumbers { get; set; }
        public DateTime TimeOrder { get; set; }
    }
}
