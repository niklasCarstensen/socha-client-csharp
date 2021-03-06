﻿using System.Collections.Generic;
using System.Drawing;

namespace SochaClient
{
    public static class Extensions
    {
        public static PlayerTeam OtherTeam(this PlayerTeam t) => t == PlayerTeam.ONE ? PlayerTeam.TWO : PlayerTeam.ONE;

        public static PlayerTeam ToTeam(this PieceColor c) => c == PieceColor.RED ? PlayerTeam.ONE : PlayerTeam.TWO;
        public static PieceColor ToColor(this PlayerTeam t) => t == PlayerTeam.ONE ? PieceColor.RED : PieceColor.BLUE;

        public static Color ToColor(this PieceColor? c) 
        {
            if (c.HasValue)
                if (c.Value == PieceColor.BLUE)
                    return Color.Blue;
                else
                    return Color.Red;
            else
                return Color.Black;
        }
    }
}
