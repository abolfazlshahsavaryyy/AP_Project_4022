using AP_Project_4022;//.RestaurantPage
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project_4022.classes
{
    public enum AdmissionType
    {
        delivery, dine_in
    }
    public class Restaurant
    {
        //username
        public string userName { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public AdmissionType? admissionType { get; set; }
        //name of two restaurant must not be same
        public string name { get; set; }
        //save every rating (food rating,reserve rating,order rating)
        public List<int> allrating { get; set; }
        public List<Food> foods { get; set; }
        public double averagePoint { get; set; }
        //number of table in restaurant
        public int numberTable {  get; set; }
        public string adress { get; set; }
        public static Restaurant currentRestaurant { get; set; }
        public static List<Restaurant> allRestaurant { get; set; }
        //################################################################################
        //pages
        //public AddFood add_food { get; set; }
        //public ChangeStock change_stock { get; set; }
        //public EditFood edit_food { get; set; }
        //public History history { get; set; }
        //public RemoveFood remove_food { get; set; }
        //public RestaurantPanel restaurant_panel { get; set; }

        //################################################################################
        static Restaurant()
        {
            allRestaurant=new List<Restaurant>();
            allRestaurant.Add(new Restaurant("Restaurant", "password", "Esfahan", AdmissionType.delivery, "Restaurant", 5, "address", 10));
            allRestaurant[0].foods = new List<Food>();
            allRestaurant[0].foods.Add(new Food("gheime", 20, 9, 5, new List<Comment>(), "",new List<string>()));
            allRestaurant[0].foods.Add(new Food("sabzi", 25, 8, 2, new List<Comment>(), "", new List<string>()));
            allRestaurant[0].foods.Add(new Food("khalal", 40, 10, 1, new List<Comment>(), "", new List<string>()));
            allRestaurant[0].foods.Add(new Food("felafe", 10, 5, 5, new List<Comment>(), "", new List<string>()));
            allRestaurant[0].foods.Add(new Food("food1", 18, 6, 12, new List<Comment>(), "", new List<string>()));
            allRestaurant[0].foods.Add(new Food("food2", 24, 4, 9, new List<Comment>(), "", new List<string>()));
            allRestaurant[0].foods[0].foodCategory = "category1";
            allRestaurant[0].foods[1].foodCategory = "category2";
            allRestaurant[0].foods[2].foodCategory = "category3";
            allRestaurant[0].foods[3].foodCategory = "category1";
            allRestaurant[0].foods[4].foodCategory = "category2";
            allRestaurant[0].foods[5].foodCategory = "category3";
            Restaurant.allRestaurant.Add(new Restaurant("username", "password", "Tehran", AdmissionType.delivery, "name", 5, "address", 10));
            Restaurant.allRestaurant.Add(new Restaurant("username1", "password1", "Kermanshah", AdmissionType.dine_in, "name1", 6, "address1", 10));
            Restaurant.allRestaurant.Add(new Restaurant("username2", "password2", "Esfahan", AdmissionType.delivery, "name2", 3, "address2", 10));
            Restaurant.allRestaurant.Add(new Restaurant("username3", "password3", "Tehran", AdmissionType.dine_in, "name3", 8, "address3", 10));
            Restaurant.allRestaurant.Add(new Restaurant("username4", "password4", "Tehran", null, "name4", 2, "address4", 10));

        }
        public Restaurant(string userName, string password, string city, AdmissionType? admissionType, string name, double averagePoint, string adress,int number_table)   
        {
            this.city = city;
            this.admissionType = admissionType;
            this.name = name;
            this.numberTable= number_table;
            this.userName = userName;
            this.password = password;   
            this.averagePoint = averagePoint;
            this.adress = adress;
            this.foods=new List<Food>();
        }
        public static void AddRestaurant(Restaurant restaurant)
        {
            allRestaurant.Add(restaurant);
        }
        public static Restaurant? GetRestaurant(string username)
        {
            return allRestaurant.Where(x=>x.userName == username).FirstOrDefault();
        }
        public static Restaurant? GetRestaurant(string name,bool t)
        {
            return allRestaurant.Where(x=>x.name == name).FirstOrDefault();
        }
        public static bool IsRestaurantExists(string username)
        {
            for(int i = 0; i < allRestaurant.Count; i++)
            {
                if (allRestaurant[i].userName == username)
                {
                    return true;
                }
            }
            return false;
        }
        public void ReserveTable(int number_table_reserve)
        {
            this.numberTable-=number_table_reserve;
        }
        public void ChangeAdmissionType(AdmissionType admissionType)
        {
            this.admissionType = admissionType;
        }
    }
}
