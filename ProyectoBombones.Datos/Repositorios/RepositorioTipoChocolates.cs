using ProyectoBombones.Entidades;

namespace ProyectoBombones.Datos.Repositorios
{
    public class RepositorioTipoChocolates
    {
        private List<TipoChocolate> listaTipoChocolates = new();
        private readonly string ruta = null!;
        private readonly char separador = '|';

        public RepositorioTipoChocolates(string rutaArchivo)
        {
            ruta = rutaArchivo;
            LeerDatos();
        }

        public int ObtenerTipoChocolateId()
        {
            return listaTipoChocolates.Any() ? listaTipoChocolates.Max(c => c.Id) + 1 : 1;
        }

        public void AgregarTipoChocolate(TipoChocolate tipoChocolate)
        {
            tipoChocolate.Id = ObtenerTipoChocolateId();
            listaTipoChocolates.Add(tipoChocolate);

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
                string linea = ConstruirLinea(tipoChocolate);
                escritor.WriteLine(linea);
            }
        }

        public void BorrarTipoChocolate(TipoChocolate tipoChocolate)
        {
            TipoChocolate? chocolateBorrar = listaTipoChocolates.FirstOrDefault(c => c.Nombre == tipoChocolate.Nombre);

            if (chocolateBorrar is null)
            {
                return;
            }
            listaTipoChocolates.Remove(chocolateBorrar);

            var registros = listaTipoChocolates.Select(c => ConstruirLinea(c)).ToArray();
            File.WriteAllLines(ruta, registros);
        }

        public void EditarTipoChocolate(TipoChocolate tipoChocolate)
        {
            var chocolateEditado = listaTipoChocolates.FirstOrDefault(c => c.Id == tipoChocolate.Id);

            if (chocolateEditado is null)
            {
                return;
            }

            chocolateEditado.Nombre = tipoChocolate.Nombre;

            var registros = listaTipoChocolates.Select(c => ConstruirLinea(c)).ToArray();
            File.WriteAllLines(ruta, registros);
        }

        public bool Existe(TipoChocolate tipoChocolate)
        {
            return tipoChocolate.Id == 0 ? listaTipoChocolates.Any(c => c.Nombre == tipoChocolate.Nombre) :
                listaTipoChocolates.Any(c => c.Nombre == tipoChocolate.Nombre && c.Id != tipoChocolate.Id);
        }

        public List<TipoChocolate> ObtenerTipoChocolates()
        {
            return listaTipoChocolates;
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
                TipoChocolate tipoChocolate = ConstruirTipoChocolate(registro);
                listaTipoChocolates.Add(tipoChocolate);
            }
        }

        private TipoChocolate ConstruirTipoChocolate(string registro)
        {
            var partes = registro.Split(separador);
            TipoChocolate tipoChocolate = new()
            {
                Id = int.Parse(partes[0]),
                Nombre = partes[1]
            };

            return tipoChocolate;
        }

        private string ConstruirLinea(TipoChocolate tipoChocolate)
        {
            return $"{tipoChocolate.Id}{separador}{tipoChocolate.Nombre}";
        }
    }
}