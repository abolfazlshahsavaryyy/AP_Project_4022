using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Class_Enum
{
    public class Restaurant
    {
        public string userName {  get; set; }
        public string password { get; set; }
        public string city {  get; set; }
        public AdmissionType admissionType { get; set; }
        public string name {  get; set; }
        public double averagePoint {  get; set; }
        public string adress {  get; set; }
        public Restaurant(string userName, string password, string city, AdmissionType admissionType, string name, double averagePoint, string adress)
        {
            this.userName = userName;
            this.password = password;
            this.city = city;
            this.admissionType = admissionType;
            this.name = name;
            this.averagePoint = averagePoint;
            this.adress = adress;
        }
    }
}
