﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace CollisionDetection
{
    public partial class Form1 : Form
    {
        Timer loop = new Timer();

        List<Square> squares = new List<Square>();

        Bitmap map;
        Pen black = new Pen(Color.Black, 1);
        Pen red = new Pen(Color.Red, 1);

        Random rand = new Random(8675309);

        Stopwatch totalCalcTime = new Stopwatch();
        Stopwatch frameCounter = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            loop.Enabled = true;

            loop.Tick += new EventHandler(Update);
            loop.Interval = 1;

            frameCounter.Start();

            map = new Bitmap(CollisionMap.Width, CollisionMap.Height);
            Square.Bounds = new Vector2(CollisionMap.Width, CollisionMap.Height);
        }

        /// <summary>
        /// Called as fast as it possibly can be called (up to every 1ms)
        /// </summary>
        public void Update(object o, EventArgs e)
        {
            totalCalcTime.Reset(); totalCalcTime.Start();
            map = new Bitmap(CollisionMap.Width, CollisionMap.Height);
            for (int i = 0; i < 20; i++)
                squares.Add(new Square(rand.Next(3, 5), new Vector2(rand.Next(0, CollisionMap.Width), rand.Next(0, CollisionMap.Height)), new Vector2(rand.Next(-3, 4), rand.Next(-3, 4))));

            foreach(Square s in squares)
            {
                s.Move();
            }
            /**********************************************************************/
            /* SWITCH THESE LINES OF CODE TO TEST THE DIFFERENT METHODS */
            //CollisionDetection();
            CollisionDetectionParallel();
            /**********************************************************************/
            DrawSquares(map);

            totalCalcTime.Stop();
            NumSquaresLabel.Invoke(new MethodInvoker(delegate ()
            {
                FPSLabel.Text = "Frames Per Second = " + 1000f / frameCounter.ElapsedMilliseconds;
                NumSquaresLabel.Text = "Num Squares = " + squares.Count;
                CalcTimeLabel.Text = "Total Calculation Time = " + totalCalcTime.ElapsedMilliseconds + "ms";
            }));
            frameCounter.Reset(); frameCounter.Start();
        }

        /// <summary>
        /// Collision detection without tasks
        /// </summary>
        public void CollisionDetection()
        {

        }

        /// <summary>
        /// Parallelized collision detection
        /// YOUR CODE GOES HERE!
        /// </summary>
        public void CollisionDetectionParallel()
        {
            //Reset the color of squares to black.

            for (int i = 0; i < squares.Count; i ++)
                squares[i].Color = Color.Black;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < squares.Count; i += 8)
                {
                    for (int j = 0; j < squares.Count; j ++)
                    {
                        if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                        {
                            squares[i].Color = Color.Red;
                            squares[j].Color = Color.Red;
                        }
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 1; i < squares.Count; i += 8)
                {
                    for (int j = 0; j < squares.Count; j++)
                    {
                        if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                        {
                            squares[i].Color = Color.Red;
                            squares[j].Color = Color.Red;
                        }
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 2; i < squares.Count; i += 8)
                {
                    for (int j = 0; j < squares.Count; j++)
                    {
                        if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                        {
                            squares[i].Color = Color.Red;
                            squares[j].Color = Color.Red;
                        }
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 3; i < squares.Count; i += 8)
                {
                    for (int j = 0; j < squares.Count; j++)
                    {
                        if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                        {
                            squares[i].Color = Color.Red;
                            squares[j].Color = Color.Red;
                        }
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 4; i < squares.Count; i += 8)
                {
                    for (int j = 0; j < squares.Count; j++)
                    {
                        if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                        {
                            squares[i].Color = Color.Red;
                            squares[j].Color = Color.Red;
                        }
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 5; i < squares.Count; i += 8)
                {
                    for (int j = 0; j < squares.Count; j++)
                    {
                        if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                        {
                            squares[i].Color = Color.Red;
                            squares[j].Color = Color.Red;
                        }
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 6; i < squares.Count; i += 8)
                {
                    for (int j = 0; j < squares.Count; j++)
                    {
                        if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                        {
                            squares[i].Color = Color.Red;
                            squares[j].Color = Color.Red;
                        }
                    }
                }
            });

            for (int i = 7; i < squares.Count; i+= 8)
            {
                for (int j = 0; j < squares.Count; j++)
                {
                    if (squares[i] != squares[j] && squares[i].IsCollidingWith(squares[j]))
                    {
                        squares[i].Color = Color.Red;
                        squares[j].Color = Color.Red;
                    }
                }
            }
        }

        /// <summary>
        /// Draws the squares on the screen
        /// </summary>
        /// <param name="bitmap">The bitmap to update</param>
        public void DrawSquares(Image bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            foreach (Square s in squares.Where(t => t.Color == Color.Red))
            {
                g.DrawRectangle(red, s.Position.X, s.Position.Y, s.Size, s.Size);
            }
            foreach (Square s in squares.Where(t => t.Color == Color.Black))
            {
                g.DrawRectangle(black, s.Position.X, s.Position.Y, s.Size, s.Size);
            }
            CollisionMap.Image = bitmap;
        }
    }
}
