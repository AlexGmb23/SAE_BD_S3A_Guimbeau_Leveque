using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3A_LEVEQUE_GUIMBEAU
{
    internal class Epreuve
    {
        int ReferenceEpreuve { get; set; }
        string IntituleEpreuve { get; set; }
        float NoteEpreuve { get; set; }

        public Epreuve(int referenceEpreuve, string intituleEpreuve, float noteEpreuve)
        {
            ReferenceEpreuve = referenceEpreuve;
            IntituleEpreuve = intituleEpreuve;
            NoteEpreuve = noteEpreuve;
        }
    }
}
