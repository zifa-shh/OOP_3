using System;
using ClassLibrary;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainersLibrary
{
    public class Massive
    {
        public TFigure[] massive;
        public int counter;

        public Massive()
        {
            this.massive = new TFigure[18];
            counter = 0;
        }
        public Massive(Random random)
        {
            this.massive = new TFigure[18];
            counter = 0;

            for (int i = 0; i < 18; i++)
            {
                var index = random.Next(1, 7);
                switch (index)
                {
                    case (int)Figure.Square:
                        this.massive[counter] = new TSquare();
                        break;
                    case (int)Figure.Line:
                        this.massive[counter] = new Line();
                        break;
                    case (int)Figure.Circle:
                        this.massive[counter] = new TCircle();
                        break;
                    case (int)Figure.Rhombus:
                        this.massive[counter] = new Rhombus();
                        break;
                    case (int)Figure.Rectangle:
                        this.massive[counter] = new ClassLibrary.Rectangle();
                        break;
                    case (int)Figure.Ellipse:
                        this.massive[counter] = new Ellipse();
                        break;
                }
                counter++;
            }
        }

        public bool AddElement(Random random, int canvasWidth, int canvasHeight)
        {
            var index = random.Next(1, 6);

            try
            {
                switch (index)
                {
                    case (int)Figure.Square:
                        this.massive[counter] = new TSquare();
                        TSquare square = (TSquare)massive[counter];
                        if (square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                        //break;
                    case (int)Figure.Rhombus:
                        this.massive[counter] = new Rhombus();
                        Rhombus rhombus = (Rhombus)massive[counter];
                        if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                        //break;
                    case (int)Figure.Rectangle:
                        this.massive[counter] = new ClassLibrary.Rectangle();
                        ClassLibrary.Rectangle rectangle = (ClassLibrary.Rectangle)massive[counter];
                        if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                        //break;
                    case (int)Figure.Circle:
                        this.massive[counter] = new TCircle();
                        TCircle circle = (TCircle)massive[counter];
                        if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                        //break;
                    case (int)Figure.Ellipse:
                        this.massive[counter] = new Ellipse();
                        Ellipse ellipse = (Ellipse)massive[counter];
                        if (ellipse.IsWithinCanvas(ellipse.x - 10, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                        //break;
                    case (int)Figure.Line:
                        this.massive[counter] = new Line();
                        Line line = (Line)massive[counter];
                        if (line.IsWithinCanvas(line.x, line.y, line.x1 - 10, line.y1, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                        //break;
                }
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize(ref massive, counter + counter / 10);
                switch (index)
                {
                    case (int)Figure.Square:
                        this.massive[counter] = new TSquare();
                        TSquare square = (TSquare)massive[counter];
                        if (square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                    //break;
                    case (int)Figure.Rhombus:
                        this.massive[counter] = new Rhombus();
                        Rhombus rhombus = (Rhombus)massive[counter];
                        if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                    //break;
                    case (int)Figure.Rectangle:
                        this.massive[counter] = new ClassLibrary.Rectangle();
                        ClassLibrary.Rectangle rectangle = (ClassLibrary.Rectangle)massive[counter];
                        if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                    //break;
                    case (int)Figure.Circle:
                        this.massive[counter] = new TCircle();
                        TCircle circle = (TCircle)massive[counter];
                        if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                    //break;
                    case (int)Figure.Ellipse:
                        this.massive[counter] = new Ellipse();
                        Ellipse ellipse = (Ellipse)massive[counter];
                        if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                    //break;
                    case (int)Figure.Line:
                        this.massive[counter] = new Line();
                        Line line = (Line)massive[counter];
                        if (line.IsWithinCanvas(line.x, line.y, line.x1, line.y1, canvasWidth, canvasHeight))
                        {
                            counter++;
                            return true;
                        }
                        else return false;
                        //break;
                }
                //counter++;
                return false;
            }
        }
        public void Iterate(int actionIndex, Graphics g, Color color, int canvasWidth, int canvasHeight, int x = 0, int y = 0)
        {

            switch (actionIndex)
            {
                case (int)Action.Move:
                    for (int i = 0; i < counter; i++)
                    {
                        if (massive[i] is TSquare && !(massive[i] is ClassLibrary.Rectangle) && !(massive[i] is Rhombus))
                        {
                            TSquare square = (TSquare)massive[i];
                            if(square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight)) 
                                massive[i].MoveTo(x, y);
                        }
                        else if (massive[i] is TCircle && !(massive[i] is Ellipse))
                        {
                            TCircle circle = (TCircle)massive[i];
                            if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                                massive[i].MoveTo(x, y);
                        }
                        else if (massive[i] is Line)
                        {
                            Line line = (Line)massive[i];
                            if (line.IsWithinCanvas(line.x, line.y, line.x1, line.y1, canvasWidth, canvasHeight))
                                massive[i].MoveTo(x, y);
                        }
                        else if (massive[i] is Ellipse)
                        {
                            Ellipse ellipse = (Ellipse)massive[i];
                            if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                                massive[i].MoveTo(x, y);
                        }
                        else if (massive[i] is ClassLibrary.Rectangle)
                        {
                            ClassLibrary.Rectangle rectangle = (ClassLibrary.Rectangle)massive[i];
                            if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                                massive[i].MoveTo(x, y);
                        }
                        else if (massive[i] is Rhombus)
                        {
                            Rhombus rhombus = (Rhombus)massive[i];
                            if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                                massive[i].MoveTo(x, y);
                        }
                    }
                    break;
                case (int)Action.Remove:
                    for (int i = 0; i < counter; i++)
                    {
                        massive[i].Remove(g);
                    }
                    break;
                case (int)Action.Show:
                    for (int i = 0; i < counter; i++)
                    {
                        massive[i].Show(g, color, canvasWidth, canvasHeight);
                    }
                    break;
            }
        }
        public int GetCount()
        {
            return counter;
        }

        public void DeleteMassive()
        {
            massive = new TFigure[18];
            counter = 0;
        }
    }
}
