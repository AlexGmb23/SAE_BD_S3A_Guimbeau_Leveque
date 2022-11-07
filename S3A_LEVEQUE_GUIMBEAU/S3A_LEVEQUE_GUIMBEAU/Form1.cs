using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S3A_LEVEQUE_GUIMBEAU
{
    public partial class Form1 : Form
    {
        static public Entities donneesSQL;
        List<Eleve> eleves;
        public Form1()
        {
            InitializeComponent();
            donneesSQL = new Entities();
            fillEleves();
        }

        private void fillEleves()
        {
            var lesEleves = from Eleve in donneesSQL.T_Eleve_ELV
                            select Eleve;
            foreach (var e in lesEleves)
            {
                Eleve elv = new Eleve(id: (int)e.ELV_Id, name: e.ELV_Nom, refElv: (int)e.ELV_REF_ELV, refCls: (int)e.ELV_REF_CLS, moyElv: 0, nbEpr: 0);
                eleves.Add(elv);
            }
            
        }
    }
}
