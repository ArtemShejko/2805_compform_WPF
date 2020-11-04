using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_2805_compform
{
    public class Product
    {
        string _name;
        string _specification;
        string _description;
        double _price;

        public Product(string name, string specification, string description, double price)
        {
            _name = name;
            _specification = specification;
            _description = description;
            _price = price;
        }

        public Product()
        {
            _name = "name";
            _specification = "specification";
            _description = "description";
            _price = 0;
        }
        public string Name { get => _name; set => _name = value; }
        public string Specification { get => _specification; set => _specification = value; }
        public string Description { get => _description; set => _description = value; }
        public double Price { get => _price; set => _price = value; }
        public string AllChar => $"{_name}\n {Specification} \n {Description}";
                




    }
}
