using NLTU_Labs.Models;
using System.Collections.Generic;

namespace NLTU_Labs.Data
{
    public static class Data
    {
        public static List<Bus> BusesPark { get; set; }
        public static List<Bus> BusesRoute { get; set; }
        public static List<string> Options { get; set; }

        static Data()
        {
            InitData();
        }

        private static void InitData()
        {
            var busesPark = new List<Bus>()
            {
                new Bus(1, 23145, "Ivan Kovalenko", 47),
                new Bus(2, 38245, "Vasil Rovskiy", 51),
            };

            var busesRoute = new List<Bus>()
            {
                new Bus(3, 12354, "Volodimir Cherenk", 17),
                new Bus(4, 98504, "Ivan Nevalnyu", 29),
            };
            var options = new List<string>()
            {
                "Decimal to binary",
                "Decimal to octal",
                "Decimal to hexadecimal",
                "Binary to decimal",
                "Octal to decimal",
                "Hexadecimal to decimal"
             };
            BusesPark = busesPark;
            BusesRoute = busesRoute;
            Options = options;
        }
    }
}