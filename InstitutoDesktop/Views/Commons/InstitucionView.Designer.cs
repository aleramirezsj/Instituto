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
            panel1.Size = new Size(1351, 60);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 6);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(302, 37);
            label1.TabIndex = 0;
            label1.Text = "Datos de la institución";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(1, 65);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1351, 768);
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
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Margin = new Padding(2);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(2);
            tabPageAgregarEditar.Size = new Size(1343, 735);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // TxtNombreCorto
            // 
            TxtNombreCorto.Anchor = AnchorStyles.None;
            TxtNombreCorto.Font = new Font("Segoe UI", 11F);
            TxtNombreCorto.Location = new Point(325, 133);
            TxtNombreCorto.Margin = new Padding(2);
            TxtNombreCorto.Name = "TxtNombreCorto";
            TxtNombreCorto.Size = new Size(437, 32);
            TxtNombreCorto.TabIndex = 1;
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.None;
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 11F);
            label25.Location = new Point(130, 140);
            label25.Margin = new Padding(2, 0, 2, 0);
            label25.Name = "label25";
            label25.Size = new Size(174, 25);
            label25.TabIndex = 44;
            label25.Text = "Nombre abreviado:";
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.None;
            TxtEmail.Font = new Font("Segoe UI", 11F);
            TxtEmail.Location = new Point(329, 588);
            TxtEmail.Margin = new Padding(2);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(437, 32);
            TxtEmail.TabIndex = 10;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11F);
            label11.Location = new Point(242, 595);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(62, 25);
            label11.TabIndex = 40;
            label11.Text = "Email:";
            // 
            // TxtCodigoPostal
            // 
            TxtCodigoPostal.Anchor = AnchorStyles.None;
            TxtCodigoPostal.Font = new Font("Segoe UI", 11F);
            TxtCodigoPostal.Location = new Point(327, 328);
            TxtCodigoPostal.Margin = new Padding(2);
            TxtCodigoPostal.Name = "TxtCodigoPostal";
            TxtCodigoPostal.Size = new Size(437, 32);
            TxtCodigoPostal.TabIndex = 9;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F);
            label10.Location = new Point(171, 335);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(133, 25);
            label10.TabIndex = 38;
            label10.Text = "Código postal:";
            // 
            // TxtProvincia
            // 
            TxtProvincia.Anchor = AnchorStyles.None;
            TxtProvincia.Font = new Font("Segoe UI", 11F);
            TxtProvincia.Location = new Point(327, 393);
            TxtProvincia.Margin = new Padding(2);
            TxtProvincia.Name = "TxtProvincia";
            TxtProvincia.Size = new Size(437, 32);
            TxtProvincia.TabIndex = 8;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.Location = new Point(210, 400);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(94, 25);
            label9.TabIndex = 36;
            label9.Text = "Provincia:";
            // 
            // TxtLocalidad
            // 
            TxtLocalidad.Anchor = AnchorStyles.None;
            TxtLocalidad.Font = new Font("Segoe UI", 11F);
            TxtLocalidad.Location = new Point(325, 263);
            TxtLocalidad.Margin = new Padding(2);
            TxtLocalidad.Name = "TxtLocalidad";
            TxtLocalidad.Size = new Size(437, 32);
            TxtLocalidad.TabIndex = 7;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.Location = new Point(207, 270);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(97, 25);
            label8.TabIndex = 34;
            label8.Text = "Localidad:";
            // 
            // TxtTelefono
            // 
            TxtTelefono.Anchor = AnchorStyles.None;
            TxtTelefono.Font = new Font("Segoe UI", 11F);
            TxtTelefono.Location = new Point(329, 523);
            TxtTelefono.Margin = new Padding(2);
            TxtTelefono.Name = "TxtTelefono";
            TxtTelefono.Size = new Size(437, 32);
            TxtTelefono.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(216, 530);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 32;
            label3.Text = "Teléfono:";
            // 
            // TxtDomicilio
            // 
            TxtDomicilio.Anchor = AnchorStyles.None;
            TxtDomicilio.Font = new Font("Segoe UI", 11F);
            TxtDomicilio.Location = new Point(329, 458);
            TxtDomicilio.Margin = new Padding(2);
            TxtDomicilio.Name = "TxtDomicilio";
            TxtDomicilio.Size = new Size(437, 32);
            TxtDomicilio.TabIndex = 5;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(208, 465);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(96, 25);
            label7.TabIndex = 29;
            label7.Text = "Dirección:";
            // 
            // TxtSigla
            // 
            TxtSigla.Anchor = AnchorStyles.None;
            TxtSigla.Font = new Font("Segoe UI", 11F);
            TxtSigla.Location = new Point(327, 198);
            TxtSigla.Margin = new Padding(2);
            TxtSigla.Name = "TxtSigla";
            TxtSigla.Size = new Size(437, 32);
            TxtSigla.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(247, 205);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 25;
            label2.Text = "Sigla:";
            // 
            // TxtNombreCompleto
            // 
            TxtNombreCompleto.Anchor = AnchorStyles.None;
            TxtNombreCompleto.Font = new Font("Segoe UI", 11F);
            TxtNombreCompleto.Location = new Point(325, 68);
            TxtNombreCompleto.Margin = new Padding(2);
            TxtNombreCompleto.Name = "TxtNombreCompleto";
            TxtNombreCompleto.Size = new Size(437, 32);
            TxtNombreCompleto.TabIndex = 0;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(135, 75);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(169, 25);
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
            btnCancelar.Location = new Point(1204, 278);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(122, 57);
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
            btnGuardar.Location = new Point(1204, 218);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(122, 57);
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
            btnModificar.Location = new Point(597, 849);
            btnModificar.Margin = new Padding(2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(128, 52);
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
            iconButtonSalir.Location = new Point(1225, 849);
            iconButtonSalir.Margin = new Padding(3, 4, 3, 4);
            iconButtonSalir.Name = "iconButtonSalir";
            iconButtonSalir.Size = new Size(123, 54);
            iconButtonSalir.TabIndex = 15;
            iconButtonSalir.Text = "&Salir";
            iconButtonSalir.TextAlign = ContentAlignment.MiddleRight;
            iconButtonSalir.UseVisualStyleBackColor = false;
            iconButtonSalir.Click += iconButtonSalir_Click_1;
            // 
            // InstitucionView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 912);
            Controls.Add(iconButtonSalir);
            Controls.Add(btnModificar);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "InstitucionView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos de la institución";
            WindowState = FormWindowState.Maximized;
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