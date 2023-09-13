using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boletin.Entities
{
    public class Boletin
    {
        List<float> quices = new List<float>();
        List<float> trabajos = new List<float>();
        List<float> parciales = new List<float>();

        public Boletin()
        {
        }

        public Boletin(List<float> quices, List<float> trabajos, List<float> parciales)
        {
            this.Quices = quices;
            this.Trabajos = trabajos;
            this.Parciales = parciales;
        }

        public List<float> Quices { get => quices; set => quices = value; }
        public List<float> Trabajos { get => trabajos; set => trabajos = value; }
        public List<float> Parciales { get => parciales; set => parciales = value; }
    }

}