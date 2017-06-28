using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValor1.Text != "" && txtValor2.Text != "")
                {
                    int resultado = Int32.Parse(txtValor1.Text) + Int32.Parse(txtValor2.Text);
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Error: uno o ambos espacios estan vacios!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValor1.Text != "" && txtValor2.Text != "")
                {
                    int resultado = Int32.Parse(txtValor1.Text) - Int32.Parse(txtValor2.Text);
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Error: uno o ambos espacios estan vacios!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValor1.Text != "" && txtValor2.Text != "")
                {
                    int resultado = Int32.Parse(txtValor1.Text) * Int32.Parse(txtValor2.Text);
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Error: uno o ambos espacios estan vacios!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValor1.Text != "" && txtValor2.Text != "")
                {
                    int resultado = Int32.Parse(txtValor1.Text) / Int32.Parse(txtValor2.Text);
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Error: uno o ambos espacios estan vacios!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
