using System;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Fractals
{
    public partial class MainWindow : Window
    {
        private double angle = 0;
        private double length = 350;
        private double angleIncrement = 0.8;
        private double lengthScale = 0.99;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            drawingCanvas = new Canvas();
            this.Content = drawingCanvas;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2); // Adjust the interval for the animation speed
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Draw a line segment with the current angle and length
            double x1 = drawingCanvas.ActualWidth / 2;
            double y1 = drawingCanvas.ActualHeight / 2;

            double x2 = x1 + length * Math.Cos(angle);
            double y2 = y1 + length * Math.Sin(angle);

            Line line = new Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Brushes.Black,
                StrokeThickness = 0.5
            };

            drawingCanvas.Children.Add(line);

            // Update angle and length for the next segment
            angle += angleIncrement;
            length += lengthScale;
        }
    }
}
