using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_.src
{
    public class KeyListener
    {
        /// <summary>
        /// Movement Vertical
        /// </summary>
        int vertical = 0;
        /// <summary>
        /// Movement Horizontal
        /// </summary>
        int horizontal = 0;



        /// <summary>
        /// User Input Listener
        /// </summary>
        public KeyListener(){
            // Turns off Ctrl + C Exit
            Console.TreatControlCAsInput = true;

            // KeyListener Thread
            Thread thread = new(new ThreadStart(Listener));
            thread.Start();
        }



        /// <summary>
        /// Key Listener
        /// </summary>
        void Listener(){
            do{
                // Clear input buffer
                while(Console.KeyAvailable)
                    Console.ReadKey(true);
                ConsoleKey key = Console.ReadKey(true).Key; // User Input Key Reader

                // Handling Key Events
                if(key == ConsoleKey.Escape){
                    Environment.Exit(0); // Stops Program
                }


                #region Movement
                switch(key){
                    // Up
                    case ConsoleKey.W:
                        horizontal = -1;
                        break;

                    // Down
                    case ConsoleKey.S:
                        horizontal = 1;
                        break;

                    // Left
                    case ConsoleKey.A:
                        vertical = -1;
                        break;
                    
                    // Right
                    case ConsoleKey.D:
                        vertical = 1;
                        break;
                }


                // Suspends thread after 60 FPS count
                Thread.Sleep(Program.FPS * 4);

                horizontal = 0; // Resets horizontal Movement
                vertical   = 0; // Resets vertical Movement
                #endregion
            
            }while(Program.Run);
        }




        /// <summary>
        /// Vertical Movement, X Axis
        /// </summary>
        public int Vertical{
            get { return vertical; }
        }
        /// <summary>
        /// Horizontal Movement, Y Axis
        /// </summary>
        public int Horizontal{
            get { return horizontal; }
        }
    }
}