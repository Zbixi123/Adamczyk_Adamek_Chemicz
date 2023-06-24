using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private List<string> selectedValues;

        private double Wzor(double a, double b, double c, double d, double e, double f, double g)
        {
            const double ilosc_podwyzek_calkowita = 1;
            const double awans = 2;
            const double calkowita_ilosc_premii = 3;
            const double premia_w_roku_obliczeniowym = 4;
            const double szkolenia = 5;
            const double przepracowanych_lat = 6;
            const double staz_pracy_total = 7;

            double wynik = ilosc_podwyzek_calkowita * a + awans * b + calkowita_ilosc_premii * c + premia_w_roku_obliczeniowym * d + szkolenia * e + przepracowanych_lat * f + staz_pracy_total * g;
            return wynik;
        }
        public Form2(List<string> selectedValues)
        {
            InitializeComponent();
            this.selectedValues = selectedValues;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label11.Text = "Ilość podwyżej całkowita * 1 + Awans * 2 \n + Całkowita ilość premii * 3 + Premia w roku obliczeniowym * 4 \n + Szkolenia * 5 + Przepracowanych lat * 6 \n + Całkowity staż pracy * 7";


            if (selectedValues.Count >= 2) // Sprawdź, czy jest co najmniej dwie wartości (kolumny)
            {
                string[] userData = selectedValues[0].Split(' ');
              
                textBox1.Text = userData[0];
                //textBox1.Text = selectedValues[0];
                textBox2.Text = selectedValues[1];

                textBox3.Text = selectedValues[6];
                textBox4.Text = selectedValues[7];
                textBox5.Text = selectedValues[8];
                textBox6.Text = selectedValues[9];
                textBox7.Text = selectedValues[10];
                textBox8.Text = selectedValues[11];
                textBox9.Text = selectedValues[12];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            double wynik = Wzor(double.Parse(selectedValues[6]), double.Parse(selectedValues[7]), double.Parse(selectedValues[8]), double.Parse(selectedValues[9]), double.Parse(selectedValues[10]), double.Parse(selectedValues[11]), double.Parse(selectedValues[12]));
            if (wynik <= 99)
            {
                label12.ForeColor = Color.Red;
                label12.Text = wynik.ToString() + " Wysokie Prawdopodobieństwo złożenia \n wypowiedzenia przez pracownika";
            }
            else if (wynik >= 100 && wynik <= 199)
            {
                label12.ForeColor = Color.Orange;
                label12.Text = wynik.ToString() + " Średnie Prawdopodobieństwo złożenia \n wypowiedzenia przez pracownika";
            }
            else if (wynik >= 200)
            {
                label12.ForeColor = Color.Green;
                label12.Text = wynik.ToString() + " Niskie Prawdopodobieństwo złożenia \n wypowiedzenia przez pracownika";
            }
        }
    }
}
