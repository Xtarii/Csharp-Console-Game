using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_.src.world;

namespace C_.src.player
{
    /// <summary>
    /// Player Object
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Player Color
        /// </summary>
        public ConsoleColor color = ConsoleColor.Green;

        /// <summary>
        /// Player X Position
        /// </summary>
        int pos_x = Program.World_Width / 2;
        /// <summary>
        /// Player Y Position
        /// </summary>
        int pos_y = Program.World_Height - 1;
        /// <summary>
        /// Player Speed
        /// </summary>
        public static int speed = 1;

        /// <summary>
        /// Player Health
        /// </summary>
        public int health = 3;

        /// <summary>
        /// Input Key Listener
        /// </summary>
        KeyListener keyListener;



        /// <summary>
        /// Player Object
        /// </summary>
        /// <param name="keyListener">Key Listener</param>
        public Player(KeyListener keyListener){
            this.keyListener = keyListener; // Setting Input Key Listener
        }

        /// <summary>
        /// Player Update
        /// </summary>
        public void Update(){
            // Player Movement
            pos_x += keyListener.Vertical * speed;


            // World Bounds
            if(pos_x == Program.World_Width)
                pos_x = 0;
            if(pos_x == -1)
                pos_x = Program.World_Width - 1;


            // Health
            if(health <= 0)
                Environment.Exit(0);
        }

        public void DrawStats(){
            // Player: Speed
            Renderer.RenderStatType(
                "Player Speed", speed.ToString(),
                // Colors
                ConsoleColor.DarkCyan, ConsoleColor.Black,
                ConsoleColor.Gray
            );

            // Player: Health
            Renderer.RenderStatType(
                "Player Health", health.ToString(),
                // Colors
                ConsoleColor.DarkCyan, ConsoleColor.Black,
                
                // Player Health: Normal = Gray, Low = Red
                health > 1 ? ConsoleColor.Gray : ConsoleColor.Red
            );
        }





        public int x{
            get { return pos_x; }
        }
        public int y{
            get { return pos_y; }
        }
    }
}