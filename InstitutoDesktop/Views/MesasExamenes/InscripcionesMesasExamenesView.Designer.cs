namespace InstitutoDesktop.Views
{
    partial class InscripcionesMesasExamenesView
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            chkFiltrarPorCarrera = new CheckBox();
            cboAniosCarreras = new ComboBox();
            cboCarreras = new ComboBox();
            label4 = new Label();
            cboTurnosExamenes = new ComboBox();
            label1 = new Label();
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            btnSalir = new FontAwesome.Sharp.IconButton();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            txtFiltro = new TextBox();
            btnModificar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            dataGridInscripciones = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            dataGridInscripcionSeleccioanda = new DataGridView();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcionSeleccioanda).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(chkFiltrarPorCarrera);
            panel1.Controls.Add(cboAniosCarreras);
            panel1.Controls.Add(cboCarreras);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cboTurnosExamenes);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1458, 60);
            panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1254, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(175, 24);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Filtrar por año carrera";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkFiltrarPorCarrera
            // 
            chkFiltrarPorCarrera.AutoSize = true;
            chkFiltrarPorCarrera.Location = new Point(807, 6);
            chkFiltrarPorCarrera.Name = "chkFiltrarPorCarrera";
            chkFiltrarPorCarrera.Size = new Size(146, 24);
            chkFiltrarPorCarrera.TabIndex = 8;
            chkFiltrarPorCarrera.Text = "Filtrar por carrera";
            chkFiltrarPorCarrera.UseVisualStyleBackColor = true;
            // 
            // cboAniosCarreras
            // 
            cboAniosCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboAniosCarreras.FormattingEnabled = true;
            cboAniosCarreras.Location = new Point(1254, 30);
            cboAniosCarreras.Name = "cboAniosCarreras";
            cboAniosCarreras.Size = new Size(195, 28);
            cboAniosCarreras.TabIndex = 6;
            // 
            // cboCarreras
            // 
            cboCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCarreras.FormattingEnabled = true;
            cboCarreras.Location = new Point(807, 30);
            cboCarreras.Name = "cboCarreras";
            cboCarreras.Size = new Size(441, 28);
            cboCarreras.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(494, 6);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 3;
            label4.Text = "Turno de examen";
            // 
            // cboTurnosExamenes
            // 
            cboTurnosExamenes.FormattingEnabled = true;
            cboTurnosExamenes.Location = new Point(494, 31);
            cboTurnosExamenes.Name = "cboTurnosExamenes";
            cboTurnosExamenes.Size = new Size(307, 28);
            cboTurnosExamenes.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 6);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(460, 37);
            label1.TabIndex = 0;
            label1.Text = "Inscripciones a mesas de exámenes";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(1, 65);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1458, 604);
            tabControl.TabIndex = 1;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(dataGridInscripcionSeleccioanda);
            tabPageLista.Controls.Add(btnSalir);
            tabPageLista.Controls.Add(BtnBuscar);
            tabPageLista.Controls.Add(label3);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnAgregar);
            tabPageLista.Controls.Add(dataGridInscripciones);
            tabPageLista.Location = new Point(4, 29);
            tabPageLista.Margin = new Padding(2);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(2);
            tabPageLista.Size = new Size(1450, 571);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Ver por alumnos";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = Color.OrangeRed;
            btnSalir.ForeColor = Color.White;
            btnSalir.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnSalir.IconColor = Color.White;
            btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSalir.IconSize = 44;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(1303, 504);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(141, 54);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "&Salir";
            btnSalir.TextAlign = ContentAlignment.MiddleRight;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
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
            BtnBuscar.Location = new Point(1303, 9);
            BtnBuscar.Margin = new Padding(3, 4, 3, 4);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(145, 51);
            BtnBuscar.TabIndex = 13;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscar.UseVisualStyleBackColor = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 21);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 12;
            label3.Text = "Buscar alumno:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(179, 18);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(483, 27);
            txtFiltro.TabIndex = 11;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(1303, 126);
            btnModificar.Margin = new Padding(2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(142, 63);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Imprimir seleccionada";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnAgregar.IconColor = Color.Black;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(1303, 66);
            btnAgregar.Margin = new Padding(2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 56);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Imprimir\ntodas";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridInscripciones
            // 
            dataGridInscripciones.AllowUserToAddRows = false;
            dataGridInscripciones.AllowUserToDeleteRows = false;
            dataGridInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridInscripciones.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridInscripciones.Location = new Point(6, 63);
            dataGridInscripciones.Margin = new Padding(2);
            dataGridInscripciones.Name = "dataGridInscripciones";
            dataGridInscripciones.ReadOnly = true;
            dataGridInscripciones.RowHeadersWidth = 62;
            dataGridInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInscripciones.Size = new Size(1293, 312);
            dataGridInscripciones.TabIndex = 0;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Margin = new Padding(2);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(2);
            tabPageAgregarEditar.Size = new Size(1450, 513);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Ver por materias";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // dataGridInscripcionSeleccioanda
            // 
            dataGridInscripcionSeleccioanda.AllowUserToAddRows = false;
            dataGridInscripcionSeleccioanda.AllowUserToDeleteRows = false;
            dataGridInscripcionSeleccioanda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridInscripcionSeleccioanda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridInscripcionSeleccioanda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridInscripcionSeleccioanda.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridInscripcionSeleccioanda.Location = new Point(6, 390);
            dataGridInscripcionSeleccioanda.Margin = new Padding(2);
            dataGridInscripcionSeleccioanda.Name = "dataGridInscripcionSeleccioanda";
            dataGridInscripcionSeleccioanda.ReadOnly = true;
            dataGridInscripcionSeleccioanda.RowHeadersWidth = 62;
            dataGridInscripcionSeleccioanda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInscripcionSeleccioanda.Size = new Size(1293, 168);
            dataGridInscripcionSeleccioanda.TabIndex = 15;
            // 
            // InscripcionesMesasExamenesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 665);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "InscripcionesMesasExamenesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripciones a mesas de exámenes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcionSeleccioanda).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        public TabControl tabControl;
        public TabPage tabPageLista;
        public DataGridView dataGridInscripciones;
        public TabPage tabPageAgregarEditar;
        public FontAwesome.Sharp.IconButton btnAgregar;
        public FontAwesome.Sharp.IconButton btnModificar;
        public FontAwesome.Sharp.IconButton btnSalir;
        public FontAwesome.Sharp.IconButton BtnBuscar;
        private Label label3;
        public TextBox txtFiltro;
        private Label label4;
        public ComboBox cboTurnosExamenes;
        public ComboBox cboCarreras;
        public ComboBox cboAniosCarreras;
        private CheckBox checkBox1;
        private CheckBox chkFiltrarPorCarrera;
        public DataGridView dataGridInscripcionSeleccioanda;
    }
}