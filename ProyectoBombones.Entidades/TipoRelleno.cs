namespace ProyectoBombones.Entidades
{
    public class TipoRelleno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
