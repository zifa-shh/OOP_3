using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class TFigure
    {
        private static Random random = new Random();

        public TFigure(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine($"Объект TFigure создан с координатами ({x}, {y}).");
        }
        public TFigure()
        {
            this.x = random.Next(0, 450);
            this.y = random.Next(0, 370);
            Console.WriteLine($"Объект TFigure создан с координатами ({x}, {y}).");
        }

        public int x { get; set; }
        public int y { get; set; }

        public int x1 { get; set; }
        public int y1 { get; set; }

        public virtual void Rotate() { }
        public virtual void ChangeRadius(int r, int canvasWidth, int canvasHeight) { }
        public abstract void Remove(Graphics gc);
        
        public virtual void Show(Graphics canvas, Color color, int canvasWidth, int canvasHeight) { }
        public void MoveTo(int x, int y)
        {
            this.x += x;
            this.y += y;
            this.x1 += x;
            this.y1 += y;
        }
        public void ReturnToBasePoint()
        {
            this.x = 290;
            this.y = 250;
        }

    }
}
