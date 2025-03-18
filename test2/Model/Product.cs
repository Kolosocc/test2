using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Category} - ${Price} - {(InStock ? "В наличии" : "Нет в наличии")}";
        }
    }
}
