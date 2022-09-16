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
                            ActorName = "Actor 1",
                            Biography = "This is the Bio of the first actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            ActorName = "Actor 2",
                            Biography = "This is the Bio of the second actor",
                             ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                        ActorName = "Actor 3",
                        Biography = "This is the Bio of the third actor",
                        ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"


                        },
                        new Actor()
                        {
                        ActorName = "Actor 4",
                        Biography = "This is the Bio of the fourth actor",
                        ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                        ActorName = "Actor 5",
                        Biography = "This is the Bio of the fifth actor",
                        ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

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
                            DirectorName = "Director 1",
                            Biography = "This is the Bio of the first director",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Director()
                        {
                            DirectorName = "Director 2",
                            Biography = "This is the Bio of the second director",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Director()
                        {
                            DirectorName = "Director 3",
                            Biography = "This is the Bio of the third director",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Director()
                        {
                            DirectorName = "Director 4",
                            Biography = "This is the Bio of the fourth director",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Director()
                        {
                            DirectorName = "Director ",
                            Biography = "This is the Bio of the fifth director",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"
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
                            MovieDescription = "This is the Life movie description",
                            MoviePrice = 39.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(10),
                            DirectorId = 1,
                            CategoryId = 1,
                        },
                        new Movie()
                        {
                            MovieName = "The Shawshank Redemption",
                            MovieDescription = "This is the Shawshank Redemption description",
                            MoviePrice = 29.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DirectorId = 2,
                            CategoryId = 2,
                        },
                        new Movie()
                        {
                            MovieName = "Ghost",
                            MovieDescription = "This is the Ghost movie description",
                            MoviePrice = 39.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(7),
                            DirectorId = 3,
                            CategoryId = 3,
                        },
                        new Movie()
                        {
                            MovieName = "Race",
                            MovieDescription = "This is the Race movie description",
                            MoviePrice = 39.50,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(-5),
                            DirectorId = 4,
                            CategoryId = 4,
                        },
                        new Movie()
                        {
                            MovieName = "Scoob",
                            MovieDescription = "This is the Scoob movie description",
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
                            ReviewDescription ="This is review for movie 1",

                            StarRating=4,

                            MovieId=1

    },
                        new Review()
                        {   ReviewDescription ="This is review for movie 2",

                            StarRating=5,
                            MovieId=2
                        },
                        new Review()
                        {
                            ReviewDescription ="This is review for movie 3",

                            StarRating=4,

                            MovieId=3

                        },
                        new Review()
                        {
                            ReviewDescription ="This is review for movie 4",

                            StarRating=5,

                            MovieId=4
                        },
                        new Review()
                        {
                            ReviewDescription ="This is review for movie 5",

                            StarRating=5,

                            MovieId=5

                        },
                    });
                    context.SaveChanges();
                }

            }

        }
    }
}
