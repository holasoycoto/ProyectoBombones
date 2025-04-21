using ProyectoBombones.Datos.Repositorios;
using ProyectoBombones.Entidades;

namespace ProyectoBombones.Servicios
{
    public class TipoChocolateServicio
    {

        private readonly RepositorioTipoChocolates _repositorioTipoChocolates = null!;

        public TipoChocolateServicio(string archivo)
        {
            _repositorioTipoChocolates = new RepositorioTipoChocolates(archivo);
        }

        public void Agregar(TipoChocolate chocolate)
        {
            _repositorioTipoChocolates.AgregarTipoChocolate(chocolate);
        }

        public void Borrar(TipoChocolate chocolate)
        {
            _repositorioTipoChocolates.BorrarTipoChocolate(chocolate);
        }

        public bool Existe(TipoChocolate chocolate)
        {
            return _repositorioTipoChocolates.Existe(chocolate);
        }

        public void Editar(TipoChocolate chocolate)
        {
            _repositorioTipoChocolates.EditarTipoChocolate(chocolate);
        }

        public List<TipoChocolate> ObtenerFrutosSecos()
        {
            return _repositorioTipoChocolates.ObtenerTipoChocolates();
        }

    }
}
