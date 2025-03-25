namespace ProyectoBombones.Entidades
{
    public class FrutoSeco
    {

        public int FrutoID { get; set; }
        public string NombreFruto { get; set; } = null!;
        
        public override string ToString()
        {
            return $"{NombreFruto}";
        }

    }
}
