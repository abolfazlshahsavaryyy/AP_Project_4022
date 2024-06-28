using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Class_Enum
{
    public class Food
    {
        public string name {  get; set; }
        public double price {  get; set; }
        public double aveagePoint {  get; set; }
        public int numberFood {  get; set; }
        public Comment commentFood { get; set; }
        public string picturePath {  get; set; }
        public List<string> foodRawMaterials { get; set; }
        //add caregory and complaint class and category enum
        public Food(string name, double price, double aveagePoint, int numberFood, Comment commentFood, string picturePath, List<string> foodRawMaterials)
        {
            this.name = name;
            this.price = price;
            this.aveagePoint = aveagePoint;
            this.numberFood = numberFood;
            this.commentFood = commentFood;
            this.picturePath = picturePath;
            this.foodRawMaterials = foodRawMaterials;
        }
    }
}
