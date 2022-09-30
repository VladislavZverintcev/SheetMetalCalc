using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetMetalCalc.Models
{
    public class Material
    {
        public string Name { get; set; } // Марка
        public double Density { get; set; } // Плотность
        public double Height { get; set; } // Высота листа
        public double Width { get; set; } // Ширина листа
        public double Thickness { get; set; } //Толщина листа
    }
}
