using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TanksWindowsForm
{
    public abstract class GameObject
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Rectangle Collider { get; protected set; }  
    }
}