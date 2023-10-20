using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Tools
{
    public static class ToConverts
    {
      
        public static double ToDouble(this object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public static decimal ToDecimal(this object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public static decimal ToLong(this object value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch (Exception)
            {

                throw new Exception("Long Türüne Donuşturulemedi");
            }

        }

        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value);
        }

        public static bool ToBool(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {

                return false;
            }
       
        }

        public static int ToInt32(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public static string ToEvetHayır(this bool value)
        {
            if (value) return "Evet"; else return "Hayır";

        }
        public static bool SayiKont(this string value)
        {
            double oReturn = 0;
            return double.TryParse(value, out oReturn);
        }

        public static string TutaraCevir(this object value)
        {
            try
            {
                return Convert.ToDouble(value).ToString("n2");
            }
            catch (Exception)
            {

                return "0,00";
            }


        }
    }
}
