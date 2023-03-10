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

        public static void StartTimer()
        {
            Thread thread = new Thread(TimerCallback);
            thread.Start();
        }


        static void TimerCallback()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Timer timer = new Timer((state) => {
                MessageBox.Show("Прошло времени: " + stopwatch.Elapsed.Minutes+" минут");
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(10));
            var time2r = new Timer(state => Environment.Exit(0), null, TimeSpan.FromMinutes(15), TimeSpan.FromMilliseconds(-1));
            while (true) { }
        }
    }
}
