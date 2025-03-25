using ProyectoBombones.Entidades;

namespace ProyectoBombones.Datos.Repositorios
{
    public class RepositorioPaises
    {

        private List<Pais> listaPaises = new();
        private readonly string ruta = null!;
        private readonly char separador = '|';

        public RepositorioPaises(string rutaArchivo)
        {
            ruta = rutaArchivo;
            LeerDatos();
        }

        public List<Pais> ObtenerPaises()
        {
            return listaPaises;
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
                Pais pais = ConstruirPais(registro);
                listaPaises.Add(pais);
            }

        }

        private Pais ConstruirPais(string registro)
        {
            
            var partesPais = registro.Split(separador);
            Pais pais = new()
            {
                PaisId = int.Parse(partesPais[0]),
                NombrePais = partesPais[1]
            };

            return pais;

        }
    }
}
