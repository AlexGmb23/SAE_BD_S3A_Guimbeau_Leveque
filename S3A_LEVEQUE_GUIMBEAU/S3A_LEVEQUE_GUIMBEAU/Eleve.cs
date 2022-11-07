using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3A_LEVEQUE_GUIMBEAU
{
    internal class Eleve
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RefElv { get; set; }
        public int RefCls { get; set; }
        public float MoyElvEpr { get; set; }
        public int NombreEpreuve { get; set; }

        public Eleve (int id, string name, int refElv, int refCls, float moyElv, int nbEpr)
        {
            Id = id;
            Name = name;
            RefElv = refElv;
            RefCls = refCls;
            MoyElvEpr = moyElv;
            NombreEpreuve = nbEpr;
        }
    }

}
