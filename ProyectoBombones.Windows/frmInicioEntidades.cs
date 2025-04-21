using ProyectoBombones.Servicios;
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
    public partial class frmInicioEntidades : Form
    {
        public frmInicioEntidades()
        {
            InitializeComponent();
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {

            PaisServicio pais = new("Datos/Paises.txt");
            frmPaises frm = new frmPaises(pais);

            frm.ShowDialog(this);

        }

        private void btnFrutosSecos_Click(object sender, EventArgs e)
        {

            FrutoSecoServicio frutoSeco = new("Datos/FrutosSecos.txt");
            frmFrutosSecos frm = new(frutoSeco);

            frm.ShowDialog(this);

        }

        private void btnTipoRelleno_Click(object sender, EventArgs e)
        {
            TipoRellenoServicio tipoRelleno = new("Datos/TiposRellenos.txt");
            frmTipoRelleno frm = new(tipoRelleno);

            frm.ShowDialog(this);
        }

        private void btnTipoChocolate_Click(object sender, EventArgs e)
        {
            TipoChocolateServicio tipoChocolate = new("Datos/TiposChocolates.txt");
            frmTipoChocolates frm = new(tipoChocolate);

            frm.ShowDialog(this);
        }
    }
}
