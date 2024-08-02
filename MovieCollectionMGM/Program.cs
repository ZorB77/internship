// See https://aka.ms/new-console-template for more information

using MovieCollectionMGM;


var list = MovieCollection.LoadFromFile();
string option = "0";

while (option != "4")
{
    MovieCollection.PrintMovies(list);
    Console.WriteLine("Select option: 0 AddMovie, 1 UpdateMovie, 2 DeleteMovie, 3 SearchByTitle; 4 SaveToFile & Stop");
    option = Console.ReadLine();
    switch (option)
    {
        case "0":
            string movie = Console.ReadLine();
            MovieCollection.AddMovie(movie, list);
            break;
        case "1":
            Console.WriteLine("Movie to update:");
            string movieTitle = Console.ReadLine();
            Console.WriteLine("New movie title:");
            string newTitle = Console.ReadLine();

            MovieCollection.UpdateMovie(movieTitle, newTitle, list);
            break;
        case "2":
            string title = Console.ReadLine();
            MovieCollection.DeleteMovie(title, list);
            break;
        case "3":
            string titleMovie = Console.ReadLine();
            MovieCollection.SearchByTitle(titleMovie, list);
            break;
        case "4":
            MovieCollection.SaveToFile(list);
            break;
    }



}



