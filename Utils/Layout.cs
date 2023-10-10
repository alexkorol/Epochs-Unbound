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

        // Layout struct and related methods go here
    }
}
