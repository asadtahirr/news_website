﻿using Microsoft.AspNetCore.Identity;

namespace mitt_news
{
    public class SeedData
    {
        private static UserManager<IdentityUser> UserManager { get; set; }
        private static RoleManager<IdentityRole> RoleManager { get; set; }

        public static async Task InsertNewData(IServiceProvider? serviceProvider)
        {
            UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string roleName1 = "Administrator";

            IdentityRole role1 = await RoleManager.FindByNameAsync(roleName1);

            if (role1 == null)
            {
                role1 = new IdentityRole(roleName1);

                IdentityResult createRole1 = await RoleManager.CreateAsync(role1);

                if (createRole1.Succeeded)
                {
                    Console.WriteLine("Created role Administrator.");
                }
                else
                {
                    Console.WriteLine("Could not create role Administrator.");
                }
            }

            string roleName2 = "Editor";

            IdentityRole role2 = await RoleManager.FindByNameAsync(roleName2);

            if (role2 == null)
            {
                role2 = new IdentityRole(roleName2);

                IdentityResult createRole2 = await RoleManager.CreateAsync(role2);

                if (createRole2.Succeeded)
                {
                    Console.WriteLine("Editor Role has been Created.");
                }
                else
                {
                    Console.WriteLine("Fatal!! Failed to create a Role for Editor.");
                }
            }

            string roleName3 = "MarketingManager";

            IdentityRole role3 = await RoleManager.FindByNameAsync(roleName3);

            if (role3 == null)
            {
                role3 = new IdentityRole(roleName3);

                IdentityResult createRole3 = await RoleManager.CreateAsync(role3);

                if (createRole3.Succeeded)
                {
                    Console.WriteLine("MarketingManager Role has been Created.");
                }
                else
                {
                    Console.WriteLine("Fatal!! Failed to create a Role for MarketingManager.");
                }
            }

            string userName1 = "johnsnow@got.com";

            IdentityUser user1 = await UserManager.FindByNameAsync(userName1);

            if (user1 == null)
            {
                user1 = new IdentityUser()
                {
                    UserName = userName1,
                    Email = userName1,
                    EmailConfirmed = true
                };

                IdentityResult saveUser1 = await UserManager.CreateAsync(user1, "Pass123$");

                if (saveUser1.Succeeded)
                {
                    Console.WriteLine($"User {userName1} saved to database.");

                    bool isUser1Administrator = await UserManager.IsInRoleAsync(user1, roleName1);

                    if (!isUser1Administrator)
                    {
                        IdentityResult assignUser1AsAdministrator = await UserManager.AddToRoleAsync(user1, roleName1);

                        if (assignUser1AsAdministrator.Succeeded)
                        {
                            Console.WriteLine($"{userName1} is assigned to role {roleName1}");
                        }
                        else
                        {
                            Console.WriteLine($"Could not assign {userName1} to role {roleName1}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Could not save user {userName1}");
                }
            }

            string userName2 = "peterbaelish@got.com";

            IdentityUser user2 = await UserManager.FindByNameAsync(userName2);

            if (user2 == null)
            {
                user2 = new IdentityUser(userName2)
                {
                    UserName = userName2,
                    Email = userName2,
                    EmailConfirmed = true
                };

                IdentityResult saveUser2 = await UserManager.CreateAsync(user2, "Pass321$");

                if (saveUser2.Succeeded)
                {
                    Console.WriteLine($"User {userName2} saved to database.");

                    bool isUser2Administrator = await UserManager.IsInRoleAsync(user2, roleName2);

                    if (!isUser2Administrator)
                    {
                        IdentityResult assignUser2AsAdministrator = await UserManager.AddToRoleAsync(user2, roleName2);

                        if (assignUser2AsAdministrator.Succeeded)
                        {
                            Console.WriteLine($"{userName2} is assigned to role {roleName2}");
                        }
                        else
                        {
                            Console.WriteLine($"Could not assign {userName2} to role {roleName2}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Could not save user {userName2}.");
                }
            }

            string userName3 = "tyrionlannister@got.com";

            IdentityUser user3 = await UserManager.FindByNameAsync(userName3);

            if (user3 == null)
            {
                user3 = new IdentityUser(userName3)
                {
                    UserName = userName3,
                    Email = userName3,
                    EmailConfirmed = true
                };

                IdentityResult saveUser3 = await UserManager.CreateAsync(user3, "Pass456$");

                if (saveUser3.Succeeded)
                {
                    Console.WriteLine($" User {userName3} saved the Database.");

                    bool isUser3MarketingManager = await UserManager.IsInRoleAsync(user3, roleName3);

                    if (!isUser3MarketingManager)
                    {
                        IdentityResult assignUser3AsMarketingManager = await UserManager.AddToRoleAsync(user3, roleName3);

                        if (assignUser3AsMarketingManager.Succeeded)
                        {
                            Console.WriteLine($"{userName3} is assigned to role {roleName3}");
                        }
                        else
                        {
                            Console.WriteLine($"Could not assign {userName3} to role {roleName3}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Could not save user {userName3}.");
                }
            }
        }
    }
}
    

