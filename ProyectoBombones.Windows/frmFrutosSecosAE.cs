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
    public partial class frmFrutosSecosAE : Form
    {

        private FrutoSeco? fruto;

        public frmFrutosSecosAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (fruto is not null)
            {
                TxtFrutoSeco.Text = fruto.NombreFruto;
            }

        }

        public FrutoSeco? ObtenerFrutoSeco()
        {
            return fruto;
        }

        public void EstablecerFrutoSeco(FrutoSeco fruto)
        {
            this.fruto = fruto;
        }

        public bool EsValido()
        {

            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(TxtFrutoSeco.Text))
            {
                valido = false;
                errorProvider1.SetError(TxtFrutoSeco, "Ingrese un nombre de fruto seco valido");
            }

            return valido;

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            if (EsValido())
            {

                if (fruto is null)
                {
                    fruto = new();
                }

                fruto.NombreFruto = TxtFrutoSeco.Text;

                DialogResult = DialogResult.OK;

            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
