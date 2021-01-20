using System;
using BALKAN;

namespace BALKANConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Configuration.ApiAccessKey = "ak_8252286e-1af0-4f6c-a9a8-c572f7afbf74";
            //REPLACE ak_06d16bd3-6ac3-4097-ae77-42395a6da98c2 with your Access API Key

            HelloOrgChart();

            var chartService = new ChartService();
            var tokenService = new TokenService();
            var userService = new UserService();
            var imageService = new ImageService();

            chartService.Empty();
            //tokenService.Empty();
            userService.Empty();
            imageService.Empty();


            Charts.AddEmployees();
            Charts.AddNodes();
            Charts.UpdateNode();
            Charts.RemoveNode();
            Charts.GetNode();
            Charts.GetNodes();
            Charts.Search();
            Charts.CreateUpdateRemoveList();
            Charts.GenerateNodeIds();


            Users.InviteAndCreateGuests();
            Users.UpdateGuest();
            Users.ListGuests();
            Users.RemoveGuest();

            Image.Upload();

            Token.CreateAccess();
            Token.CreateSession();
        }

        public static void HelloOrgChart()
        {
            var chartService = new ChartService();
            var options = new OptionsCreateNewChart
            {
                ChartId = "HelloOrgChart",
                TemplateName = "Sofia"
            };

            var result = chartService.Create(options);

            if (result.IsSuccess)
            {
                Console.WriteLine("Hello OrgChart. Successfully created chart with id HelloOrgChart and template Sofia!");
            }
            else
            {
                Console.WriteLine(result.Error);
                Console.WriteLine("Failed! Verify ApiAccessKey!");
            }
        }
    }
}