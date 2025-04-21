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

        public void Agregar(FrutoSeco fruto)
        {
            _repositorioFrutosSecos.AgregarFrutoSeco(fruto);
        }

        public void Borrar(FrutoSeco fruto)
        {
            _repositorioFrutosSecos.BorrarFrutoSeco(fruto);
        }

        public bool Existe(FrutoSeco fruto)
        {
            return _repositorioFrutosSecos.Existe(fruto);
        }

        public void Editar(FrutoSeco fruto)
        {
            _repositorioFrutosSecos.EditarFrutoSeco(fruto);
        }

        public List<FrutoSeco> ObtenerFrutosSecos()
        {
            return _repositorioFrutosSecos.ObtenerFrutosSecos();
        }

    }
}