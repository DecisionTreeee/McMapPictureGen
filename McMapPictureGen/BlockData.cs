﻿using System.Drawing;

namespace McMapPictureGen
{
    public static class BlockData
    {
        public static Dictionary<string, string> BlockDic = new Dictionary<string, string>()
        {
            { "0", "minecraft:glass" },
            { "1", "minecraft:slime_block" },
            { "2", "minecraft:birch_planks" },
            { "3", "minecraft:mushroom_stem[east=true,west=true,north=true,south=true,up=true,down=true]" },
            { "4", "minecraft:redstone_block" },
            { "5", "minecraft:ice" },
            { "6", "minecraft:iron_block" },
            { "7", "minecraft:oak_leaves[distance=7,persistent=true]" },
            { "8", "minecraft:white_concrete" },
            { "9", "minecraft:clay" },
            { "10", "minecraft:polished_granite"},
            { "11", "minecraft:cobblestone" },
            { "12", "minecraft:water[level=0]" },
            { "13", "minecraft:oak_planks" },
            { "14", "minecraft:polished_diorite" },
            { "15", "minecraft:orange_concrete" },
            { "16", "minecraft:magenta_concrete" },
            { "17", "minecraft:light_blue_concrete" },
            { "18", "minecraft:yellow_concrete" },
            { "19", "minecraft:lime_concrete" },
            { "20", "minecraft:pink_concrete" },
            { "21", "minecraft:gray_concrete" },
            { "22", "minecraft:light_gray_concrete" },
            { "23", "minecraft:cyan_concrete" },
            { "24", "minecraft:purple_concrete" },
            { "25", "minecraft:blue_concrete" },
            { "26", "minecraft:brown_concrete" },
            { "27", "minecraft:green_concrete" },
            { "28", "minecraft:red_concrete" },
            { "29", "minecraft:black_concrete" },
            { "30", "minecraft:gold_block" },
            { "31", "minecraft:diamond_block" },
            { "32", "minecraft:lapis_block" },
            { "33", "minecraft:emerald_block" },
            { "34", "minecraft:spruce_planks" },
            { "35", "minecraft:netherrack" },
            { "36", "minecraft:white_terracotta" },
            { "37", "minecraft:orange_terracotta" },
            { "38", "minecraft:magenta_terracotta" },
            { "39", "minecraft:light_blue_terracotta" },
            { "40", "minecraft:yellow_terracotta" },
            { "41", "minecraft:lime_terracotta" },
            { "42", "minecraft:pink_terracotta" },
            { "43", "minecraft:gray_terracotta" },
            { "44", "minecraft:light_gray_terracotta" },
            { "45", "minecraft:cyan_terracotta" },
            { "46", "minecraft:purple_terracotta" },
            { "47", "minecraft:blue_terracotta" },
            { "48", "minecraft:brown_terracotta" },
            { "49", "minecraft:green_terracotta" },
            { "50", "minecraft:red_terracotta" },
            { "51", "minecraft:black_terracotta" },
            { "52", "minecraft:crimson_nylium" },
            { "53", "minecraft:crimson_planks" },
            { "54", "minecraft:crimson_hyphae[axis=y]" },
            { "55", "minecraft:warped_nylium" },
            { "56", "minecraft:warped_planks" },
            { "57", "minecraft:warped_hyphae[axis=y]" },
            { "58", "minecraft:warped_wart_block" },
            { "59", "minecraft:deepslate" },
            { "60", "minecraft:raw_iron_block" }
        };

        public static Dictionary<string, Color> ColorDic = new Dictionary<string, Color>()
        {
            { "1", Color.FromArgb(127, 178, 56) },
            { "2", Color.FromArgb(247, 233, 163) },
            { "3", Color.FromArgb(199, 199, 199) },
            { "4", Color.FromArgb(255, 0, 0) },
            { "5", Color.FromArgb(160, 160, 255) },
            { "6", Color.FromArgb(167, 167, 167) },
            { "7", Color.FromArgb(0, 124, 0) },
            { "8", Color.FromArgb(255, 255, 255) },
            { "9", Color.FromArgb(164, 168, 184) },
            { "10", Color.FromArgb(151, 109, 77) },
            { "11", Color.FromArgb(112, 112, 112) },
            { "12", Color.FromArgb(64, 64, 255) },
            { "13", Color.FromArgb(143, 119, 72) },
            { "14", Color.FromArgb(255, 252, 245) },
            { "15", Color.FromArgb(216, 127, 51) },
            { "16", Color.FromArgb(178, 76, 216) },
            { "17", Color.FromArgb(102, 153, 216) },
            { "18", Color.FromArgb(229, 229, 51) },
            { "19", Color.FromArgb(127, 204, 25) },
            { "20", Color.FromArgb(242, 127, 165) },
            { "21", Color.FromArgb(76, 76, 76) },
            { "22", Color.FromArgb(153, 153, 153) },
            { "23", Color.FromArgb(76, 127, 153) },
            { "24", Color.FromArgb(127, 63, 178) },
            { "25", Color.FromArgb(51, 76, 178) },
            { "26", Color.FromArgb(102, 76, 51) },
            { "27", Color.FromArgb(102, 127, 51) },
            { "28", Color.FromArgb(153, 51, 51) },
            { "29", Color.FromArgb(25, 25, 25) },
            { "30", Color.FromArgb(250, 238, 77) },
            { "31", Color.FromArgb(92, 219, 213) },
            { "32", Color.FromArgb(74, 128, 255) },
            { "33", Color.FromArgb(0, 217, 58) },
            { "34", Color.FromArgb(129, 86, 4) },
            { "35", Color.FromArgb(112, 2, 0    ) },
            { "36", Color.FromArgb(209, 177, 161) },
            { "37", Color.FromArgb(159, 82, 36) },
            { "38", Color.FromArgb(149, 87, 108) },
            { "39", Color.FromArgb(112, 108, 138) },
            { "40", Color.FromArgb(186, 133, 36) },
            { "41", Color.FromArgb(103, 117, 53) },
            { "42", Color.FromArgb(160, 77, 78) },
            { "43", Color.FromArgb(57, 41, 35) },
            { "44", Color.FromArgb(135, 107, 98) },
            { "45", Color.FromArgb(87, 92, 92) },
            { "46", Color.FromArgb(122, 73, 88) },
            { "47", Color.FromArgb(76, 62, 92) },
            { "48", Color.FromArgb(76, 50, 35) },
            { "49", Color.FromArgb(76, 82, 42) },
            { "50", Color.FromArgb(142, 60, 46) },
            { "51", Color.FromArgb(37, 22, 16) },
            { "52", Color.FromArgb(189, 48, 49) },
            { "53", Color.FromArgb(148, 63, 97) },
            { "54", Color.FromArgb(92, 25, 29) },
            { "55", Color.FromArgb(22, 126, 134) },
            { "56", Color.FromArgb(58, 142, 140) },
            { "57", Color.FromArgb(86, 44, 62) },
            { "58", Color.FromArgb(20, 180, 133) },
            { "59", Color.FromArgb(86, 86, 86) },
            { "60", Color.FromArgb(186, 150, 12) }
        };

        public static Dictionary<string, float> ShadowDic = new Dictionary<string, float>()
        {
            { "0", 0.71f },
            { "1", 0.86f },
            { "2", 1f }
        };
    }
}
