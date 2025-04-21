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
    public partial class frmTipoChocolates : Form
    {

        private TipoChocolateServicio _servicioTipoChocolate;
        private List<TipoChocolate> lista = new()!;

        public frmTipoChocolates(TipoChocolateServicio servicio)
        {
            InitializeComponent();
            _servicioTipoChocolate = servicio;
        }

        private void MostrarDatos()
        {
            lista = _servicioTipoChocolate.ObtenerFrutosSecos();
            GridViewHelper.MostrarDatosEnGrilla<TipoChocolate>(lista, dgvDatos);
        }

        private void frmTipoChocolates_Load(object sender, EventArgs e)
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

            frmTipoChocolatesAE frm = new() { Text = "Agregar un Tipo de Chocolate" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            TipoChocolate? chocolate = frm.ObtenerTipoChocolate();
            if (chocolate == null) return;

            try
            {

                if (!_servicioTipoChocolate.Existe(chocolate))
                {
                    _servicioTipoChocolate.Agregar(chocolate);
                    MostrarDatos();

                    MessageBox.Show("Tipo de chocolate agregado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("¡Este tipo de chocolate ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TipoChocolate chocolateBorrar = (TipoChocolate)cBorrar.Tag!;

            DialogResult dr = MessageBox.Show("¿Esta seguro de realizar esta accion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            try
            {

                _servicioTipoChocolate.Borrar(chocolateBorrar);

                MostrarDatos();

                MessageBox.Show("Tipo de Chocolate Eliminado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            TipoChocolate chocolateEditar = (TipoChocolate)cEditar.Tag!;
            string tempNombre = chocolateEditar.Nombre;

            frmTipoChocolatesAE frm = new frmTipoChocolatesAE() { Text = "Editar Tipo de Chocolate" };
            frm.EstablecerTipoChocolate(chocolateEditar);
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            try
            {

                TipoChocolate? chocolateEditado = frm.ObtenerTipoChocolate();
                if (chocolateEditado is null) return;

                if (chocolateEditado.Nombre == tempNombre)
                {
                    MessageBox.Show("¡Este tipo de chocolate ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _servicioTipoChocolate.Editar(chocolateEditado);

                MostrarDatos();

                MessageBox.Show("Tipo de Chocolate Editado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
