namespace ProyectoBombones.Entidades
{
    public class TipoChocolate
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
