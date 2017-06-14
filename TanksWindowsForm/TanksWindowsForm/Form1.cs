using System;
using System.Linq;
using System.Windows.Forms;

namespace TanksWindowsForm
{
    public partial class Form1 : Form
    {
        private GameController gameController;

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            gameController = new GameController();

            // Получаем все существующие объекты типа Label
            foreach (var label in this.Controls.OfType<Label>())
            {
                gameController.AddTanks(label);
            }

            // Получаем все существующие объекты типа Button
            foreach (var button in this.Controls.OfType<Button>())
            {
                gameController.AddObstacle(button);
            }

            gameController.CheckCollisions(this, true);

            // Запускаем таймер
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            gameController.MoveTanks();
            gameController.CheckCollisions(this);
        }

        private void OnTrackBarValueChange(object sender, EventArgs e)
        {
            if (trackBar1.Value != 0)
            {
                timer1.Interval = 1000 / trackBar1.Value;
                timer1.Start();
            }
            else
                timer1.Stop();
        }

        public void CloseForm(string message)
        {
            MessageBox.Show(message);
            Close();
        }
    }
}
