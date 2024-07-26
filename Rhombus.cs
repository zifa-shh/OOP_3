using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Rhombus : TSquare
    {
        public int width { get; set; }

        public Rhombus(int _x, int _y, int _sideLength, int _width) : base (_x, _y, _sideLength)
        {
            this.width = _width;
        }

        public Rhombus() : base()
        {
            Random random = new Random();
            this.width = random.Next(10, 200);
        }
        
        public override void Show(Graphics gc, Color color, int canvasWidth, int canvasHeight)
        {
            var pen = new Pen(color, 5);
            Point[] points = new Point[4];

            // координаты вершин ромба
            Point top = new Point(this.x, this.y - this.sideLength / 2);
            Point bottom = new Point(this.x, this.y + this.sideLength / 2);
            Point left = new Point(this.x - this.width / 2, this.y);
            Point right = new Point(this.x + this.width / 2, this.y);

            points[0] = top;
            points[1] = left;
            points[2] = bottom;
            points[3] = right;

            if (IsWithinCanvas(x, y, sideLength, canvasWidth, canvasHeight))
            {
                gc.DrawPolygon(pen, points);
            }
        }

        private new bool IsWithinCanvas(int x, int y, int sideLength, int canvasWidth, int canvasHeight)
        {
            int halfSideLength = sideLength / 2;

            if (x - halfSideLength >= 4 && x + halfSideLength <= canvasWidth &&
                y - halfSideLength >= 4 && y + halfSideLength <= canvasHeight)
            {
                return true;
            }

            return false;
        }


        //public override bool MoveTo(int newX, int newY, int canvasWidth, int canvasHeight)
        //{
        //    int tempX = this.x + newX;
        //    int tempY = this.y + newY;

        //    // координаты вершин ромба на новом местоположении
        //    Point top = new Point(tempX, tempY - this.sideLength / 2);
        //    Point bottom = new Point(tempX, tempY + this.sideLength / 2);
        //    Point left = new Point(tempX - this.width / 2, tempY);
        //    Point right = new Point(tempX + this.width / 2, tempY);

        //    if (top.Y >= 4 && bottom.Y <= canvasHeight &&
        //        left.X >= 4 && right.X <= canvasWidth)
        //    {
        //        this.x = tempX;
        //        this.y = tempY;
        //        return true;
        //    }

        //    return false;
        //}

        public override void Remove(Graphics gc)
        {
            Point top = new Point(this.x, this.y - this.sideLength / 2);
            Point bottom = new Point(this.x, this.y + this.sideLength / 2);
            Point left = new Point(this.x - this.width / 2, this.y);
            Point right = new Point(this.x + this.width / 2, this.y);
            Point[] points = new Point[4] { top, left, bottom, right };
            Pen pen = new Pen(SystemColors.Control, 5);
            gc.DrawPolygon(pen, points);
        }
    }
}
