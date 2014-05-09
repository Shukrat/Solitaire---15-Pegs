using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    abstract class Hole
    {
        public bool filled;
        public int holeNo;

        public Hole ne;
        public Hole nw;
        public Hole w;
        public Hole sw;
        public Hole se;
        public Hole e;

        #region Properties
        public Hole NE
        {
            get { return ne; }
            set { ne = value; }
        }

        public Hole NW
        {
            get { return nw; }
            set { nw = value; }
        }

        public Hole W
        {
            get { return w; }
            set { w = value; }
        }

        public Hole SW
        {
            get { return sw; }
            set { sw = value; }
        }

        public Hole SE
        {
            get { return se; }
            set { se = value; }
        }

        public Hole E
        {
            get { return e; }
            set { e = value; }
        }

        public bool Filled
        {
            get { return filled; }
            set { filled = value; }
        }
        #endregion


    }
}
