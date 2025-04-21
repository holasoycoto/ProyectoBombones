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
    public partial class frmTipoRelleno : Form
    {

        private TipoRellenoServicio _tipoRellenoServicio;
        private List<TipoRelleno> lista = new()!;

        public frmTipoRelleno(TipoRellenoServicio tipoRellenoServicio)
        {
            InitializeComponent();
            _tipoRellenoServicio = tipoRellenoServicio;
        }

        private void MostrarDatos()
        {
            lista = _tipoRellenoServicio.ObtenerFrutosSecos();
            GridViewHelper.MostrarDatosEnGrilla<TipoRelleno>(lista, dgvDatos);
        }

        private void frmTipoRelleno_Load(object sender, EventArgs e)
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

            frmTipoRellenoAE frm = new() { Text = "Agregar un Tipo de Relleno" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            TipoRelleno? relleno = frm.ObtenerTipoRelleno();
            if (relleno == null) return;

            try
            {

                if (!_tipoRellenoServicio.Existe(relleno))
                {
                    _tipoRellenoServicio.Agregar(relleno);
                    MostrarDatos();

                    MessageBox.Show("Tipo de Relleno agregado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("¡Este tipo de relleno ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TipoRelleno rellenoBorrar = (TipoRelleno)cBorrar.Tag!;

            DialogResult dr = MessageBox.Show("¿Esta seguro de realizar esta accion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            try
            {

                _tipoRellenoServicio.Borrar(rellenoBorrar);

                MostrarDatos();

                MessageBox.Show("Tipo de Relleno Eliminado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            TipoRelleno rellenoEditar = (TipoRelleno)cEditar.Tag!;
            string tempNombre = rellenoEditar.Nombre;

            frmTipoRellenoAE frm = new frmTipoRellenoAE() { Text = "Editar Tipo de Relleno" };
            frm.EstablecerTipoRelleno(rellenoEditar);
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            try
            {

                TipoRelleno? rellenoEditado = frm.ObtenerTipoRelleno();
                if (rellenoEditado is null) return;

                if (rellenoEditado.Nombre == tempNombre)
                {
                    MessageBox.Show("¡Este tipo de relleno ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _tipoRellenoServicio.Editar(rellenoEditado);

                MostrarDatos();

                MessageBox.Show("Tipo de Relleno Editado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
