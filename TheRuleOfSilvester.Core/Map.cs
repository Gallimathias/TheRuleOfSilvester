﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TheRuleOfSilvester.Core.Cells;

namespace TheRuleOfSilvester.Core
{
    public class Map
    {
        //┌┬┐└┴┘─│├┼┤
        //╔╦╗╚╩╝═║╠╬╣
        public List<Cell> Cells { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Map(int height, int width)
        {
            Height = height;
            Width = width;
            Cells = new List<Cell>
            {
                new CornerRightDown (this) { Position = new Point(0, 0) },
                new LeftDownRight   (this) { Position = new Point(0, 1) },
                new CornerLeftDown  (this) { Position = new Point(0, 2) },
                new UpDownRight     (this) { Position = new Point(1, 0) },
                new CrossLeftRightUpDown (this) { Position = new Point(1, 1) },
                new UpDownLeft      (this) { Position = new Point(1, 2) },
                new CornerRightUp   (this) { Position = new Point(2, 0) },
                new LeftUpRight     (this) { Position = new Point(2, 1) },
                new CornerLeftUp    (this) { Position = new Point(2, 2) }
            };
        }
        public Map(int height, int width, Cell[] cells) : this(height, width)
        {
            Cells = new List<Cell>(cells);
        }

        public bool IsTileOccupied(Point pos)
        {
            var cellList = Cells.Where(x=>x.GetType()!=typeof(Player)).Where(x =>
             x.Position.X * x.Height <= pos.X && (x.Position.X * x.Height + x.Height) > pos.X
             && x.Position.Y * x.Width <= pos.Y && (x.Position.Y * x.Width + x.Width) > pos.Y);

            foreach (var cell in cellList)
            {
                if (cell.Lines[pos.X % cell.Height, pos.Y % cell.Width] != null)
                    return true;
            }

            return false;
        }
        public Cell GetTileAbsolutePos(Point pos)
        {
            return Cells.Where(x => x.GetType() != typeof(Player)).FirstOrDefault(x =>
                 x.Position.X * x.Height <= pos.X && (x.Position.X * x.Height + x.Height) > pos.X
                 && x.Position.Y * x.Width <= pos.Y && (x.Position.Y * x.Width + x.Width) > pos.Y);
            
        }
    }
}
