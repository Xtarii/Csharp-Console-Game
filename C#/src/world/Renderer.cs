using C_.src.rock;

namespace C_.src.world
{
    /// <summary>
    /// Render Object
    /// </summary>
    public sealed class Renderer
    {
        /// <summary>
        /// Renders Tile to World Space
        /// </summary>
        /// <param name="model">Tile Model</param>
        /// <param name="color">Tile Color</param>
        public static void RenderTile(string model, ConsoleColor color){
            Console.ForegroundColor = color; // Color Config
            Console.Write(model); // Prints Model


            Console.ForegroundColor = ConsoleColor.White; // Resets Color
        }

        /// <summary>
        /// Renders Game Status
        /// </summary>
        /// <param name="status">Status Name</param>
        /// <param name="value">Status Value</param>
        /// <param name="c1">Name Color</param>
        /// <param name="c2">Value Color</param>
        /// <param name="background">Background Color</param>
        public static void RenderStatType(
            string status, string value, 
            ConsoleColor c1, ConsoleColor c2,
            ConsoleColor background
        ){
            // Color Config
            Console.BackgroundColor = background;
            Console.ForegroundColor = c1;

            // Prints Message
            Console.Write(status + ": ");

            Console.ForegroundColor = c2;
            Console.Write(value);


            // Resets Color
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n"); // New Empty Line
        }



        /// <summary>
        /// Draw Game Scene
        /// </summary>
        public static void Draw(){
            // Clears Console
            Console.Clear();

            // Padding
            for(int p = 0; p < Program.Padding_Top; p++){
                Console.WriteLine();
            }


            // Draws Map, Y Axis
            for(int y = 0; y < Program.World_Height; y++){
                // Padding
                for(int p = 0; p < Program.Padding_Left; p++){
                    Console.Write(" ");
                }

                // X Axis
                for(int x = 0; x < Program.World_Width; x++){
                    // Draws Player
                    if(Program.player?.x == x && Program.player?.y == y){
                        RenderTile("[]", Program.player.color);
                        continue;
                    }

                    // Check For Rocks
                    bool r = false;
                    for(int i = 0; i < Program.rocks.Count; i++){
                        Rock rock = Program.rocks[i]; // Getting Rock

                        // Check Rock Position
                        if(rock.x == x && rock.y == y){
                            RenderTile("[]", ConsoleColor.DarkRed);
                            r = true;
                        }
                    }


                    // Renders Normal Tile Or Floor
                    if(r == false)
                        RenderTile((y == Program.World_Height - 1) ? "--" : "  ", ConsoleColor.Magenta);
                }
                Console.WriteLine(); // New Render Line
            }
            Console.WriteLine(); // New Empty Line



            // Draws Game Stats
            RenderStatType(
                "[w/s] Frame Update", // Name
                Program.FPS + "/" + Program.FPS_damper + "/" + Program.FPS * Program.FPS_damper, // Value
                
                // Text Colors
                ConsoleColor.DarkCyan, // Name
                ConsoleColor.Black, // Value
                
                ConsoleColor.Gray); // Background Color
        }
    }
}