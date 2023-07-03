using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using NearestVehiclePositionsAssessment;
using NearestVehiclePositionsAssessment.Models;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of all the cars.
            var cars = Finder.GetVehicles();
            FindNearestVehicles(cars);
        }

        public static void FindNearestVehicles(List<Car> cars)
        {
            // Get the 10 coordinates to find the nearest cars to.
            var coordinates = new[]
            {
                new { Latitude = 34.544909f, Longitude = -102.100843f },
                new { Latitude = 32.345544f, Longitude = -99.123124f },
                new { Latitude = 33.234235f, Longitude = -100.214124f },
                new { Latitude = 35.195739f, Longitude = -95.348899f },
                new { Latitude = 31.895839f, Longitude = -97.789573f },
                new { Latitude = 32.895839f, Longitude = -101.789573f },
                new { Latitude = 34.115839f, Longitude = -100.225732f },
                new { Latitude = 32.335839f, Longitude = -99.992232f },
                new { Latitude = 33.535339f, Longitude = -94.792232f },
                new { Latitude = 32.234235f, Longitude = -100.22222f }
            };

            // Find the nearest car to each coordinate.
            var nearestCars = new List<Car>();
            foreach (var coordinate in coordinates)
            {

                Car nearest = cars.OrderBy(c => c.DistanceTo(coordinate.Latitude, coordinate.Longitude)).First();
                nearestCars.Add(nearest);
                Console.WriteLine("The nearest car to {0}, {1} is [{2}] at {3}, {4}", coordinate.Latitude, coordinate.Longitude, nearest.VehicleRegistration, nearest.Latitude, nearest.Longitude);

            }
        }
    }

}
