using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Stronghold.Resources.Styling
{
    public static class ColorResource
    {
        public static readonly string Catawba = "#773344";
        public static readonly string Tumbleweed = "#E3B5A4";
        public static readonly string Linen = "#F5E9E2";
        public static readonly string AlmostBlack = "#0B0014";
        public static readonly string Xiketic = "#190F21";
        public static readonly string ParadisePink = "#D44D5C";
        public static SolidColorBrush ToSolidColorBrush(string hex)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFromString(hex);
        }
    }
}
