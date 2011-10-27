// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test1pokemon2
{
    class Programs
    {
        [STAThread]
        static void main(string[] args)
        {
            Console.Title = "POKèMON the text based game!!";
            string Name, ans1, ans2, ans3, ans4, ans5, ans6, ans7;
            string sure = "no";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("   [][][][]");
            Console.WriteLine("   []    []");
            Console.WriteLine("   [][][][]");
            Console.WriteLine("   []");
            Console.WriteLine("   []");
            System.Threading.Thread.Sleep(300);
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]");
            Console.WriteLine("   []    []  []    []");
            Console.WriteLine("   [][][][]  []    []");
            Console.WriteLine("   []        []    []");
            Console.WriteLine("   []        [][][][]");
            System.Threading.Thread.Sleep(300);
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []");
            Console.WriteLine("   []    []  []    []  []  []");
            Console.WriteLine("   [][][][]  []    []  [][]");
            Console.WriteLine("   []        []    []  []  []");
            Console.WriteLine("   []        [][][][]  []    []");
            System.Threading.Thread.Sleep(300);
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []  [][][][]");
            Console.WriteLine("   []    []  []    []  []  []    []");
            Console.WriteLine("   [][][][]  []    []  [][]      [][][]");
            Console.WriteLine("   []        []    []  []  []    []");
            Console.WriteLine("   []        [][][][]  []    []  [][][][]");
            System.Threading.Thread.Sleep(300);
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []  [][][][]  []      []");
            Console.WriteLine("   []    []  []    []  []  []    []        [][]  [][]");
            Console.WriteLine("   [][][][]  []    []  [][]      [][][]    []  []  []");
            Console.WriteLine("   []        []    []  []  []    []        []      []");
            Console.WriteLine("   []        [][][][]  []    []  [][][][]  []      []");
            System.Threading.Thread.Sleep(300);
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []  [][][][]  []      []  [][][][]");
            Console.WriteLine("   []    []  []    []  []  []    []        [][]  [][]  []    []");
            Console.WriteLine("   [][][][]  []    []  [][]      [][][]    []  []  []  []    []");
            Console.WriteLine("   []        []    []  []  []    []        []      []  []    []");
            Console.WriteLine("   []        [][][][]  []    []  [][][][]  []      []  [][][][]");
            System.Threading.Thread.Sleep(300);
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            Console.WriteLine("   []    []  []    []  []  []    []        [][]  [][]  []    []  [][]    []");
            Console.WriteLine("   [][][][]  []    []  [][]      [][][]    []  []  []  []    []  []  []  []");
            Console.WriteLine("   []        []    []  []  []    []        []      []  []    []  []    [][]");
            Console.WriteLine("   []        [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            System.Threading.Thread.Sleep(300);

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            Console.WriteLine("   []    []  []    []  []  []    []        [][]  [][]  []    []  [][]    []");
            Console.WriteLine("   [][][][]  []    []  [][]      [][][]    []  []  []  []    []  []  []  []");
            Console.WriteLine("   []        []    []  []  []    []        []      []  []    []  []    [][]");
            Console.WriteLine("   []        [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            System.Threading.Thread.Sleep(300);

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            Console.WriteLine("   []    []  []    []  []  []    []        [][]  [][]  []    []  [][]    []");
            Console.WriteLine("   [][][][]  []    []  [][]      [][][]    []  []  []  []    []  []  []  []");
            Console.WriteLine("   []        []    []  []  []    []        []      []  []    []  []    [][]");
            Console.WriteLine("   []        [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            System.Threading.Thread.Sleep(300);

            Console.WriteLine("");
            Console.WriteLine("   [][][][]  [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            Console.WriteLine("   []    []  []    []  []  []    []        [][]  [][]  []    []  [][]    []");
            Console.WriteLine("   [][][][]  []    []  [][]      [][][]    []  []  []  []    []  []  []  []");
            Console.WriteLine("   []        []    []  []  []    []        []      []  []    []  []    [][]");
            Console.WriteLine("   []        [][][][]  []    []  [][][][]  []      []  [][][][]  []      []");
            System.Threading.Thread.Sleep(300);

            Console.SetCursorPosition(11, 9);
            Console.Write("┌───────────────────────────────────────────────────────╖");
            Console.SetCursorPosition(11, 10);
            Console.Write("│");
            Console.SetCursorPosition(67, 10);
            Console.Write("║");
            Console.SetCursorPosition(11, 11);
            Console.Write("╘═══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.SetCursorPosition(13, 10);
            Console.Write("Enter your player name? ");
            Name = Console.ReadLine();

            Console.SetCursorPosition(0, 13);

            string text = "Hello " + Name + "!\nWelcom to the world of POKèMON!\nThis world is inhabited by creatures called POKèMON!\nFor some people, POKèMON are pets. Others use them for fights.\n\n" + Name + "! Your very own POKèMON legend is about to unfold!\nA world of dreams and adventures with POKèMON awaits!\n\nLets go!";
            TextScroll(text);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            text = "*You find yourself standing in your room.*";
            TextScroll(text);
            Console.ResetColor();
            Console.WriteLine("");

            text = "What do you want to do?\n - Watch TV\n - Use the computer\n - Take a nap\n - Go downstairs";
            TextScroll(text);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            ans1 = Console.ReadLine().ToLower();
            Console.ResetColor();
            Console.WriteLine("");

            while (ans1 != "go downstairs")
            {
                if (ans1 == "watch tv")
                {
                    text = "There is nothing intresting on TV.";
                    TextScroll(text);
                }
                else if (ans1 == "use the computer")
                {
                    text = "You check your Facebook but then see you dont have any friends.";
                    TextScroll(text);
                }
                else if (ans1 == "take a nap")
                {
                    text = "Your not tired.";
                    TextScroll(text);
                }
                else
                {
                    text = "Enter a valid input!";
                    TextScroll(text);
                }
                Console.WriteLine("");
                text = "What do you want to do?";
                TextScroll(text);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                ans1 = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.WriteLine("");

            }
            Console.ForegroundColor = ConsoleColor.White;
            text = "*You find yourself in the living room.*";
            TextScroll(text);
            Console.ResetColor();
            Console.WriteLine("");
            text = "What do you want to do?\n - Talk to mom\n - Watch TV\n - Go outside\n - Have a snack";
            TextScroll(text);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            ans2 = Console.ReadLine().ToLower();
            Console.ResetColor();
            Console.WriteLine("");

            while (ans2 != "go outside")
            {
                if (ans2 == "talk to mom")
                {
                    text = "Hi " + Name + ", dont forget to go see Prof. Oak!\nHe asked if you would come by his lab.";
                    TextScroll(text);
                }
                else if (ans2 == "watch tv")
                {
                    text = "There is nothing intresting on TV.";
                    TextScroll(text);
                }
                else if (ans2 == "have a snack")
                {
                    text = "You send your mom to fetch you a snack from the kitchen.\nAfter waiting a few minutes she reteurns with a snack.";
                    TextScroll(text);
                }
                else
                {
                    text = "Enter a valid input!";
                    TextScroll(text);
                }
                Console.WriteLine("");
                text = "What do you want to do?";
                TextScroll(text);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                ans2 = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.WriteLine("");
            }
            text = "While making your way to the door your mom reminds you to go see Prof. Oak\n";
            TextScroll(text);
            Console.ForegroundColor = ConsoleColor.White;
            text = "*You find yourself infront of your house*";
            TextScroll(text);
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine(@"                ) )        /\");
            Console.WriteLine(@"               =====      /  \");
            Console.WriteLine(@"              _|___|_____/ __ \____________");
            Console.WriteLine(@"             |::::::::::/ |  | \:::::::::::|");
            Console.WriteLine(@"             |:::::::::/  ====  \::::::::::|");
            Console.WriteLine(@"             |::::::::/__________\:::::::::|");
            Console.WriteLine(@"             |_________|  ____  |__________|");
            Console.WriteLine(@"              | ______ | / || \ | _______ |");
            Console.WriteLine(@"              ||  |   || ====== ||   |   ||");
            Console.WriteLine(@"              ||--+---|| |    | ||---+---||");
            Console.WriteLine(@"              ||__|___|| |   o| ||___|___||");
            Console.WriteLine(@"              |========| |____| |=========|");
            Console.WriteLine(@"             (^^-^^^^^-|________|-^^^--^^^)");
            Console.WriteLine(@"             (,, , ,, ,/________\,,,, ,, ,)");
            Console.WriteLine(@"            ','',,,,' /__________\,,,',',;;");
            Console.WriteLine("");
            text = "Where do you want to go?\n - North\n - East\n - South\n - West";
            TextScroll(text);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            ans3 = Console.ReadLine().ToLower();
            Console.ResetColor();
            Console.WriteLine("");

            while (ans3 != "east" && ans3 != "north")
            {
                if (ans3 == "south")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    text = "*You walk south until you spot a lake.*\n*You need a POKèMON that knows surf to go on the water.*\n\n*There is nothing else to see here.*\n*You head back home.*";
                    TextScroll(text);
                    Console.ResetColor();

                }
                else if (ans3 == "west")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    text = "*You walk west until you notice that you cant go any further*\n*A long line of trees are in your way.*\n*You head back because you are at a dead end.*";
                    TextScroll(text);
                    Console.ResetColor();
                }
                else
                {
                    text = "Enter a valid input!";
                    TextScroll(text);
                }
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                text = "*You find yourself infront of your house*";
                TextScroll(text);
                Console.ResetColor();
                Console.WriteLine("");
                text = "Where do you want to go?";
                TextScroll(text);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                ans3 = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.WriteLine("");
            }
            if (ans3 == "east")
            {
                Console.ForegroundColor = ConsoleColor.White;
                text = "*You walk east until you see prof. Oak's lab.*\n*You decide to go inside*\n*You are inside but dont seem to see prof. Oak around.*";
                TextScroll(text);
                Console.WriteLine("");
                Console.ResetColor();
                text = "What do you want to do?\n - Talk to Gary\n - Talk to a lab assistant\n - Leave";
                TextScroll(text);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                ans4 = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.WriteLine("");

                while (ans4 != "talk to gary")
                {
                    if (ans4 == "Talk to a lab assistant")
                    {
                        text = "Prof.Oak just left...\nIf your looking for him, you should ask Gary where he might have gone.";
                        TextScroll(text);
                    }
                    else if (ans4 == "leave")
                    {
                        text = "Maybe you should ask someone to find out where Prof. Oak is?";
                        TextScroll(text);
                    }
                    else
                    {
                        text = "Enter a valid input";
                        TextScroll(text);
                    }
                    Console.WriteLine("");
                    text = "What do you want to do?";
                    TextScroll(text);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    ans4 = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.WriteLine("");
                }
                text = "Gary: Prof. Oak just left to studie POKèMON in route 1.\n";
                TextScroll(text);
                Console.ForegroundColor = ConsoleColor.White;
                text = "*Route 1 is located just north of here*\n*You head outside.*\n";
                TextScroll(text);
                Console.ResetColor();
                text = "Where do you want to go?\n - North\n - East\n - South\n - West";
                TextScroll(text);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                ans5 = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.WriteLine("");

                while (ans5 != "north")
                {
                    if (ans5 == "east")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        text = "*You walk east until you notice that you cant go any further*\n*A long line of trees are in your way.*\n*You head back because you are at a dead end.*";
                        TextScroll(text);
                        Console.ResetColor();
                    }
                    else if (ans5 == "south")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        text = "*You walk south until you spot a lake.*\n*You need a POKèMON that knows surf to go on the water.*\n\n*There is nothing else to see here.*\n*You head back.*";
                        TextScroll(text);
                        Console.ResetColor();
                    }
                    else if (ans5 == "west")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        text = "*You walk west until you spot your house.*\n*You head back because you mom wants you to clean your room.*";
                        TextScroll(text);
                        Console.ResetColor();
                    }
                    else
                    {
                        text = "Enter a valid input!";
                        TextScroll(text);
                    }
                    Console.WriteLine("");
                    text = "What do you want to do?";
                    TextScroll(text);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    ans5 = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            text = "*You walk north entering tall grass*\n*Right before you enter, you hear someone scream not to step in the tall grass.*\n*You look over and see Prof. Oak.*";
            TextScroll(text);
            Console.ResetColor();
            Console.WriteLine("");
            text = "OAK: What where you thinking going in the tall grass without a POKèMON to protect you!\nOAK: Wild POKèMON live in tall grass and will attack you!\nOAK: Follow me!\n";
            TextScroll(text);
            Console.ForegroundColor = ConsoleColor.White;
            text = "*You follow Prof. Oak to his lab*\n";
            TextScroll(text);
            Console.ResetColor();
            text = "OAK: " + Name + ", I have 3 POKèMON.\nOAK: You may choose one POKèMON.\nOAK: This POKèMON will protect you from wild POKèMON in tall grass\n\nWhich POKèMON do you want?\n - Charmander\n - Bulbasaur\n - Squirtle";
            TextScroll(text);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            ans6 = Console.ReadLine().ToLower();
            Console.ResetColor();
            Console.WriteLine("");

            while (sure != "yes")
            {
                if (ans6 == "charmander")
                {
                    text = "You choose Charmander";
                    TextScroll(text);
                    Console.WriteLine("");
                    Console.WriteLine("              _.--''`-..  ");
                    Console.WriteLine("            ,'          `.");
                    Console.WriteLine("          ,'          __  `.");
                    Console.WriteLine("         /|          ' __   |'  ");
                    Console.WriteLine("        , |           / |.   .");
                    Console.WriteLine("        |,'          !_.'|   |");
                    Console.WriteLine("      ,'             '   |   |");
                    Console.WriteLine("     /              |`--'|   |");
                    Console.WriteLine("    |                `---'   |");
                    Console.WriteLine("     .   ,                   |                       ,'.");
                    Console.WriteLine("      ._     '           _'  |                    , ' / `");
                    Console.WriteLine("  `.. `.`-...___,...---''    |       __,.        ,`'   /,|");
                    Console.WriteLine("  |, `- .`._        _,-,.'   .  __.-'-. /        .   ,    /");
                    Console.WriteLine("-:..     `. `-..--_.,.<       `'      / `.        `-/ |   .");
                    Console.WriteLine("  `,         '''''     `.              ,'         |   |  ',,");
                    Console.WriteLine("    `.      '            '            /          '    |'. |/");
                    Console.WriteLine("      `.   |              |       _,-'           |       ''");
                    Console.WriteLine("        `._'               |  ''|               .      |");
                    Console.WriteLine("           |                '     |                `._  ,'");
                    Console.WriteLine("           |                 '     |                 .'|");
                    Console.WriteLine("           |                 .      |                | |");
                    Console.WriteLine("           |                 |       L              ,' |");
                    Console.WriteLine("           `                 |       |             /   '");
                    Console.WriteLine("            |                |       |           ,'   /");
                    Console.WriteLine("          ,' |               |  _.._ ,-..___,..-'    ,'");
                    Console.WriteLine("         /     .             .      `!             ,j'");
                    Console.WriteLine("        /       `.          /        .           .'/");
                    Console.WriteLine("       .          `.       /         |        _.'.'");
                    Console.WriteLine("        `.          7`'---'          |------''_.'");
                    Console.WriteLine("       _,.`,_     _'                ,''-----''");
                    Console.WriteLine("   _,-_    '       `.     .'      ,|");
                    Console.WriteLine("   -' /`.         _,'     | _  _  _.|");
                    Console.WriteLine("    ''--'---''''''        `' '! |! /");
                    Console.WriteLine("                            `' ' -'   ");
                    Console.WriteLine("");
                    text = "Are you sure?\n - Yes\n - No";
                    TextScroll(text);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    sure = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.WriteLine("");
                    if (sure == "no")
                    {
                        text = "Which POKèMON do you want?\n - Charmander\n - Bulbasaur\n - Squirtle";
                        TextScroll(text);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        ans6 = Console.ReadLine().ToLower();
                        Console.ResetColor();
                    }
                }
                else if (ans6 == "bulbasaur")
                {
                    text = "You choose bulbasaur";
                    TextScroll(text);
                    Console.WriteLine("");
                    Console.WriteLine("                                           /");
                    Console.WriteLine("                        _,.------....___,.' ',.-.");
                    Console.WriteLine("                     ,-'          _,.--'        |");
                    Console.WriteLine("                   ,'         _.-'              .");
                    Console.WriteLine("                  /   ,     ,'                   `");
                    Console.WriteLine("                 .   /     /                     ``.");
                    Console.WriteLine("                 |  |     .                       /./");
                    Console.WriteLine("       ____      |___._.  |       __               / `.");
                    Console.WriteLine("     .'    `---''       ``'-.--''`  /               .  /");
                    Console.WriteLine("    .  ,            __               `              |   .");
                    Console.WriteLine("    `,'         ,-''  .               /             |    L");
                    Console.WriteLine("   ,'          '    _.'                -._          /    |");
                    Console.WriteLine("  ,`-.    ,'.   `--'                      >.      ,'     |");
                    Console.WriteLine(" . .' :   `-'       __    ,  ,-.         /  `.__.-      ,'");
                    Console.WriteLine(" ||:,  .          ,'  ;  /  / / `        `.    .      .'/");
                    Console.WriteLine(" /|:   /          `--'  ' ,'_  . .         `.__, /   , /");
                    Console.WriteLine("/ L:_  |                 .  '' :_;                `.'.'");
                    Console.WriteLine(".    '''                  ''''''                    V");
                    Console.WriteLine(" `.                                 .    `.   _,..  `");
                    Console.WriteLine("   `,_   .    .                _,-'/    .. `,'   __  `");
                    Console.WriteLine("    ) /`._        ___....----''  ,'   .'  / |   '  /  .");
                    Console.WriteLine("   /   `. '`-.--''         _,' ,'     `---' |    `./  |");
                    Console.WriteLine("  .   _  `'''--.._____..--'   ,             '         |");
                    Console.WriteLine("  | .' `. `-.                /-.           /          ,");
                    Console.WriteLine("  | `._.'    `,_            ;  /         ,'          .");
                    Console.WriteLine(" .'          /| `-.        . ,'         ,           ,");
                    Console.WriteLine(" '-.__ __ _,','    '`-..___;-...__   ,.'| ____.___.'");
                    Console.WriteLine(" `'^--'..'   '-`-^-''--    `-^-'`.'''''''`.,^.`.--' ");
                    Console.WriteLine("");
                    text = "Are you sure?\n - Yes\n - No";
                    TextScroll(text);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    sure = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.WriteLine("");
                    if (sure == "no")
                    {
                        text = "Which POKèMON do you want?\n - Charmander\n - Bulbasaur\n - Squirtle";
                        TextScroll(text);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        ans6 = Console.ReadLine().ToLower();
                        Console.ResetColor();
                    }
                }
                else if (ans6 == "squirtle")
                {
                    text = "You choose squirtle";
                    TextScroll(text);
                    Console.WriteLine("");
                    Console.WriteLine("               _,........__");
                    Console.WriteLine("            ,-'            '`-.");
                    Console.WriteLine("          ,'                   `-.");
                    Console.WriteLine("        ,'                        /");
                    Console.WriteLine("      ,'                           .");
                    Console.WriteLine("      .'                ,''.       `");
                    Console.WriteLine("     ._.'|             / |  `       /");
                    Console.WriteLine("     |   |            `-.'  ||       `.");
                    Console.WriteLine("     |   |            '-._,'||       | /");
                    Console.WriteLine("     .`.,'             `..,'.'       , |`-.");
                    Console.WriteLine("     l                       .'`.  _/  |   `.");
                    Console.WriteLine("     `-.._'-   ,          _ _'   -' /  .     `");
                    Console.WriteLine("`.''''''-.`-...,---------','         `. `....__.");
                    Console.WriteLine(".'        `'-..___      __,'/          /  /     /");
                    Console.WriteLine("/_ .          |   `'''''    `.           . /     /");
                    Console.WriteLine("  `.          |              `.          |  .     L");
                    Console.WriteLine("    `.        |`--...________.'.        j   |     |");
                    Console.WriteLine("      `._    .'      |          `.     .|   ,     |");
                    Console.WriteLine("         `--,/       .            `7''' |  ,      |");
                    Console.WriteLine("            ` `      `            /     |  |      |    _,-''''`-.");
                    Console.WriteLine("             / `.     .          /      |  '      |  ,'          `.");
                    Console.WriteLine("              /  v.__  .        '       .   /    /| /              /");
                    Console.WriteLine("               //    `''/'''''''`.       /   /  /.''                |");
                    Console.WriteLine("                `        .        `._ ___,j.  `/ .-       ,---.     |");
                    Console.WriteLine("                ,`-.      /         .'     `.  |/        j     `    |");
                    Console.WriteLine("               /    `.     /       /         / /         |     /    j");
                    Console.WriteLine("              |       `-.   7-.._ .          |'          '         /");
                    Console.WriteLine("              |          `./_    `|          |            .     _,'");
                    Console.WriteLine("              `.           / `----|          |-............`---'");
                    Console.WriteLine("                /          /      |          |");
                    Console.WriteLine("               ,'           )     `.         |");
                    Console.WriteLine("                7____,,..--'      /          |");
                    Console.WriteLine("                                  `---.__,--.'");
                    Console.WriteLine("");
                    text = "Are you sure?\n - Yes\n - No";
                    TextScroll(text);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    sure = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    Console.WriteLine("");
                    if (sure == "no")
                    {
                        text = "Which POKèMON do you want?\n - Charmander\n - Bulbasaur\n - Squirtle";
                        TextScroll(text);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        ans6 = Console.ReadLine().ToLower();
                        Console.ResetColor();
                    }
                }
                else
                {
                    text = "Enter a valid input!";
                    TextScroll(text);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    ans6 = Console.ReadLine().ToLower();
                    Console.ResetColor();
                }
            }
            text = "You recieve " + ans6 + "\nOAK: Now that you have a pokemon you can fight other wild pokemon\n\nWhat do you want to do?\n - Leave\n - Talk to Prof. Oak\n - Talk to Gary\n - Talk to lab assistant";
            TextScroll(text);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            ans7 = Console.ReadLine().ToLower();
            Console.ResetColor();
            Console.WriteLine("");

            while (ans7 != "leave")
            {
                if (ans7 == "talk to prof. oak")
                {
                    text = "OAK: What are you still doing here?\nGo out there and catch POKèMON!";
                    TextScroll(text);
                }
                else if (ans7 == "talk to gary")
                {
                    text = "Get out of my way!\nIm going to go train my POKèMON";
                    TextScroll(text);
                }
                else if (ans7 == "talk to lab assistant")
                {
                    text = "You can level you POKèMON by beating other POKèMON";
                    TextScroll(text);
                }
                else
                {
                    text = "Enter a valid input!";
                    TextScroll(text);
                }
                text = "\nWhat do you want to do?";
                TextScroll(text);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                ans7 = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
        public static void TextScroll(string Text)
        {
            char Character;
            int Position = 0;
            int E = 0;
            int F = Text.Length;
            bool G = true;
            while (F > Position)
            {
                Character = Text[Position];
                E++;
                if (G == true)
                {
                    Console.Write(Character);
                }
                G = true;
                System.Threading.Thread.Sleep(30);
                if (E == 0)
                {
                    System.Threading.Thread.Sleep(250);
                }
                Position++;
            }
            Console.WriteLine("");
        }
    }
}
#pragma warning restore
