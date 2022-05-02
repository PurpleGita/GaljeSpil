using GaljeSpil_OrdblindVersion;

bool gameplaying = true;
bool guessing;
string[] gusses = { "gættet forkerte bogstaver" , "gættet rigtige bogstaver" , "om det sidste gæt var rigtigt"};
int maxHP = 13;
int HP;
List<string> catagories = Tools.LoadCatagories();



Menu.StartMenu();
while (gameplaying == true)
{
    gusses[0] = "";
    gusses[1] = "";
    gusses[2] = "Right";
    HP = maxHP;
    guessing = true;
    List<int> Generated_Seed = Tools.GenerateSeed(catagories);
    Tools.ShowCatagorys(Generated_Seed, catagories);
    int chosen_catagory = Menu.ChoseCatagory(Generated_Seed);
    string word = Tools.LoadWordIn(catagories[chosen_catagory] , Generated_Seed[3]);
    do
    {
        guessing = Menu.PrintWord(word, gusses[0], gusses[1]);
        gusses = Tools.ReciveGuess(word, gusses, guessing);
        HP = Tools.ChangeHP(gusses[2], HP, guessing);
    } while (guessing);
    maxHP = maxHP -1;
}