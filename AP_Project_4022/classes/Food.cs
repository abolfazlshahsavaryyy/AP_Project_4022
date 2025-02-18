﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;

namespace AP_Project_4022.classes
{
    public class Food
    {
        public int Id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double aveagePoint { get; set; }
        public List<int> allrating { get; set; }
        public int numberFood { get; set; } //number of foods that are exists
        public List<Comment> foodComments { get; set; }
        public string foodCategory {  get; set; }//mainfood or deser or drink etc...
        public string picturePath { get; set; }//not important
        public List<string> foodRawMaterials { get; set; }
        public static List<Food> allFood { get; set; }
        static Food()
        {
            allFood = new List<Food>();
           
        }
        public Food()
        {

        }
        //add caregory and complaint class and category enum
        public Food(int id,string name, double price, double aveagePoint, int numberFood, List<Comment> commentFood, string picturePath, List<string> foodRawMaterials)
        {
            this.Id = Id;
            this.name = name;
            this.price = price;
            this.aveagePoint = aveagePoint;
            this.numberFood = numberFood;
            this.foodComments = commentFood;
            this.picturePath = picturePath;
            this.foodRawMaterials = foodRawMaterials;
        }
        public void AddFood(string name,int number,int price, List<string> foodRawMaterials)//foodRawMaterials is not important
        {
            for(int i=0;i<allFood.Count;i++) 
            {
                if (allFood[i].name == name)
                {
                    allFood[i].numberFood += number;
                    return;
                }
            }
            
        }
        public static Food? GetFood(string name)
        {
            return allFood.Where(x=>x.name == name).FirstOrDefault();
        }
        public static bool IsFoodExists(string name)
        {
            for(int i=0;i<allFood.Count;i++)
            {
                if (allFood[i].name == name) {
                    return true;
                }
            }
            return false;
        }
        public bool RemoveFood(string name)
        {
            for(int i = 0; i < allFood.Count; i++)
            {
                if (allFood[i].name == name)
                {
                    allFood.Remove(allFood[i]);
                    return true;
                }
            }
            return false;
            
        }
        
    }
}
