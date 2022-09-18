using Microsoft.AspNetCore.Identity;

namespace EMovies.Models
{
    public class MovieDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MovieDbContext>();

                context.Database.EnsureCreated();

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            ActorName = "Ken Adams",
                            Biography = "Masterful Actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            ActorName = "JK Simmons",
                            Biography = "A Savage when it comes to cult classic roles",
                             ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"

                        },
                        new Actor()
                        {
                        ActorName = "Keith Lee",
                        Biography = "Great Performer.. Fanatastic actor of many awards",
                        ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"


                        },
                        new Actor()
                        {
                        ActorName = "Stan Lee",
                        Biography = "Actor Mainly seen in powerful cameo roles",
                        ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"

                        },
                        new Actor()
                        {
                        ActorName = "Edward Norton",
                        Biography = "Acted in the incredible hulk",
                        ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"

                        }
                    });
                    context.SaveChanges();
                }
                //Directors
                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director()
                        {
                            DirectorName = "Steven Spielberg",
                            Biography = "He has an extraordinary number of commercially successful and critically acclaimed credits to his name",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Director()
                        {
                            DirectorName = "Joe Russo",
                            Biography = "He is one among the actors who directed the world's higgest grossing film",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"

                        },
                        new Director()
                        {
                            DirectorName = "Jon Watts",
                            Biography = "Director of marvel spiderman triology",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Director()
                        {
                            DirectorName = "Sam Raimi",
                            Biography = "Director of old spiderman triology",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Director()
                        {
                            DirectorName = "Matt Reeves",
                            Biography = "Director of Batman.. Critically acclaimed film",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            CategoryName="Action"
                        },
                        new Category()
                        {
                            CategoryName="Drama"
                        },new Category()
                        {
                            CategoryName="Adventure"
                        },new Category()
                        {
                            CategoryName="ScienceFiction"
                        },new Category()
                        {
                            CategoryName="Comedy"
                        },
                    });
                    context.SaveChanges();

                }


                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            MovieName = "Life",
                            MovieDescription = "This is a action movie filled with suspense",
                            MoviePrice = 39.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(10),
                            DirectorId = 1,
                            CategoryId = 1,
                        },
                        new Movie()
                        {
                            MovieName = "The Shawshank Redemption",
                            MovieDescription = "This is no.1 rated movie in IMDB",
                            MoviePrice = 29.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DirectorId = 2,
                            CategoryId = 2,
                        },
                        new Movie()
                        {
                            MovieName = "Ghost",
                            MovieDescription = "One of the most thrilling horror films",
                            MoviePrice = 39.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(7),
                            DirectorId = 3,
                            CategoryId = 3,
                        },
                        new Movie()
                        {
                            MovieName = "Race",
                            MovieDescription = "Race is about time travel and thrill",
                            MoviePrice = 39.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(-5),
                            DirectorId = 4,
                            CategoryId = 4,
                        },
                        new Movie()
                        {
                            MovieName = "Scoob",
                            MovieDescription = "Animation movie of cooby doo and his friends.",
                            MoviePrice = 39.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(-2),
                            DirectorId = 5,
                            CategoryId = 5,
                        },
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 1
                        },
                    });
                    context.SaveChanges();
                }

                //Review
                if (!context.Reviews.Any())
                {
                    context.Reviews.AddRange(new List<Review>()
                    {
                        new Review()
                        {
                            ReviewDescription ="Nice!! Well Done...",

                            StarRating=4,

                            MovieId=1,

                            UserId="4b25bace-d1f7-44d0-bd7b-7af5a474bfde"

    },
                        new Review()
                        {   ReviewDescription ="Excellent!! Screenplay and acting....",

                            StarRating=5,
                            MovieId=2,
                            UserId="4b25bace-d1f7-44d0-bd7b-7af5a474bfde"
                        },
                        new Review()
                        {
                            ReviewDescription ="Visual Treat of a film...!!",

                            StarRating=4,

                            MovieId=3,
                            UserId="4b25bace-d1f7-44d0-bd7b-7af5a474bfde"

                        },
                        new Review()
                        {
                            ReviewDescription ="Amazing visual and great direction",

                            StarRating=5,

                            MovieId=4,
                            UserId="4b25bace-d1f7-44d0-bd7b-7af5a474bfde"
                        },
                        new Review()
                        {
                            ReviewDescription ="Similar movie to the previous part!!Not much new",

                            StarRating=3,

                            MovieId=5,
                            UserId="4b25bace-d1f7-44d0-bd7b-7af5a474bfde"

                        },
                    });
                    context.SaveChanges();
                }

            }

        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!await roleManager.RoleExistsAsync("User"))
                    await roleManager.CreateAsync(new IdentityRole("User"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, "User");
                }
            }

        }

    }
}
