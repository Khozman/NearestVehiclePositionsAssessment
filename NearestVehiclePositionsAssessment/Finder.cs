using System;
using System.Reflection.PortableExecutable;
using System.Text;
using NearestVehiclePositionsAssessment.Models;

namespace NearestVehiclePositionsAssessment
{
	public class Finder
	{

        internal static List<Car> GetVehicles()
        {
            byte[] array = ReadVehiclePositionsFileData();
            List<Car> list = new List<Car>();
            int offset = 0;
            while (offset < array.Length)
            {
                var car = Car.FromBytes(array, ref offset);
                list.Add(car);
            }
            list = list.OrderBy(c => c.Coordinate.Latitude).ThenBy(c => c.Coordinate.Longitude).ToList();
            return list;
        }

        internal static byte[] ReadVehiclePositionsFileData()
        {
            string filePath = "VehiclePositions.dat";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Data file not found.");
                return null;
            }
            return File.ReadAllBytes(filePath);
        }
    }
}

