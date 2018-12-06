using System;

namespace RobotApplication
{
    
    class Arena
    {
        public int maxX {get; set;}
        public int maxY {get; set;}

        public void SetArena(int x, int y)
        {
            maxX = x;
            maxY = y;
        }

    }
}
