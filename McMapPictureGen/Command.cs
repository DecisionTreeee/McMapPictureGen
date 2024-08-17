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
        public CommandType Type;

        public Command(int x, int y, int z, string blockId, CommandType type = CommandType.Setblock)
        {
            X = x;
            Y = y;
            Z = z;
            BlockId = blockId;
            Type = type;
        }

        public string MergeCommand()
        {
            if (Type == CommandType.Setblock)
            {
                return $"setblock {X} {Y} {Z} {BlockId}";
            }
            else
            {
                return $"tp @a {X} {Y} {Z}";
            }
        }
    }

    public enum CommandType
    {
        Setblock, Tp
    }
}
