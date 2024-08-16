using MovieApp.Models;
using MovieApplication.Models;
using MovieApplication.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text;

namespace MovieApplication.Services
{
    public class APIService : IAPIService
    {
        public string AddMovie(string title, DateTime releaseDate, string description, string genre, decimal budget, int duration)
        {
            var newMovie = new Movie
            {
                Title = title,
                ReleaseDate = releaseDate,
                Description = description,
                Genre = genre,
                Budget = budget,
                Duration = duration
            };

            string url = "https://localhost:44316/api/addMovie";
            string jsonData = JsonConvert.SerializeObject(newMovie);
            var response = PostMethod(url, jsonData);

            return response;
        }

        public List<Movie> GetAllMovies()
        {
            string url = "https://localhost:44316/api/getMovies";
            var response = GetMethod(url);

            List<Movie> allMovies = JsonConvert.DeserializeObject<List<Movie>>(response);

            return allMovies;
        }

        public Movie GetMovieById(int id)
        {
            string url = "https://localhost:44316/api/getMovieById/ID=" + id;
            var response = GetMethod(url);
            
            var movie = JsonConvert.DeserializeObject<Movie>(response);

            return movie;
        }

        public string DeleteMovie(int id)
        {
            string url = "https://localhost:44316/api/deleteMovie/ID=" + id;
            var response = DeleteMethod(url);

            return response;
        }
        public string UpdateMovie(int id, string title, DateTime releaseDate, string description, string genre, decimal budget, int duration)
        {
            var updatedMovie = new Movie
            {
                ID = id,
                Title = title,
                ReleaseDate = releaseDate,
                Description = description,
                Genre = genre,
                Budget = budget,
                Duration = duration
            };

            string url = "https://localhost:44316/api/updateMovie/ID=" + id;
            string jsonData = JsonConvert.SerializeObject(updatedMovie);
            var response = PutMethod(url, jsonData);

            return response;
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            string url = "https://localhost:44316/api/filterByGenre/genre=" + genre;
            var response = GetMethod(url);

            List<Movie> moviesByGenre = JsonConvert.DeserializeObject<List<Movie>>(response);

            return moviesByGenre;
        }

        public List<Movie> GetMoviesByYear(int year)
        {
            string url = "https://localhost:44316/api/filterByYear/year=" + year;
            var response = GetMethod(url);

            List<Movie> moviesByYear = JsonConvert.DeserializeObject<List<Movie>>(response);

            return moviesByYear;
        }

        public List<Movie> GetMoviesByDateInterval(int year1, int year2)
        {
            string url = "https://localhost:44316/api/filterByDateInterval/year1=" + year1 + "&year2=" + year2;
            var response = GetMethod(url);

            List<Movie> moviesByInterval = JsonConvert.DeserializeObject<List<Movie>>(response);

            return moviesByInterval;
        }


        public string AddPerson(string firstName, string lastName, DateTime birthday)
        {
            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday,
            };

            string url = "https://localhost:44316/api/addPerson";
            string jsonData = JsonConvert.SerializeObject(newPerson);
            var response = PostMethod(url, jsonData);

            return response;
        }

        public List<Person> GetAllPersons()
        {
            string url = "https://localhost:44316/api/getPersons";
            var response = GetMethod(url);

            List<Person> allPersons = JsonConvert.DeserializeObject<List<Person>>(response);

            return allPersons;
        }

        public Person GetPersonById(int id)
        {
            string url = "https://localhost:44316/api/getPersonById/ID=" + id;
            var response = GetMethod(url);

            var person = JsonConvert.DeserializeObject<Person>(response);

            return person;
        }

        public string DeletePerson(int id)
        {
            string url = "https://localhost:44316/api/deletePerson/ID=" + id;
            var response = DeleteMethod(url);

            return response;
        }

        public string UpdatePerson(int id, string firstName, string lastName, DateTime birthday)
        {
            var updatedPerson = new Person
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday
            };

            string url = "https://localhost:44316/api/updatePerson/ID=" + id;
            string jsonData = JsonConvert.SerializeObject(updatedPerson);
            var response = PutMethod(url, jsonData);

            return response;
        }

        public string AddReview(int movieId, double rating, string comment, DateTime reviewDate, string reviewerName)
        {
            var newReview = new Review
            {
                MovieId = movieId,
                Rating = rating,
                Comment = comment,
                ReviewDate = reviewDate,
                ReviewerName = reviewerName
            };

            string url = "https://localhost:44316/api/addReview";
            string jsonData = JsonConvert.SerializeObject(newReview);
            var response = PostMethod(url, jsonData);

            return response;
        }

        public List<Review> GetAllReviews()
        {
            string url = "https://localhost:44316/api/getReviews";
            var response = GetMethod(url);

            List<Review> allPersons = JsonConvert.DeserializeObject<List<Review>>(response);

            return allPersons;
        }

        public Review GetReviewById(int id)
        {
            string url = "https://localhost:44316/api/getReviewById/ID=" + id;
            var response = GetMethod(url);

            var review = JsonConvert.DeserializeObject<Review>(response);

            return review;
        }

        public string DeleteReview(int id)
        {
            string url = "https://localhost:44316/api/deleteReview/ID=" + id;
            var response = DeleteMethod(url);

            return response;
        }

        public string UpdateReview(int id, double rating, string comment, DateTime reviewDate, string reviewerName)
        {
            var updatedReview = new Review
            {
                ID = id,
                Rating = rating,
                Comment = comment,
                ReviewDate = reviewDate,    
                ReviewerName = reviewerName
            };

            string url = "https://localhost:44316/api/updateReview/ID=" + id;
            string jsonData = JsonConvert.SerializeObject(updatedReview);
            var response = PutMethod(url, jsonData);

            return response;
        }

        public List<Review> GetReviewsByRating(double rating)
        {
            string url = "https://localhost:44316/api/filterByRating/rating=" + rating;
            var response = GetMethod(url);

            List<Review> reviewsByRating = JsonConvert.DeserializeObject<List<Review>>(response);

            return reviewsByRating;
        }

        public int GetAverageRatingForGivenMovie(int movieId)
        {
            string url = "https://localhost:44316/api/averageRating/movieID=" + movieId;
            var response = GetMethod(url);

            return Convert.ToInt32(response);
        }

        public List<Movie> Top10Movies()
        {
            string url = "https://localhost:44316/api/top10Movies";
            var response = GetMethod(url);

            List<Movie> top10 = JsonConvert.DeserializeObject<List<Movie>>(response);

            return top10;
        }

        public string AddRole(int movieId, int personId, string name)
        {
            string baseUrl = "https://localhost:44316/api/addRole";
            string url = $"{baseUrl}?movieId={movieId}&personId={personId}&name={name}";
            string jsonData = string.Empty;
            var response = PostMethod(url, jsonData);

            return response;
        }

        public List<Role> GetAllRoles()
        {
            string url = "https://localhost:44316/api/getRoles";
            var response = GetMethod(url);

            List<Role> allRoles = JsonConvert.DeserializeObject<List<Role>>(response);

            return allRoles;
        }

        public Role GetRoleById(int id)
        {
            string url = "https://localhost:44316/api/getRoleById/ID=" + id;
            var response = GetMethod(url);

            var role = JsonConvert.DeserializeObject<Role>(response);

            return role;
        }

        public string DeleteRole(int id)
        {
            string url = "https://localhost:44316/api/deleteRole/ID=" + id;
            var response = DeleteMethod(url);

            return response;
        }

        public string UpdateRole(int id, int movieId, int personId, string name)
        {
            string baseUrl = "https://localhost:44316/api/updateRole/ID=" + id;
            string url = $"{baseUrl}?movieId={movieId}&personId={personId}&name={name}";
            string jsonData = string.Empty;
            var response = PutMethod(url, jsonData);

            return response;
        }

        public string AddStudio(string name, DateTime year, string location)
        {
            var newStudio = new Studio
            {
                Name = name,
                Year = year,
                Locatiton = location
            };

            string url = "https://localhost:44316/api/addStudio";
            string jsonData = JsonConvert.SerializeObject(newStudio);
            var response = PostMethod(url, jsonData);

            return response;
        }

        public List<Studio> GetAllStudios()
        {
            string url = "https://localhost:44316/api/getStudios";
            var response = GetMethod(url);

            List<Studio> allStudios = JsonConvert.DeserializeObject<List<Studio>>(response);

            return allStudios;
        }

        public Studio GetStudioById(int id)
        {
            string url = "https://localhost:44316/api/getStudioById/ID=" + id;
            var response = GetMethod(url);

            var studio = JsonConvert.DeserializeObject<Studio>(response);

            return studio;
        }

        public string DeleteStudio(int id)
        {
            string url = "https://localhost:44316/api/deleteStudio/ID=" + id;
            var response = DeleteMethod(url);

            return response;
        }

        public string UpdateStudio(int id, string name, DateTime year, string location)
        {
            var updatedStudio = new Studio
            {
                ID = id,
                Name = name,
                Year = year,
                Locatiton = location
            };

            string url = "https://localhost:44316/api/updateStudio/ID=" + id;
            string jsonData = JsonConvert.SerializeObject(updatedStudio);
            var response = PutMethod(url, jsonData);

            return response;
        }

        public string AddMovieStudioAssociation(int movieId, int studioId)
        {
            var newAssociation = new MovieStudio
            {
                MovieID = movieId,
                StudioID = studioId
            };

            string url = "https://localhost:44316/api/addAssociation";
            string jsonData = JsonConvert.SerializeObject(newAssociation);
            var response = PostMethod(url, jsonData);

            return response;
        }

        public List<MovieStudio> GetAllMovieStudiosAssociations()
        {
            string url = "https://localhost:44316/api/getAssociations";
            var response = GetMethod(url);

            List<MovieStudio> allAssociations = JsonConvert.DeserializeObject<List<MovieStudio>>(response);

            return allAssociations;
        }

        public List<Studio> GetStudiosForMovie(int movieId)
        {
            string url = "https://localhost:44316/api/getStudiosForMovie/MovieId=" + movieId;
            var response = GetMethod(url);

            var studios = JsonConvert.DeserializeObject<List<Studio>>(response);

            return studios;
        }

        public List<Movie> GetMoviesForStudio(int studioId)
        {
            string url = "https://localhost:44316/api/getMoviesForStudio/StudioId=" + studioId;
            var response = GetMethod(url);

            var movies = JsonConvert.DeserializeObject<List<Movie>>(response);

            return movies;
        }

        public string DeleteMovieStudioAssociation(int id)
        {
            string url = "https://localhost:44316/api/deleteAssociation/ID=" + id;
            var response = DeleteMethod(url);

            return response;
        }

        public string UpdateMovieStudioAssociation(int id, int movieId, int studioId)
        {
            var updateAssociation = new MovieStudio
            {
                ID = id,
                MovieID = movieId,
                StudioID = studioId
            };

            string url = "https://localhost:44316/api/updateAssociation/ID=" + id;
            string jsonData = JsonConvert.SerializeObject(updateAssociation);
            var response = PutMethod(url, jsonData);

            return response;
        }

        private string GetMethod(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    return responseData;
                }
                else
                {
                    return "Error: " + response.StatusCode.ToString();
                }
            }
        }

        private string PostMethod(string url, string jsonData)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    return responseData;
                }
                else
                {
                    return "Error: " + response.StatusCode.ToString();
                }
            }
        }

        private string DeleteMethod(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    return responseData;
                }
                else
                {
                    return "Error: " + response.StatusCode.ToString();
                }
            }
        }
        
        private string PutMethod(string url, string jsonData)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PutAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    return responseData;
                }
                else
                {
                    return "Error: " + response.StatusCode.ToString();
                }
            }
        }
    }
}
