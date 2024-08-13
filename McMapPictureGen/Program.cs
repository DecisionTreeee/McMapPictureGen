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
            string fileName = Path.GetFileNameWithoutExtension(path);
            Console.WriteLine("压缩程度(百分比)");
            float compress = float.Parse(Console.ReadLine());

            Dictionary<Color, int[]> colorShadowedDic = new Dictionary<Color, int[]>();
            for (int i = 1; i <= 60; i++)
            {
                if (i == 12)
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

            File.WriteAllText($"./{fileName}.mcfunction", sb.ToString());
            Console.WriteLine($"文件保存在 {Path.GetFullPath($"./{fileName}.mcfunction")}");
        }
    }
}
