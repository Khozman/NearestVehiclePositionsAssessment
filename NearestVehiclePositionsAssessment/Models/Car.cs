using System;
using System.Text;

namespace NearestVehiclePositionsAssessment.Models
{
	public class Car
	{
        public int VehicleId { get; set; }
        public string VehicleRegistration { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public UInt64 RecordedTimeUtc { get; set; }

        public Car(int vehicleId, string vehicleRegistration, float latitude, float longitude, UInt64 recordedTimeUtc)
        {
            VehicleId = vehicleId;
            VehicleRegistration = vehicleRegistration;
            Latitude = latitude;
            Longitude = longitude;
            RecordedTimeUtc = recordedTimeUtc;
        }

        public float DistanceTo(float latitude, float longitude)
        {

            var distance = Math.Sqrt(Math.Pow(Latitude - latitude, 2) + Math.Pow(Longitude - longitude, 2));
            return (float)distance;
        }

        internal static Car FromBytes(byte[] buffer, ref int offset)
        {
            int vehicleId = BitConverter.ToInt32(buffer, offset);
            offset += sizeof(int);
            StringBuilder stringBuilder = new StringBuilder();
            while (buffer[offset] != 0)
            {
                stringBuilder.Append((char)buffer[offset]);
                offset += 1;
            }
            string vehicleRegistration = stringBuilder.ToString();
            offset += 1;
            float latitude = BitConverter.ToSingle(buffer, offset);
            offset += sizeof(float);
            float longitude = BitConverter.ToSingle(buffer, offset);
            offset += sizeof(float);
            ulong recordedTimeUtc = BitConverter.ToUInt64(buffer, offset);
            offset += sizeof(UInt64);

            Car car = new Car(vehicleId, vehicleRegistration, latitude, longitude, recordedTimeUtc);

            return car;
        }
    }
}

