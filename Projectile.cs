using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace tankDualBattle
{
    class Projectile
    {
        public string direction;
        public int projectileL;
        public int projectileT;

        private sbyte speed = 10;
        private PictureBox projectile = new PictureBox();
        private Timer projectileTimer = new Timer();

        public void MakeProjectile(Form form)
        {
            projectile.BackColor = Color.White;
            projectile.Size = new Size(5, 5);
            projectile.Tag = "projectile";
            projectile.Left = projectileL;
            projectile.Top = projectileT;
            projectile.BringToFront();

            form.Controls.Add(projectile);

            projectileTimer.Interval = speed;
            projectileTimer.Tick += new EventHandler(projectileTimerEvent);
            projectileTimer.Start();

        }

        private void projectileTimerEvent(object sender, EventArgs e)
        {
            switch (direction)
            {
                case "left":
                    projectile.Left -= speed;
                    break;
                case "right":
                    projectile.Left += speed;
                    break;
                case "up":
                    projectile.Left -= speed;
                    break;
                case "down":
                    projectile.Left += speed;
                    break;
            }

            if (projectile.Left < 10 || projectile.Left > 860 || projectile.Top < 10 || projectile.Top >600)
            {
                projectileTimer.Stop();
                projectileTimer.Dispose();
                projectile.Dispose();
                projectileTimer = null;
                projectile = null;
            }
        }
    }
}
