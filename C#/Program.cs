using C_.src;
using C_.src.player;
using C_.src.rock;
using C_.src.world;

namespace C_
{
    /// <summary>
    /// Main Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program: Run
        /// </summary>
        static bool run = true;
        /// <summary>
        /// Application FPS
        /// </summary>
        public static int FPS { get; set; } = 60;
        /// <summary>
        /// FPS Screen Update Damper
        /// </summary>
        public static int FPS_damper { get; set; } = 2;
        /// <summary>
        /// Top Side Space for Game Scene
        /// </summary>
        public static int Padding_Top { get; } = 5;
        /// <summary>
        /// Left Side Space for Game Scene
        /// </summary>
        public static int Padding_Left { get; } = 5;

        /// <summary>
        /// World Width Render
        /// </summary>
        public static int World_Width { get; } = 20;
        /// <summary>
        /// World Height Render
        /// </summary>
        public static int World_Height { get; } = 7;

        /// <summary>
        /// Game Player Object
        /// </summary>
        public static Player? player;
        /// <summary>
        /// Game Score
        /// </summary>
        public static int score = 0;

        /// <summary>
        /// Rock Spawn Rarity
        /// </summary>
        public static int rockSpawn = 5;
        /// <summary>
        /// Game Rocks List
        /// </summary>
        public static List<Rock> rocks = new List<Rock>();

        /// <summary>
        /// Last Score ( Rarity Update )
        /// </summary>
        static int lastScore = 0;
        /// <summary>
        /// Score Update Boost
        /// </summary>
        static int nextBoost = 5;



        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args">Parameters</param>
        public static void Main(string[] args)
        {
            Random random = new(); // Creates Random
            KeyListener keyListener = new(); // Creates KeyListener
            
            player = new(keyListener); // Creates Player



            // Main Thread
            while(run){
                // Game Render
                Renderer.Draw();
                
                // Render Rock Spawn Rarity
                string value = rockSpawn + " / " + (lastScore + nextBoost); // Value
                Renderer.RenderStatType("Rock Rarity", value,
                ConsoleColor.DarkCyan, ConsoleColor.Black, ConsoleColor.Gray);
                
                player.DrawStats(); // Draws Player Status
                Renderer.RenderStatType("Score", score.ToString(),
                ConsoleColor.DarkMagenta, ConsoleColor.Black, ConsoleColor.Blue);



                // FPS Damper Controlls, Reverse Controlls
                FPS_damper += (keyListener.Horizontal == -1 && FPS_damper == 1) ? 0 : keyListener.Horizontal;

                // Update ( player )
                player.Update();

                // Rocks Update
                int chance = random.Next(100); // Spawn Chance
                if(chance < rockSpawn){
                    Rock rock = new(random.Next(World_Width), 0); // New Rock
                    rocks.Add(rock); // Adds new Rock
                }

                // Update Rocks
                for(int i = 0; i < rocks.Count; i++){
                    Rock rock = rocks[i]; // Getting Rock

                    // Update Rock
                    rock.Update();

                    // Checks Rocks Position
                    if(rock.x == player.x && rock.y == player.y){
                        // Damage Player
                        player.health--;
                        // Removes Player Score if posible
                        score -= score > 0 ? 1 : 0;
                        
                        // Destroy Rock
                        rocks.RemoveAt(i);


                    // World Bounds
                    }else if(rock.y == World_Height){
                        // Adds on Player Score
                        score++;

                        // Destroy Rock
                        rocks.RemoveAt(i);
                    }
                }

                // Update Rock Rarity
                if((lastScore + nextBoost) == score){
                    // Setup
                    lastScore = score;
                    nextBoost += lastScore / 2;

                    // Rarity Change
                    rockSpawn += rockSpawn != 100 ? 5 : 0;
                }


                // FPS Controller
                Thread.Sleep(FPS * FPS_damper);
            }
        }



        /// <summary>
        /// Program Run
        /// </summary>
        public static bool Run{
            get { return run; }
        }
    }
}
