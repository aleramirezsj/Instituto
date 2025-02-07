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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            chkFiltrarPorAñoCarrera = new CheckBox();
            chkFiltrarPorCarrera = new CheckBox();
            cboAniosCarreras = new ComboBox();
            cboCarreras = new ComboBox();
            label4 = new Label();
            cboTurnosExamenes = new ComboBox();
            label1 = new Label();
            tabControl = new TabControl();
            tabPageVerPorAlumnos = new TabPage();
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
            tabPageVerPorMaterias = new TabPage();
            dataGridAlumnos = new DataGridView();
            btnBuscarMateria = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            textBox1 = new TextBox();
            btnImprimirMateriaSeleccionada = new FontAwesome.Sharp.IconButton();
            btnImprimirTodasMaterias = new FontAwesome.Sharp.IconButton();
            dataGridMaterias = new DataGridView();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageVerPorAlumnos.SuspendLayout();
            statusbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcionSeleccioanda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripciones).BeginInit();
            tabPageVerPorMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAlumnos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridMaterias).BeginInit();
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
            panel1.Size = new Size(1435, 60);
            panel1.TabIndex = 0;
            // 
            // chkFiltrarPorAñoCarrera
            // 
            chkFiltrarPorAñoCarrera.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkFiltrarPorAñoCarrera.AutoSize = true;
            chkFiltrarPorAñoCarrera.Enabled = false;
            chkFiltrarPorAñoCarrera.Location = new Point(1201, 5);
            chkFiltrarPorAñoCarrera.Name = "chkFiltrarPorAñoCarrera";
            chkFiltrarPorAñoCarrera.Size = new Size(175, 24);
            chkFiltrarPorAñoCarrera.TabIndex = 9;
            chkFiltrarPorAñoCarrera.Text = "Filtrar por año carrera";
            chkFiltrarPorAñoCarrera.UseVisualStyleBackColor = true;
            // 
            // chkFiltrarPorCarrera
            // 
            chkFiltrarPorCarrera.AutoSize = true;
            chkFiltrarPorCarrera.Location = new Point(777, 6);
            chkFiltrarPorCarrera.Name = "chkFiltrarPorCarrera";
            chkFiltrarPorCarrera.Size = new Size(146, 24);
            chkFiltrarPorCarrera.TabIndex = 8;
            chkFiltrarPorCarrera.Text = "Filtrar por carrera";
            chkFiltrarPorCarrera.UseVisualStyleBackColor = true;
            // 
            // cboAniosCarreras
            // 
            cboAniosCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboAniosCarreras.Enabled = false;
            cboAniosCarreras.FormattingEnabled = true;
            cboAniosCarreras.Location = new Point(1201, 30);
            cboAniosCarreras.Name = "cboAniosCarreras";
            cboAniosCarreras.Size = new Size(195, 28);
            cboAniosCarreras.TabIndex = 6;
            // 
            // cboCarreras
            // 
            cboCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCarreras.Enabled = false;
            cboCarreras.FormattingEnabled = true;
            cboCarreras.Location = new Point(777, 30);
            cboCarreras.Name = "cboCarreras";
            cboCarreras.Size = new Size(418, 28);
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
            cboTurnosExamenes.Size = new Size(279, 28);
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
            tabControl.Controls.Add(tabPageVerPorAlumnos);
            tabControl.Controls.Add(tabPageVerPorMaterias);
            tabControl.Location = new Point(1, 65);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1435, 604);
            tabControl.TabIndex = 1;
            // 
            // tabPageVerPorAlumnos
            // 
            tabPageVerPorAlumnos.Controls.Add(statusbar);
            tabPageVerPorAlumnos.Controls.Add(dataGridInscripcionSeleccioanda);
            tabPageVerPorAlumnos.Controls.Add(btnSalir);
            tabPageVerPorAlumnos.Controls.Add(BtnBuscar);
            tabPageVerPorAlumnos.Controls.Add(label3);
            tabPageVerPorAlumnos.Controls.Add(txtFiltro);
            tabPageVerPorAlumnos.Controls.Add(btnImprimirSeleccionada);
            tabPageVerPorAlumnos.Controls.Add(btnImprimirTodas);
            tabPageVerPorAlumnos.Controls.Add(dataGridInscripciones);
            tabPageVerPorAlumnos.Location = new Point(4, 29);
            tabPageVerPorAlumnos.Margin = new Padding(2);
            tabPageVerPorAlumnos.Name = "tabPageVerPorAlumnos";
            tabPageVerPorAlumnos.Padding = new Padding(2);
            tabPageVerPorAlumnos.Size = new Size(1427, 571);
            tabPageVerPorAlumnos.TabIndex = 0;
            tabPageVerPorAlumnos.Text = "Ver por alumnos";
            tabPageVerPorAlumnos.UseVisualStyleBackColor = true;
            // 
            // statusbar
            // 
            statusbar.ImageScalingSize = new Size(20, 20);
            statusbar.Items.AddRange(new ToolStripItem[] { statusBarMessage });
            statusbar.Location = new Point(2, 547);
            statusbar.Name = "statusbar";
            statusbar.Size = new Size(1423, 22);
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
            dataGridInscripcionSeleccioanda.Size = new Size(1170, 168);
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
            btnSalir.Location = new Point(1181, 489);
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
            BtnBuscar.Location = new Point(1197, 18);
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
            btnImprimirSeleccionada.Location = new Point(1197, 135);
            btnImprimirSeleccionada.Margin = new Padding(2);
            btnImprimirSeleccionada.Name = "btnImprimirSeleccionada";
            btnImprimirSeleccionada.Size = new Size(142, 63);
            btnImprimirSeleccionada.TabIndex = 4;
            btnImprimirSeleccionada.Text = "Imprimir seleccionada";
            btnImprimirSeleccionada.TextAlign = ContentAlignment.MiddleRight;
            btnImprimirSeleccionada.UseVisualStyleBackColor = true;
            btnImprimirSeleccionada.Click += btnImprimirSeleccionada_Click_1;
            // 
            // btnImprimirTodas
            // 
            btnImprimirTodas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimirTodas.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnImprimirTodas.IconColor = Color.Black;
            btnImprimirTodas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImprimirTodas.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirTodas.Location = new Point(1197, 75);
            btnImprimirTodas.Margin = new Padding(2);
            btnImprimirTodas.Name = "btnImprimirTodas";
            btnImprimirTodas.Size = new Size(142, 56);
            btnImprimirTodas.TabIndex = 3;
            btnImprimirTodas.Text = "Imprimir\ntodas";
            btnImprimirTodas.TextAlign = ContentAlignment.MiddleRight;
            btnImprimirTodas.UseVisualStyleBackColor = true;
            btnImprimirTodas.Click += btnImprimirTodas_Click;
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
            dataGridInscripciones.Size = new Size(1185, 312);
            dataGridInscripciones.TabIndex = 0;
            // 
            // tabPageVerPorMaterias
            // 
            tabPageVerPorMaterias.Controls.Add(dataGridAlumnos);
            tabPageVerPorMaterias.Controls.Add(btnBuscarMateria);
            tabPageVerPorMaterias.Controls.Add(label2);
            tabPageVerPorMaterias.Controls.Add(textBox1);
            tabPageVerPorMaterias.Controls.Add(btnImprimirMateriaSeleccionada);
            tabPageVerPorMaterias.Controls.Add(btnImprimirTodasMaterias);
            tabPageVerPorMaterias.Controls.Add(dataGridMaterias);
            tabPageVerPorMaterias.Location = new Point(4, 29);
            tabPageVerPorMaterias.Margin = new Padding(2);
            tabPageVerPorMaterias.Name = "tabPageVerPorMaterias";
            tabPageVerPorMaterias.Padding = new Padding(2);
            tabPageVerPorMaterias.Size = new Size(1427, 571);
            tabPageVerPorMaterias.TabIndex = 1;
            tabPageVerPorMaterias.Text = "Ver por materias";
            tabPageVerPorMaterias.UseVisualStyleBackColor = true;
            // 
            // dataGridAlumnos
            // 
            dataGridAlumnos.AllowUserToAddRows = false;
            dataGridAlumnos.AllowUserToDeleteRows = false;
            dataGridAlumnos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridAlumnos.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridAlumnos.Location = new Point(4, 392);
            dataGridAlumnos.Margin = new Padding(2);
            dataGridAlumnos.Name = "dataGridAlumnos";
            dataGridAlumnos.ReadOnly = true;
            dataGridAlumnos.RowHeadersWidth = 62;
            dataGridAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAlumnos.Size = new Size(1293, 168);
            dataGridAlumnos.TabIndex = 22;
            // 
            // btnBuscarMateria
            // 
            btnBuscarMateria.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarMateria.BackColor = Color.OrangeRed;
            btnBuscarMateria.ForeColor = Color.White;
            btnBuscarMateria.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscarMateria.IconColor = Color.White;
            btnBuscarMateria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscarMateria.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscarMateria.Location = new Point(1197, 20);
            btnBuscarMateria.Margin = new Padding(3, 4, 3, 4);
            btnBuscarMateria.Name = "btnBuscarMateria";
            btnBuscarMateria.Size = new Size(145, 51);
            btnBuscarMateria.TabIndex = 21;
            btnBuscarMateria.Text = "&Buscar";
            btnBuscarMateria.TextAlign = ContentAlignment.MiddleRight;
            btnBuscarMateria.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 23);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 20;
            label2.Text = "Buscar materia:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(177, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(483, 27);
            textBox1.TabIndex = 19;
            // 
            // btnImprimirMateriaSeleccionada
            // 
            btnImprimirMateriaSeleccionada.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimirMateriaSeleccionada.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnImprimirMateriaSeleccionada.IconColor = Color.Black;
            btnImprimirMateriaSeleccionada.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImprimirMateriaSeleccionada.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirMateriaSeleccionada.Location = new Point(1197, 137);
            btnImprimirMateriaSeleccionada.Margin = new Padding(2);
            btnImprimirMateriaSeleccionada.Name = "btnImprimirMateriaSeleccionada";
            btnImprimirMateriaSeleccionada.Size = new Size(142, 63);
            btnImprimirMateriaSeleccionada.TabIndex = 18;
            btnImprimirMateriaSeleccionada.Text = "Imprimir seleccionada";
            btnImprimirMateriaSeleccionada.TextAlign = ContentAlignment.MiddleRight;
            btnImprimirMateriaSeleccionada.UseVisualStyleBackColor = true;
            btnImprimirMateriaSeleccionada.Click += btnImprimirMateriaSeleccionada_Click;
            // 
            // btnImprimirTodasMaterias
            // 
            btnImprimirTodasMaterias.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimirTodasMaterias.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnImprimirTodasMaterias.IconColor = Color.Black;
            btnImprimirTodasMaterias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImprimirTodasMaterias.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimirTodasMaterias.Location = new Point(1197, 77);
            btnImprimirTodasMaterias.Margin = new Padding(2);
            btnImprimirTodasMaterias.Name = "btnImprimirTodasMaterias";
            btnImprimirTodasMaterias.Size = new Size(142, 56);
            btnImprimirTodasMaterias.TabIndex = 17;
            btnImprimirTodasMaterias.Text = "Imprimir\ntodas";
            btnImprimirTodasMaterias.TextAlign = ContentAlignment.MiddleRight;
            btnImprimirTodasMaterias.UseVisualStyleBackColor = true;
            btnImprimirTodasMaterias.Click += btnImprimirTodasMaterias_Click;
            // 
            // dataGridMaterias
            // 
            dataGridMaterias.AllowUserToAddRows = false;
            dataGridMaterias.AllowUserToDeleteRows = false;
            dataGridMaterias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridMaterias.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridMaterias.Location = new Point(4, 65);
            dataGridMaterias.Margin = new Padding(2);
            dataGridMaterias.Name = "dataGridMaterias";
            dataGridMaterias.ReadOnly = true;
            dataGridMaterias.RowHeadersWidth = 62;
            dataGridMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridMaterias.Size = new Size(1187, 312);
            dataGridMaterias.TabIndex = 16;
            // 
            // InscripcionesExamenesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 665);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "InscripcionesExamenesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripciones a mesas de exámenes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageVerPorAlumnos.ResumeLayout(false);
            tabPageVerPorAlumnos.PerformLayout();
            statusbar.ResumeLayout(false);
            statusbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcionSeleccioanda).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridInscripciones).EndInit();
            tabPageVerPorMaterias.ResumeLayout(false);
            tabPageVerPorMaterias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAlumnos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridMaterias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        public TabControl tabControl;
        public TabPage tabPageVerPorAlumnos;
        public DataGridView dataGridInscripciones;
        public TabPage tabPageVerPorMaterias;
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
        public DataGridView dataGridAlumnos;
        public FontAwesome.Sharp.IconButton btnBuscarMateria;
        private Label label2;
        public TextBox textBox1;
        public FontAwesome.Sharp.IconButton btnImprimirMateriaSeleccionada;
        public FontAwesome.Sharp.IconButton btnImprimirTodasMaterias;
        public DataGridView dataGridMaterias;
    }
}