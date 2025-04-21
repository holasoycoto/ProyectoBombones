using ProyectoBombones.Entidades;
using ProyectoBombones.Servicios;
using ProyectoBombones.Windows.Utilidades;
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
    public partial class frmFrutosSecos : Form
    {

        private FrutoSecoServicio _frutoSecoServicio;
        private List<FrutoSeco> lista = new()!;

        public frmFrutosSecos(FrutoSecoServicio frutoSecoServicio)
        {
            InitializeComponent();
            _frutoSecoServicio = frutoSecoServicio;
        }

        private void MostrarDatos()
        {
            lista = _frutoSecoServicio.ObtenerFrutosSecos();
            GridViewHelper.MostrarDatosEnGrilla<FrutoSeco>(lista, dgvDatos);
        }
        private void frmFrutosSecos_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            frmFrutosSecosAE frm = new() { Text = "Agregar un Fruto Seco" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            FrutoSeco? fruto = frm.ObtenerFrutoSeco();
            if (fruto == null) return;

            try
            {

                if (!_frutoSecoServicio.Existe(fruto))
                {
                    _frutoSecoServicio.Agregar(fruto);
                    MostrarDatos();

                    MessageBox.Show("Fruto Seco agregado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("¡Este fruto seco ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count <= 0) return;

            var cBorrar = dgvDatos.SelectedRows[0];
            FrutoSeco frutoBorrar = (FrutoSeco)cBorrar.Tag!;

            DialogResult dr = MessageBox.Show("¿Estas seguro de realizar esta accion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            try
            {

                _frutoSecoServicio.Borrar(frutoBorrar);

                MostrarDatos();

                MessageBox.Show("Fruto Seco Eliminado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count <= 0) return;

            var cEditar = dgvDatos.SelectedRows[0];
            FrutoSeco frutoEditar = (FrutoSeco)cEditar.Tag!;
            string tempNombre = frutoEditar.NombreFruto;

            frmFrutosSecosAE frm = new frmFrutosSecosAE() { Text = "Editar Fruto Seco" };
            frm.EstablecerFrutoSeco(frutoEditar);
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            try
            {

                FrutoSeco? frutoEditado = frm.ObtenerFrutoSeco();
                if (frutoEditado is null) return;

                if (frutoEditado.NombreFruto == tempNombre)
                {
                    MessageBox.Show("¡Este fruto seco ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _frutoSecoServicio.Editar(frutoEditado);

                MostrarDatos();

                MessageBox.Show("Fruto Seco Editado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TsbActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
            MessageBox.Show("Lista actualizada.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
