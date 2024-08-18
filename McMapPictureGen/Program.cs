using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace McMapPictureGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("文件路径");
            string path = Console.ReadLine();
            Console.WriteLine("压缩程度(百分比)");
            float compress = float.Parse(Console.ReadLine());

            Dictionary<Color, int[]> colorShadowedDic = new Dictionary<Color, int[]>();
            for (int i = 1; i <= 60; i++)
            {
                if (i == 12) // 排除流动水
                {
                    continue;
                }
                Color c = BlockData.ColorDic[i.ToString()];
                for (int j = 0; j < 3; j++)
                {
                    float s0 = BlockData.ShadowDic[j.ToString()];
                    Color tempColor = Color.FromArgb((int)Math.Round(c.R * s0), (int)Math.Round(c.G * s0), (int)Math.Round(c.B * s0));
                    colorShadowedDic.Add(tempColor, [i, j]);
                }
            }

            Bitmap source = new Bitmap(path);
            Bitmap compressed = Generator.BmpScale(source, compress);

            Bitmap outputBmp = Generator.Generate(compressed, colorShadowedDic);
            List<string> outputFunc;
            bool reach;
            (outputFunc, reach) = Generator.Transform(outputBmp, colorShadowedDic);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < outputFunc.Count; i++)
            {
                sb.Append(outputFunc[i].ToString() + "\n");
            }

            if (reach)
            {
                Console.WriteLine("警告: 到达限低或限高");
            }

            Console.WriteLine("是否自动生成数据包? (y/n)");
            string yn = Console.ReadLine();
            if (yn == "y")
            {
                Console.WriteLine("输入游戏版本(例如1.16.5)");
                int gameVersion = int.Parse(Console.ReadLine().Replace(".", ""));
                if (gameVersion < 1000)
                {
                    gameVersion *= 10;
                }
                int packVersion = PackGenerator.FindPackVersion(gameVersion);

                PackGenerator.GenerateDir(packVersion, outputFunc);
                PackGenerator.ZipPack();

                Console.WriteLine($"数据包保存在 {Path.GetFullPath($"./pic.zip")}");
            }
            if (yn == "n")
            {
                File.WriteAllText($"draw.mcfunction", sb.ToString());
                Console.WriteLine($"文件保存在 {Path.GetFullPath($"./draw.mcfunction")}");
            }

            Console.ReadLine();
        }
    }
}
