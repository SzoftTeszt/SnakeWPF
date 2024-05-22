using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Position
    {
        public int X {  get; set; }
        public int Y {  get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }  
        public Position(Position p)
        {
            X = p.X;
            Y = p.Y;
        }         
        public Position()
        {
            Random rnd = new Random();
            X = rnd.Next(20);
            Y = rnd.Next(20);
        }


    }
}
