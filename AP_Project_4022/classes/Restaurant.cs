using AP_Project_4022.RestaurantPages;
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
        public int complaintNumber { get; set; }
        public bool reserve {  get; set; }
        public static Restaurant currentRestaurant { get; set; }
        public static List<Restaurant> allRestaurant { get; set; }
        //################################################################################
        //pages
        public AddFood add_food { get; set; }
        public ChangeStock change_stock { get; set; }
        public EditFood edit_food { get; set; }
        public History history { get; set; }
        public RemoveFood remove_food { get; set; }
        public RestaurantPanel restaurant_panel { get; set; }

        public RestaurantPages.Window1 remove_category {  get; set; }

        //################################################################################
        static Restaurant()
        {
            allRestaurant=new List<Restaurant>();
            allRestaurant.Add(new Restaurant("Restaurant", "password", "Esfahan", AdmissionType.delivery, "Restaurant", 5, "address", 10));

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
            this.complaintNumber = 0;
            this.foods = new List<Food>();
            this.reserve = false;
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
