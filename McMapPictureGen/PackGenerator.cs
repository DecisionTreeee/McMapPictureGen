using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMapPictureGen
{
    public class PackGenerator
    {
        public static int FindPackVersion(int gameVersion)
        {
            int[] key = PackData.VersionDic.Keys.First(x => gameVersion >= x[0] && gameVersion <= x[1]);
            int packVersion = PackData.VersionDic[key];

            return packVersion;
        }

        public static void GenerateDir(int packVersion, List<string> cmds)
        {
            Directory.CreateDirectory("pic/data/pic/functions");
            File.WriteAllLines("pic/data/pic/functions/draw.mcfunction", cmds.ToArray());

            PackData.MetaData metaData = new PackData.MetaData(new PackData.MetaData.Pack(packVersion, "由 MMPG 自动生成的地图画数据包"));
            string metaJson = JsonConvert.SerializeObject(metaData, Formatting.Indented);
            File.WriteAllText("pic/pack.mcmeta", metaJson);
        }

        public static void ZipPack()
        {
            ZipFile.CreateFromDirectory("pic", "pic.zip", CompressionLevel.Optimal, false);
            Directory.Delete("pic", true);
        }
    }
}
