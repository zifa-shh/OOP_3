using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml.Linq;
using ContainersLibrary;
using System.CodeDom;


//enum Figure
//{ 
//    Square = 1,
//    Circle,
//    Line,
//    Ellipse,
//    Rhombus,
//    Rectangle,

//}

//enum Action
//{
//    Move = 1,
//    Change,
//    Rotate,
//    Delete
//}

namespace ConsoleApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hideall();
        }
        bool workingWithList;
        bool workingWithMassive;
        bool listFiguresAreRemoved = true;
        bool massiveFiguresAreRemoved = true;

        public TFigure[] figures = new TFigure[1];
        int figuresCnt = 0;

        public bool[] checkedFiguresList = new bool[7]; 

        Figure figureIndex;
        ContainersLibrary.Action actionIndex;

        public ContainersLibrary.List list = new List();
        public ContainersLibrary.Massive massive = new Massive();


        public TSquare[] squares = new TSquare[1];
        public int squaresCnt = 0;
        public TCircle[] circles = new TCircle[1];
        public int circlesCnt = 0;
        public Line[] lines = new Line[1];
        public int linesCnt = 0;
        public Ellipse[] ellipses = new Ellipse[1];
        public int ellipsesCnt = 0;
        public Rhombus[] rhombuses = new Rhombus[1];
        public int rhombusesCnt = 0;
        public ClassLibrary.Rectangle[] rectangles = new ClassLibrary.Rectangle[1];
        public int rectanglesCnt = 0;
        

        public bool[] checkedSquaresList = new bool[0];
        public bool[] checkedCirclesList = new bool[0];
        public bool[] checkedLinesList = new bool[0];
        public bool[] checkedEllipsesList = new bool[0];
        public bool[] checkedRhombusesList = new bool[0];
        public bool[] checkedRectanglesList = new bool[0];

        public bool createByPoint;
        //private bool move_figuresKeyPressed = false;
        //private bool move_circlesKeyPressed = false;
        //private bool move_squaresKeyPressed = false;
        //private bool move_linesKeyPressed = false;

        bool check_destroy = true;

       
        public void hideall()
        {
            parametrs1.Visible = false;
            random1.Visible = false;
            rollSquaresUp.Visible = false;

            parametrs2.Visible = false;
            random2.Visible = false;
            rollCirclesUp.Visible = false;

            parametrs3.Visible = false;
            random3.Visible = false;
            rollLinesUp.Visible = false;

            checkedListBox1.Visible = false;

            parametrs4.Visible = false;
            random4.Visible = false;
            rollEllipsesUp.Visible = false;

            parametrs5.Visible = false;
            random5.Visible = false;
            rollRhombusesUp.Visible = false;

            parametrs6.Visible = false;
            random6.Visible = false;
            rollRectanglesUp.Visible = false;

            

            inputPanel.Visible = false;
            helpyFirstLine.Visible = false;
            helpyFirstX.Visible = false;
            helpyFirstY.Visible = false;
            firstInputLine.Visible = false;
            secondInputLine.Visible = false;
            thirdInputLine.Visible = false;
            fourthInputLine.Visible = false;
            helpySecondX.Visible = false;
            helpySecondY.Visible = false;

            cancelCreateButton.Visible = false;
            confirmCreateButton.Visible = false;

            label_x_4.Visible = false;
            label_y_4.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            next4.Visible = false;

            cancel_button.Visible = false;
            checkedListBox1.Visible = false;

            //roll_move_figures_up.Visible = true;
            //roll_move_circles_up.Visible = true;
            //roll_move_squares_up.Visible = true;
            //roll_move_lines_up.Visible = true;

        }
        public void enablebuttons(bool toDo)
        {
            move_button.Enabled = toDo;
            change_radius_button.Enabled = toDo;
            rotate_ellipse_button.Enabled = toDo;
            delete_button.Enabled = toDo;
            randomFilling.Enabled = toDo;
            removeFigures.Enabled = toDo;
            showFigures.Enabled = toDo;
            destroyMassive.Enabled = toDo;
            //move_figures.Enabled = toDo;
            //move_circles.Enabled = toDo;
            //move_squares.Enabled = toDo;
            //move_lines.Enabled = toDo;
            //roll_move_figures_up.Enabled = toDo;
            //roll_move_circles_up.Enabled = toDo;
            //roll_move_squares_up.Enabled = toDo;
            //roll_move_lines_up.Enabled = toDo;

            square_button.Enabled = toDo;
            parametrs1.Enabled = toDo;
            random1.Enabled = toDo;
            rollSquaresUp.Enabled = toDo;

            circle_button.Enabled = toDo;
            parametrs2.Enabled = toDo;
            random2.Enabled = toDo;
            rollCirclesUp.Enabled = toDo;

            line_button.Enabled = toDo;
            parametrs3.Enabled = toDo;
            random3.Enabled = toDo;
            rollLinesUp.Enabled = toDo;

            ellipse_button.Enabled = toDo;
            parametrs4.Enabled = toDo;
            random4.Enabled = toDo;
            rollEllipsesUp.Enabled = toDo;

            rhombus_button.Enabled = toDo;
            parametrs5.Enabled = toDo;
            random5.Enabled = toDo;
            rollRhombusesUp.Enabled = toDo;

            rectangle_button.Enabled = toDo;
            parametrs6.Enabled = toDo;
            random6.Enabled = toDo;
            rollRectanglesUp.Enabled = toDo;

            //randomFilling.Enabled = false;
            //removeFigures.Enabled = false;
            //showFigures.Enabled = false;
            //destroyMassive.Enabled = false;
            //addRandomFigure.Enabled = false;
        }

        public void restorePaintments()
        {
            Graphics g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            for (int i = 0; i < figuresCnt; i++)
            {
                figures[i].Show(g, Color.Green, canvasWidth, canvasHeight);
            }
        }

       

        public void fillCheckedListIn()
        {
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.Add("---Все фигуры---");
            checkedListBox1.Items.Add("--Все квадраты--");
            checkedListBox1.Items.Add("-Все ромбы-");
            checkedListBox1.Items.Add("-Все прямоугольники-");
            checkedListBox1.Items.Add("--Все окружности--");
            checkedListBox1.Items.Add("-Все эллипсы-");
            checkedListBox1.Items.Add("--Все линии--");
        }
        public void setFalseOnCheckedList()
        {
            for (int i = 0; i < checkedFiguresList.Length; i++)
            {
                checkedFiguresList[i] = false;
            }
        }
        public void setFalseOnFiguresList()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
        private void square_button_Click_1(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            parametrs1.Visible = true;
            random1.Visible = true;
            rollSquaresUp.Visible = true;

            square_button.Enabled = true;
            parametrs1.Enabled = true;
            random1.Enabled = true;
            rollSquaresUp.Enabled = true;

        }

        private void parametrs1_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            figureIndex = Figure.Square;

            inputPanel.Visible = true;
            helpyFirstLine.Text = "Координаты центра квадрата";
            helpyFirstLine.Visible = true;
            helpySecondLine.Text = "Сторона квадрата";
            helpySecondLine.Visible = true;
            helpyFirstX.Visible = true;
            helpyFirstY.Visible = true;
            helpySecondX.Text = "A:";
            helpySecondX.Visible = true;
            firstInputLine.Visible = true;
            secondInputLine.Visible = true;
            thirdInputLine.Visible = true;
            confirmCreateButton.Visible = true;
            cancelCreateButton.Visible = true;
        }

        private void random1_Click(object sender, EventArgs e)
        {
            hideall();

            parametrs1.Visible = true;
            random1.Visible = true;
            rollSquaresUp.Visible = true;

            Array.Resize(ref figures, figuresCnt + 1);
            Graphics g = pictureBox1.CreateGraphics();

            int canvasWidth = pictureBox1.Width-4;
            int canvasHeight = pictureBox1.Height-4;

            

            try
            {
                figures[figuresCnt] = new TSquare();
                TSquare square = (TSquare)figures[figuresCnt];

                if (square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize(ref figures, figures.Length * 2);
                figures[figuresCnt] = new TSquare();
                TSquare square = (TSquare)figures[figuresCnt];

                if (square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }
        }

        

        private void circle_button_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            circle_button.Enabled = true;
            parametrs2.Enabled = true;
            random2.Enabled = true;
            rollCirclesUp.Enabled = true;

            parametrs2.Visible = true;
            random2.Visible = true;
            rollCirclesUp.Visible = true;
        }
        private void parametrs2_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            figureIndex = Figure.Circle;
            
            inputPanel.Visible = true;
            helpyFirstLine.Text = "Координаты центра круга";
            helpyFirstLine.Visible = true;
            helpySecondLine.Text = "Радиус круга";
            helpySecondLine.Visible = true;
            helpyFirstX.Visible = true;
            helpyFirstY.Visible = true;
            helpySecondX.Text = "R:";
            helpySecondX.Visible = true;
            firstInputLine.Visible = true;
            secondInputLine.Visible = true;
            thirdInputLine.Visible = true;
            confirmCreateButton.Visible = true;
            cancelCreateButton.Visible = true;
        }
        private void random2_Click(object sender, EventArgs e)
        {
            hideall();
            random2.Visible = true;
            parametrs2.Visible = true;
            rollCirclesUp.Visible = true;

            Array.Resize(ref figures, figuresCnt + 1);
            Random random = new Random();
            Graphics g = pictureBox1.CreateGraphics();

            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

           
            
            try
            {
                figures[figuresCnt] = new TCircle();
                TCircle circle = (TCircle)figures[figuresCnt];

                if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }

            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize(ref figures, figures.Length * 2);
                figures[figuresCnt] = new TCircle();
                TCircle circle = (TCircle)figures[figuresCnt];

                if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }


        }

        private void line_button_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            parametrs3.Visible = true;
            random3.Visible = true;
            rollLinesUp.Visible = true;

            line_button.Enabled = true;
            parametrs3.Enabled = true;
            random3.Enabled = true;
            rollLinesUp.Enabled = true;
        }

        private void parametrs3_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            figureIndex = Figure.Line;

            inputPanel.Visible = true;
            helpyFirstLine.Text = "Координаты начала линии";
            helpyFirstLine.Visible = true;
            helpySecondLine.Text = "Координаты конца линии";
            helpySecondLine.Visible = true;
            helpyFirstX.Visible = true;
            helpyFirstY.Visible = true;
            helpyFirstX.Text = "X1:";
            helpyFirstY.Text = "Y1:";
            helpySecondX.Visible = true;
            helpySecondY.Visible = true;
            helpySecondX.Text = "X2:";
            helpySecondY.Text = "Y2:";
            firstInputLine.Visible = true;
            secondInputLine.Visible = true;
            thirdInputLine.Visible = true;
            fourthInputLine.Visible = true;
            confirmCreateButton.Visible = true;
            cancelCreateButton.Visible = true;
        }

        private void random3_Click(object sender, EventArgs e)
        {
            hideall();
            parametrs3.Visible = true;
            random3.Visible = true;
            rollLinesUp.Visible = true;

            Array.Resize(ref figures, figuresCnt + 1);
            Random random = new Random();
            Graphics g = pictureBox1.CreateGraphics();

            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            
            try
            {
                figures[figuresCnt] = new Line();
                Line line = (Line)figures[figuresCnt];

                if (line.IsWithinCanvas(line.x, line.y, line.x1, line.y1, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize(ref figures, figures.Length * 2);
                figures[figuresCnt] = new Line();
                Line line = (Line)figures[figuresCnt];

                if (line.IsWithinCanvas(line.x, line.y, line.x1, line.y1, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }


        }

        private void ellipse_button_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            parametrs4.Visible = true;
            random4.Visible = true;
            rollEllipsesUp.Visible = true;

            ellipse_button.Enabled = true;
            parametrs4.Enabled = true;
            random4.Enabled = true;
            rollEllipsesUp.Enabled = true;
        }

        private void parametrs4_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            figureIndex = Figure.Ellipse;

            inputPanel.Visible = true;
            helpyFirstLine.Text = "Координаты центра эллипса";
            helpyFirstLine.Visible = true;
            helpySecondLine.Text = "Оси эллипса";
            helpySecondLine.Visible = true;

            helpyFirstX.Visible = true;
            helpyFirstY.Visible = true;
            helpySecondX.Text = "R1:";
            helpySecondX.Visible = true;
            helpySecondY.Text = "R2:";
            helpySecondY.Visible = true;
            firstInputLine.Visible = true;
            secondInputLine.Visible = true;
            thirdInputLine.Visible = true;
            fourthInputLine.Visible = true;
            confirmCreateButton.Visible = true;
            cancelCreateButton.Visible = true;
        }

        private void random4_Click(object sender, EventArgs e)
        {

            hideall();
            parametrs4.Visible = true;
            random4.Visible = true;
            rollEllipsesUp.Visible = true;

            Array.Resize(ref figures, figuresCnt + 1);
            Random random = new Random();
            Graphics g = pictureBox1.CreateGraphics();

            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            
            try
            {
                figures[figuresCnt] = new Ellipse();
                Ellipse ellipse = (Ellipse)figures[figuresCnt];

                if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize(ref figures, figures.Length * 2);
                figures[figuresCnt] = new Ellipse();
                Ellipse ellipse = (Ellipse)figures[figuresCnt];

                if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }

        }

        private void rhombus_button_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            parametrs5.Visible = true;
            random5.Visible = true;
            rollRhombusesUp.Visible = true;

            rhombus_button.Enabled = true;
            parametrs5.Enabled = true;
            random5.Enabled = true;
            rollRhombusesUp.Enabled = true;
        }

        private void parametrs5_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            figureIndex = Figure.Rhombus;

            inputPanel.Visible = true;
            helpyFirstLine.Text = "Координаты центра ромба";
            helpyFirstLine.Visible = true;
            helpySecondLine.Text = "Диагонали ромба";
            helpySecondLine.Visible = true;
            helpyFirstX.Visible = true;
            helpyFirstY.Visible = true;
            helpySecondX.Text = "A:";
            helpySecondX.Visible = true;
            helpySecondY.Text = "B:";
            helpySecondY.Visible = true;
            firstInputLine.Visible = true;
            secondInputLine.Visible = true;
            thirdInputLine.Visible = true;
            fourthInputLine.Visible = true;
            confirmCreateButton.Visible = true;
            cancelCreateButton.Visible = true;
        }

        private void random5_Click_1(object sender, EventArgs e)
        {

            hideall();
            parametrs5.Visible = true;
            random5.Visible = true;
            rollRhombusesUp.Visible = true;

            Array.Resize(ref figures, figuresCnt + 1);
            Random random = new Random();
            Graphics g = pictureBox1.CreateGraphics();

            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            try
            {
                figures[figuresCnt] = new Rhombus();
                Rhombus rhombus = (Rhombus)figures[figuresCnt];

                if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize(ref figures, figures.Length * 2);
                figures[figuresCnt] = new Rhombus();
                Rhombus rhombus = (Rhombus)figures[figuresCnt];

                if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }


        }

        private void rectangle_button_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            parametrs6.Visible = true;
            random6.Visible = true;
            rollRectanglesUp.Visible = true;

            rectangle_button.Enabled = true;
            parametrs6.Enabled = true;
            random6.Enabled = true;
            rollRectanglesUp.Enabled = true;
        }

        private void parametrs6_Click_1(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(false);

            figureIndex = Figure.Rectangle;

            inputPanel.Visible = true;
            helpyFirstLine.Text = "Коор-ты центра прямоугольника";
            helpyFirstLine.Visible = true;
            helpySecondLine.Text = "Стороны прямоугольника";
            helpySecondLine.Visible = true;
            helpyFirstX.Visible = true;
            helpyFirstY.Visible = true;
            helpySecondX.Text = "A:";
            helpySecondX.Visible = true;
            helpySecondY.Text = "B:";
            helpySecondY.Visible = true;
            firstInputLine.Visible = true;
            secondInputLine.Visible = true;
            thirdInputLine.Visible = true;
            fourthInputLine.Visible = true;
            confirmCreateButton.Visible = true;
            cancelCreateButton.Visible = true;
        }

        private void random6_Click_1(object sender, EventArgs e)
        {

            hideall();
            parametrs6.Visible = true;
            random6.Visible = true;
            rollRectanglesUp.Visible = true;

            Array.Resize(ref figures, figuresCnt + 1);
            Random random = new Random();
            Graphics g = pictureBox1.CreateGraphics();

            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

           
            try
            {
                figures[figuresCnt] = new ClassLibrary.Rectangle();
                ClassLibrary.Rectangle rectangle = (ClassLibrary.Rectangle)figures[figuresCnt];

                if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }
            catch (IndexOutOfRangeException)
            {
                Array.Resize(ref figures, figures.Length * 2);
                figures[figuresCnt] = new ClassLibrary.Rectangle();
                ClassLibrary.Rectangle rectangle = (ClassLibrary.Rectangle)figures[figuresCnt];

                if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                {
                    figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);
                    figuresCnt++;
                }
                else
                {
                    MessageBox.Show("Ошибка: фигура выходит за границы холста.");

                }
            }


        }

        

        private void rollSquaresUp_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(true);
            //if (check_destroy == false)
            //{
            //    randomFilling.Enabled = false;
            //}
            //else randomFilling.Enabled = true;


        }

        private void rollCirclesUp_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(true);
            if (check_destroy == false)
            {
                randomFilling.Enabled = false;
            }
            else randomFilling.Enabled = true;
        }
        private void rollLinesUp_Click(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(true);
            //if (check_destroy == false)
            //{
            //    randomFilling.Enabled = false;
            //}
            //else randomFilling.Enabled = true;
        }

        private void rollEllipsesUp_Click_1(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(true);
            //if (check_destroy == false)
            //{
            //    randomFilling.Enabled = false;
            //}
            //else randomFilling.Enabled = true;
        }
        private void rollRhombusesUp_Click_1(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(true);
            //if (check_destroy == false)
            //{
            //    randomFilling.Enabled = false;
            //}
            //else randomFilling.Enabled = true;
        }

        private void rollRectanglesUp_Click_1(object sender, EventArgs e)
        {
            hideall();
            enablebuttons(true);
            //if (check_destroy == false)
            //{
            //    randomFilling.Enabled = false;
            //}
            //else randomFilling.Enabled = true;
        }

        

        
        private void cancelCreateButton_Click(object sender, EventArgs e)
        {

            square_button.Enabled = true;
            line_button.Enabled = true;
            circle_button.Enabled = true;
            ellipse_button.Enabled = true;
            rhombus_button.Enabled = true;
            rectangle_button.Enabled = true;
            move_button.Enabled = true;
            change_radius_button.Enabled = true;
            rotate_ellipse_button.Enabled = true;
            delete_button.Enabled = true;


            inputPanel.Visible = false;
            helpyFirstLine.Visible = false;
            helpySecondLine.Visible = false;
            helpyFirstX.Visible = false;
            helpyFirstY.Visible = false;
            helpySecondX.Visible = false;
            helpySecondY.Visible = false;
            firstInputLine.Visible = false;
            secondInputLine.Visible = false;
            thirdInputLine.Visible = false;
            fourthInputLine.Visible = false;

            firstInputLine.Clear();
            secondInputLine.Clear();
            thirdInputLine.Clear();
            fourthInputLine.Clear();
            fifthInputLine.Clear();

            restorePaintments();
        }

        private void confirmCreateButton_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            enablebuttons(true);

            inputPanel.Visible = false;
            helpyFirstLine.Visible = false;
            helpySecondLine.Visible = false;
            helpyFirstX.Visible = false;
            helpyFirstY.Visible = false;
            helpySecondX.Visible = false;
            helpySecondY.Visible = false;

            firstInputLine.Visible = false;
            secondInputLine.Visible = false;
            thirdInputLine.Visible = false;
            fourthInputLine.Visible = false;
            

            switch (figureIndex)
            {
                case Figure.Square:
                    try
                    {
                        int x = int.Parse(firstInputLine.Text);
                        int y = int.Parse(secondInputLine.Text);
                        int canvasWidth = pictureBox1.Width - 4;
                        int canvasHeight = pictureBox1.Height - 4;
                        int sideLenght = int.Parse(thirdInputLine.Text);
                        Array.Resize(ref figures, figuresCnt + 1);
                        
                        try
                        {
                            figures[figuresCnt] = new TSquare();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Array.Resize(ref figures, figures.Length * 2);
                            figures[figuresCnt] = new TSquare();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                    }
                    break;
                case Figure.Circle:
                    try
                    {
                        int x = int.Parse(firstInputLine.Text);
                        int y = int.Parse(secondInputLine.Text);
                        int r = int.Parse(thirdInputLine.Text);
                        int canvasWidth = pictureBox1.Width - 4;
                        int canvasHeight = pictureBox1.Height - 4;
                        Array.Resize(ref figures, figuresCnt + 1);
                        
                        try
                        {
                            figures[figuresCnt] = new TCircle();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Array.Resize(ref figures, figures.Length * 2);
                            figures[figuresCnt] = new TCircle();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                    }
                    break;
                case Figure.Line:
                    try
                    {
                        int x1 = int.Parse(firstInputLine.Text);
                        int y1 = int.Parse(secondInputLine.Text);
                        int x2 = int.Parse(thirdInputLine.Text);
                        int y2 = int.Parse(fourthInputLine.Text);
                        int canvasWidth = pictureBox1.Width - 4;
                        int canvasHeight = pictureBox1.Height - 4;
                        Array.Resize(ref figures, figuresCnt + 1);
                       

                        try
                        {
                            figures[figuresCnt] = new Line();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Array.Resize(ref figures, figures.Length * 2);
                            figures[figuresCnt] = new Line();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                    }
                    break;
                case Figure.Ellipse:
                    try
                    {
                        
                        
                        int canvasWidth = pictureBox1.Width - 4;
                        int canvasHeight = pictureBox1.Height - 4;

                        int x = int.Parse(firstInputLine.Text);
                        int y = int.Parse(secondInputLine.Text);
                        int r1 = int.Parse(thirdInputLine.Text);
                        int r2 = int.Parse(fourthInputLine.Text);

                        Array.Resize(ref figures, figuresCnt + 1);
                        
                        try
                        {
                            figures[figuresCnt] = new Ellipse();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Array.Resize(ref figures, figures.Length * 2);
                            figures[figuresCnt] = new Ellipse();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                    }
                    break;
                case Figure.Rhombus:
                    try
                    {
                        int x = int.Parse(firstInputLine.Text);
                        int y = int.Parse(secondInputLine.Text);
                        int height = int.Parse(thirdInputLine.Text);
                        int width = int.Parse(fourthInputLine.Text);

                        int canvasWidth = pictureBox1.Width - 4;
                        int canvasHeight = pictureBox1.Height - 4;

                        Array.Resize(ref figures, figuresCnt + 1);
                        
                        try
                        {
                            figures[figuresCnt] = new Rhombus();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Array.Resize(ref figures, figures.Length * 2);
                            figures[figuresCnt] = new Rhombus();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                    }
                    break;

                case Figure.Rectangle:
                    try
                    {
                        int x = int.Parse(firstInputLine.Text);
                        int y = int.Parse(secondInputLine.Text);
                        int height = int.Parse(thirdInputLine.Text);
                        int width = int.Parse(fourthInputLine.Text);

                        int canvasWidth = pictureBox1.Width - 4;
                        int canvasHeight = pictureBox1.Height - 4;

                        Array.Resize(ref figures, figuresCnt + 1);
                        
                        try
                        {
                            figures[figuresCnt] = new ClassLibrary.Rectangle();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Array.Resize(ref figures, figures.Length * 2);
                            figures[figuresCnt] = new ClassLibrary.Rectangle();
                            figures[figuresCnt].Show(g, Color.Green, canvasWidth, canvasHeight);

                            figuresCnt++;
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                    }
                    break;

               

            }


            firstInputLine.Clear();
            secondInputLine.Clear();
            thirdInputLine.Clear();
            fourthInputLine.Clear();
            fifthInputLine.Clear();

            restorePaintments();
        }
        private void move_button_Click_1(object sender, EventArgs e)
        {
            actionIndex = ContainersLibrary.Action.Move;

            square_button.Enabled = true;
            line_button.Enabled = true;
            circle_button.Enabled = true;
            ellipse_button.Enabled = true;
            rhombus_button.Enabled = true;
            rectangle_button.Enabled = true;
            move_button.Enabled = true;
            change_radius_button.Enabled = true;
            rotate_ellipse_button.Enabled = true;
            delete_button.Enabled = true;


            checkedListBox1.Visible = true;
            next4.Visible = true;
            cancel_button.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            label_x_4.Visible = true;
            label_y_4.Visible = true;

            fillCheckedListIn();

            
        }
        private void delete_button_Click(object sender, EventArgs e)
        {
            actionIndex = ContainersLibrary.Action.Delete;

            enablebuttons(false);
            hideall();

            square_button.Enabled = true;
            line_button.Enabled = true;
            circle_button.Enabled = true;
            ellipse_button.Enabled = true;
            rhombus_button.Enabled = true;
            rectangle_button.Enabled = true;
            move_button.Enabled = true;
            change_radius_button.Enabled = true;
            rotate_ellipse_button.Enabled = true;
            delete_button.Enabled = true;


            checkedListBox1.Visible = true;
            next4.Visible = true;
            cancel_button.Visible = true;


            fillCheckedListIn();

            
        }
        








        private void change_radius_button_Click(object sender, EventArgs e)
        {
            actionIndex = ContainersLibrary.Action.Change;

            Graphics g = pictureBox1.CreateGraphics();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            square_button.Enabled = true;
            line_button.Enabled = true;
            circle_button.Enabled = true;
            ellipse_button.Enabled = true;
            rhombus_button.Enabled = true;
            rectangle_button.Enabled = true;
            move_button.Enabled = true;
            change_radius_button.Enabled = true;
            rotate_ellipse_button.Enabled = true;
            delete_button.Enabled = true;

            checkedListBox1.Visible = false; 
           
            next4.Visible = true;
            cancel_button.Visible = true;
            textBox11.Visible = true;
            label_x_4.Visible = true;


        }

        private void rotate_ellipse_button_Click(object sender, EventArgs e)
        {
            actionIndex = ContainersLibrary.Action.Rotate;

            Graphics g = pictureBox1.CreateGraphics();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            square_button.Enabled = true;
            line_button.Enabled = true;
            circle_button.Enabled = true;
            ellipse_button.Enabled = true;
            rhombus_button.Enabled = true;
            rectangle_button.Enabled = true;
            move_button.Enabled = true;
            change_radius_button.Enabled = true;
            rotate_ellipse_button.Enabled = true;
            delete_button.Enabled = true;

            checkedListBox1.Visible = false;
            
            next4.Visible = false;
            cancel_button.Visible = false;

            for (int i = 0; i < figuresCnt; i++)
            {
                if (figures[i] is Ellipse)
                {
                    Ellipse ellipse = (Ellipse)figures[i];

                    if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.axle, ellipse.r, canvasWidth, canvasHeight))
                    {
                        figures[i].Rotate();
                        restorePaintments();

                    }
                    else
                    {
                        MessageBox.Show("Ошибка: фигура выходит за границы холста.");
                    }
                }
            }
           
            checkedListBox1.ClearSelected();
            setFalseOnCheckedList();
            restorePaintments();
        }

       


        private void next4_Click(object sender, EventArgs e)
        {
            enablebuttons(true);
            Graphics g = pictureBox1.CreateGraphics();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;
            hideall();
            checkedListBox1.ClearSelected();

            switch (actionIndex)
            {
                case ContainersLibrary.Action.Move:
                    try
                    {
                        int x = int.Parse(textBox11.Text);
                        int y = int.Parse(textBox12.Text);

                        if (workingWithList && (list != null)) list.Iterate((int)ContainersLibrary.Action.Move, g, Color.Orange, canvasWidth, canvasHeight, typeof(TFigure),x, y);
                        else if (workingWithMassive && massive != null) massive.Iterate((int)ContainersLibrary.Action.Move, g, Color.Violet, canvasWidth, canvasHeight);
                        

                        //for (int i = 0; i < figuresCnt; i++)
                        //{
                        //    if ((figures[i] is TSquare) && !((figures[i] is ClassLibrary.Rectangle)) && !((figures[i] is Rhombus)) && checkedFiguresList[1])
                        //    {
                        //        TSquare square = (TSquare)figures[i];

                        //        if (square.IsWithinCanvas(square.x, square.y, square.sideLength, canvasWidth, canvasHeight))
                        //        {
                        //            figures[i].MoveTo(x, y);

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Ошибка: фигура не может быть перемещена в данное место.");

                        //        }
                        //    }
                        //    else if ((figures[i] is TCircle) && !((figures[i] is Ellipse)) && checkedFiguresList[4])
                        //    {
                        //        TCircle circle = (TCircle)figures[i];

                        //        if (circle.IsWithinCanvas(circle.x, circle.y, circle.r, canvasWidth, canvasHeight))
                        //        {
                        //            figures[i].MoveTo(x, y);

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Ошибка: фигура не может быть перемещена в данное место.");

                        //        }
                        //    }
                        //    else if ((figures[i] is Line) && checkedFiguresList[6])
                        //    {
                        //        Line line = (Line)figures[i];

                        //        if (line.IsWithinCanvas(line.x, line.y, line.x1, line.y1, canvasWidth, canvasHeight))
                        //        {
                        //            figures[i].MoveTo(x, y);

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Ошибка: фигура не может быть перемещена в данное место.");

                        //        }
                        //    }
                        //    else if ((figures[i] is Ellipse) && checkedFiguresList[5])
                        //    {
                        //        Ellipse ellipse = (Ellipse)figures[i];

                        //        if (ellipse.IsWithinCanvas(ellipse.x, ellipse.y, ellipse.r, ellipse.axle, canvasWidth, canvasHeight))
                        //        {
                        //            figures[i].MoveTo(x, y);

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Ошибка: фигура не может быть перемещена в данное место.");

                        //        }
                        //    }
                        //    else if ((figures[i] is ClassLibrary.Rectangle) && checkedFiguresList[3])
                        //    {
                        //        ClassLibrary.Rectangle rectangle = (ClassLibrary.Rectangle)figures[i];

                        //        if (rectangle.IsWithinCanvas(rectangle.x, rectangle.y, rectangle.width, rectangle.sideLength, canvasWidth, canvasHeight))
                        //        {
                        //            figures[i].MoveTo(x, y);

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Ошибка: фигура не может быть перемещена в данное место.");

                        //        }
                        //    }
                        //    else if ((figures[i] is Rhombus) && checkedFiguresList[2])
                        //    {
                        //        Rhombus rhombus = (Rhombus)figures[i];

                        //        if (rhombus.IsWithinCanvas(rhombus.x, rhombus.y, rhombus.sideLength, canvasWidth, canvasHeight))
                        //        {
                        //            figures[i].MoveTo(x, y);

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Ошибка: фигура не может быть перемещена в данное место.");

                        //        }
                        //    }
                        //}
                        //restorePaintments();
                        //setFalseOnCheckedList();
                        //setFalseOnFiguresList();


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                    }
                    break;
                //case ContainersLibrary.Action.Change:
                //    try
                //    {
                //        int R = int.Parse(textBox11.Text);

                        
                //        for (int i = 0; i < figuresCnt; i++)
                //        {
                //            if ((figures[i] is TCircle) && (!(figures[i] is Ellipse)))
                //            {
                //                TCircle circle = (TCircle)figures[i];

                //                if (circle.IsWithinCanvas(circle.x, circle.y, R, canvasWidth, canvasHeight))
                //                {
                //                    figures[i].ChangeRadius(R, canvasWidth, canvasHeight);
                //                    restorePaintments();

                //                }
                                
                //                else
                //                {
                //                    MessageBox.Show("Ошибка: фигура не может быть увеличена.");
                //                }
                //            }
                //        }
                //    }
                //    catch (Exception)
                //    {
                //        MessageBox.Show("Ошибка ввода. Попробуйте ещё раз!");
                //    }
                //    break;

                //case ContainersLibrary.Action.Delete:
                //    int newFiguresCnt = 0;
                //    TFigure[] newFigures = new TFigure[figures.Length];
                //    for (int i = 0; i < figuresCnt; i++)
                //    {
                //        if ((figures[i] is TSquare) && !((figures[i] is ClassLibrary.Rectangle)) && !((figures[i] is Rhombus)) && checkedFiguresList[1])
                //        {
                //            continue;
                //        }
                //        else if ((figures[i] is TCircle) && !((figures[i] is Ellipse)) && checkedFiguresList[4])
                //        {
                //            continue;
                //        }
                //        else if ((figures[i] is Line) && checkedFiguresList[6])
                //        {
                //            continue;
                //        }
                //        else if ((figures[i] is Ellipse) && checkedFiguresList[5])
                //        {
                //            continue;
                //        }
                //        else if ((figures[i] is ClassLibrary.Rectangle) && checkedFiguresList[3])
                //        {
                //            continue;
                //        }
                //        else if ((figures[i] is Rhombus) && checkedFiguresList[2])
                //        {
                //            continue;
                //        }
                //        else
                //        {
                //            newFigures[newFiguresCnt] = figures[i];
                //            newFiguresCnt++;
                //        }
                //    }
                //    figures = newFigures;
                //    figuresCnt = newFiguresCnt;
                //    setFalseOnCheckedList();
                //    setFalseOnFiguresList();
                //    restorePaintments();
                //    break;
                   

            }
            textBox11.Clear();
            textBox12.Clear();
            restorePaintments();
            setFalseOnCheckedList();
            checkedListBox1.ClearSelected();
        }

        
        private void checkedListBox1_ItemCheck_1(Object sender, ItemCheckEventArgs e)
        {
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            Graphics g = pictureBox1.CreateGraphics();
            Color color = Color.Green;

            if (workingWithList)
                color = Color.Orange;
            else if (workingWithMassive) color = Color.Violet;
            if (e.NewValue == CheckState.Checked) color = Color.Red;

            switch (e.Index)
            {
                case 0:
                    {
                        for (int i = 1; i < checkedFiguresList.Length; i++)
                        {
                            checkedFiguresList[i] = (e.NewValue == CheckState.Checked);
                            checkedListBox1.SetItemChecked(i, (e.NewValue == CheckState.Checked));
                        }
                    }
                    break;
                case 1:
                    {
                        //checkedFiguresList[1] = (e.NewValue == CheckState.Checked);
                        //for (int i = 0; i < figuresCnt; i++)
                        //{
                        //    if (figures[i] is TSquare) figures[i].Show(g, color, canvasWidth, canvasHeight);
                        //}
                        //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                        //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                        checkedFiguresList[1] = (e.NewValue == CheckState.Checked);

                        if (workingWithList)
                        {
                            if (list != null)
                            {
                                list.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight, typeof(TSquare));
                                list.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight, typeof(TSquare));
                                //if (massiveFiguresAreRemoved == false)
                                //    massive.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        else if (workingWithMassive)
                        {
                            if (massive != null)
                            {
                                massive.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight);
                                massive.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight);                               
                                //if (listFiguresAreRemoved == false)
                                //    list.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                        checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                    }
                    break;
                case 2:
                    {
                        checkedFiguresList[2] = (e.NewValue == CheckState.Checked);
                        if (workingWithList)
                        {
                            if (list != null)
                            {
                                list.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight, typeof(Rhombus));
                                list.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight, typeof(Rhombus));
                                //if (massiveFiguresAreRemoved == false)
                                //    massive.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        else if (workingWithMassive)
                        {
                            if (massive != null)
                            {
                                massive.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight);
                                massive.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight);                                
                                //if (listFiguresAreRemoved == false)
                                //    list.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        checkedFiguresList[3] = (e.NewValue == CheckState.Checked);
                        if (workingWithList)
                        {
                            if (list != null)
                            {
                                list.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight, typeof(ClassLibrary.Rectangle));
                                list.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight, typeof(ClassLibrary.Rectangle));
                                //if (massiveFiguresAreRemoved == false)
                                //    massive.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        else if (workingWithMassive)
                        {
                            if (massive != null)
                            {
                                massive.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight);
                                massive.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight);
                                //if (listFiguresAreRemoved == false)
                                //    list.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        
                    }
                    break;
                case 4:
                    {
                        checkedFiguresList[4] = (e.NewValue == CheckState.Checked);
                        if (workingWithList)
                        {
                            if (list != null)
                            {
                                list.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight, typeof(TCircle));
                                list.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight, typeof(TCircle));
                                //if (massiveFiguresAreRemoved == false)
                                //    massive.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        else if (workingWithMassive)
                        {
                            if (massive != null)
                            {
                                massive.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight);
                                massive.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight);
                                //if (listFiguresAreRemoved == false)
                                //    list.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        checkedListBox1.SetItemChecked(5, (e.NewValue == CheckState.Checked));
                    }
                    break;
                case 5:
                    {
                        checkedFiguresList[5] = (e.NewValue == CheckState.Checked);
                        if (workingWithList)
                        {
                            if (list != null)
                            {
                                list.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight, typeof(Ellipse));
                                list.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight, typeof(Ellipse));
                                //if (massiveFiguresAreRemoved == false)
                                //    massive.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        else if (workingWithMassive)
                        {
                            if (massive != null)
                            {
                                massive.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight);
                                massive.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight);
                                //if (listFiguresAreRemoved == false)
                                //    list.iterate((int)containerslibrary.action.show, g, canvaswidth, canvasheight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                    }
                    break;
                case 6:
                    {
                        if (checkedFiguresList.Length > 6)
                        {
                            checkedFiguresList[6] = (e.NewValue == CheckState.Checked);
                        }

                        if (workingWithList)
                        {
                            if (list != null)
                            {
                                list.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight, typeof(Line));
                                list.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight, typeof(Line));
                                //if (massiveFiguresAreRemoved == false)
                                //    massive.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                        else if (workingWithMassive)
                        {
                            if (massive != null)
                            {
                                massive.Iterate((int)ContainersLibrary.Action.Remove, g, color, canvasWidth, canvasHeight);
                                massive.Iterate((int)ContainersLibrary.Action.Show, g, color, canvasWidth, canvasHeight);
                                //if (listFiguresAreRemoved == false)
                                //    list.Iterate((int)ContainersLibrary.Action.Show, g, canvasWidth, canvasHeight);
                                //checkedListBox1.SetItemChecked(2, (e.NewValue == CheckState.Checked));
                                //checkedListBox1.SetItemChecked(3, (e.NewValue == CheckState.Checked));
                            }
                        }
                    }
                    break;
            }

        }
       
        private void cancel_button_Click(object sender, EventArgs e)
        {
            enablebuttons(false);
            square_button.Enabled = true;
            line_button.Enabled = true;
            circle_button.Enabled = true;
            ellipse_button.Enabled = true;
            rhombus_button.Enabled = true;
            rectangle_button.Enabled = true;
            move_button.Enabled = true;
            change_radius_button.Enabled = true;
            rotate_ellipse_button.Enabled = true;
            delete_button.Enabled = true;
            //move_figures.Enabled = true;
            //move_circles.Enabled = true;
            //move_squares.Enabled = true;
            //move_lines.Enabled = true;
            //roll_move_figures_up.Enabled = true;
            //roll_move_circles_up.Enabled = true;
            //roll_move_squares_up.Enabled = true;
            //roll_move_lines_up.Enabled = true;
            //randomFilling.Enabled = true;
            removeFigures.Enabled = true;
            showFigures.Enabled = true;
            destroyMassive.Enabled = true;


            hideall();
            checkedListBox1.ClearSelected();
            textBox11.Clear();
            textBox12.Clear();

            restorePaintments();
        }

        

        private void randomFilling_Click_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Random random = new Random();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            if (workingWithList)
            {
                if (list != null)
                {
                    list.Iterate((int)ContainersLibrary.Action.Remove, g, Color.Orange, canvasWidth, canvasHeight, typeof(TFigure));
                    if (massiveFiguresAreRemoved == false)
                        massive.Iterate((int)ContainersLibrary.Action.Show, g, Color.Violet, canvasWidth, canvasHeight);
                }
                list = new List(random);
                MessageBox.Show("Массив заполнен");
            }
            else if (workingWithMassive)
            {
                if (massive != null)
                {
                    massive.Iterate((int)ContainersLibrary.Action.Remove, g, Color.Violet, canvasWidth, canvasHeight);
                    if (listFiguresAreRemoved == false)
                        list.Iterate((int)ContainersLibrary.Action.Show, g, Color.Orange, canvasWidth, canvasHeight, typeof(TFigure));
                }
                massive = new Massive(random);
                MessageBox.Show("Массив заполнен");
            }
            else MessageBox.Show("Выберите: массив или список!");
            //Random random = new Random();
            //for (int i = 0; i < 20; i++)
            //{
            //    Array.Resize(ref figures, figuresCnt + 1);

            //    int index = random.Next(1, 6);
            //    switch (index)
            //    {
            //        case (int)Figure.Square:
            //            figures[figuresCnt] = new TSquare();
            //            break;
            //        case (int)Figure.Line:
            //            figures[figuresCnt] = new Line();
            //            break;
            //        case (int)Figure.Circle:
            //            figures[figuresCnt] = new TCircle();
            //            break;
            //        case (int)Figure.Rhombus:
            //            figures[figuresCnt] = new Rhombus();
            //            break;
            //        case (int)Figure.Rectangle:
            //            figures[figuresCnt] = new ClassLibrary.Rectangle();
            //            break;
            //        case (int)Figure.Ellipse:
            //            figures[figuresCnt] = new Ellipse();
            //            break;
            //    }
            //    //restorePaintments();
            //    figuresCnt++;

            //}

            //randomFilling.Enabled = false;
            //check_destroy = false;


        }

        private void showFigures_Click_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;

            Color color = Color.Green; 
            if (workingWithList)
            {
                list.Iterate((int)ContainersLibrary.Action.Show, g, Color.Orange, canvasWidth, canvasHeight);
                listFiguresAreRemoved = false;
            }
            else if(workingWithMassive)
            {
                massive.Iterate((int)ContainersLibrary.Action.Show, g, Color.Violet, canvasWidth, canvasHeight);
                massiveFiguresAreRemoved = false;
            }
            

            //for (int i = 0; i < figuresCnt; i++)
            //{
            //    figures[i].Show(g, color, canvasWidth, canvasHeight);

            //}
        }

        private void removeFigures_Click_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;
            //for (int i = 0; i < figuresCnt; i++)
            //{
            //    figures[i].Remove(g);
            //}
            if (workingWithList)
            {
                listFiguresAreRemoved = true;
                list.Iterate((int)ContainersLibrary.Action.Remove, g, Color.Orange, canvasWidth, canvasHeight, typeof(TFigure));
                if ((massive != null) && (!(massiveFiguresAreRemoved))) massive.Iterate((int)ContainersLibrary.Action.Show, g, Color.Violet, canvasWidth, canvasHeight);
            }
            else if (workingWithMassive)
            {
                massiveFiguresAreRemoved = true;
                massive.Iterate((int)ContainersLibrary.Action.Remove, g, Color.Violet, canvasWidth, canvasHeight);
                if ((list != null) && (!(listFiguresAreRemoved))) list.Iterate((int)ContainersLibrary.Action.Show, g, Color.Orange, canvasWidth, canvasHeight, typeof(TFigure));
            }
        }

        private void destroyMassive_Click_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;
            //figuresCnt = 0;
            //figures = null;
            ////figures = new TFigure[20];
            //pictureBox1.Refresh();
            ////randomFilling.Enabled = true;
            ////check_destroy = true;
            if (workingWithList && (list != null))
            {
                list.Iterate((int)ContainersLibrary.Action.Remove, g, Color.Orange, canvasWidth, canvasHeight, typeof(TFigure));
                list.DeleteList();
                if (!(massiveFiguresAreRemoved)) massive.Iterate((int)ContainersLibrary.Action.Show, g, Color.Violet, canvasWidth, canvasHeight);
            }
            else if (workingWithMassive && (massive != null))
            {
                massive.Iterate((int)ContainersLibrary.Action.Remove, g, Color.Violet, canvasWidth, canvasHeight);
                massive.DeleteMassive();
                if (!(listFiguresAreRemoved)) list.Iterate((int)ContainersLibrary.Action.Show, g, Color.Orange, canvasWidth, canvasHeight, typeof(TFigure));
            }
        }

        //private void move_figures_Click(object sender, EventArgs e)
        //{
        //    move_figuresKeyPressed = true;

        //    enablebuttons(false);
        //    roll_move_figures_up.Visible = true;
        //    roll_move_figures_up.Enabled = true;


        //}

        //private void move_circles_Click(object sender, EventArgs e)
        //{
        //    move_circlesKeyPressed = true;
        //    enablebuttons(false);
        //    roll_move_circles_up.Visible = true;
        //    roll_move_circles_up.Enabled = true;

        //}

        //private void move_squares_Click(object sender, EventArgs e)
        //{
        //    move_squaresKeyPressed = true;
        //    enablebuttons(false);
        //    roll_move_squares_up.Visible = true;
        //    roll_move_squares_up.Enabled = true;
        //}

        //private void move_lines_Click(object sender, EventArgs e)
        //{
        //    move_linesKeyPressed = true;
        //    enablebuttons(false);
        //    roll_move_lines_up.Visible = true;
        //    roll_move_lines_up.Enabled = true;

        //}

        //private void roll_move_figures_up_Click(object sender, EventArgs e)
        //{
        //    move_figuresKeyPressed = false;
        //    enablebuttons(true);
        //}

        //private void roll_move_circles_up_Click(object sender, EventArgs e)
        //{
        //    move_circlesKeyPressed = false;
        //    enablebuttons(true);
        //}

        //private void roll_move_squares_up_Click(object sender, EventArgs e)
        //{
        //    move_squaresKeyPressed = false;
        //    enablebuttons(true);
        //}

        //private void roll_move_lines_up_Click(object sender, EventArgs e)
        //{
        //    move_linesKeyPressed = false;
        //    enablebuttons(true);
        //}

        private void switchToList_CheckedChanged(object sender, EventArgs e)
        {
            workingWithList = true;
            workingWithMassive = false;
            //randomFilling.Enabled = true;
            //removeFigures.Enabled = true;
            //showFigures.Enabled = true;
            //destroyMassive.Enabled = true;
            //addRandomFigure.Enabled = true;
        }

        private void switchToMassive_CheckedChanged(object sender, EventArgs e)
        {
            workingWithList = false;
            workingWithMassive = true;
            //randomFilling.Enabled = true;
            //removeFigures.Enabled = true;
            //showFigures.Enabled = true;
            //destroyMassive.Enabled = true;
            //addRandomFigure.Enabled = true;
        }

        private void addRandomFigure_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int canvasWidth = pictureBox1.Width - 4;
            int canvasHeight = pictureBox1.Height - 4;
            if (workingWithList) { 
                if (list.AddNode(canvasWidth, canvasHeight))
                {
                    MessageBox.Show("Фигура добавлена");
                }
                else
                {
                    MessageBox.Show("Фигура выходит за рамки! Нажмите еще раз");
                }
            }
            else if (workingWithMassive)
            {
                if (massive.AddElement(random, canvasWidth, canvasHeight))
                {
                    MessageBox.Show("Фигура добавлена");
                }
                else
                {
                    MessageBox.Show("Фигура выходит за рамки! Нажмите еще раз");
                }
            }
        }
    }
}
