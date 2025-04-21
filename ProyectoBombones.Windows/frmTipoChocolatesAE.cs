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
    public partial class frmTipoChocolatesAE : Form
    {
        private TipoChocolate? chocolate;

        public frmTipoChocolatesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (chocolate is not null)
            {
                TxtTipoChocolate.Text = chocolate.Nombre;
            }
        }

        public TipoChocolate? ObtenerTipoChocolate()
        {
            return chocolate;
        }

        public void EstablecerTipoChocolate(TipoChocolate tipoChocolate)
        {
            this.chocolate = tipoChocolate;
        }

        public bool EsValido()
        {

            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(TxtTipoChocolate.Text))
            {
                valido = false;
                errorProvider1.SetError(TxtTipoChocolate, "Ingrese un nombre de chocolate valido");
            }

            return valido;

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            if (EsValido())
            {

                if (chocolate is null)
                {
                    chocolate = new();
                }

                chocolate.Nombre = TxtTipoChocolate.Text;

                DialogResult = DialogResult.OK;

            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
