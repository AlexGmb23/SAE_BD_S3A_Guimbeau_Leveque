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
            Font f = new Font(FontFamily.GenericMonospace, listBoxReponse.Font.Size);
            listBoxReponse.Font = f;
        }



        private void fillElevesRequete1()
        {
            var lesEleves = from Eleve in donneesSQL.T_Eleve_ELV
                            orderby Eleve.ELV_Id descending
                            where Eleve.ELV_Id < 42
                            select Eleve;
            foreach (var eleveImporte in lesEleves)
            {
                eleves.Add(eleveImporte);
            }
        }

        private void remplissageRequete1()
        {
            double moyenneTotale = 0;
            int[] nbEpreuvesTotal = { 0, 0 }; // Premier élément [0] = nbEpreuvesTotal et [1] correspond à nbEpreuveTotal mais valides (notes non nulles)
            listBoxReponse.Items.Add(String.Format("{0,-12} | {1,-12} | {2,-12} | {3,-12} ","EPR_REF_ELV" ,"EPR_Abrv", "Moy_Epr_Note" , "Nb_Epr_Elv"));
            foreach (T_Eleve_ELV elv in eleves)
            {
                if (elv.ELV_Id < 42)
                {
                    var cacheRef = elv.ELV_REF_ELV;
                    int[] nbEpreuves = {0, 0};// Premier élément [0] = nbEpreuvesElv et [1] correspond à nbEpreuveElv mais valides (notes non nulles)
                    var valMoyennes = 0.0;
                    var aSubisEpreuve = false;
                    var onlyNull = true;
                    foreach (T_Epreuve_EPR eprElv in elv.T_Epreuve_EPR.Reverse())
                    {
                        if(eprElv.EPR_Abrv.Equals("CC1") || eprElv.EPR_Abrv.Equals("CC2") || eprElv.EPR_Abrv.Equals("CC3"))
                        {
                            var note = eprElv.EPR_Note;
                            aSubisEpreuve = true;
                            String reponse;
                            if (note != null)
                            {
                                onlyNull = false;
                                valMoyennes += (float)note;
                                reponse = String.Format("{0,-12} | {1,-12} | {2,-12} | {3,-12}", eprElv.EPR_REF_ELV, eprElv.EPR_Abrv, note, 1);
                                nbEpreuvesTotal[1]++;
                                nbEpreuves[1]++;
                            }
                            else
                            {
                                reponse = String.Format("{0,-12} | {1,-12} | {2,-12} | {3,-12}", eprElv.EPR_REF_ELV, eprElv.EPR_Abrv, "null", 1);
                            }
                            nbEpreuves[0]++;
                            listBoxReponse.Items.Add(reponse);
                        }
                        
                    }
                    if(aSubisEpreuve)
                    {
                        if (!onlyNull)
                        {
                            listBoxReponse.Items.Add(String.Format("{0,-12} | {1,-12:0.000000} | {2,-12:0.000000} | {3,-12} ", elv.ELV_Id, "null", (float)(valMoyennes / nbEpreuves[1]), nbEpreuves[0]));
                            
                        }
                        else
                        {
                            listBoxReponse.Items.Add(String.Format("{0,-12} | {1,-12:0.000000} | {2,-12:0.000000} | {3,-12} ", elv.ELV_Id, "null", "null", nbEpreuves[0]));
                        }
                        moyenneTotale += valMoyennes;
                        nbEpreuvesTotal[0] += nbEpreuves[0];
                    }
                    
                }
            }
            listBoxReponse.Items.Add(String.Format("{0,-12:0.000000} | {1,-12:0.000000} | {2,-12:0.000000} | {3,-12} ", "null", "null", (moyenneTotale / (nbEpreuvesTotal[1])), nbEpreuvesTotal[0]));
        }

        private void remplissageRequete2()
        {
            var elevesRcp = from Eleve in donneesSQL.T_Eleve_ELV
                            join classes in donneesSQL.T_Classe_CLS on Eleve.ELV_REF_CLS equals classes.CLS_Num
                            join recomp in donneesSQL.T_Recompense_RCP on Eleve.ELV_Id equals recomp.RCP_REF_ELV
                            where Eleve.ELV_Id >= 837 && classes.CLS_Intit.Equals("Hadron")
                            orderby Eleve.ELV_Id descending
                            select new
                            {
                                Eleve.ELV_Id,
                                Eleve.ELV_Nom,
                                recomp.RCP_Annee
                            };

            elevesRcp.ToList();

            int numLigne = 1;
            int rangIdAnnee = 1;
            int rangId = 1;
            int nbEpreuvesInBoucle = 0;
            decimal lastEleveId  = 0;
            decimal actualEleveId;
            listBoxReponse.Items.Add(String.Format("{0,-6} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", "ELV_Id", "ELV_Nom", "Num_Ligne", "Rg_Id", "RCP_Annee", "Rg_Annee_par_Id"));
            foreach (var item in elevesRcp)
            {
                actualEleveId = item.ELV_Id;
                if(lastEleveId.Equals(actualEleveId))
                {
                    rangIdAnnee++;
                    nbEpreuvesInBoucle++;
                }
                else
                {
                    rangId += nbEpreuvesInBoucle;
                    nbEpreuvesInBoucle = 1;
                    rangIdAnnee = 1;
                }
                listBoxReponse.Items.Add(String.Format("{0,-6} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10}",actualEleveId,item.ELV_Nom,numLigne,rangId,item.RCP_Annee,rangIdAnnee));
                lastEleveId = item.ELV_Id;
                numLigne++;
            }
        }

        private void buttonMoy_Click(object sender, EventArgs e)
        {
            eleves.Clear();
            listBoxReponse.Items.Clear();
            fillElevesRequete1();
            remplissageRequete1();
        }

        private void buttonSrcIdRcp_Click(object sender, EventArgs e)
        {
            eleves.Clear();
            listBoxReponse.Items.Clear();
            remplissageRequete2();
        }
    }
}
