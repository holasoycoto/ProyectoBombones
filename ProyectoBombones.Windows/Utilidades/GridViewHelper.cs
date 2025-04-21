using ProyectoBombones.Entidades;

namespace ProyectoBombones.Windows.Utilidades
{
    public static class GridViewHelper
    {

        public static void MostrarDatosEnGrilla<T>(List<T> lista, DataGridView dgv) where T : class
        {
            LimpiarGrilla(dgv);
            foreach (var item in lista)
            {
                var r = ConstruirFila(dgv);
                EstablecerLinea(r, item);
                AgregarFila(r, dgv);
            }
        }

        private static void AgregarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Add(r);
        }

        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }

        public static void EstablecerLinea(DataGridViewRow r, object obj)
        {

            switch (obj)
            {

                case Pais pais:
                    r.Cells[0].Value = pais.PaisId;
                    r.Cells[1].Value = pais.NombrePais;
                    r.Tag = obj;
                break;
                case FrutoSeco fruto:
                    r.Cells[0].Value = fruto.FrutoID;
                    r.Cells[1].Value = fruto.NombreFruto;
                    r.Tag = obj;
                break;
                case TipoRelleno relleno:
                    r.Cells[0].Value = relleno.Id;
                    r.Cells[1].Value = relleno.Nombre;
                    r.Tag = relleno;
                break;
                case TipoChocolate chocolate:
                    r.Cells[0].Value = chocolate.Id;
                    r.Cells[1].Value = chocolate.Nombre;
                    r.Tag = chocolate;
                break;

            }
        
        }

        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

    }
}
