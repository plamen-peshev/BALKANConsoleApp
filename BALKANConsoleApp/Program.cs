using System;
using BALKAN;

namespace BALKANConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Configuration.ApiAccessKey = "ak_06d16bd3-6ac3-4097-ae77-42395a6da98c";
            //REPLACE ak_06d16bd3-6ac3-4097-ae77-42395a6da98c2 with your Access API Key

            var chartService = new ChartService();
            var tokenService = new TokenService();
            var userService = new UserService();
            var imageService = new ImageService();

            chartService.Empty();
            //tokenService.Empty();
            userService.Empty();
            imageService.Empty();

            Charts.HelloOrgChart();
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
        }
    }
}