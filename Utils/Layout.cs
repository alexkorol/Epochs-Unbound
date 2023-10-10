using System;
using System.Collections.Generic;

namespace EpochsUnbound.Utils
{
    struct Layout
    {
        public static Orientation FlatTop = new Orientation(3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0), 2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0, 0.0);
        public static Orientation PointyTop = new Orientation(Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0, Math.Sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0, 0.5);

        public Orientation orientation;
        public Point size;
        public Point origin;

        public Layout(Orientation orientation, Point size, Point origin)
        {
            this.orientation = orientation;
            this.size = size;
            this.origin = origin;
        }

        public static Point[] PolygonCorners(Layout layout, Hex h)
        {
            Point[] corners = new Point[6];
            Point center = HexToPixel(layout, h);
            for (int i = 0; i < 6; i++)
            {
                Point offset = HexCornerOffset(layout, i);
                corners[i] = new Point(center.x + offset.x, center.y + offset.y);
            }
            return corners;
        }

        public static Point HexToPixel(Layout layout, Hex h)
        {
            Orientation M = layout.orientation;
            Point size = layout.size;
            Point origin = layout.origin;
            double x = (M.f0 * h.q + M.f1 * h.r) * size.x;
            double y = (M.f2 * h.q + M.f3 * h.r) * size.y;
            return new Point(x + origin.x, y + origin.y);
        }

        public static Point HexCornerOffset(Layout layout, int corner)
        {
            Orientation M = layout.orientation;
            double size = layout.size.x;
            double angle = 2.0 * Math.PI * (M.start_angle - corner) / 6;
            return new Point(size * Math.Cos(angle), size * Math.Sin(angle));
        }

        // Layout struct and related methods go here
    }
}
