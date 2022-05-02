using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaljeSpil_OrdblindVersion
{
    internal class Tools
    {

        internal static List<string> LoadCatagories()
        {
            // skaber en ny liste
            List<string> loadedCatagories = new List<string>();

            // tilføjer strings til listen
            loadedCatagories.Add("Anime");
            loadedCatagories.Add("Marvel Film");
            loadedCatagories.Add("Navne");
            loadedCatagories.Add("Dyr");
            loadedCatagories.Add("Spil");
            loadedCatagories.Add("Offentlig Transport");
            loadedCatagories.Add("Musik");


            // retunere listen af catogorier så vi kan bruge den senere ude fra denne metode
            return (loadedCatagories);
        }

        internal static List<int> GenerateSeed(List<string> Catagories)
        {
            // skaber en ny liste
            List<int> seed = new List<int>();

            // laver en ny værdi vi siger skal være tilfældig
            Random rnd = new Random();

            // tilføjer tilfældige værdier til seed listen
            seed.Add(rnd.Next(Catagories.Count));
            seed.Add(rnd.Next(Catagories.Count));
            seed.Add(rnd.Next(Catagories.Count));
            seed.Add(rnd.Next(5));

            // retunere seed listen så vi kan bruge den senere ude for denne metode
            return (seed);
                
        }

        internal static void ShowCatagorys(List<int> seed , List<string> catagories) 
        {
            // udskriver tekst
            Console.WriteLine("vælg en katagori ved at intaste tallet til venstre for den ønsket katogori \n \n");

            // viser en katogorier svarne til de tal Seed har genereret
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine((i + 1) + "  " + catagories[seed[i]]); 
            }
        }

        internal static string[] ReciveGuess(string word, string[] gusses , bool stillGuessing) 
        {
            if (stillGuessing)
            {
                //tager imod input
                string guessing = Console.ReadKey().KeyChar.ToString();

                //fjerner ting fra skærmen
                Console.Clear();

                // chekker om ordert indeholder det som gættes
                if (word.ToLower().Contains(guessing))
                {
                    // checkker om der allerede er blevet gættet på det samme
                    if (!gusses[0].Contains(guessing))
                    {
                        gusses[0] = gusses[0] + guessing;
                        Console.WriteLine(guessing + " er rigtigt!!");
                    }
                    // siger til programmet at spilleren har gættet rigtig denne gang
                    gusses[2] = "Right";
                }
                else
                {
                    //sker hvis spilleren gætter forkert og tilføjer bogstavet til den string som indeholder forkerte bogstaver
                    if (!gusses[1].Contains(guessing))
                    {
                        gusses[1] = gusses[1] + " " + guessing;
                        gusses[2] = "Wrong";
                    }
                }
            }
            return (gusses);


        }

        internal static int ChangeHP(string rightOrWrong , int HP , bool stillGuessing) 
        {

            if (stillGuessing)
            {
                // denne metode chekker om spilleren gættet forkert og ændre spillerens liv
                if (rightOrWrong == "Wrong")
                {
                    HP = HP - 1;
                    Console.WriteLine(HP + "liv tilbage");

                    if (HP <= 0)
                    {
                        Console.WriteLine("You Lost");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            return HP;
        }

        internal static string LoadWordIn(string Catagory, int seed)
        {

            // denne metode laver en liste af ord baseret på den valgte katagori og vælger ordet udfra seed
            List<string> LoadedWord = new List<string>();
            string word = "";
            switch (Catagory)
            {
                case "Anime":

                    LoadedWord.Add("Re:Zero");
                    LoadedWord.Add("Hunter X Hunter");
                    LoadedWord.Add("Overlord");
                    LoadedWord.Add("Made In Abyss");
                    LoadedWord.Add("Naruto");
                    LoadedWord.Add("Kill La Kill");

                    word = LoadedWord[seed];

                    break;


                case "Marvel Film":

                    LoadedWord.Add("Thor: Ragnarok");
                    LoadedWord.Add("Avengers");
                    LoadedWord.Add("Iron Man");
                    LoadedWord.Add("Ant Man");
                    LoadedWord.Add("Spiderman Far From Home");
                    LoadedWord.Add("The Incredibale Hulk");

                    word = LoadedWord[seed];

                    break;


                case "Navne":

                    LoadedWord.Add("Rasmus");
                    LoadedWord.Add("Qassim");
                    LoadedWord.Add("Bilal");
                    LoadedWord.Add("Mads");
                    LoadedWord.Add("Silja");
                    LoadedWord.Add("Daniel");

                    word = LoadedWord[seed];

                    break;

                case "Dyr":

                    LoadedWord.Add("Leopard");
                    LoadedWord.Add("Zebra");
                    LoadedWord.Add("Menneske");
                    LoadedWord.Add("Blæksprutte");
                    LoadedWord.Add("Antelope");
                    LoadedWord.Add("Bjerg Ged");

                    word = LoadedWord[seed];

                    break;


                case "Spil":

                    LoadedWord.Add("Elden Ring");
                    LoadedWord.Add("Genshin Impact");
                    LoadedWord.Add("Castle Crashers");
                    LoadedWord.Add("Super Smash Bros");
                    LoadedWord.Add("Guilty Gear");
                    LoadedWord.Add("Apex Legends");

                    word = LoadedWord[seed];

                    break; 

                 case "Offentlig Transport":

                    LoadedWord.Add("Togspor");
                    LoadedWord.Add("Station");
                    LoadedWord.Add("Depression");
                    LoadedWord.Add("Angstanfald");
                    LoadedWord.Add("Forsinket");
                    LoadedWord.Add("Busstopsted");
                    

                    word = LoadedWord[seed];

                    break;

                case "Musik":

                    LoadedWord.Add("Jazz");
                    LoadedWord.Add("Instrumenter");
                    LoadedWord.Add("Fløjte");
                    LoadedWord.Add("Slipknot");
                    LoadedWord.Add("Queen");
                    LoadedWord.Add("Guitar");

                    word = LoadedWord[seed];

                    break;


            }

            return (word);
        }


    }
}
