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

        public void Agregar(Pais pais)
        {
            _repositorioPaises.AgregarPais(pais);
        }

        public void Borrar(Pais pais)
        {
            _repositorioPaises.BorrarPais(pais);
        }

        public bool Existe(Pais pais)
        {
            return _repositorioPaises.Existe(pais);
        }

        public void Editar(Pais pais)
        {
            _repositorioPaises.EditarPais(pais);
        }

        public List<Pais> ObtenerPaises()
        {
            return _repositorioPaises.ObtenerPaises();
        }

    }
}
