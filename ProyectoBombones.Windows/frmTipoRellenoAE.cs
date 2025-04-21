using ProyectoBombones.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBombones.Windows
{
    public partial class frmTipoRellenoAE : Form
    {

        private TipoRelleno relleno;

        public frmTipoRellenoAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (relleno is not null)
            {
                TxtTipoRelleno.Text = relleno.Nombre;
            }

        }

        public TipoRelleno? ObtenerTipoRelleno()
        {
            return relleno;
        }

        public void EstablecerTipoRelleno(TipoRelleno _relleno)
        {
            this.relleno = _relleno;
        }

        public bool EsValido()
        {
            bool valido = true;
            errorProvider1.Clear();

            if(string.IsNullOrEmpty(TxtTipoRelleno.Text))
            {
                errorProvider1.SetError(TxtTipoRelleno, "Ingrese un valor de relleno valido.");
                valido = false;
            }

            return valido;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            if(EsValido())
            {

                if(relleno is null)
                {
                    relleno = new();
                }

                relleno.Nombre = TxtTipoRelleno.Text;

                DialogResult = DialogResult.OK;

            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
