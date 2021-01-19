using BALKAN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BALKANConsoleApp
{
    public static class Users
    {

        public static void InviteAndCreateGuests()
        {
            var userService = new UserService();

            var optionsInvite = new OptionsInvite
            {
                Emails = "john.smith@balkan.app,ana.garson@balkan.app",
                Permissions = new Dictionary<string, bool> {
                    {"Read", true },
                    {"Write", true }
                },
                SendEmails = false
            };
            var resultInvite = userService.Invite(optionsInvite);
            if (!resultInvite.IsSuccess)
            {
                Console.WriteLine(resultInvite.Error);
            }
            else
            {
                foreach (var invitation in resultInvite.Invitations)
                {
                    Console.WriteLine($"Invited email: {invitation.Email}");
                    Console.WriteLine($"Invitation link: {invitation.Link}");
                    //Send the invitation link to the email using your email service
                }
            }

            var firstInvitation = resultInvite.Invitations.First();
            var optionsSignUp = new OptionsSignUp
            {
                InvitationKey = firstInvitation.Key,
                DisplayName = "Jack Hill",
                Email = firstInvitation.Email,
                Password = "ADSG45Ss_sf!#f",
                SendEmail = false
            };

            var resultCreate = userService.Create(optionsSignUp);

            if (!resultCreate.IsSuccess)
            {
                Console.WriteLine(resultInvite.Error);
            }
        }


        public static void UpdateGuest()
        {
            var userService = new UserService();

            var resultUpdateGuest = userService.UpdateGuest(new OptionsUpdateGuest
            {
                Email = "john.smith@balkan.app",
                Permissions = new Dictionary<string, bool> {
                    {"Read", true },
                    {"Write", true },
                    {"Invite", true }
                }
            });

            if (!resultUpdateGuest.IsSuccess)
            {
                Console.WriteLine(resultUpdateGuest.Error);
            }
        }

        public static void ListGuests()
        {
            var userService = new UserService();

            var resultListGuests = userService.ListGuests(new OptionsListGuests
            {
                Skip = 0,
                Take = 10
            });

            if (!resultListGuests.IsSuccess)
            {
                Console.WriteLine(resultListGuests.Error);
            }
            else
            {
                Console.WriteLine("------invited-------");
                foreach (var invited in resultListGuests.Invited)
                {
                    Console.WriteLine(invited);
                }

                Console.WriteLine("------accepted-------");
                foreach (var accepted in resultListGuests.Accepted)
                {
                    Console.WriteLine(accepted);
                }


                Console.WriteLine($"Accepted total count: {resultListGuests.AcceptedCount}");
                Console.WriteLine($"Invited total count: {resultListGuests.InvitedCount}");
            }
        }

        public static void RemoveGuest()
        {
            var userService = new UserService();

            var resultRemoveGuest = userService.RemoveGuest(new OptionsRemoveGuest
            {
                Email = "john.smith@balkan.app"
                
            });

            if (!resultRemoveGuest.IsSuccess)
            {
                Console.WriteLine(resultRemoveGuest.Error);
            }
        }


    }
}
