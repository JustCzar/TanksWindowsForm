using System.Drawing;
using System.Windows.Forms;

namespace TanksWindowsForm
{
    public class Obstacle : GameObject
    {
        private Button button;

        public Obstacle(Button button)
        {            
            this.button = button;
            button.Text = "";
            Collider = button.Bounds;
            X = button.Location.X; Y = button.Location.Y;
            button.BackColor = Color.Black;
        }
    }
}