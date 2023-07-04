using System;
using System.Collections.Generic;
using NearestVehiclePositionsAssessment;
using NearestVehiclePositionsAssessment.Models;

namespace FindNearestCar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of vehicles.
            List<Car> cars = Finder.GetVehicles();

            // List of coordinates.
            var coordinates = new List<Coordinate>();

            coordinates.Add(new Coordinate { Latitude = 34.544909f, Longitude = -102.100843f });
            coordinates.Add(new Coordinate { Latitude = 32.345544f, Longitude = -99.123124f });
            coordinates.Add(new Coordinate { Latitude = 33.234235f, Longitude = -100.214124f });
            coordinates.Add(new Coordinate { Latitude = 35.195739f, Longitude = -95.348899f });
            coordinates.Add(new Coordinate { Latitude = 31.895839f, Longitude = -97.789573f });
            coordinates.Add(new Coordinate { Latitude = 32.895839f, Longitude = -101.789573f });
            coordinates.Add(new Coordinate { Latitude = 34.115839f, Longitude = -100.225732f });
            coordinates.Add(new Coordinate { Latitude = 32.335839f, Longitude = -99.992232f });
            coordinates.Add(new Coordinate { Latitude = 33.535339f, Longitude = -94.792232f });
            coordinates.Add(new Coordinate { Latitude = 32.234235f, Longitude = -100.22222f });


            // Find the nearest car to each coordinate using a binary search algorithm.
            Dictionary < Coordinate, Car > nearestCars = new Dictionary<Coordinate, Car>();
            for (int i = 0; i < coordinates.Count; i++)
            {
                Car nearestCar = null;
                double nearestCarDistance = double.MaxValue;
                int low = 0;
                int high = cars.Count - 1;
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    double distance = Math.Sqrt(Math.Pow(coordinates[i].Latitude - cars[mid].Coordinate.Latitude, 2) + Math.Pow(coordinates[i].Longitude - cars[mid].Coordinate.Longitude, 2));
                    if (distance < nearestCarDistance)
                    {
                        nearestCar = cars[mid];
                        nearestCarDistance = distance;
                    }

                    if (coordinates[i].Latitude < cars[mid].Coordinate.Latitude)
                    {
                        high = mid - 1;
                    }
                    else if (coordinates[i].Latitude > cars[mid].Coordinate.Latitude)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        if (coordinates[i].Longitude < cars[mid].Coordinate.Longitude)
                        {
                            high = mid - 1;
                        }
                        else
                        {
                            low = mid + 1;
                        }
                    }
                }

                nearestCars[coordinates[i]] = nearestCar;
            }


            // Print the nearest car for each coordinate.
            foreach (var coordinate in coordinates)
            {
                var nearest = nearestCars[coordinate];
                Console.WriteLine("The nearest car to {0}, {1} is [{2}] at {3}, {4}", coordinate.Latitude, coordinate.Longitude, nearest.VehicleRegistration, nearest.Coordinate.Latitude, nearest.Coordinate.Longitude);
            }
        }
    }
}