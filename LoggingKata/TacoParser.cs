using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {

            string[] cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogInfo("Less than 3");
                return null;
              
            }

            double Long;
            double Lat;


            if (Double.TryParse(cells[0], out Lat) && Double.TryParse(cells[1], out Long)) 
                {

                Taco taco = new Taco();
                taco.Name = cells[2];

                taco.Location = new Point { Latitude = Lat, Longitude = Long };

                return taco;

                }
            else
            {
                Console.WriteLine(cells[2]);
                logger.LogInfo("Failed to Parse");
                return null;
            }


//




            // using the method 

            // Do not fail if one record parsing fails, return null
            //return null; // TODO Implement



            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            //var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
           //if (cells.Length < 3)
           //{
            //    logger.LogInfo("Less than 3");
            //    return null;
            //    // Log that and return null
           // }

            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

           
            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
        }
    }
}