using System;
using System.Drawing;


namespace ClassLibrary
{
    public class TCircle: TFigure
    {
        public int r { get; set; }


        public TCircle(int _x, int _y, int _r) : base(_x, _y) 
        {
            this.r = _r;
        }

        public TCircle() : base()
        {
            Random random = new Random();
            this.r = random.Next(5, 100);
        }

        

        public override void ChangeRadius(int rad, int canvasWidth, int canvasHeight)
        {
            //int newRadius = rad;
            //if (IsWithinCanvas(this.x, this.y, newRadius, canvasWidth, canvasHeight))
            //{
            //    this.r = newRadius;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            this.r = rad;
        }

        public override void Show(Graphics canvas, Color color, int canvasWidth, int canvasHeight)
        {
            var pen = new Pen(color, 4);

            if (IsWithinCanvas(x, y, r, canvasWidth, canvasHeight))
            {
                var xTopLeft = x - r;
                var yTopLeft = y - r;

                canvas.DrawEllipse(pen, xTopLeft, yTopLeft, r * 2, r * 2);
            }
        }

        //public override bool MoveTo(int newX, int newY, int canvasWidth, int canvasHeight)
        //{
        //    int tempX = x + newX;
        //    int tempY = y + newY;

        //    if (IsWithinCanvas(tempX, tempY, r, canvasWidth, canvasHeight))
        //    {
        //        x = tempX;
        //        y = tempY;
        //        return true;
        //    }

        //    return false;
        //}

        
        
        public bool IsWithinCanvas(int x, int y, int r, int canvasWidth, int canvasHeight)
        {
            int xTopLeft = x - r;
            int yTopLeft = y - r;

            return xTopLeft >= 4 && yTopLeft >= 4 &&
                   xTopLeft + 2 * r <= canvasWidth && yTopLeft + 2 * r <= canvasHeight;
        }
        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public int GetR()
        {
            return this.r;
        }
        public override void Remove(Graphics gc)
        {
            Pen pen = new Pen(SystemColors.Control, 5);
            gc.DrawEllipse(pen, this.x - this.r, this.y - this.r, 2 * this.r, 2 * this.r);
        }
    }
}
