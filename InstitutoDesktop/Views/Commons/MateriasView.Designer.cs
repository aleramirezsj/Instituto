namespace InstitutoDesktop.Views.Commons
{
    partial class MateriasView
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
            comboBoxAñosCarreras = new ComboBox();
            label4 = new Label();
            comboBoxCarreras = new ComboBox();
            label1 = new Label();
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            iconButtonSalir = new FontAwesome.Sharp.IconButton();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            txtFiltro = new TextBox();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnModificar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            Grilla = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            label6 = new Label();
            comboBoxTipoMateria = new ComboBox();
            chkEsRecreo = new CheckBox();
            label5 = new Label();
            comboBoxTipoPeriodo = new ComboBox();
            txtNombre = new TextBox();
            label2 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grilla).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(comboBoxAñosCarreras);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBoxCarreras);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1201, 138);
            panel1.TabIndex = 0;
            // 
            // comboBoxAñosCarreras
            // 
            comboBoxAñosCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxAñosCarreras.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxAñosCarreras.FormattingEnabled = true;
            comboBoxAñosCarreras.Location = new Point(151, 69);
            comboBoxAñosCarreras.Margin = new Padding(4, 4, 4, 4);
            comboBoxAñosCarreras.Name = "comboBoxAñosCarreras";
            comboBoxAñosCarreras.Size = new Size(1036, 53);
            comboBoxAñosCarreras.TabIndex = 3;
            comboBoxAñosCarreras.SelectedIndexChanged += comboBoxAñosCarreras_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 72);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(89, 45);
            label4.TabIndex = 2;
            label4.Text = "Año:";
            // 
            // comboBoxCarreras
            // 
            comboBoxCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCarreras.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCarreras.FormattingEnabled = true;
            comboBoxCarreras.Location = new Point(151, 8);
            comboBoxCarreras.Margin = new Padding(4, 4, 4, 4);
            comboBoxCarreras.Name = "comboBoxCarreras";
            comboBoxCarreras.Size = new Size(1036, 53);
            comboBoxCarreras.TabIndex = 1;
            comboBoxCarreras.SelectedIndexChanged += comboBoxCarreras_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 45);
            label1.TabIndex = 0;
            label1.Text = "Carrera";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(1, 142);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1201, 718);
            tabControl.TabIndex = 1;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(iconButtonSalir);
            tabPageLista.Controls.Add(BtnBuscar);
            tabPageLista.Controls.Add(label3);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnAgregar);
            tabPageLista.Controls.Add(Grilla);
            tabPageLista.Location = new Point(4, 34);
            tabPageLista.Margin = new Padding(2);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(2);
            tabPageLista.Size = new Size(1193, 680);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // iconButtonSalir
            // 
            iconButtonSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonSalir.BackColor = Color.OrangeRed;
            iconButtonSalir.ForeColor = Color.White;
            iconButtonSalir.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            iconButtonSalir.IconColor = Color.White;
            iconButtonSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSalir.IconSize = 44;
            iconButtonSalir.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSalir.Location = new Point(1030, 285);
            iconButtonSalir.Margin = new Padding(4, 5, 4, 5);
            iconButtonSalir.Name = "iconButtonSalir";
            iconButtonSalir.Size = new Size(154, 68);
            iconButtonSalir.TabIndex = 14;
            iconButtonSalir.Text = "&Salir";
            iconButtonSalir.TextAlign = ContentAlignment.MiddleRight;
            iconButtonSalir.UseVisualStyleBackColor = false;
            iconButtonSalir.Click += iconButtonSalir_Click;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnBuscar.BackColor = Color.OrangeRed;
            BtnBuscar.ForeColor = Color.White;
            BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscar.IconColor = Color.White;
            BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnBuscar.Location = new Point(1034, 22);
            BtnBuscar.Margin = new Padding(4, 5, 4, 5);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(154, 64);
            BtnBuscar.TabIndex = 13;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscar.UseVisualStyleBackColor = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 26);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 25);
            label3.TabIndex = 12;
            label3.Text = "Buscar:";
            // 
            // txtFiltro
            // 
            txtFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFiltro.Location = new Point(121, 20);
            txtFiltro.Margin = new Padding(4, 4, 4, 4);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(603, 31);
            txtFiltro.TabIndex = 11;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.DarkGray;
            btnEliminar.Enabled = false;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(1034, 220);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 58);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextAlign = ContentAlignment.MiddleRight;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.BackColor = Color.LightGray;
            btnModificar.Enabled = false;
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(1034, 158);
            btnModificar.Margin = new Padding(2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(150, 58);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = Color.DarkGray;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAgregar.IconColor = Color.Black;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(1034, 94);
            btnAgregar.Margin = new Padding(2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 58);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // Grilla
            // 
            Grilla.AllowUserToAddRows = false;
            Grilla.AllowUserToDeleteRows = false;
            Grilla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grilla.Location = new Point(8, 79);
            Grilla.Margin = new Padding(2);
            Grilla.Name = "Grilla";
            Grilla.ReadOnly = true;
            Grilla.RowHeadersWidth = 62;
            Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grilla.Size = new Size(1015, 588);
            Grilla.TabIndex = 0;
            Grilla.DataBindingComplete += Grilla_DataBindingComplete;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(comboBoxTipoMateria);
            tabPageAgregarEditar.Controls.Add(chkEsRecreo);
            tabPageAgregarEditar.Controls.Add(label5);
            tabPageAgregarEditar.Controls.Add(comboBoxTipoPeriodo);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Location = new Point(4, 34);
            tabPageAgregarEditar.Margin = new Padding(2);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(2);
            tabPageAgregarEditar.Size = new Size(1193, 680);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(322, 350);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(115, 25);
            label6.TabIndex = 10;
            label6.Text = "Tipo materia:";
            // 
            // comboBoxTipoMateria
            // 
            comboBoxTipoMateria.Anchor = AnchorStyles.None;
            comboBoxTipoMateria.FormattingEnabled = true;
            comboBoxTipoMateria.Location = new Point(464, 340);
            comboBoxTipoMateria.Margin = new Padding(4, 4, 4, 4);
            comboBoxTipoMateria.Name = "comboBoxTipoMateria";
            comboBoxTipoMateria.Size = new Size(354, 33);
            comboBoxTipoMateria.TabIndex = 9;
            // 
            // chkEsRecreo
            // 
            chkEsRecreo.Anchor = AnchorStyles.None;
            chkEsRecreo.AutoSize = true;
            chkEsRecreo.Location = new Point(464, 422);
            chkEsRecreo.Margin = new Padding(4, 4, 4, 4);
            chkEsRecreo.Name = "chkEsRecreo";
            chkEsRecreo.Size = new Size(109, 29);
            chkEsRecreo.TabIndex = 8;
            chkEsRecreo.Text = "Es recreo";
            chkEsRecreo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(296, 269);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(145, 25);
            label5.TabIndex = 7;
            label5.Text = "Periodo cursado:";
            // 
            // comboBoxTipoPeriodo
            // 
            comboBoxTipoPeriodo.Anchor = AnchorStyles.None;
            comboBoxTipoPeriodo.FormattingEnabled = true;
            comboBoxTipoPeriodo.Location = new Point(464, 259);
            comboBoxTipoPeriodo.Margin = new Padding(4, 4, 4, 4);
            comboBoxTipoPeriodo.Name = "comboBoxTipoPeriodo";
            comboBoxTipoPeriodo.Size = new Size(354, 33);
            comboBoxTipoPeriodo.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.None;
            txtNombre.Location = new Point(464, 184);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(354, 31);
            txtNombre.TabIndex = 5;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(360, 190);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 4;
            label2.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(1015, 259);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(152, 71);
            btnCancelar.TabIndex = 3;
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
            btnGuardar.Location = new Point(1015, 184);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(152, 71);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // MateriasView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 856);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "MateriasView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Materias";
            TopMost = true;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Grilla).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Panel panel1;
        private Label label1;
        public TabControl tabControl;
        public TabPage tabPageLista;
        public DataGridView Grilla;
        public TabPage tabPageAgregarEditar;
        public FontAwesome.Sharp.IconButton btnCancelar;
        public FontAwesome.Sharp.IconButton btnGuardar;
        public FontAwesome.Sharp.IconButton btnAgregar;
        public FontAwesome.Sharp.IconButton btnModificar;
        public FontAwesome.Sharp.IconButton btnEliminar;
        public FontAwesome.Sharp.IconButton iconButtonSalir;
        public FontAwesome.Sharp.IconButton BtnBuscar;
        private Label label3;
        public TextBox txtFiltro;
        public FontAwesome.Sharp.IconButton iconButton1;
        public TextBox txtNombre;
        private Label label2;
        public ComboBox comboBoxCarreras;
        public ComboBox comboBoxAñosCarreras;
        private Label label4;
        private Label label5;
        public ComboBox comboBoxTipoPeriodo;
        public CheckBox chkEsRecreo;
        private Label label6;
        public ComboBox comboBoxTipoMateria;
    }
}