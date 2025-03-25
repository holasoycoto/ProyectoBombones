using ProyectoBombones.Servicios;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Obtener lista de paises");
            Console.WriteLine("2. Obtener lista de frutos secos");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    MostrarListaDePaises();
                    break;
                case "2":
                    Console.Clear();
                    MostrarListaDeFrutosSecos();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opcion no valida. Presiona cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void MostrarListaDePaises()
    {

        var paisesServicio = new PaisServicio("Paises.txt");
        var paises = paisesServicio.ObtenerPaises();

        Console.WriteLine("Lista de paises:");
        foreach (var pais in paises)
        {
            Console.WriteLine(pais.ToString());
        }

        Console.WriteLine("Presiona cualquier tecla para volver al menu.");
        Console.ReadKey();
    }

    static void MostrarListaDeFrutosSecos()
    {

        var frutosSecosServicio = new FrutoSecoServicio("FrutosSecos.txt");
        var frutosSecos = frutosSecosServicio.ObtenerFrutosSecos();

        Console.WriteLine("Lista de frutos secos:");
        foreach (var fruto in frutosSecos)
        {
            Console.WriteLine(fruto.ToString());
        }
        Console.WriteLine("Presiona cualquier tecla para volver al menu.");
        Console.ReadKey();
    }
}