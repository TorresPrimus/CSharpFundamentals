using _06_RepositoryPatern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Console
{
    class ProgramUI
    {
        private StreamingContentRepository _contentRepo = new StreamingContentRepository();

        // Method that runs /starts the UI part of the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display options to the USER
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Content\n" +
                    "2. View All Content\n" +
                    "3. View Content By Title\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

                // Get the Users input
                string input = Console.ReadLine();

                // Evaluate Users input and act acoordingly
                switch (input)
                {
                    case "1":
                        // Create new content
                        CreateNewContent();
                        break;
                    case "2":
                        // View All Content
                        DisplayAllContent();
                        break;
                    case "3":
                        // View Content By Title
                        DisplayContentByTitle();
                        break;
                    case "4":
                        // Update Existing Content
                        UpdateExistingContent();
                        break;
                    case "5":
                        // Delete Existing Content
                        DeleteExistingContent();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-6.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new StreamingContent
        private void CreateNewContent()
        {
            StreamingContent newContent = new StreamingContent();

            //Title
            Console.WriteLine("Enter the Title for the content:");
            newContent.Title = Console.ReadLine();

            //Description
            Console.WriteLine("Enter Description of the content:");
            newContent.Description = Console.ReadLine();

            //MaturityRating
            Console.WriteLine("Enter rating for content (G, PG, PG-13, etc):");
            newContent.MaturityRating = Console.ReadLine();

            //StarRating
            Console.WriteLine("Enter contents Star Rating (1.0 - 10.0):");
            string StarsAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(StarsAsString);

            //IsFamilyFriendly
            Console.WriteLine("Is the content family friendly? (y/n)");
            string familyFriendlyString = Console.ReadLine().ToLower();

            if (familyFriendlyString == "y")
            {
                newContent.IsFamilyFriendly = true;
            }
            else if (familyFriendlyString == "n")
            {
                newContent.IsFamilyFriendly = false;
            }
            else
            {

            }

            //GenreType
            Console.WriteLine("Enter the Genre number:\n" +
                "1. Horror\n" +
                "2. RomCom\n" +
                "3. SciFi\n" +
                "4. Documentary\n" +
                "5. Bromance\n" +
                "6. Drama\n" +
                "7. Action");

            string genreAsString = Console.ReadLine();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType)genreAsInt;

            _contentRepo.AddContentToList(newContent);
        }

        // View Current StreamingContent that is saved
        private void DisplayAllContent()
        {
            Console.Clear();

            List<StreamingContent> listOfContent = _contentRepo.GetContentList();

            foreach (StreamingContent content in listOfContent)
            {
                Console.WriteLine($"Title: {content.Title}\n" +
                    $"Description: {content.Description}");
            }
        }

        // View Existing Content by Title
        private void DisplayContentByTitle()
        {
            Console.Clear();

            // Prompt the User to give me a title
            Console.WriteLine("What is the title you are looking for?");

            // Get User's input
            string userTitle = Console.ReadLine();

            // Find the content by title
            StreamingContent content = _contentRepo.GetContentByTitle(userTitle);

            // Display found content if isn't null
            if (content != null)
            {
                Console.WriteLine($"Title: {content.Title}\n" +
                    $"Descirption: {content.Description}\n" +
                    $"Maturity Rating: {content.MaturityRating}\n" +
                    $"Star Rating: {content.StarRating}\n" +
                    $"Family Friendly: {content.IsFamilyFriendly}\n" +
                    $"Genre: {content.TypeOfGenre}");
            }
            else
            {
                Console.WriteLine("Not content by that title!");
            }
        }

        // Update Existing Content
        private void UpdateExistingContent()
        {
            // Display all content
            DisplayAllContent();

            // Ask for title that will be updated
            Console.WriteLine("Enter the title you would like to update:");

            // Get that title
            string oldTitle = Console.ReadLine();

            // Build a new object
            StreamingContent newContent = new StreamingContent();

            //Title
            Console.WriteLine("Enter the Title for the content:");
            newContent.Title = Console.ReadLine();

            //Description
            Console.WriteLine("Enter Description of the content:");
            newContent.Description = Console.ReadLine();

            //MaturityRating
            Console.WriteLine("Enter rating for content (G, PG, PG-13, etc):");
            newContent.MaturityRating = Console.ReadLine();

            //StarRating
            Console.WriteLine("Enter contents Star Rating (1.0 - 10.0):");
            string StarsAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(StarsAsString);

            //IsFamilyFriendly
            Console.WriteLine("Is the content family friendly? (y/n)");
            string familyFriendlyString = Console.ReadLine().ToLower();

            if (familyFriendlyString == "y")
            {
                newContent.IsFamilyFriendly = true;
            }
            else if (familyFriendlyString == "n")
            {
                newContent.IsFamilyFriendly = false;
            }
            else
            {

            }

            //GenreType
            Console.WriteLine("Enter the Genre number:\n" +
                "1. Horror\n" +
                "2. RomCom\n" +
                "3. SciFi\n" +
                "4. Documentary\n" +
                "5. Bromance\n" +
                "6. Drama\n" +
                "7. Action");

            string genreAsString = Console.ReadLine();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType)genreAsInt;

            // Verify if update worked
            bool wasUpdated = _contentRepo.UpdateExistingContent(oldTitle, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Content updated successfully!");
            }
            else
            {
                Console.WriteLine("Content failed to update.");
            }
        }

        // Delete Existing Content
        private void DeleteExistingContent()
        {

            DisplayAllContent();

            // Get the title to delete
            Console.WriteLine("\nEnter the title of the content you would like to remove:");
            
            string userInput = Console.ReadLine();

            // Call the delete method
            bool wasDeleted = _contentRepo.RemoveContentFromList(userInput);

            // If content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The content was deleted successfully!");
            }

            // Otherwise state it could not be deleted
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
        }

        //See method
        private void SeedContentList()
        {
            StreamingContent phantomMenace = new StreamingContent("Phantom Menace", "His M-Count is high!", "PG", 9.7, true, GenreType.Action);
            StreamingContent cloneWars = new StreamingContent("Clone Wars", "What about the attack on the Wookies?", "PG", 9.8, true, GenreType.Drama);
            StreamingContent revenge = new StreamingContent("Revenge of the Sith", "You were a brother to me!", "PG-13", 9.9, true, GenreType.Documentary);

            _contentRepo.AddContentToList(phantomMenace);
            _contentRepo.AddContentToList(cloneWars);
            _contentRepo.AddContentToList(revenge);
        }
    }
}
