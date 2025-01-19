using System;
using System.Collections.Generic;

namespace TextAdventureGame
{
    class Program
    {
        static int health = 100;
        static List<string> inventory = new List<string>();
        static bool hasKey = false;

        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            Console.WriteLine("Welcome to the Text Adventure Game!");
            Console.WriteLine("You find yourself in a dark forest. There are two paths ahead.");
            Console.WriteLine("1. Take the left path.");
            Console.WriteLine("2. Take the right path.");
            Console.WriteLine("3. Stay where you are.");
            Console.WriteLine("4. Check your inventory.");
            string choice = Console.ReadLine();

            if (choice == "1")
                LeftPath();
            else if (choice == "2")
                RightPath();
            else if (choice == "3")
                Stay();
            else if (choice == "4")
                CheckInventory();
            else
                InvalidChoice();
        }

        static void LeftPath()
        {
            Console.WriteLine("You took the left path and encountered a wild bear.");
            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Run away.");
            Console.WriteLine("2. Fight the bear.");
            Console.WriteLine("3. Try to befriend the bear.");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("You ran away safely and stumbled upon a hidden cave. Do you enter it? (yes/no)");
                string caveChoice = Console.ReadLine();
                if (caveChoice.ToLower() == "yes")
                {
                    CaveScenario();
                }
                else
                {
                    Console.WriteLine("You chose not to enter the cave and found your way out of the forest. You win!");
                    EndGame();
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("You tried to fight the bear.");
                BearFight();
            }
            else if (choice == "3")
            {
                Console.WriteLine("The bear seems to like you and shows you a hidden path out of the forest. Along the way, you find a magical spring that grants you eternal luck. You win!");
                EndGame();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                LeftPath();
            }
        }

        static void RightPath()
        {
            Console.WriteLine("You took the right path and found a hidden treasure chest.");
            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Open the chest.");
            Console.WriteLine("2. Ignore the chest and keep walking.");
            Console.WriteLine("3. Look around for traps.");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                OpenChest();
            }
            else if (choice == "2")
            {
                Console.WriteLine("You ignored the chest and kept walking. You find a serene lake with a boat. Do you take the boat across? (yes/no)");
                string boatChoice = Console.ReadLine();
                if (boatChoice.ToLower() == "yes")
                {
                    Console.WriteLine("You rowed across the lake and found a village. You’re safe and win!");
                    EndGame();
                }
                else
                {
                    Console.WriteLine("You stayed on the shore and eventually got lost in the forest. You lost.");
                    EndGame();
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("You found a hidden trap near the chest and disabled it. Inside, you found a magical artifact that grants you a wish. You win!");
                EndGame();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                RightPath();
            }
        }

        static void Stay()
        {
            Console.WriteLine("You decided to stay where you are. Night falls, and you hear strange noises around you.");
            Console.WriteLine("What do you do?");
            Console.WriteLine("1. Build a fire.");
            Console.WriteLine("2. Climb a tree to stay safe.");
            Console.WriteLine("3. Call for help.");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("You built a fire to keep warm, but the light attracted a pack of wolves. You lost.");
                EndGame();
            }
            else if (choice == "2")
            {
                Console.WriteLine("You climbed a tree and stayed safe through the night. At dawn, you found your way out. You win!");
                EndGame();
            }
            else if (choice == "3")
            {
                Console.WriteLine("You called for help, and a group of travelers heard you. They guided you out of the forest. You win!");
                EndGame();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Stay();
            }
        }

        static void BearFight()
        {
            Console.WriteLine("The bear attacks you. You lose 30 health.");
            health -= 30;

            if (health <= 0)
            {
                Console.WriteLine("You succumbed to your injuries. Game over.");
                EndGame();
            }
            else
            {
                Console.WriteLine("You managed to escape but are injured. Health: " + health);
                Console.WriteLine("You stumble upon a healer’s hut. Do you enter? (yes/no)");
                string healerChoice = Console.ReadLine();

                if (healerChoice.ToLower() == "yes")
                {
                    Console.WriteLine("The healer restores your health to full. You continue your journey.");
                    health = 100;
                    EndGame();
                }
                else
                {
                    Console.WriteLine("You chose not to enter and eventually succumbed to your injuries. You lost.");
                    EndGame();
                }
            }
        }

        static void CaveScenario()
        {
            Console.WriteLine("Inside the cave, you find a glowing sword and a mysterious map. Which do you take? (sword/map/both)");
            string caveChoice = Console.ReadLine();

            if (caveChoice.ToLower() == "sword")
            {
                inventory.Add("Sword");
                Console.WriteLine("You took the sword. It might come in handy.");
                EndGame();
            }
            else if (caveChoice.ToLower() == "map")
            {
                inventory.Add("Map");
                Console.WriteLine("You took the map. It reveals a secret exit from the forest.");
                EndGame();
            }
            else if (caveChoice.ToLower() == "both")
            {
                inventory.Add("Sword");
                inventory.Add("Map");
                Console.WriteLine("You took both the sword and the map. You feel well-prepared for the journey ahead.");
                EndGame();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                CaveScenario();
            }
        }

        static void OpenChest()
        {
            Console.WriteLine("You opened the chest and found a pile of gold coins. However, a mystical guardian appears and asks you a riddle. Answer correctly to keep the gold. What has keys but can’t open locks? (type your answer)");
            string riddleAnswer = Console.ReadLine();
            if (riddleAnswer.ToLower() == "piano")
            {
                Console.WriteLine("Correct! The guardian vanishes, and you keep the gold. You win!");
                inventory.Add("Gold Coins");
                EndGame();
            }
            else
            {
                Console.WriteLine("Wrong answer. The guardian curses you, and you lose the treasure. You lost.");
                EndGame();
            }
        }

        static void CheckInventory()
        {
            Console.WriteLine("Your inventory contains:");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Nothing yet.");
            }
            else
            {
                foreach (string item in inventory)
                {
                    Console.WriteLine("- " + item);
                }
            }
            Console.WriteLine("Health: " + health);
            StartGame();
        }

        static void InvalidChoice()
        {
            Console.WriteLine("Invalid choice. Please try again.");
            StartGame();
        }

        static void EndGame()
        {
            Console.WriteLine("Game Over. Do you want to play again? (y/n)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                health = 100;
                inventory.Clear();
                StartGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing! Goodbye!");
            }
        }
    }
}
