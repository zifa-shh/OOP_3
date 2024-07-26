using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibrary;
using System.Xml.Linq;
using System.Windows.Forms;

namespace ContainersLibrary
{
    public class List
    {
        private Node firstNode;
        private Node lastNode;
        private int counter = 0;

        public List(Random random)
        {
            this.counter = 0;

            for (int i = 0; i < 18; i++)
            {
                this.AddNodeList(new Node(random));
            }
        }
        public List()
        {
            this.firstNode = null;
            this.lastNode = null;
            this.counter = 0;
        }
        public void AddNodeList(Node node)
        {
            if (this.firstNode == null) this.firstNode = node;
            else this.lastNode.SetNextNode(node);
            this.lastNode = node;
            this.counter++;
        }
        public bool AddNode(int canvasWidth, int canvasHeight)
        {
            Random random = new Random();

            try
            {
                //if (IsWithinCanvas(node, canvasWidth, canvasHeight))
                //{
                //    if (this.firstNode == null)
                //    {
                //        this.firstNode = node;
                //    }
                //    else
                //    {
                //        this.lastNode.SetNextNode(node);
                //    }
                //    this.lastNode = node;
                //    this.counter++;
                //}
                //else
                //{
                //    Console.WriteLine("Error: Figure is outside the canvas boundaries.");
                //}
                Node node = new Node(random);

                // Добавляем проверку, что фигура - квадрат
                if (node.GetNodeFigure() is TSquare square)
                {
                    if (square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight))
                    {
                        if (this.firstNode == null)
                        {
                            this.firstNode = node;
                        }
                        else
                        {
                            this.lastNode.SetNextNode(node);
                        }
                        this.lastNode = node;
                        this.counter++;
                        return true;
                    }
                    else return false;
                }
                else if (node.GetNodeFigure() is Rhombus rhombus)
                {
                    if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                    {
                        if (this.firstNode == null)
                        {
                            this.firstNode = node;
                        }
                        else
                        {
                            this.lastNode.SetNextNode(node);
                        }
                        this.lastNode = node;
                        this.counter++;
                        return true;
                    }
                    else return false;
                }
                else if (node.GetNodeFigure() is ClassLibrary.Rectangle rectangle)
                {
                    if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                    {
                        if (this.firstNode == null)
                        {
                            this.firstNode = node;
                        }
                        else
                        {
                            this.lastNode.SetNextNode(node);
                        }
                        this.lastNode = node;
                        this.counter++;
                        return true;
                    }
                    else return false;
                }
                else if (node.GetNodeFigure() is TCircle circle)
                {
                    if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                    {
                        if (this.firstNode == null)
                        {
                            this.firstNode = node;
                        }
                        else
                        {
                            this.lastNode.SetNextNode(node);
                        }
                        this.lastNode = node;
                        this.counter++;
                        return true;
                    }
                    else return false;
                }
                else if (node.GetNodeFigure() is Ellipse ellipse)
                {
                    if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                    {
                        if (this.firstNode == null)
                        {
                            this.firstNode = node;
                        }
                        else
                        {
                            this.lastNode.SetNextNode(node);
                        }
                        this.lastNode = node;
                        this.counter++;
                        return true;
                    }
                    else return false;
                }
                else if (node.GetNodeFigure() is Line line)
                {
                    if (line.IsWithinCanvas(line.x, line.y, line.x1, line.y1, canvasWidth, canvasHeight))
                    {
                        if (this.firstNode == null)
                        {
                            this.firstNode = node;
                        }
                        else
                        {
                            this.lastNode.SetNextNode(node);
                        }
                        this.lastNode = node;
                        this.counter++;
                        return true;
                    }
                    else return false;
                }

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;


            
            //if (this.firstNode == null) this.firstNode = node;
            //else this.lastNode.SetNextNode(node);
            //this.lastNode = node;
            //this.counter++;
        }
        public void Iterate(int actionIndex, Graphics g, Color color, int canvasWidth, int canvasHeight, Type figureType = null, int _x = 0, int _y = 0)
        {
            Node temp = firstNode;
            switch (actionIndex)
            {
                case (int)Action.Move:
                    for (int i = 0; i < counter; i++)
                    {
                        temp.GetNodeFigure().MoveTo(_x, _y);
                        temp = temp.GetNextNode();
                    }
                    break;
                case (int)Action.Remove:
                    for (int i = 0; i < counter; i++)
                    {
                        if (figureType == null || temp.GetNodeFigure().GetType() == figureType)
                        {
                            temp.GetNodeFigure().Remove(g);
                        }
                        temp = temp.GetNextNode();
                    }
                    break;
                case (int)Action.Show:
                    for (int i = 0; i < counter; i++)
                    {
                        if (figureType == null || temp.GetNodeFigure().GetType() == figureType)
                        {
                            if (temp.GetNodeFigure() is TSquare square)
                            {
                                if (square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight))
                                {
                                    square.Show(g, color, canvasWidth, canvasHeight);

                                }
                            }
                            else if (temp.GetNodeFigure() is Rhombus rhombus)
                            {
                                if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                                {
                                    rhombus.Show(g, color, canvasWidth, canvasHeight);

                                }
                            }
                            else if (temp.GetNodeFigure() is ClassLibrary.Rectangle rectangle)
                            {
                                if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                                {
                                    rectangle.Show(g, color, canvasWidth, canvasHeight);

                                }
                            }
                            else if (temp.GetNodeFigure() is TCircle circle)
                            {
                                if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                                {
                                    circle.Show(g, color, canvasWidth, canvasHeight);

                                }
                            }
                            else if (temp.GetNodeFigure() is Ellipse ellipse)
                            {
                                if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                                {
                                    ellipse.Show(g, color, canvasWidth, canvasHeight);

                                }
                            }
                            else if (temp.GetNodeFigure() is Line line)
                            {
                                if (line.IsWithinCanvas(line.x, line.y, line.x1, line.y1, canvasWidth, canvasHeight))
                                {
                                    line.Show(g, color, canvasWidth, canvasHeight);

                                }
                            }
                        }
                        temp = temp.GetNextNode();
                    }
                    break;
            }
        }

        public void DeleteList()
        {
            Node temp1 = firstNode;
            Node temp2 = firstNode;
            for (int i = 0; i < counter; i++)
            {
                temp2 = temp1.GetNextNode();
                temp1 = null;
                temp1 = temp2;
            }
            this.counter = 0;
        }
    }
}
