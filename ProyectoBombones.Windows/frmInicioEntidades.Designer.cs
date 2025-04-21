namespace ProyectoBombones.Windows
{
    partial class frmInicioEntidades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnFrutosSecos = new Button();
            btnPaises = new Button();
            btnTipoRelleno = new Button();
            btnTipoChocolate = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnFrutosSecos
            // 
            btnFrutosSecos.Location = new Point(39, 104);
            btnFrutosSecos.Name = "btnFrutosSecos";
            btnFrutosSecos.Size = new Size(82, 52);
            btnFrutosSecos.TabIndex = 0;
            btnFrutosSecos.Text = "Frutos Secos";
            btnFrutosSecos.UseVisualStyleBackColor = true;
            btnFrutosSecos.Click += btnFrutosSecos_Click;
            // 
            // btnPaises
            // 
            btnPaises.Location = new Point(127, 104);
            btnPaises.Name = "btnPaises";
            btnPaises.Size = new Size(82, 52);
            btnPaises.TabIndex = 1;
            btnPaises.Text = "Paises";
            btnPaises.UseVisualStyleBackColor = true;
            btnPaises.Click += btnPaises_Click;
            // 
            // btnTipoRelleno
            // 
            btnTipoRelleno.Location = new Point(215, 104);
            btnTipoRelleno.Name = "btnTipoRelleno";
            btnTipoRelleno.Size = new Size(82, 52);
            btnTipoRelleno.TabIndex = 2;
            btnTipoRelleno.Text = "Tipo de Relleno";
            btnTipoRelleno.UseVisualStyleBackColor = true;
            btnTipoRelleno.Click += btnTipoRelleno_Click;
            // 
            // btnTipoChocolate
            // 
            btnTipoChocolate.Location = new Point(303, 104);
            btnTipoChocolate.Name = "btnTipoChocolate";
            btnTipoChocolate.Size = new Size(82, 52);
            btnTipoChocolate.TabIndex = 3;
            btnTipoChocolate.Text = "Tipo de Chocolate";
            btnTipoChocolate.UseVisualStyleBackColor = true;
            btnTipoChocolate.Click += btnTipoChocolate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(100, 48);
            label1.Name = "label1";
            label1.Size = new Size(226, 21);
            label1.TabIndex = 4;
            label1.Text = "Seleccione una de las opciones:";
            // 
            // frmInicioEntidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 201);
            Controls.Add(label1);
            Controls.Add(btnTipoChocolate);
            Controls.Add(btnTipoRelleno);
            Controls.Add(btnPaises);
            Controls.Add(btnFrutosSecos);
            Name = "frmInicioEntidades";
            ShowIcon = false;
            Text = "Seleccion de Entidad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFrutosSecos;
        private Button btnPaises;
        private Button btnTipoRelleno;
        private Button btnTipoChocolate;
        private Label label1;
    }
}