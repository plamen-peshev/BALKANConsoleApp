using BALKAN;
using System;
using System.Collections.Generic;
using System.Text;

namespace BALKANConsoleApp
{
    public static class Token
    {
        public static void CreateAccess()
        {
            Charts.CreateTestChart("CreateAccessChart");

            var tokenService = new TokenService();

            var resultCreateAccess = tokenService.CreateAccess(new OptionsCreateAccess
            {
                ExpireAfterMunutes = 10,
                ResourceId = "CreateAccessChart",
                Permissions = new Dictionary<string, bool>
                {
                    {  "SharedReadAccess", true }
                }
            });

            if (!resultCreateAccess.IsSuccess)
            {
                Console.WriteLine(resultCreateAccess.Error);
            }
            else
            {
                //Now you can share a link to "CreateAccessChart" chart
                Console.WriteLine($"https://orgchart.balkan.app/org/MyChartName?ak={resultCreateAccess.Key}");                
            }
        }

        public static void CreateSession()
        {
            Charts.CreateTestChart("CreateSessionChart");

            var tokenService = new TokenService();

            var resultCreateSession = tokenService.CreateSession(new OptionsCreateSession
            {                
                ResourceId = "CreateSessionChart",
                Permissions = new Dictionary<string, bool>
                {
                    {  "Read", true },
                    {  "Write", true },
                }
            });

            if (!resultCreateSession.IsSuccess)
            {
                Console.WriteLine(resultCreateSession.Error);
            }
            else
            {
                Console.WriteLine($"Session key: {resultCreateSession.Key}");
            }
        }
    }
}
