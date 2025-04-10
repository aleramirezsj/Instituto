namespace InstitutoDesktop.Views
{
    partial class InstitucionView
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
            panel1 = new Panel();
            label1 = new Label();
            tabControl = new TabControl();
            tabPageAgregarEditar = new TabPage();
            TxtNombreCorto = new TextBox();
            label25 = new Label();
            TxtEmail = new TextBox();
            label11 = new Label();
            TxtCodigoPostal = new TextBox();
            label10 = new Label();
            TxtProvincia = new TextBox();
            label9 = new Label();
            TxtLocalidad = new TextBox();
            label8 = new Label();
            TxtTelefono = new TextBox();
            label3 = new Label();
            TxtDomicilio = new TextBox();
            label7 = new Label();
            TxtSigla = new TextBox();
            label2 = new Label();
            TxtNombreCompleto = new TextBox();
            label6 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            btnModificar = new FontAwesome.Sharp.IconButton();
            iconButtonSalir = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageAgregarEditar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1689, 75);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(357, 45);
            label1.TabIndex = 0;
            label1.Text = "Datos de la institución";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(1, 81);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1689, 960);
            tabControl.TabIndex = 1;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(TxtNombreCorto);
            tabPageAgregarEditar.Controls.Add(label25);
            tabPageAgregarEditar.Controls.Add(TxtEmail);
            tabPageAgregarEditar.Controls.Add(label11);
            tabPageAgregarEditar.Controls.Add(TxtCodigoPostal);
            tabPageAgregarEditar.Controls.Add(label10);
            tabPageAgregarEditar.Controls.Add(TxtProvincia);
            tabPageAgregarEditar.Controls.Add(label9);
            tabPageAgregarEditar.Controls.Add(TxtLocalidad);
            tabPageAgregarEditar.Controls.Add(label8);
            tabPageAgregarEditar.Controls.Add(TxtTelefono);
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Controls.Add(TxtDomicilio);
            tabPageAgregarEditar.Controls.Add(label7);
            tabPageAgregarEditar.Controls.Add(TxtSigla);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Controls.Add(TxtNombreCompleto);
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Location = new Point(4, 34);
            tabPageAgregarEditar.Margin = new Padding(2);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(2);
            tabPageAgregarEditar.Size = new Size(1681, 922);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // TxtNombreCorto
            // 
            TxtNombreCorto.Anchor = AnchorStyles.None;
            TxtNombreCorto.Font = new Font("Segoe UI", 11F);
            TxtNombreCorto.Location = new Point(406, 166);
            TxtNombreCorto.Margin = new Padding(2);
            TxtNombreCorto.Name = "TxtNombreCorto";
            TxtNombreCorto.Size = new Size(545, 37);
            TxtNombreCorto.TabIndex = 1;
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.None;
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 11F);
            label25.Location = new Point(162, 175);
            label25.Margin = new Padding(2, 0, 2, 0);
            label25.Name = "label25";
            label25.Size = new Size(202, 30);
            label25.TabIndex = 44;
            label25.Text = "Nombre abreviado:";
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.None;
            TxtEmail.Font = new Font("Segoe UI", 11F);
            TxtEmail.Location = new Point(411, 735);
            TxtEmail.Margin = new Padding(2);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(545, 37);
            TxtEmail.TabIndex = 10;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11F);
            label11.Location = new Point(302, 744);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(69, 30);
            label11.TabIndex = 40;
            label11.Text = "Email:";
            // 
            // TxtCodigoPostal
            // 
            TxtCodigoPostal.Anchor = AnchorStyles.None;
            TxtCodigoPostal.Font = new Font("Segoe UI", 11F);
            TxtCodigoPostal.Location = new Point(409, 410);
            TxtCodigoPostal.Margin = new Padding(2);
            TxtCodigoPostal.Name = "TxtCodigoPostal";
            TxtCodigoPostal.Size = new Size(545, 37);
            TxtCodigoPostal.TabIndex = 9;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F);
            label10.Location = new Point(214, 419);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(153, 30);
            label10.TabIndex = 38;
            label10.Text = "Código postal:";
            // 
            // TxtProvincia
            // 
            TxtProvincia.Anchor = AnchorStyles.None;
            TxtProvincia.Font = new Font("Segoe UI", 11F);
            TxtProvincia.Location = new Point(409, 491);
            TxtProvincia.Margin = new Padding(2);
            TxtProvincia.Name = "TxtProvincia";
            TxtProvincia.Size = new Size(545, 37);
            TxtProvincia.TabIndex = 8;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.Location = new Point(262, 500);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(105, 30);
            label9.TabIndex = 36;
            label9.Text = "Provincia:";
            // 
            // TxtLocalidad
            // 
            TxtLocalidad.Anchor = AnchorStyles.None;
            TxtLocalidad.Font = new Font("Segoe UI", 11F);
            TxtLocalidad.Location = new Point(406, 329);
            TxtLocalidad.Margin = new Padding(2);
            TxtLocalidad.Name = "TxtLocalidad";
            TxtLocalidad.Size = new Size(545, 37);
            TxtLocalidad.TabIndex = 7;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.Location = new Point(259, 338);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(109, 30);
            label8.TabIndex = 34;
            label8.Text = "Localidad:";
            // 
            // TxtTelefono
            // 
            TxtTelefono.Anchor = AnchorStyles.None;
            TxtTelefono.Font = new Font("Segoe UI", 11F);
            TxtTelefono.Location = new Point(411, 654);
            TxtTelefono.Margin = new Padding(2);
            TxtTelefono.Name = "TxtTelefono";
            TxtTelefono.Size = new Size(545, 37);
            TxtTelefono.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(270, 662);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 30);
            label3.TabIndex = 32;
            label3.Text = "Teléfono:";
            // 
            // TxtDomicilio
            // 
            TxtDomicilio.Anchor = AnchorStyles.None;
            TxtDomicilio.Font = new Font("Segoe UI", 11F);
            TxtDomicilio.Location = new Point(411, 572);
            TxtDomicilio.Margin = new Padding(2);
            TxtDomicilio.Name = "TxtDomicilio";
            TxtDomicilio.Size = new Size(545, 37);
            TxtDomicilio.TabIndex = 5;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(260, 581);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(108, 30);
            label7.TabIndex = 29;
            label7.Text = "Dirección:";
            // 
            // TxtSigla
            // 
            TxtSigla.Anchor = AnchorStyles.None;
            TxtSigla.Font = new Font("Segoe UI", 11F);
            TxtSigla.Location = new Point(409, 248);
            TxtSigla.Margin = new Padding(2);
            TxtSigla.Name = "TxtSigla";
            TxtSigla.Size = new Size(545, 37);
            TxtSigla.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(309, 256);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 30);
            label2.TabIndex = 25;
            label2.Text = "Sigla:";
            // 
            // TxtNombreCompleto
            // 
            TxtNombreCompleto.Anchor = AnchorStyles.None;
            TxtNombreCompleto.Font = new Font("Segoe UI", 11F);
            TxtNombreCompleto.Location = new Point(406, 85);
            TxtNombreCompleto.Margin = new Padding(2);
            TxtNombreCompleto.Name = "TxtNombreCompleto";
            TxtNombreCompleto.Size = new Size(545, 37);
            TxtNombreCompleto.TabIndex = 0;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(169, 94);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(197, 30);
            label6.TabIndex = 19;
            label6.Text = "Nombre completo:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(1505, 348);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(152, 71);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = Color.DarkGray;
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(1505, 272);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(152, 71);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Bottom;
            btnModificar.BackColor = Color.LightGray;
            btnModificar.Enabled = false;
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(746, 971);
            btnModificar.Margin = new Padding(2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(160, 65);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // iconButtonSalir
            // 
            iconButtonSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButtonSalir.BackColor = Color.OrangeRed;
            iconButtonSalir.ForeColor = Color.White;
            iconButtonSalir.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            iconButtonSalir.IconColor = Color.White;
            iconButtonSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSalir.IconSize = 44;
            iconButtonSalir.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSalir.Location = new Point(1531, 971);
            iconButtonSalir.Margin = new Padding(4, 5, 4, 5);
            iconButtonSalir.Name = "iconButtonSalir";
            iconButtonSalir.Size = new Size(154, 68);
            iconButtonSalir.TabIndex = 15;
            iconButtonSalir.Text = "&Salir";
            iconButtonSalir.TextAlign = ContentAlignment.MiddleRight;
            iconButtonSalir.UseVisualStyleBackColor = false;
            iconButtonSalir.Click += iconButtonSalir_Click_1;
            // 
            // InstitucionView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1691, 1050);
            Controls.Add(iconButtonSalir);
            Controls.Add(btnModificar);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "InstitucionView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos de la institución";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Panel panel1;
        private Label label1;
        public TabControl tabControl;
        public TabPage tabPageAgregarEditar;
        public FontAwesome.Sharp.IconButton btnCancelar;
        public FontAwesome.Sharp.IconButton btnGuardar;
        public FontAwesome.Sharp.IconButton iconButton1;
        public TextBox TxtSigla;
        private Label label2;
        private Label label4;
        public TextBox TxtNombreCompleto;
        private Label label6;
        public TextBox TxtDomicilio;
        private Label label7;
        public TextBox TxtCondicionIVA;
        private Label label5;
        public FontAwesome.Sharp.IconButton btnModificar;
        public TextBox TxtIngresosBrutos;
        public TextBox TxtTelefono;
        private Label label3;
        public TextBox TxtProvincia;
        private Label label9;
        public TextBox TxtLocalidad;
        private Label label8;
        public TextBox TxtCodigoPostal;
        private Label label10;
        public TextBox TxtEmail;
        private Label label11;
        public FontAwesome.Sharp.IconButton iconButtonSalir;
        public TextBox TxtNombreCorto;
        private Label label25;
    }
}