namespace InstitutoDesktop.Views
{
    partial class InscripcionesExamenesView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            chkFiltrarPorAñoCarrera = new CheckBox();
            chkFiltrarPorCarrera = new CheckBox();
            cboAniosCarreras = new ComboBox();
            cboCarreras = new ComboBox();
            label4 = new Label();
            cboTurnosExamenes = new ComboBox();
            label1 = new Label();
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            statusbar = new StatusStrip();
            statusBarMessage = new ToolStripStatusLabel();
            dataGridInscripcionSeleccioanda = new DataGridView();
            btnSalir = new FontAwesome.Sharp.IconButton();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            txtFiltro = new TextBox();
            btnImprimirSeleccionada = new FontAwesome.Sharp.IconButton();
            btnImprimirTodas = new FontAwesome.Sharp.IconButton();
            dataGridInscripciones = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            statusbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcionSeleccioanda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripciones).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(chkFiltrarPorAñoCarrera);
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
            // chkFiltrarPorAñoCarrera
            // 
            chkFiltrarPorAñoCarrera.AutoSize = true;
            chkFiltrarPorAñoCarrera.Location = new Point(1254, 5);
            chkFiltrarPorAñoCarrera.Name = "chkFiltrarPorAñoCarrera";
            chkFiltrarPorAñoCarrera.Size = new Size(175, 24);
            chkFiltrarPorAñoCarrera.TabIndex = 9;
            chkFiltrarPorAñoCarrera.Text = "Filtrar por año carrera";
            chkFiltrarPorAñoCarrera.UseVisualStyleBackColor = true;
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
            cboCarreras.Enabled = false;
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
            tabPageLista.Controls.Add(statusbar);
            tabPageLista.Controls.Add(dataGridInscripcionSeleccioanda);
            tabPageLista.Controls.Add(btnSalir);
            tabPageLista.Controls.Add(BtnBuscar);
            tabPageLista.Controls.Add(label3);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(btnImprimirSeleccionada);
            tabPageLista.Controls.Add(btnImprimirTodas);
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
            // statusbar
            // 
            statusbar.ImageScalingSize = new Size(20, 20);
            statusbar.Items.AddRange(new ToolStripItem[] { statusBarMessage });
            statusbar.Location = new Point(2, 547);
            statusbar.Name = "statusbar";
            statusbar.Size = new Size(1446, 22);
            statusbar.TabIndex = 16;
            // 
            // statusBarMessage
            // 
            statusBarMessage.Name = "statusBarMessage";
            statusBarMessage.Size = new Size(0, 16);
            // 
            // dataGridInscripcionSeleccioanda
            // 
            dataGridInscripcionSeleccioanda.AllowUserToAddRows = false;
            dataGridInscripcionSeleccioanda.AllowUserToDeleteRows = false;
            dataGridInscripcionSeleccioanda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridInscripcionSeleccioanda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridInscripcionSeleccioanda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridInscripcionSeleccioanda.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridInscripcionSeleccioanda.Location = new Point(6, 390);
            dataGridInscripcionSeleccioanda.Margin = new Padding(2);
            dataGridInscripcionSeleccioanda.Name = "dataGridInscripcionSeleccioanda";
            dataGridInscripcionSeleccioanda.ReadOnly = true;
            dataGridInscripcionSeleccioanda.RowHeadersWidth = 62;
            dataGridInscripcionSeleccioanda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInscripcionSeleccioanda.Size = new Size(1293, 168);
            dataGridInscripcionSeleccioanda.TabIndex = 15;
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
            // btnImprimirSeleccionada
            // 
            btnImprimirSeleccionada.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimirSeleccionada.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnImprimirSeleccionada.IconColor = Color.Black;
            btnImprimirSeleccionada.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImprimirSeleccionada.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirSeleccionada.Location = new Point(1303, 126);
            btnImprimirSeleccionada.Margin = new Padding(2);
            btnImprimirSeleccionada.Name = "btnImprimirSeleccionada";
            btnImprimirSeleccionada.Size = new Size(142, 63);
            btnImprimirSeleccionada.TabIndex = 4;
            btnImprimirSeleccionada.Text = "Imprimir seleccionada";
            btnImprimirSeleccionada.TextAlign = ContentAlignment.MiddleRight;
            btnImprimirSeleccionada.UseVisualStyleBackColor = true;
            // 
            // btnImprimirTodas
            // 
            btnImprimirTodas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimirTodas.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnImprimirTodas.IconColor = Color.Black;
            btnImprimirTodas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImprimirTodas.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirTodas.Location = new Point(1303, 66);
            btnImprimirTodas.Margin = new Padding(2);
            btnImprimirTodas.Name = "btnImprimirTodas";
            btnImprimirTodas.Size = new Size(142, 56);
            btnImprimirTodas.TabIndex = 3;
            btnImprimirTodas.Text = "Imprimir\ntodas";
            btnImprimirTodas.TextAlign = ContentAlignment.MiddleRight;
            btnImprimirTodas.UseVisualStyleBackColor = true;
            // 
            // dataGridInscripciones
            // 
            dataGridInscripciones.AllowUserToAddRows = false;
            dataGridInscripciones.AllowUserToDeleteRows = false;
            dataGridInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridInscripciones.DefaultCellStyle = dataGridViewCellStyle2;
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
            tabPageAgregarEditar.Size = new Size(1450, 571);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Ver por materias";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // InscripcionesExamenesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 665);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "InscripcionesExamenesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripciones a mesas de exámenes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            statusbar.ResumeLayout(false);
            statusbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcionSeleccioanda).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        public TabControl tabControl;
        public TabPage tabPageLista;
        public DataGridView dataGridInscripciones;
        public TabPage tabPageAgregarEditar;
        public FontAwesome.Sharp.IconButton btnImprimirTodas;
        public FontAwesome.Sharp.IconButton btnImprimirSeleccionada;
        public FontAwesome.Sharp.IconButton btnSalir;
        public FontAwesome.Sharp.IconButton BtnBuscar;
        private Label label3;
        public TextBox txtFiltro;
        private Label label4;
        public ComboBox cboTurnosExamenes;
        public ComboBox cboCarreras;
        public ComboBox cboAniosCarreras;
        public CheckBox chkFiltrarPorAñoCarrera;
        public CheckBox chkFiltrarPorCarrera;
        public DataGridView dataGridInscripcionSeleccioanda;
        public StatusStrip statusbar;
        public ToolStripStatusLabel statusBarMessage;
    }
}