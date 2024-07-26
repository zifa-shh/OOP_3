using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Ellipse : TCircle
    {
        public int axle { get; set; }
        public Ellipse(int _x, int _y, int _r, int _axle) : base(_x, _y, _r)
        {
            this.axle = _axle;
        }

        public Ellipse()
        {
            Random random = new Random();
           
            this.axle = random.Next(10, 200);
        }

        public override void Show(Graphics canvas, Color color, int canvasWidth, int canvasHeight)
        {
            var pen = new Pen(color, 4);

            if (IsWithinCanvas(x, y, r, axle, canvasWidth, canvasHeight))
            {
                var xTopLeft = x - axle;
                var yTopLeft = y - r;

                canvas.DrawEllipse(pen, xTopLeft, yTopLeft, 2 * axle, 2 * r);
            }
        }


        public bool IsWithinCanvas(int x, int y, int r, int axle, int canvasWidth, int canvasHeight)
        {
            int xLeft = x - axle;
            int xRight = x + axle;
            int yTop = y - r;
            int yBottom = y + r;

            return xLeft >= 4 && xRight <= canvasWidth && yTop >= 4 && yBottom <= canvasHeight;
        }

        //public bool Rotate(int canvasWidth, int canvasHeight)
        //{

        //    int temp = this.r;
        //    this.r = this.axle;
        //    this.axle = temp;
        //    if (IsWithinCanvas(x, y, this.r, this.axle, canvasWidth, canvasHeight))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        this.axle = this.r;
        //        this.r = temp;

        //        return false;
        //    }
        //}
        public override void Remove(Graphics gc)
        {
            Pen pen = new Pen(SystemColors.Control, 5);
            gc.DrawEllipse(pen, this.x - this.axle, this.y - this.r, 2 * this.axle, 2 * this.r);
        }

        public override void Rotate()
        {
            int temp = this.r;
            this.r = this.axle;
            this.axle = temp;
        }


        public int GetAxle()
        {
            return this.axle;
        }

    }
}
