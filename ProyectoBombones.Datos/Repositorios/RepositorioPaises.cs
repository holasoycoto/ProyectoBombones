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

        public int ObtenerPaisId()
        {
            return listaPaises.Any() ? listaPaises.Max(f => f.PaisId) + 1 : 1;
        }

        public void AgregarPais(Pais pais)
        {

            pais.PaisId = ObtenerPaisId();
            listaPaises.Add(pais);

            if (File.Exists(ruta))
            {
                var registros = File.ReadAllText(ruta);
                if (!string.IsNullOrEmpty(registros) && !registros.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(ruta, registros + Environment.NewLine);
                }
            }
            using (var escritor = new StreamWriter(ruta, true))
            {
                string linea = ConstruirLinea(pais);
                escritor.WriteLine(linea);
            }

        }

        public void BorrarPais(Pais pais)
        {

            Pais? paisBorrar = listaPaises.FirstOrDefault(p => p.NombrePais == pais.NombrePais);
            
            if (paisBorrar is null)
            {
                return;
            }
            listaPaises.Remove(paisBorrar);

            var registros = listaPaises.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);

        }

        public void EditarPais(Pais pais)
        {
            var paisEditado = listaPaises.FirstOrDefault(p => p.PaisId == pais.PaisId);
           
            if (paisEditado is null)
            {
                return;
            }
           
            paisEditado.NombrePais = pais.NombrePais;
           
            var registros = listaPaises.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);
        }

        public bool Existe(Pais pais)
        {
            return pais.PaisId == 0 ? listaPaises.Any(p => p.NombrePais == pais.NombrePais) :
                listaPaises.Any(p => p.NombrePais == pais.NombrePais && p.PaisId != pais.PaisId);
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

        private string ConstruirLinea(Pais pais)
        {

            return $"{pais.PaisId}{separador}{pais.NombrePais}";

        }

    }
}
