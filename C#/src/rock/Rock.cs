namespace C_.src.rock
{
    /// <summary>
    /// Rock Object
    /// </summary>
    public class Rock
    {
        /// <summary>
        /// Position X
        /// </summary>
        public int x;
        /// <summary>
        /// Position Y
        /// </summary>
        public int y;

        /// <summary>
        /// Rock Speed
        /// </summary>
        int speed = 0;
        /// <summary>
        /// Rock Max Speed
        /// </summary>
        public static int maxSpeed = 3;



        /// <summary>
        /// Rock Object
        /// </summary>
        /// <param name="x">Rock x position</param>
        /// <param name="y">Rock y position</param>
        public Rock(int x, int y){
            this.x = x;
            this.y = y;
        }



        /// <summary>
        /// Updates Rock
        /// </summary>
        public void Update(){
            if(speed == maxSpeed){
                y++; // Moves This Rock Down
                speed = 0; // Resets Speed
            }else{
                speed++; // Adds Speed Movement
            }
        }
    }
}