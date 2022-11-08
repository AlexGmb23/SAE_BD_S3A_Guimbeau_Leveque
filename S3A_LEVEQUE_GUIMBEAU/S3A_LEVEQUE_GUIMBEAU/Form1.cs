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
        List<T_Eleve_ELV> eleves;
        public Form1()
        {
            InitializeComponent();
            donneesSQL = new Entities();
            eleves = new List<T_Eleve_ELV>();
            fillEleves();
            remplissageRequete1();
        }



        private void fillEleves()
        {
            var lesEleves = from Eleve in donneesSQL.T_Eleve_ELV
                            orderby Eleve.ELV_Id descending
                            select Eleve;
            foreach (var eleveImporte in lesEleves)
            {
                eleves.Add(eleveImporte);
            }
        }

        private void remplissageRequete1()
        {
            foreach (T_Eleve_ELV elv in eleves)
            {
                if (elv.ELV_Id < 42)
                {
                    var cacheRef = elv.ELV_REF_ELV;
                    var nbEpreuves = 0;
                    var valMoyennes = 0.0;
                    var aSubis = false;
                    foreach (T_Epreuve_EPR eprElv in elv.T_Epreuve_EPR)
                    {
                        if(eprElv.EPR_Abrv.Equals("CC1") || eprElv.EPR_Abrv.Equals("CC2") || eprElv.EPR_Abrv.Equals("CC3"))
                        {
                            aSubis = true;
                            if (eprElv.EPR_Note != null)
                            {
                                valMoyennes += (float)eprElv.EPR_Note;
                            }
                            nbEpreuves += 1;
                            listBoxReponse.Items.Add(eprElv.EPR_REF_ELV + " " + eprElv.EPR_Abrv + " " + eprElv.EPR_Note + " 1");
                        }
                        
                    }
                    if (aSubis) { listBoxReponse.Items.Add(elv.ELV_Id + " null " + valMoyennes / nbEpreuves + nbEpreuves); }
                }
            }
        }
    }
}
