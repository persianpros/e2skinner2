﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using e2skinner2.Logic;

namespace e2skinner2.Structures
{
    public class sColor : IComparable
    {
        public String pName;
        public UInt32 pValue;
        public Color pColor;
        public Color pColorAlpha;

        public sColor(Color value)
        {
            pName = value.Name;
            pValue = (uint)value.ToArgb();
            pColorAlpha = value;
            pColor      = value;
        }

        public sColor(int alpha, Color value)
        {
            pName = value.Name;
            pValue = (uint)value.ToArgb();
            pColorAlpha = Color.FromArgb(255 - alpha, value);
            pColor = value;
        }


        public sColor(String name, UInt32 value)
        {
            pName = name; 
            pValue = value;

            int alpha = 255 - ((int)(pValue >> 24) & 0xff);
            int red = (int)(pValue >> 16) & 0xff;
            int green = (int)(pValue >> 8) & 0xff;
            int blue = (int)pValue & 0xff;
           
            pColorAlpha = Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
            pColor = Color.FromArgb((int)red, (int)green, (int)blue);
        }

        public int CompareTo(object obj)
        {
            sColor val = (sColor)obj;
            if (val.pName.CompareTo(this.pName) < 0)
                return 1;
            else if (val.pName.Equals(this.pName))
                return 0;
            else
                return -1;
        }
    }
}