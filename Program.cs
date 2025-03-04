using System.Text.RegularExpressions;
using Microsoft.Win32.SafeHandles;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        public static async Task Main()
        {

            try
            {
                string postCode = GetUserInput(); //nw51tl   //490008660N  490008660S   
                PostCodeClient postCodeClient = new();
                var coordinates = await postCodeClient.GetPostCodeCoordinates(postCode);
                TflClient tflClient = new();
                var nearestStopPoints = await tflClient.GetStopPoints(coordinates.Result.Latitude, coordinates.Result.Longitude);
                if (nearestStopPoints?.StopPoints?.Count > 0)
                {
                    string formatString = "{0,-30} {1,-20} {2,-10}";
                    Console.WriteLine(formatString, "Station Name", "Time to station", "Stop Name");
                    Console.WriteLine("======================================================================");
                    foreach (var stop in nearestStopPoints.StopPoints.Take(2))
                    {
                        var arrivalsInformation = await tflClient.GetStopArrivals(stop.Id);
                        if (arrivalsInformation.Count > 0)
                        {
                            foreach (var information in arrivalsInformation.OrderBy(a => a.TimeToStation).Take(5))
                            {
                                Console.WriteLine(formatString, information.DestinationName, information.TimeToStation / 60, stop.CommonName);
                            }
                        }
                        else
                        {
                            Print("There are no busses coming at the 2 nearest stop points for this postcode.");
                        }
                    }
                }
                else
                {
                    Print("There are no stop points near this postcode.");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetUserInput()
        {
            string regExPostalCode = @"^([A-Z]{1,2}\d[A-Z\d]?\d[A-Z]{2})$";
            bool keepRunning = true;
            string userInput = "";
            while (keepRunning)
            {
                Print("Please provide a valid post code.");
                userInput = Console.ReadLine() ?? "";
                switch (true)
                {
                    case bool when Regex.IsMatch(userInput, regExPostalCode, RegexOptions.IgnoreCase):
                        keepRunning = false;
                        break;

                    case bool when userInput.Contains("exit", StringComparison.CurrentCultureIgnoreCase):
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid postcode");
                        break;
                }
            }
            return userInput;
        }

        private static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}