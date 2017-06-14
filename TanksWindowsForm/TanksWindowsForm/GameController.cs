using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TanksWindowsForm
{
    public class GameController
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<Obstacle> obstacles = new List<Obstacle>();
        private List<Tank> tanks = new List<Tank>();

        public void AddObstacle(Button button)
        {
            obstacles.Add(new Obstacle(button));
            gameObjects.Add((GameObject)obstacles[obstacles.Count - 1]);
        }
        public void AddTanks(Label label)
        {
            tanks.Add(new Tank(label));
            gameObjects.Add((GameObject)tanks[tanks.Count - 1]);
        }

        public void CheckCollisions(Form1 form, bool onStart = false)
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                // Границы формы
                if (tanks[i].X < 0 || tanks[i].Y < 0 || tanks[i].Collider.Bottom >
                    form.ClientRectangle.Bottom || tanks[i].Collider.Right > form.ClientRectangle.Right)
                {
                    if (onStart)
                        form.CloseForm("Танки выходят за границы формы");
                    Rectangle rect = new Rectangle(0, 0, form.ClientRectangle.Width, form.ClientRectangle.Height);
                    tanks[i].ChangeDirection(tanks[i], rect);
                }
                // Колизия с объектами
                for (int j = 0; j < obstacles.Count; j++)
                {
                    if (tanks[i].Collider.IntersectsWith(obstacles[j].Collider))
                    {
                        if (onStart)
                            form.CloseForm("Танки пересекаются с препятствиями");
                        tanks[i].ChangeDirection(tanks[i], obstacles[j].Collider);
                    }
                }
                // Колизия с танками
                for (int j = 1 + i; j < tanks.Count; j++)
                {
                    if (tanks[i].Collider.IntersectsWith(tanks[j].Collider))
                    {
                        if (onStart)
                            form.CloseForm("Танки пересекаются между собой");
                        tanks[i].ChangeDirection(tanks[i], tanks[j].Collider);
                        tanks[j].ChangeDirection(tanks[j], tanks[i].Collider);
                    }
                }
            }
        }

        public void MoveTanks()
        {
            foreach (var tank in tanks)
            {
                tank.Move();
                tank.UpdateCollider();
            }
        }

        public List<Tank> GetTanks()
        {
            return tanks;
        }
        public List<Obstacle> GetObstacles()
        {
            return obstacles;
        }
        public List<GameObject> GetAllObjects()
        {
            return gameObjects;
        }
    }
}