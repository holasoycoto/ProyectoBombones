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

        private int ObtenerFrutoSecoId()
        {
            return listaFrutos.Any() ? listaFrutos.Max(f => f.FrutoID) + 1 : 1;
        }

        public void AgregarFrutoSeco(FrutoSeco fruto)
        {
            fruto.FrutoID = ObtenerFrutoSecoId();
            listaFrutos.Add(fruto);

            if (File.Exists(ruta))
            {
                var registros = File.ReadAllText(ruta);
                if (!string.IsNullOrEmpty(registros) && !registros.EndsWith(Environment.NewLine))
                {
                    File.AppendAllText(ruta, registros + Environment.NewLine);
                }
            }

            using (var escritor = new StreamWriter(ruta, true))
            {
                string linea = ConstruirLinea(fruto);
                escritor.WriteLine(linea);
            }
        }

        public void BorrarFrutoSeco(FrutoSeco fruto)
        {
            var frutoBorrar = listaFrutos.FirstOrDefault(f => f.NombreFruto == fruto.NombreFruto);
            if (frutoBorrar is null)
            {
                return;
            }

            listaFrutos.Remove(frutoBorrar);
            var registros = listaFrutos.Select(f => ConstruirLinea(f)).ToArray();
            File.WriteAllLines(ruta, registros);
        }

        public void EditarFrutoSeco(FrutoSeco fruto)
        {
            var frutoEditado = listaFrutos.FirstOrDefault(f => f.FrutoID == fruto.FrutoID);
            if (frutoEditado is null)
            {
                return;
            }

            frutoEditado.NombreFruto = fruto.NombreFruto;
            var registros = listaFrutos.Select(f => ConstruirLinea(f)).ToArray();
            File.WriteAllLines(ruta, registros);
        }

        public bool Existe(FrutoSeco fruto)
        {
            return fruto.FrutoID == 0
                ? listaFrutos.Any(f => f.NombreFruto == fruto.NombreFruto)
                : listaFrutos.Any(f => f.NombreFruto == fruto.NombreFruto && f.FrutoID != fruto.FrutoID);
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
            return new FrutoSeco
            {
                FrutoID = int.Parse(partesFruto[0]),
                NombreFruto = partesFruto[1]
            };
        }

        private string ConstruirLinea(FrutoSeco fruto)
        {
            return $"{fruto.FrutoID}{separador}{fruto.NombreFruto}";
        }
    }
}
