using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DragonAndThePrincess
{
    internal class Game
    {

        public bool GameOver = true;
       
        public Location TheLocation { get; set; }
        public List<Items> Inventory { get; set; }
        public Heroes SelectedTheHero { get; set; }

        Items dragonSlayer = new Items("Dragon Slayer\n");
        Items onePunchHand = new Items("One Punch hand\n");
        Items antiTitanBlades = new Items("Anti-titan Blades\n");

        public Game() 
        {
            
            Inventory = new List<Items>();
            GameOver = false;
            SelectTheHero();
            TheLocation = new Location("Village", "");
           
        }

        public void Options()
        {
            Console.WriteLine("Choose something: ");
            Console.WriteLine("1. Lets get going to another location");
            Console.WriteLine("2. Talk to the dragon");
            Console.WriteLine("3. Your inventory");
            Console.WriteLine("9. Quit\n");
            
        }

        public void SelectTheHero()
        {
            Console.WriteLine("Pick a Hero you like:");
            Console.WriteLine("1. Little John The Drunk");
            Console.WriteLine("2. SlickRick The Quick");
            Console.WriteLine("3. PegLegJoe");
            Console.WriteLine("4. Drakulf");

            int Choosenhero = int.Parse(Console.ReadLine());

            switch (Choosenhero)
            {
                case 1:
                    SelectedTheHero = new Heroes("Little John The Drunk", "Barbarian");
                    break;

                case 2:
                    SelectedTheHero = new Heroes("SlickRick The Quick", "Necromancer");
                    break;

                case 3:
                    SelectedTheHero = new Heroes("PegLegJoe", "Paladin");
                    break;

                case 4:
                    SelectedTheHero = new Heroes("Drakulf", "Coward");
                    Console.WriteLine("A pack of wolfs appears and starts to attack drakulf");
                    Console.WriteLine("Drakulf is a known coward and deserves to get eaten");
                    GameOver = true;
                    break;

                default:
                    Console.WriteLine("Stupid, you can choose that.");
                    SelectedTheHero = new Heroes("Little John The Drunk", "Barbarian");
                    break;
            }
            if(!GameOver)
            {
                Console.WriteLine("Your hero of choice is " + SelectedTheHero.Name);
            }
            
        }

        public void MenuInput(string input)
        {
            switch (input)
            {
                case "1":
                    StartMoving();
                    break;
                case "2":
                    TalkToDragon();
                    break;
                case "3":
                    TheInventory();
                    break;
                case "9":
                    GameOver = true;
                    Console.WriteLine("Thank you for not playing i guess");
                    break;
                default:
                    Console.Write("Didnt work, try again");
                    break;
            }
        }

        private void StartMoving()
        {
            try
            {
                string[] locations = { "The bush", "The man with the yellow outfit and a cape", "Cathedral\n" };
                Console.Write("Lets get going! ");

                for (int i = 0; i < locations.Length; i++)
                {
                    Console.WriteLine("\n" + (i + 1).ToString() + ". " + locations[i]);
                }

                int thepick;
                while (!int.TryParse(Console.ReadLine(), out thepick) || thepick < 1 || thepick > locations.Length)
                {
                    Console.WriteLine("Cant choose that, enter 1-3 please");
                }

                string locationName = locations[thepick - 1];
                string locationDescription = "Your location" + locationName + " item you found.";

                TheLocation = new Location(locationName, locationDescription);

                switch (thepick)
                {
                    case 1:
                        
                        Inventory.Add(dragonSlayer);
                        Console.WriteLine("\nYou have found Dragon Slayer Sword\n");
                        break;
                    case 2:
                        
                        Inventory.Add(onePunchHand);
                        Console.WriteLine("You Borrow Saitamas hand\n");
                        break;
                    case 3:
                        
                        Inventory.Add(antiTitanBlades);
                        Console.WriteLine("A man jumps down from the roof and hands you Anti-Titan Blades\n");
                        break;
                }
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Has to be a number.");
            }



        }
        private void TalkToDragon()

        {
            
            {
                Console.WriteLine("\nYou walk up to the dragon");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("\n1. Speak to the dragon");
                Console.WriteLine("2. Attack the dragon");

                int dragonChooses;
                while (!int.TryParse(Console.ReadLine(), out dragonChooses) || (dragonChooses != 1 && dragonChooses != 2))

                {
                    Console.WriteLine("Choose something else. Options are 1 to speak to the dragon and 2 to attack it");
                    return;
                }

                if (dragonChooses == 1)
                {

                    Console.WriteLine("The dragon is friendly, you may have the princess");
                    GameOver = true;
                    return;
                }

                if (dragonChooses == 2 && Inventory.Contains(dragonSlayer) && Inventory.Contains(onePunchHand) && Inventory.Contains(antiTitanBlades))
                { 
 
                        Console.WriteLine("You walk up to the dragon!");
                        Console.WriteLine("YOU KILL THE DRAGON, PRINCESS IS YOURS!");
                        GameOver = true;
                }
                else
                {
                    Console.WriteLine("\nYou dont have all the weapons! ");
                    Console.WriteLine("The dragon attacks and eats you!!\n");
                    GameOver = true;
                }
                
                  
                

                


                

                
                        
                
            }
        }    
        
        private void TheInventory()
        {
            Console.WriteLine("Inventory Contains: ");
            foreach (var item in Inventory)
            {
                
                Console.WriteLine(item.name);
            
            }
            if (Inventory.Count == 0)
            {
                Console.WriteLine("An Empty Inventory\n");
            }
            
            
        }
    }
}
