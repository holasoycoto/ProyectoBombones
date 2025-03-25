using ProyectoBombones.Datos.Repositorios;
using ProyectoBombones.Entidades;

namespace ProyectoBombones.Servicios
{
    public class FrutoSecoServicio
    {

        private readonly RepositorioFrutosSecos _repositorioFrutosSecos = null!;

        public FrutoSecoServicio(string archivo)
        {
            _repositorioFrutosSecos = new RepositorioFrutosSecos(archivo);
        }

        public List<FrutoSeco> ObtenerFrutosSecos()
        {
            return _repositorioFrutosSecos.ObtenerFrutosSecos();
        }

    }
}
