using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TanksWindowsForm
{
    public class Tank : GameObject
    {
        private Label label;
        private double direction;
        private Point directionPoint;        

        public Tank(Label label)
        {
            this.label = label;
            label.Text = Settings.letter;
            Collider = label.Bounds;
            label.Margin = new Padding(0);
            label.Padding = new Padding(0);

            // Создаем рандомный угол в радианах                
            direction = Settings.randomNumbers.NextDouble() * Math.PI * 2;
            directionPoint = new Point((int)Math.Round(Math.Cos(direction))
                , (int)Math.Round(Math.Sin(direction)));

            X = label.Location.X; Y = label.Location.Y;
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void Move()
        {
            AddCoord(new Point(directionPoint.X ,directionPoint.Y ));
        }
        public void UpdateCollider()
        {
            Collider = label.Bounds;
        }

        public void AddCoord(Point point)
        {
            Point newLocation = new Point(label.Location.X + point.X,
                              label.Location.Y + point.Y);
            label.Location = newLocation;
            X = label.Location.X;
            Y = label.Location.Y;
        }

        public void ChangeDirection(Tank tank, Rectangle obj)
        {
            // Границы формы по оси x
            if (tank.Collider.Left < obj.Left || tank.Collider.Right > obj.Right)
            {
                directionPoint = new Point(directionPoint.X * -1, directionPoint.Y);
            }
            // Границы формы по оси y
            if (tank.Collider.Top < obj.Top || tank.Collider.Bottom > obj.Bottom)
            {
                directionPoint = new Point(directionPoint.X, directionPoint.Y * -1);
            }
        }
    }
}