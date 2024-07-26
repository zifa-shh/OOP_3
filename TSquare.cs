using System;
using System.Drawing;


namespace ClassLibrary
{
    public class TSquare: TFigure
    {
        
        public int sideLength;

        public TSquare(int _x, int _y, int _sideLenght) : base(_x, _y)
        {

            this.sideLength = _sideLenght;
        }


        public TSquare() : base()
        {
            Random random = new Random();
            this.sideLength = random.Next(10, 150);
        }

        
        public override void Show(Graphics canvas, Color color, int canvasWidth, int canvasHeight)
        {
            var pen = new Pen(color, 4);

            if (x >= 0 && y >= 0 && sideLength > 0)
            {
                var xTopLeft = x - sideLength / 2;
                var yTopLeft = y - sideLength / 2;

                if (IsWithinCanvas(x, y, sideLength, canvasWidth, canvasHeight))
                {
                    canvas.DrawRectangle(pen, xTopLeft, yTopLeft, sideLength, sideLength);
                }
            }
        }

        public bool IsWithinCanvas(int x, int y, int SideLength, int canvasWidth, int canvasHeight)
        {
            return x - SideLength / 2 >= 4 && y - SideLength / 2 >= 4 &&
                   x + SideLength / 2 <= canvasWidth && y + SideLength / 2 <= canvasHeight;
        }

        //public override bool MoveTo(int newX, int newY, int canvasWidth, int canvasHeight)
        //{
        //    int tempX = x + newX;
        //    int tempY = y + newY;

        //    if (IsWithinCanvas(tempX, tempY, sideLength, canvasWidth, canvasHeight))
        //    {
        //        x = tempX;
        //        y = tempY;
        //        return true;
        //    }

        //    return false;
        //}

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public int GetSL()
        {
            return this.sideLength;
        }
        public override void Remove(Graphics gc)
        {
            Pen pen = new Pen(SystemColors.Control, 5);
            gc.DrawRectangle(pen, this.x - (this.sideLength / 2), this.y - (this.sideLength / 2), this.sideLength, this.sideLength);
        }

       
    }
}
