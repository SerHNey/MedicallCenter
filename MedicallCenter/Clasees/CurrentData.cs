using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicallCenter.Clasees
{
    public class CurrentData
    {
        public static EntitiesMedical db;
        public static List<Result> results = new List<Result>();
        public static List<Service> services = new List<Service>();
        public static List<User> users = new List<User>();
        public static List<Worker> workers = new List<Worker>();
        public static List<Type> types = new List<Type>();
        public static Worker worker;
    }
}
