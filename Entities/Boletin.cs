using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boletin.Entities
{
    public class Boletin
    {
        List<float> quices = new List<double>();
        List<double> trabajos = new List<double>();
        List<double> parciales = new List<double>();

        public Boletin()
        {
        }

        public Boletin(List<double> quices, List<double> trabajos, List<double> parciales)
        {
            this.Quices = quices;
            this.Trabajos = trabajos;
            this.Parciales = parciales;
        }

        public List<double> Quices { get => quices; set => quices = value; }
        public List<double> Trabajos { get => trabajos; set => trabajos = value; }
        public List<double> Parciales { get => parciales; set => parciales = value; }
    }

}