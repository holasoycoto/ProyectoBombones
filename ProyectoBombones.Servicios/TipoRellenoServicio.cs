using ProyectoBombones.Datos.Repositorios;
using ProyectoBombones.Entidades;

namespace ProyectoBombones.Servicios
{
    public class TipoRellenoServicio
    {

        private readonly RepositorioTipoRellenos? _repositorioTipoRellenos = null!;

        public TipoRellenoServicio(string archivo)
        {
            _repositorioTipoRellenos = new RepositorioTipoRellenos(archivo);
        }

        public void Agregar(TipoRelleno relleno)
        {
            _repositorioTipoRellenos.AgregarTipoRelleno(relleno);
        }

        public void Borrar(TipoRelleno relleno)
        {
            _repositorioTipoRellenos.BorrarTipoRelleno(relleno);
        }

        public bool Existe(TipoRelleno relleno)
        {
            return _repositorioTipoRellenos.Existe(relleno);
        }

        public void Editar(TipoRelleno relleno)
        {
            _repositorioTipoRellenos.EditarTipoRelleno(relleno);
        }

        public List<TipoRelleno> ObtenerFrutosSecos()
        {
            return _repositorioTipoRellenos.ObtenerTipoRellenos();
        }

    }
}
