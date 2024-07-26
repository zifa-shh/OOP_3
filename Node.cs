using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ContainersLibrary
{
    public class Node
    {
        private TFigure figure;
        private Node nextNode;

        public Node(TFigure _figure)
        {
            this.figure = _figure;
            this.nextNode = null;
        }

        public Node(Random random)
        {
            var index = random.Next(1, 6);
            switch (index)
            {
                case (int)Figure.Square:
                    this.figure = new TSquare();
                    break;
                case (int)Figure.Rhombus:
                    this.figure = new Rhombus();
                    break;
                case (int)Figure.Rectangle:
                    this.figure = new ClassLibrary.Rectangle();
                    break;
                case (int)Figure.Circle:
                    this.figure = new TCircle();
                    break;
                case (int)Figure.Ellipse:
                    this.figure = new Ellipse();
                    break;
                case (int)Figure.Line:
                    this.figure = new Line();
                    break;
            }
        }
        public void SetNextNode(Node _nextFigure)
        {
            this.nextNode = _nextFigure;
        }

        public Node GetNextNode()
        {
            return this.nextNode;
        }

        public TFigure GetNodeFigure()
        {
            return this.figure;
        }
    }
}

