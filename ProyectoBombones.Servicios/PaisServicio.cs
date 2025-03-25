using ProyectoBombones.Datos.Repositorios;
using ProyectoBombones.Entidades;

namespace ProyectoBombones.Servicios
{
    public class PaisServicio
    {

        private readonly RepositorioPaises _repositorioPaises = null!;

        public PaisServicio(string archivo)
        {
            _repositorioPaises = new RepositorioPaises(archivo);
        }

        public List<Pais> ObtenerPaises()
        {
            return _repositorioPaises.ObtenerPaises();
        }

    }
}
