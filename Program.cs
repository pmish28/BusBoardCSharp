using System.Text.RegularExpressions;
using Microsoft.Win32.SafeHandles;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        public static async Task Main()
        {
            string stopCode =  "490008660N";//GetUserInput(); //490008660N
            string postCode = "nw51tl" ;//GetUserInput(); //nw51tl    NaptanPublicBusCoachTram

            var arrivalsInformation = await TflClient.GetStopArrivals(stopCode);
            string formatString = "{0,-30} {1,-15}";
            Console.WriteLine(formatString, "Station Name", "Time to station (in minutes)");
            Console.WriteLine("====================================================");
            foreach (var information in arrivalsInformation.OrderBy(a => a.TimeToStation).Take(5))
            {                           
                Console.WriteLine(formatString, information.DestinationName, information.TimeToStation / 60 );               
            }
            var coordinates = await PostCodeClient.GetPostCodeCoordinates(postCode);
            Console.WriteLine(coordinates.Result.Latitude);
            Console.WriteLine(coordinates.Result.Longitude);
            Console.WriteLine(coordinates.Status);
            
        }

        private static string GetUserInput()
        {
            // string regExPostalCode = "([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})";

            while (true)
            {
                Console.WriteLine("Please provide a post code.");
                string? userInput = Console.ReadLine()?? "";
                return userInput;
            }
        }
    }
}