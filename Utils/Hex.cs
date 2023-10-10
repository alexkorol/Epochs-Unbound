using System;
using System.Collections.Generic;

namespace EpochsUnbound.Utils
{
    struct Hex
    {
        public int q;
        public int r;
        public int s;

        public Hex(int q, int r)
        {
            this.q = q;
            this.r = r;
            this.s = -q - r;
        }

        public Hex(int q, int r, int s)
        {
            this.q = q;
            this.r = r;
            this.s = s;
        }

        public int Distance(Hex b)
        {
            return (Math.Abs(q - b.q) + Math.Abs(r - b.r) + Math.Abs(s - b.s)) / 2;
        }
        // Hex struct and related methods go here
    }
}
