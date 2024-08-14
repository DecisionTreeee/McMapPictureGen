using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMapPictureGen
{
    public class Command
    {
        public int X;
        public int Y;
        public int Z;
        public string BlockId;

        public Command(int x, int y, int z, string blockId)
        {
            X = x;
            Y = y;
            Z = z;
            BlockId = blockId;
        }

        public string MergeCommand()
        {
            return $"setblock {X} {Y} {Z} {BlockId}";
        }
    }
}
