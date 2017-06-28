using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo3
{
    public partial class TextBoxNum : TextBox
    {

        char[] digitos = new char[]{'0','1','2','3','4','5','6','7','8','9','.',',','-','\b'};
        bool mConDecimales = true;

        public TextBoxNum()
        {
            InitializeComponent();
        }

        [Description("Indica si se aceptarán decimales o no")]
        public virtual bool ConDecimales
        {
            get
            {
                return this.mConDecimales;
            }

            set
            {
                mConDecimales = value;
            }
        }

        protected virtual bool CaracterCorrecto(char c)
        {
            if (ConDecimales == false)
            {
                if (c == ',' || c == '.')
                {
                    return false;
                }
            }
            return (Array.IndexOf(digitos, c) != -1);
        }
           

        protected override void OnKeyPress(KeyPressEventArgs e)
        {           
            if (!CaracterCorrecto(e.KeyChar))
            {
                e.Handled = true;
            }                
           
            base.OnKeyPress(e);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {                
                string s = "";
                foreach (char c in value)
                {                    
                    if (CaracterCorrecto(c))
                    {
                        s += c;
                    }                        
                }
                base.Text = s;
            }
        }


    }
}
