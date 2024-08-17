using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMapPictureGen
{
    public static class PackData
    {
        public static Dictionary<int[], int> VersionDic = new Dictionary<int[], int>()
        {
            { [1130, 1144], 4 },
            { [1150, 1161], 5 },
            { [1162, 1165], 6 },
            { [1170, 1171], 7 },
            { [1180, 1181], 8 },
            { [1182, 1182], 9 },
            { [1190, 1193], 10 },
            { [1194, 1194], 12 },
            { [1200, 1201], 15 },
            { [1202, 1202], 18 },
            { [1203, 9999], 23 },
        };

        public class MetaData
        {
            public Pack pack;

            public MetaData(Pack pack)
            {
                this.pack = pack;
            }

            public class Pack
            {
                public int pack_format;
                public string description;

                public Pack(int pack_format, string description)
                {
                    this.pack_format = pack_format;
                    this.description = description;
                }
            }
        }
    }
}
