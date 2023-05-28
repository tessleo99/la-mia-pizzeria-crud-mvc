using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeriaNew.Models
{
    public class GustiPizza
    {
        [Key] public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [MaxLength(300)]
        public string Image { get; set; }

        public float Price { get; set; }

        public int? GustiPizzaCategoryId { get; set; }
        public PizzaCategory? Category { get; set; }

        public GustiPizza() { }


        public GustiPizza(string name, string description, string image, float price) 
        { 
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
