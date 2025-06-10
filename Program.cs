
namespace Hangman3
{
    internal class Hangman3
    {
        static void Main(string[] args)
        {
            //total number of chances that the user has to guess the chosen word 
            const int MAX_LIVES = 10;

            //will keep track of all correct guesses entered 
            List<char> rightGuesses = new List<char>();

            //will keep track of all wrong guesses entered 
            List<char> wrongGuesses = new List<char>();

            //List with multiple words to choose from    
            List<string> theWords = new List<string>()
            {
                "Blackberry", "Blueberry", "Strawberry", "Cherry", "Raspberry", "Elderberry"
            };

            // will select a random index from the list above 
            Random rnd = new Random();
            int randomIndexer = rnd.Next(theWords.Count);

            //will throw the index of the picked word 
            string theChosenOne = theWords[randomIndexer];

            //will convert the word to lowercase so that the user can enter upper/lowercases
            string theWord = theChosenOne.ToLower();

            //will break the string into individual characters
            char[] dottedLine = new char [theWord.Length];
            Console.WriteLine(dottedLine);

            //will reiterate through the random word and replace each character with an underscore 
            for (int i = 0; i < theWord.Length; i++)
            {
                dottedLine[i] = '_';
            }

            //will print the word
            Console.WriteLine(theWord);

            //maximum number of lives
            int numOfLives = MAX_LIVES;
            Console.WriteLine($"You got a total of {MAX_LIVES} guesses");

            //while numOfLives != 0 
            while (numOfLives >= 0)
            {
                //will ask user to enter a guess
                Console.WriteLine("Guess the word. Here we go! Enter a letter");

                //user will enter their guess and the system will read the specific key entered by the user 
                char userGuess = Console.ReadKey().KeyChar;

                //will validate letters a-z or invalidate non-letter characters
                if (Char.IsLetter(userGuess))
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"{userGuess} is an invalid Input! Enter a letter from A to Z");
                    continue;
                }

                //will check if the entered letter has already been tried 
                if (rightGuesses.Contains(userGuess) || wrongGuesses.Contains(userGuess))
                {
                    Console.WriteLine("You already entered that guess. Try again");
                    continue;
                }

                //boolean to regulate contained characters in the chosen word
                bool isContained = theWord.Contains(userGuess);

                if (isContained)
                {
                    //for loop will reiterate through the chosen word and compare the entered character to the word
                    //if the entered letter is in the word it'll be displayed else an underscore will appear
                    for (int j = 0; j < theWord.Length; j++)
                    {
                        if (userGuess == theWord[j])
                        {
                            dottedLine[j] = userGuess;
                        }

                        //will add guess to the LIST storaging the correct guesses 
                        {
                            rightGuesses.Add(userGuess);
                        }
                    }
                }
                else
                {
                    //will add the guess to the LIST storaging the incorrect guesses 
                    wrongGuesses.Add(userGuess);
                    Console.WriteLine($"{userGuess} is not one of the letters " +
                                      $"Let's try again. You got {numOfLives--} chances left");
                }
                
                //if there are no more underscores covering any letters on the word then the user wins
                bool coveredWord = dottedLine.Contains('_');
                if (!coveredWord)
                {
                    Console.WriteLine($"You won! You guessed all the letters in {theWord}");
                    break;
                }

            }
            Console.WriteLine(dottedLine);
        }
    }
}

    