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
    public partial class frmPaises : Form
    {

        private readonly PaisServicio _paisServicio;
        private List<Pais> lista = new()!;

        public frmPaises(PaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }

        private void MostrarDatos()
        {
            lista = _paisServicio.ObtenerPaises();
            GridViewHelper.MostrarDatosEnGrilla<Pais>(lista, dgvDatos);
        }

        private void frmPaises_Load(object sender, EventArgs e)
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

            frmPaisesAE frm = new() { Text = "Agregar un Pais" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            Pais? pais = frm.ObtenerPais();
            if (pais == null) return;

            try
            {

                if (!_paisServicio.Existe(pais))
                {
                    _paisServicio.Agregar(pais);
                    MostrarDatos();

                    MessageBox.Show("Pais agregado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("¡Este pais ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Pais paisBorrar = (Pais)cBorrar.Tag!;

            DialogResult dr = MessageBox.Show("¿Esta seguro de realizar esta accion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            try
            {

                _paisServicio.Borrar(paisBorrar);

                MostrarDatos();

                MessageBox.Show("Pais Eliminado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            Pais paisEditar = (Pais)cEditar.Tag!;
            string tempNombre = paisEditar.NombrePais;

            frmPaisesAE frm = new frmPaisesAE() { Text = "Editar Pais" };
            frm.EstablecerPais(paisEditar);
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            try
            {

                Pais? paisEditado = frm.ObtenerPais();
                if (paisEditado is null) return;

                if (paisEditado.NombrePais == tempNombre)
                {
                    MessageBox.Show("¡Este pais ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _paisServicio.Editar(paisEditado);

                MostrarDatos();

                MessageBox.Show("Pais Editado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
