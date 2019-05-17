using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
            ITrackable firstlocation = null;
            ITrackable secondlocation = null;
            double distance = 0;

            var locations = lines.Select(parser.Parse).ToArray();

            for (int i = 0; i < locations.Length; i++)
            {
                double findFurthestdistance = 0;
                ITrackable locA = locations[i];
                GeoCoordinate locAPosition = new GeoCoordinate();
                locAPosition.Latitude = locA.Location.Latitude;
                locAPosition.Longitude = locA.Location.Longitude;
                for (int e = 0; e < locations.Length; e++)
                {
                    ITrackable locB = locations[e];
                    GeoCoordinate locBPosition = new GeoCoordinate();
                    locBPosition.Latitude = locB.Location.Latitude;
                    locBPosition.Longitude = locB.Location.Longitude;
                    findFurthestdistance = locAPosition.GetDistanceTo(locBPosition);
                    if (findFurthestdistance >= distance)
                    {
                        distance = findFurthestdistance;
                        firstlocation = locA;
                        secondlocation = locB; 
                    }
                }
            }
            Console.WriteLine(firstlocation.Name);
            Console.WriteLine(secondlocation.Name);
            Console.WriteLine(distance);
            {

            }
        }

    }
}