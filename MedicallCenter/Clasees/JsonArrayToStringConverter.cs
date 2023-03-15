using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MedicallCenter.Clasees
{
    internal class JsonArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            JArray jsonArray = JArray.Parse(value.ToString());
            string str = "";
            List<Service> cur_services = new List<Service>();
            int i = 0;
            foreach (JObject jobj in jsonArray)
            {
                str+= CurrentData.services.FirstOrDefault(n => n.kod_service == (int)jobj["code"]).service1;
                if(i+1<jsonArray.Count)
                    str += ", ";
                i++;
            }
            return str;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
