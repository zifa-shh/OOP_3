using System;
using System.Drawing;

namespace ClassLibrary
{
    public class Line: TFigure
    {
       

        public Line(int _x, int _y, int _x1, int _y1) : base(_x, _y)
        {
            this.x1 = _x1;
            this.y1 = _y1;
        }

        

        public Line()
        {
            Random random = new Random();
            this.x = random.Next(0, 508);
            this.y = random.Next(0, 418);
            this.x1 = random.Next(0, 508);
            this.y1 = random.Next(0, 418);
        }

        public override void Show(Graphics canvas, Color color, int canvasWidth, int canvasHeight)
        {
            var pen = new Pen(color, 4);

            if (IsWithinCanvas(x, y, x1, y1, canvasWidth, canvasHeight))

            {
                canvas.DrawLine(pen, x, y, x1, y1);
            }
        }

        //public override bool MoveTo(int newX, int newY, int canvasWidth, int canvasHeight)
        //{

        //    int tempX = x + newX;
        //    int tempX1 = x1 + newX;
        //    int tempY = y + newY;
        //    int tempY1 = y1 + newY;

        //    if (IsWithinCanvas(tempX, tempY, tempX1, tempY1, canvasWidth, canvasHeight))
        //    {
        //        x = tempX;
        //        x1 = tempX1;
        //        y = tempY;
        //        y1 = tempY1;
        //        return true;
        //    }

        //    return false;
        //}

        
        public bool IsWithinCanvas(int X, int Y, int X1, int Y1, int canvasWidth, int canvasHeight)
        {
            return X >= 4 && Y >= 4 && X1 >= 4 && Y1 >= 4 &&
                   X <= canvasWidth && Y <= canvasHeight &&
                   X1 <= canvasWidth && Y1 <= canvasHeight;
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public int GetX1()
        {
            return this.x1;
        }

        public int GetY1()
        {
            return this.y1;
        }

        public override void Remove(Graphics gc)
        {
            Pen pen = new Pen(SystemColors.Control, 5);
            gc.DrawLine(pen, this.x, this.y, this.x1, this.y1);
        }
    }
}

