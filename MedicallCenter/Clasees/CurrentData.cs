using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
        public static List<HistoryHot> historyHots = new List<HistoryHot>();
        public static Worker worker;
    }
}
