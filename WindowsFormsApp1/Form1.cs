using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool mame = false;

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader cteni = new StreamReader("rodna_cis.txt");
            StreamWriter psani = new StreamWriter("rodna_cis.txt");
            int znamka = 0;
            int pocet_znamek = 0;
            string prvni_clovek_v_prosinci = "";
            
            while (!cteni.EndOfStream)
            {
                string veta = cteni.ReadLine();
                listBox1.Items.Add(veta);
                string[] pole = veta.Split(';');
                znamka = +int.Parse(pole[1]);
                pocet_znamek++;
                string rodnecislo = pole[2];

                string mesic = Vek(rodnecislo);
                string[] pole2 = mesic.Split(';');

                if (pole[0] == "Prosinec")
                {
                    prvni_clovek_v_prosinci = pole[0];
                    mame = true;
                }
                psani.Write(";" + pole2[1]);
            }
            cteni.Close();
            psani.Close();
            StringWriter sw = new StringWriter();
            sw.WriteLine((znamka/pocet_znamek).ToString());
            StreamReader cteni2 = new StreamReader("rodna_cis.txt");
            while(!cteni.EndOfStream)
            {
                listBox2.Items.Add(cteni2.ReadLine());
            }
            cteni2.Close();
        }

        public string Vek(string rodnecislo)
        {
            string den = (rodnecislo[0] + rodnecislo[1]).ToString();
            string mesic = (rodnecislo[2] + rodnecislo[3]).ToString();
            string roky = (rodnecislo[4] + rodnecislo[5]).ToString();
            DateTime datum_narozeni = DateTime.Parse(den + "." + mesic + "." + roky);
            DateTime now = DateTime.Now;
            TimeSpan rozdil = now - datum_narozeni;
            double vek_v_rocich = (rozdil.TotalDays/365);

            int mesic2 = int.Parse(mesic);
            if (mesic2 < 50)
            {
                mesic2 = mesic2 - 50;
            }


            /*if (mesic2 == 1)
            {
                return "Leden";
            }
            else
            {
                if (mesic2 == 2)
                {
                    return "Unor";
                }
                else
                {
                    if(mesic2 == 3)
                    {
                        return "Brezen";
                    }
                    else
                    {
                        if (mesic2 == 4)
                        {
                            return "Duben";
                        }
                        else
                        {
                            if(mesic2 == 5)
                            {
                                return "Kveten";
                            }
                            else
                            {
                                if (mesic2 == 6)
                                {
                                    return "Cerven";
                                }
                                else
                                {
                                    if (mesic2 == 7)
                                    {
                                        return "Cervenec";
                                    }
                                    else
                                    {
                                        if (mesic2 == 8)
                                        {
                                            return "Srpen";
                                        }
                                        else
                                        {
                                            if (mesic2 == 9)
                                            {
                                                return "Zari";
                                            }
                                            else
                                            {
                                                if (mesic2 == 10)
                                                {
                                                    return "Rijen";
                                                }
                                                else
                                                {
                                                    if (mesic2 == 11)
                                                    {
                                                        return "Listopad";
                                                    }
                                                    else
                                                    {
                                                        if (mesic2 == 12)
                                                        {
                                                            return "Prosinec";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }*/
            string mesic_slovne = "";
            switch(mesic2)
            {
                case 1: mesic_slovne = "Leden"; break;
                case 2: mesic_slovne = "Unor"; break;
                case 3: mesic_slovne = "Brezen"; break;
                case 4: mesic_slovne = "Duben"; break;
                case 5: mesic_slovne = "Kveten"; break;
                case 6: mesic_slovne = "Cerven"; break;
                case 7: mesic_slovne = "Cervenec"; break;
                case 8: mesic_slovne = "Srpen"; break;
                case 9: mesic_slovne = "Zari"; break;
                case 10: mesic_slovne = "Rijen"; break;
                case 11: mesic_slovne = "Listopad"; break;
                case 12: mesic_slovne = "Prosinec"; break;
                default: mesic_slovne = "something went wrong"; break;

            }
            return mesic_slovne + ";" + vek_v_rocich.ToString();
        }
    }
}
