using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tren.App
{
    public class CreateHelper
    {
        Random random = new Random();

        public PictureBox CreateSnakePart(int x, int y)
        {
            return new PictureBox
            {
                BackColor = Color.DarkGreen,
                Width = Settings.SellSize,
                Height = Settings.SellSize,
                Location = new Point(x, y)
            };
        }

        public Label CreateFood(int x, int y)
        {
            return new Label
            {
                BackColor = Color.Orange,
                Location = new Point(x, y),
                Width = Settings.SellSize,
                Height = Settings.SellSize,
            };
        }

        public Point CreateNewLocation()
        {
            // генерируем от 0 до ширины/высоты
            int foodX = random.Next(0, Settings.FieldWidth - Settings.SellSize);
            // что бы переменная была кратна размеру клетки поля (что бы еда появлялась не где попало а только на определенных координатах, проходя через которые голова змеи четко совпадет с координатами еды)
            int tmpX = foodX % Settings.SellSize;
            foodX -= tmpX;

            int foodY = random.Next(0, Settings.FieldHeight - Settings.SellSize);
            int tmpY = foodY % Settings.SellSize;
            foodY -= tmpY;

            return new Point(foodX, foodY);
        }

        public PictureBox CreateGrigItem(int iterator, string how)
        {
            PictureBox item = new PictureBox();
            item.BackColor = Color.LightBlue;

            switch (how)
            {
                case "byX":
                    item.Location = new Point(0, Settings.SellSize * iterator);
                    item.Size = new Size(Settings.FieldWidth, 1);
                    break;
                case "byY":
                    item.Location = new Point(Settings.SellSize * iterator, 0);
                    item.Size = new Size(1, Settings.FieldWidth);
                    break;
            }
            return item;
        }
    }
}
