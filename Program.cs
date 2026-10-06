using System.Security.Cryptography.X509Certificates;

string word = "msmoody".ToLower();

int maxLives = 6;
int currentLives = maxLives;

bool win = false;
List<char> guessedLetters = new List<char>();
string message = "";


while (currentLives > 0 && !win)
{
    Console.Clear(); //this is where stick man grows with each current letters

    DrawStickMan(maxLives - currentLives);
    Console.WriteLine();


    foreach (char c in word)
    {
        if (guessedLetters.Contains(c))
            Console.Write(c);
        else
            Console.Write("_");
    }
    Console.WriteLine("\n + message");
    Console.WriteLine("Guess a letter HUN, (tips:it's my nickname) ");
    Console.WriteLine(currentLives + "/" + maxLives + " lives");

    string input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) || input.Length != 1)
    {
        message = "One letter only, hun!";
        continue;
    }

    char guess = char.ToLower(input[0]);

    if (guessedLetters.Contains(guess))
    {
        message = "you already guessed that letter, hun!";
    }
    else if (word.Contains(guess))
    {
        message = "correct!";
        guessedLetters.Add(guess);
    }
    else
    {
        message = "nope!";
        guessedLetters.Add(guess);
        currentLives--;
    }

    win = word.All(c => guessedLetters.Contains(c));
}

Console.Clear();
DrawStickMan(maxLives - currentLives);
Console.WriteLine("\nThe word was: " + word);

if (win)
    Console.WriteLine("congratulations, you win baddie!");
else
    Console.WriteLine("you lose hun...");

Console.ReadKey();



void DrawStickMan(int wrongGuesses)
{
    string head = wrongGuesses >= 1 ? "O" : " ";
    string body = wrongGuesses >= 2 ? "|" : " ";
    string leftArm = wrongGuesses >= 3 ? "/" : " ";
    string rightArm = wrongGuesses >= 4 ? "\\" : " ";
    string leftLeg = wrongGuesses >= 5 ? "/" : " ";
    string rightLeg = wrongGuesses >= 6 ? "\\" : " ";

    Console.WriteLine("  " + head);
    Console.WriteLine(" " + leftArm + body + rightArm);
    Console.WriteLine(" " + leftLeg + " " + rightLeg);
}


