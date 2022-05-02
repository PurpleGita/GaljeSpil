

namespace GaljeSpil_OrdblindVersion
{
    internal class Menu
    {
        internal static void StartMenu() 
        {
            // Her printer jeg start menuen, og readkey er for når man klikker forsætter man
            Console.WriteLine("hey velkommen til GaljeSpil Ordblind Version. \n \n" +
                "i dette spil er det din opgave at gætte hvilke ord der står under galjen. \n" +
                "Gæt ordet inden du løber tør for liv og dør... smertefuldt. \n" +
                "Nå ja btw ordene kan indeholde stavefejl. mange stave fejl. \n" +
                "\n klik enter for at starter");
            Console.ReadKey();

            Console.Clear();
            return;

        }

        internal static int ChoseCatagory(List<int> Generated_Seed) 
        {
            bool failed = true;
            int chosenCatagory_int = 0;
            
            do
            {
                // her prøver vi at lave brugernes input til en int så de kan vælge en menu
                try
                {
                    ConsoleKeyInfo chosenCatagory = Console.ReadKey();
                    chosenCatagory_int = int.Parse(chosenCatagory.KeyChar.ToString());

                    if (chosenCatagory_int > 0 && chosenCatagory_int < 4)
                    {
                        failed = false;
                    }
                    
                }
                catch (Exception)
                {
                    failed = true;
                    Console.WriteLine("\n forkert valg");
                }
            }
            while (failed == true); // do while løkken sikre sig at man bliver ved med indtastnigner indtill der valgt noget rigtigt

            // switch case som sætter det valgte til til at svare med den valgte menu
            switch (chosenCatagory_int) 
            {

                case 1: 
                    
                    chosenCatagory_int = Generated_Seed[0];

                    break;

                case 2:

                    chosenCatagory_int = Generated_Seed[1];

                    break;

                case 3:

                    chosenCatagory_int = Generated_Seed[2];

                    break;

            
            }

            return(chosenCatagory_int);
        }

        internal static bool PrintWord(string word , string gussedWord , string wrongLetters) 
        {
            bool wordIsGuessed = true;
            // Laver strings om til CharArrays fordi de nemmere at arbejde med
            char[] word_Chars = word.ToCharArray();
            char[] underscoreChar = "_".ToCharArray();

            // En for løkke som køre antal gange baseret længden af ordet der skal gættes
            for (int i = 0; i < word.Length; i++)
            {
                // checkker hvilke bogstaver i ordet allerede er blever gættet på
                if (!gussedWord.Contains(word_Chars[i].ToString().ToLower()))
                {
                    //sætter de bogstaver der ikke er blevet gættet på til _
                    word_Chars[i] = underscoreChar[0];
                    wordIsGuessed = false;
                }

            }

            if (wordIsGuessed == true)
            {
                Console.Clear();
                Console.WriteLine(word + " var Riggtigt! \n tilykke du kan nu prøver igen, men du starter med et mindre liv");
                return (false);
            }
            // WrtieLines
            Console.WriteLine("\n");
            Console.WriteLine(word_Chars);
            Console.WriteLine("Bogstaver allerede gættet på : " + wrongLetters);
            Console.WriteLine("Gæt på et bogstav!");
            return (true);

        }
    }
}
