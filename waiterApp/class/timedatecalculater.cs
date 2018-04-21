using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waiterApp
{

    public class timedatecalculater
{
        
        //tarih verisini db ye yyyy-mm-dd formatında göndermek için kullanılacak
        //public string dateformatter(string date)
        //{

        //}
        // şimdiki zamanı tarih ve saat olarak db ye uygun formata getirecek
        public string[] datetimeNowformatterforDate()
        {
            string year = DateTime.Now.Year.ToString();
            string mon = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string date1 = year + "-" + mon + "-" + day;
            string date2 = year + "-" + mon + "-" + (DateTime.Now.Day + 1).ToString();
            string[] arr = new string[2];
            arr[0] = date1;
            arr[1] = date2;

            return arr;  
        }
        //anlık zamanın sade saat kısmını alacak
        public int datetimeNowformatterforTime()
        {
            int time = DateTime.Now.Hour;
            if (DateTime.Now.Minute < 30)
            {
                return time;
            }
            else return time++;
        }
}
}