using ProyectoBombones.Entidades;

namespace ProyectoBombones.Datos.Repositorios
{
    public class RepositorioFrutosSecos
    {

        private List<FrutoSeco> listaFrutos = new();
        private readonly string ruta = null!;
        private readonly char separador = '|';

        public RepositorioFrutosSecos(string rutaArchivo)
        {
            ruta = rutaArchivo;
            LeerDatos();
        }

        public List<FrutoSeco> ObtenerFrutosSecos()
        {
            return listaFrutos;
        }

        private void LeerDatos()
        {

            if (!File.Exists(ruta))
            {
                return;
            }

            var registros = File.ReadAllLines(ruta);

            foreach (var registro in registros)
            {
                FrutoSeco fruto = ConstruirFrutoSeco(registro);
                listaFrutos.Add(fruto);
            }

        }

        private FrutoSeco ConstruirFrutoSeco(string registro)
        {

            var partesFruto = registro.Split(separador);

            FrutoSeco fruto = new()
            {
                FrutoID = int.Parse(partesFruto[0]),
                NombreFruto = partesFruto[1]
            };

            return fruto;

        }

    }
}