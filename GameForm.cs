using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Happy_Hunting
{
    class GameForm : Form
    {
        GameLevel GameLevel;
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        Character winner;

        public GameForm(DirectoryInfo imagesDirectory = null)
        {
            GameLevel = new GameLevel(GameMaps.MapFirst);
            ClientSize = new Size(50 * GameLevel.Width, 50 * GameLevel.Height + 25);
            FormBorderStyle = FormBorderStyle.FixedDialog;

            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Model");
            foreach (var e in imagesDirectory.GetFiles("*.jpg"))
                bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);
            Paint += PaintMap;
            KeyDown += MoveCharacter;
            GameLevel.GameFinish += (winner) =>
            {
                this.winner = winner;
                Paint += PaintFinishScreen;
                KeyDown -= MoveCharacter;
                Invalidate();
            };

            var menu = new MenuStrip();
            var first = new ToolStripMenuItem("Первый");
            first.Click += (sender, e) => NewGame(GameMaps.MapFirst);
            menu.Items.Add(first);
            var second = new ToolStripMenuItem("Второй");
            second.Click += (sender, e) => NewGame(GameMaps.MapSecond);
            menu.Items.Add(second);
            Controls.Add(menu);
        }

        private void MoveCharacter(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    GameLevel.Gomer.Move(GameLevel, Direction.Left);
                    break;
                case Keys.Right:
                    GameLevel.Gomer.Move(GameLevel, Direction.Right);
                    break;
                case Keys.Down:
                    GameLevel.Gomer.Move(GameLevel, Direction.Down);
                    break;
                case Keys.Up:
                    GameLevel.Gomer.Move(GameLevel, Direction.Up);
                    break;
            }
            Invalidate();
        }

        private void PaintMap(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, 0, 25, 50 * GameLevel.Width, 50 * GameLevel.Height + 25);
            for (var x = 0; x < GameLevel.Width; x++)
                for (var y = 0; y < GameLevel.Height; y++)
                    e.Graphics.DrawImage(bitmaps[GameLevel[new Point(x, y)].ToString() + ".jpg"], new Point(x * 50, y * 50 + 25));
        }

        private void NewGame(ElementsOfMap[,] map)
        {
            KeyDown -= MoveCharacter;
            Paint -= PaintMap;
            GameLevel = new GameLevel(map);
            ClientSize = new Size(50 * GameLevel.Width, 50 * GameLevel.Height + 25);
            Paint += PaintMap;
            KeyDown += MoveCharacter;
            GameLevel.GameFinish += (winner) =>
            {
                this.winner = winner;
                Paint += PaintFinishScreen;
                KeyDown -= MoveCharacter;
                Invalidate();
            };
            Invalidate();
        }

        private void PaintFinishScreen(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                        Brushes.Yellow, 0, 25, 50 * GameLevel.Width,
                        50 * GameLevel.Height + 25);
            e.Graphics.DrawString("Win:" + winner.ToString(), new Font("Arial", 16), Brushes.Black, new Point(0, 25));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Happy Hunting";
            DoubleBuffered = true;
        }
    }
}
