using ProyectoBombones.Entidades;

namespace ProyectoBombones.Windows
{
    public partial class frmPaisesAE : Form
    {

        private Pais? pais;

        public frmPaisesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            if (pais is not null)
            {
                TxtPais.Text = pais.NombrePais;
            }

        }

        public Pais? ObtenerPais()
        {
            return pais;
        }

        public void EstablecerPais(Pais? _pais)
        {
            this.pais = _pais;
        }

        public bool EsValido()
        {

            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(TxtPais.Text))
            {
                valido = false;
                errorProvider1.SetError(TxtPais, "Ingrese un nombre de pais valido");
            }

            return valido;

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            if (EsValido())
            {

                if (pais is null)
                {
                    pais = new();
                }

                pais.NombrePais = TxtPais.Text;

                DialogResult = DialogResult.OK;

            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
