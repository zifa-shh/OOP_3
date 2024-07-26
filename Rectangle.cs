using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Rectangle : TSquare
    {
        public int width { get; set; }
        public Rectangle(int _x, int _y, int _width, int _sideLength) : base(_x, _y, _sideLength)
        {
            this.width = _width;
        }
        public Rectangle() : base()
        {
            Random random = new Random();
            this.width = random.Next(10, 200);
        }
        public override void Show(Graphics gc, Color color, int canvasWidth, int canvasHeight)
        {
            var pen = new Pen(color, 5);
            int xTopLeft = this.x - (this.width / 2);
            int yTopLeft = this.y - (this.sideLength / 2);

            if (IsWithinCanvas(x, y, width, sideLength, canvasWidth, canvasHeight))
            {
                gc.DrawRectangle(pen, xTopLeft, yTopLeft, this.width, this.sideLength);
            }
        }

        public bool IsWithinCanvas(int x, int y, int width, int sideLength, int canvasWidth, int canvasHeight)
        {
            int xTopLeft = x - (width / 2);
            int yTopLeft = y - (sideLength / 2);

            return xTopLeft >= 0 && yTopLeft >= 0 &&
                   xTopLeft + width <= canvasWidth && yTopLeft + sideLength <= canvasHeight;
        }

        //public override bool MoveTo(int newX, int newY, int canvasWidth, int canvasHeight)
        //{
        //    int tempX = this.x + newX;
        //    int tempY = this.y + newY;



        //    if (IsWithinCanvas(tempX, tempY, width, sideLength, canvasWidth, canvasHeight))

        //    {
        //        this.x = tempX;
        //        this.y = tempY;
        //        return true;
        //    }

        //    return false;
        //}
        public int GetW()
        {
            return this.width;
        }
        public override void Remove(Graphics gc)
        {
            Pen pen = new Pen(SystemColors.Control, 5);
            gc.DrawRectangle(pen, this.x - (this.width / 2), this.y - (this.sideLength / 2), this.width, this.sideLength);
        }
    }
}
