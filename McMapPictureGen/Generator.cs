using System.Drawing;
using System.Drawing.Drawing2D;

namespace McMapPictureGen
{
    public class Generator
    {
        public static Bitmap BmpScale(Bitmap bmp, float percent)
        {
            if (bmp.Width == bmp.Width * percent / 100f && bmp.Height == bmp.Height * percent / 100f)
            {
                return bmp;
            }

            Bitmap scaledBitmap = new Bitmap((int)(bmp.Width * percent / 100f), (int)(bmp.Height * percent / 100f));
            using (Graphics g = Graphics.FromImage(scaledBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, 0, 0, (int)(bmp.Width * percent / 100f), (int)(bmp.Height * percent / 100f));
            }

            return scaledBitmap;
        }

        public static float ColorDistance(Color c1, Color c2)
        {
            float rMean = (c1.R + c2.R) / 2f;
            float r = c1.R - c2.R;
            float g = c1.G - c2.G;
            float b = c1.B - c2.B;

            float dis = (float)Math.Sqrt((2f + rMean / 256f) * Math.Pow(r, 2f) + 4f * Math.Pow(g, 2f) + (2f + (255f - rMean) / 256f) * Math.Pow(b, 2f));
            return dis;
        }

        public static Color FindColor(Color c, Dictionary<Color, int[]> colorShadowedDic)
        {
            Dictionary<Color, float> dic = new Dictionary<Color, float>();
            foreach (Color test in colorShadowedDic.Keys)
            {
                dic.Add(test, ColorDistance(c, test));
            }

            return dic.First(x => x.Value == dic.Values.Min()).Key;
        }

        public static Bitmap Generate(Bitmap bmp, Dictionary<Color, int[]> colorShadowedDic)
        {
            Bitmap output = new Bitmap(bmp.Width, bmp.Height);
            PointBitmap pointOutput = new PointBitmap(output);
            pointOutput.LockBits();

            for (int w = 0; w < output.Width; w++)
            {
                for (int h = 0; h < output.Height; h++)
                {
                    pointOutput.SetPixel(w, h, FindColor(pointOutput.GetPixel(w, h), colorShadowedDic));
                }
            }

            pointOutput.UnlockBits();

            return output;
        }

        public static (List<string>, bool) Transform(Bitmap bmp, Dictionary<Color, int[]> colorShadowedDic)
        {
            List<Command> commands = new List<Command>();
            List<string> output = new List<string>();
            int w = bmp.Width;
            int h = bmp.Height;
            int y = 20;

            PointBitmap pointBmp = new PointBitmap(bmp);
            pointBmp.LockBits();

            for (int _w = 0; _w < w; _w++)
            {
                int _y = y;
                int _x = _w - w / 2;

                //output.Add($"tp @a {_x} {_y} {h - w / 2}");

                for (int _h = 0; _h < h; _h++)
                {
                    int _z = _h - w / 2;
                    Color c = pointBmp.GetPixel(_w, _h);
                    int[] id = colorShadowedDic[c];
                    string block = BlockData.BlockDic[id[0].ToString()];

                    if (id[1] == 0)
                    {
                        _y -= 1;
                    }
                    else if (id[1] == 2)
                    {
                        _y += 1;
                    }

                    commands.Add(new Command(_x, _y, _z, block));
                }
            }

            pointBmp.UnlockBits();

            // 自动处理高度
            bool reachHighLimit = false;

            int _y_max = commands.Max(x => x.Y);
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Y += 255 - _y_max;

                if (commands[i].Y < 0)
                {
                    reachHighLimit = true;
                }

                output.Add(commands[i].MergeCommand());
            }

            return (output, reachHighLimit);
        }
    }
}
