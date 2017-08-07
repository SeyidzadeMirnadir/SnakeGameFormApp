
using System.Drawing;
using System.Linq;

namespace Snake
{
    public class Snake
    {
        public Rectangle[] SnakeRec; // ilanin qrulusu dordbucaqlilardan ibaret arraydir
        Brush brush;
        int x, y;
        private string currentDirection;
        public int SnakeFormWidth;
        public int SnakeFormHeight;

        //?
        private static Snake _instance = null;
        public static Snake GetInstance()
        {
            return _instance ?? (_instance = new Snake());
        }

        public Snake()
        {
            SnakeFormWidth = 0;
            SnakeRec = new Rectangle[10];
            x = 50;
            y = 0;
            brush = new SolidBrush(Color.Red);
            currentDirection = "right";

            for (var i = 0; i < SnakeRec.Length; i++)
            {
                if (i == 0)
                {
                    SnakeRec[i] = new Rectangle(x, y, 9, 9);
                }
                else
                {
                    SnakeRec[i] = new Rectangle(x, y, 9, 9);
                }
                x = x - 10;
            }

        }

        //ilan yedikden sonra bir dordbucaqli artirilir
        //Butun snakeRec arreyi is bir addim geriye gedir 
        //ve butun koordinatlari basa kocurulur

        public void IncreaseLength()
        {
            // yeni array +1 uzunluga malik snakeRec arayi olur
            var snakeTemp = new Rectangle[SnakeRec.Count() + 1];
            var j = 0;
            for (var i = 1; i < snakeTemp.Count(); i++)
            {
                snakeTemp[i] = SnakeRec[j];
                j++;
            }
            //?
            snakeTemp[0] = new Rectangle(SnakeRec[0].X, SnakeRec[0].Y, 9, 9);
            SnakeRec = snakeTemp;
        }

        
        public void Draw(Graphics g)
        {
            var i = 0;
            foreach (var rec in SnakeRec)
            {
                if (i == 0)
                {
                    
                    g.FillRectangle(new SolidBrush(Color.White), rec);
                    i++;
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.Red), rec);
                }
            }
        }

        internal void Move(string direction)
        {
            
            for (var i = SnakeRec.Length - 1; i > 0; i--)
            {
                SnakeRec[i] = SnakeRec[i - 1];
            }

            //Sol divara deyende vereceyi reaksiya
            if (SnakeRec[0].X - 10 < 0)
            {
                if (direction == "left")
                {
                    SnakeRec[0].X = SnakeFormWidth;
                }
            }

            //Sag divara deyende vereceyi reaksiya
            if (SnakeRec[0].X + 10 >= SnakeFormWidth)
            {
                if (direction == "right")
                {
                    SnakeRec[0].X = -10;
                }
            }

            if (SnakeRec[0].Y - 10 < 0)
            {
                if (direction == "up")
                {
                    SnakeRec[0].Y = SnakeFormHeight;
                }
            }

            if (SnakeRec[0].Y + 10 >= SnakeFormHeight)
            {
                if (direction == "down")
                {
                    SnakeRec[0].Y = -10;
                }
            }

            if (direction == "left")
            {
                SnakeRec[0].X = SnakeRec[0].X - 10;
            }
            if (direction == "right")
            {
                SnakeRec[0].X = SnakeRec[0].X + 10;
            }
            if (direction == "down")
            {
                SnakeRec[0].Y = SnakeRec[0].Y + 10;
            }
            if (direction == "up")
                SnakeRec[0].Y = SnakeRec[0].Y - 10;

        }

        internal void Reset()
        {
            SnakeFormWidth = 0;
            SnakeRec = new Rectangle[10];
            x = 50;
            y = 0;
            brush = new SolidBrush(Color.Blue);
            currentDirection = "right";

            for (int i = 0; i < SnakeRec.Length; i++)
            {
                if (i == 0)
                    SnakeRec[i] = new Rectangle(x, y, 9, 9);
                else SnakeRec[i] = new Rectangle(x, y, 9, 9);
                x = x - 10;
            }
        }
    }
}
