using System;
using System.ComponentModel.DataAnnotations;

namespace NLTU_Labs.Models
{
    public class Bus
    {
        public Bus()
        {
        }

        public Bus(int id, int busNumber, string driverName, int routeNumber)
        {
            Id = id;
            BusNumber = busNumber;
            DriverName = driverName;
            RouteNumber = routeNumber;
        } 

        public int Id { get; set; }

        [Display(Name = "Bus number")] 
        [Required(ErrorMessage = "Bus number field can't be null!")]
        [Range(0, 99999, ErrorMessage = "Bus number value can have maximum 5 digits")]
        public int BusNumber { get; set; }

        [MaxLength(100, ErrorMessage = "Driver name field cannot be longer than 100 characters.")]
        [Required(ErrorMessage = "Driver name cant be null!")]
        public string DriverName { get; set; }

        [Display(Name = "Route number")]
        [Required(ErrorMessage = "Bus number field can't be null!")]
        [Range(0, 9999, ErrorMessage = "Route number value can have 4 digits")]
        public int RouteNumber { get; set; }
    }
}