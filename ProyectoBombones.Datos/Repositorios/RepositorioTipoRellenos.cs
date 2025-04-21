using ProyectoBombones.Entidades;

namespace ProyectoBombones.Datos.Repositorios
{
    public class RepositorioTipoRellenos
    {
        private List<TipoRelleno> listaTipoRellenos = new();
        private readonly string ruta = null!;
        private readonly char separador = '|';

        public RepositorioTipoRellenos(string rutaArchivo)
        {
            ruta = rutaArchivo;
            LeerDatos();
        }

        public int ObtenerTipoRellenoId()
        {
            return listaTipoRellenos.Any() ? listaTipoRellenos.Max(r => r.Id) + 1 : 1;
        }

        public void AgregarTipoRelleno(TipoRelleno tipoRelleno)
        {
            tipoRelleno.Id = ObtenerTipoRellenoId();
            listaTipoRellenos.Add(tipoRelleno);

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
                string linea = ConstruirLinea(tipoRelleno);
                escritor.WriteLine(linea);
            }
        }

        public void BorrarTipoRelleno(TipoRelleno tipoRelleno)
        {
            TipoRelleno? rellenoBorrar = listaTipoRellenos.FirstOrDefault(r => r.Nombre == tipoRelleno.Nombre);

            if (rellenoBorrar is null)
            {
                return;
            }
            listaTipoRellenos.Remove(rellenoBorrar);

            var registros = listaTipoRellenos.Select(r => ConstruirLinea(r)).ToArray();
            File.WriteAllLines(ruta, registros);
        }

        public void EditarTipoRelleno(TipoRelleno tipoRelleno)
        {
            var rellenoEditado = listaTipoRellenos.FirstOrDefault(r => r.Id == tipoRelleno.Id);

            if (rellenoEditado is null)
            {
                return;
            }

            rellenoEditado.Nombre = tipoRelleno.Nombre;

            var registros = listaTipoRellenos.Select(r => ConstruirLinea(r)).ToArray();
            File.WriteAllLines(ruta, registros);
        }

        public bool Existe(TipoRelleno tipoRelleno)
        {
            return tipoRelleno.Id == 0 ? listaTipoRellenos.Any(r => r.Nombre == tipoRelleno.Nombre) :
                listaTipoRellenos.Any(r => r.Nombre == tipoRelleno.Nombre && r.Id != tipoRelleno.Id);
        }

        public List<TipoRelleno> ObtenerTipoRellenos()
        {
            return listaTipoRellenos;
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
                TipoRelleno tipoRelleno = ConstruirTipoRelleno(registro);
                listaTipoRellenos.Add(tipoRelleno);
            }
        }

        private TipoRelleno ConstruirTipoRelleno(string registro)
        {
            var partes = registro.Split(separador);
            TipoRelleno tipoRelleno = new()
            {
                Id = int.Parse(partes[0]),
                Nombre = partes[1]
            };

            return tipoRelleno;
        }

        private string ConstruirLinea(TipoRelleno tipoRelleno)
        {
            return $"{tipoRelleno.Id}{separador}{tipoRelleno.Nombre}";
        }
    }
}