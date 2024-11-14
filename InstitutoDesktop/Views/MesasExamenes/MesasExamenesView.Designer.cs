namespace InstitutoDesktop.Views
{
    partial class MesasExamenesView
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label6 = new Label();
            cboAniosCarreras = new ComboBox();
            label5 = new Label();
            cboCarreras = new ComboBox();
            label4 = new Label();
            cboTurnosExamenes = new ComboBox();
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
            dataGridMesasExamenes = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            txtHorario = new TextBox();
            label11 = new Label();
            dateTime2doLlamado = new DateTimePicker();
            lbl2doLlamado = new Label();
            dateTime1erLlamado = new DateTimePicker();
            lblPrimerLlamado = new Label();
            BtnEditar = new FontAwesome.Sharp.IconButton();
            btnQuitarDocente = new FontAwesome.Sharp.IconButton();
            cboTipoIntegrante = new ComboBox();
            label9 = new Label();
            dataGridDetallesMesa = new DataGridView();
            btnAgregarDetalleMesa = new FontAwesome.Sharp.IconButton();
            cboDocentes = new ComboBox();
            label7 = new Label();
            cboMaterias = new ComboBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMesasExamenes).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDetallesMesa).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cboAniosCarreras);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cboCarreras);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cboTurnosExamenes);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1250, 60);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(1087, 6);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 7;
            label6.Text = "Año carrera:";
            // 
            // cboAniosCarreras
            // 
            cboAniosCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboAniosCarreras.FormattingEnabled = true;
            cboAniosCarreras.Location = new Point(1046, 30);
            cboAniosCarreras.Name = "cboAniosCarreras";
            cboAniosCarreras.Size = new Size(195, 28);
            cboAniosCarreras.TabIndex = 6;
            cboAniosCarreras.SelectedIndexChanged += cboAniosCarreras_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(591, 6);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 5;
            label5.Text = "Carrera:";
            // 
            // cboCarreras
            // 
            cboCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCarreras.FormattingEnabled = true;
            cboCarreras.Location = new Point(591, 30);
            cboCarreras.Name = "cboCarreras";
            cboCarreras.Size = new Size(449, 28);
            cboCarreras.TabIndex = 4;
            cboCarreras.SelectedIndexChanged += cboCarreras_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(278, 7);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 3;
            label4.Text = "Turno de examen";
            // 
            // cboTurnosExamenes
            // 
            cboTurnosExamenes.FormattingEnabled = true;
            cboTurnosExamenes.Location = new Point(278, 30);
            cboTurnosExamenes.Name = "cboTurnosExamenes";
            cboTurnosExamenes.Size = new Size(307, 28);
            cboTurnosExamenes.TabIndex = 2;
            cboTurnosExamenes.SelectedIndexChanged += cboTurnosExamenes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 6);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(264, 37);
            label1.TabIndex = 0;
            label1.Text = "Mesas de exámenes";
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
            tabControl.Size = new Size(1250, 546);
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
            tabPageLista.Controls.Add(dataGridMesasExamenes);
            tabPageLista.Location = new Point(4, 29);
            tabPageLista.Margin = new Padding(2);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(2);
            tabPageLista.Size = new Size(1242, 513);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // iconButtonSalir
            // 
            iconButtonSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonSalir.BackColor = Color.OrangeRed;
            iconButtonSalir.ForeColor = Color.White;
            iconButtonSalir.IconChar = FontAwesome.Sharp.IconChar.Close;
            iconButtonSalir.IconColor = Color.White;
            iconButtonSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSalir.IconSize = 44;
            iconButtonSalir.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSalir.Location = new Point(1114, 228);
            iconButtonSalir.Margin = new Padding(3, 4, 3, 4);
            iconButtonSalir.Name = "iconButtonSalir";
            iconButtonSalir.Size = new Size(123, 54);
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
            BtnBuscar.Location = new Point(1117, 18);
            BtnBuscar.Margin = new Padding(3, 4, 3, 4);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(123, 51);
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
            label3.Size = new Size(121, 20);
            label3.TabIndex = 12;
            label3.Text = "Buscar localidad:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(179, 18);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(483, 27);
            txtFiltro.TabIndex = 11;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(1117, 176);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 46);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextAlign = ContentAlignment.MiddleRight;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(1117, 126);
            btnModificar.Margin = new Padding(2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 46);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAgregar.IconColor = Color.Black;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(1117, 75);
            btnAgregar.Margin = new Padding(2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 46);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridMesasExamenes
            // 
            dataGridMesasExamenes.AllowUserToAddRows = false;
            dataGridMesasExamenes.AllowUserToDeleteRows = false;
            dataGridMesasExamenes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridMesasExamenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMesasExamenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridMesasExamenes.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridMesasExamenes.Location = new Point(6, 63);
            dataGridMesasExamenes.Margin = new Padding(2);
            dataGridMesasExamenes.Name = "dataGridMesasExamenes";
            dataGridMesasExamenes.ReadOnly = true;
            dataGridMesasExamenes.RowHeadersWidth = 62;
            dataGridMesasExamenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridMesasExamenes.Size = new Size(1102, 442);
            dataGridMesasExamenes.TabIndex = 0;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(txtHorario);
            tabPageAgregarEditar.Controls.Add(label11);
            tabPageAgregarEditar.Controls.Add(dateTime2doLlamado);
            tabPageAgregarEditar.Controls.Add(lbl2doLlamado);
            tabPageAgregarEditar.Controls.Add(dateTime1erLlamado);
            tabPageAgregarEditar.Controls.Add(lblPrimerLlamado);
            tabPageAgregarEditar.Controls.Add(BtnEditar);
            tabPageAgregarEditar.Controls.Add(btnQuitarDocente);
            tabPageAgregarEditar.Controls.Add(cboTipoIntegrante);
            tabPageAgregarEditar.Controls.Add(label9);
            tabPageAgregarEditar.Controls.Add(dataGridDetallesMesa);
            tabPageAgregarEditar.Controls.Add(btnAgregarDetalleMesa);
            tabPageAgregarEditar.Controls.Add(cboDocentes);
            tabPageAgregarEditar.Controls.Add(label7);
            tabPageAgregarEditar.Controls.Add(cboMaterias);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Location = new Point(4, 29);
            tabPageAgregarEditar.Margin = new Padding(2);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(2);
            tabPageAgregarEditar.Size = new Size(1242, 513);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // txtHorario
            // 
            txtHorario.Location = new Point(627, 90);
            txtHorario.Name = "txtHorario";
            txtHorario.Size = new Size(195, 27);
            txtHorario.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(559, 97);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(63, 20);
            label11.TabIndex = 24;
            label11.Text = "Horario:";
            // 
            // dateTime2doLlamado
            // 
            dateTime2doLlamado.Format = DateTimePickerFormat.Short;
            dateTime2doLlamado.Location = new Point(435, 92);
            dateTime2doLlamado.Name = "dateTime2doLlamado";
            dateTime2doLlamado.Size = new Size(108, 27);
            dateTime2doLlamado.TabIndex = 23;
            // 
            // lbl2doLlamado
            // 
            lbl2doLlamado.AutoSize = true;
            lbl2doLlamado.Location = new Point(300, 97);
            lbl2doLlamado.Margin = new Padding(2, 0, 2, 0);
            lbl2doLlamado.Name = "lbl2doLlamado";
            lbl2doLlamado.Size = new Size(130, 20);
            lbl2doLlamado.TabIndex = 22;
            lbl2doLlamado.Text = "Segundo llamado:";
            // 
            // dateTime1erLlamado
            // 
            dateTime1erLlamado.Format = DateTimePickerFormat.Short;
            dateTime1erLlamado.Location = new Point(168, 94);
            dateTime1erLlamado.Name = "dateTime1erLlamado";
            dateTime1erLlamado.Size = new Size(108, 27);
            dateTime1erLlamado.TabIndex = 21;
            dateTime1erLlamado.ValueChanged += dateTime1erLlamado_ValueChanged;
            // 
            // lblPrimerLlamado
            // 
            lblPrimerLlamado.AutoSize = true;
            lblPrimerLlamado.Location = new Point(49, 99);
            lblPrimerLlamado.Margin = new Padding(2, 0, 2, 0);
            lblPrimerLlamado.Name = "lblPrimerLlamado";
            lblPrimerLlamado.Size = new Size(114, 20);
            lblPrimerLlamado.TabIndex = 20;
            lblPrimerLlamado.Text = "Primer llamado:";
            // 
            // BtnEditar
            // 
            BtnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnEditar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            BtnEditar.IconColor = Color.Black;
            BtnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEditar.Location = new Point(1055, 290);
            BtnEditar.Margin = new Padding(2);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(113, 46);
            BtnEditar.TabIndex = 19;
            BtnEditar.Text = "Editar";
            BtnEditar.TextAlign = ContentAlignment.MiddleRight;
            BtnEditar.UseVisualStyleBackColor = true;
            BtnEditar.Click += iconButton1_Click;
            // 
            // btnQuitarDocente
            // 
            btnQuitarDocente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarDocente.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnQuitarDocente.IconColor = Color.Black;
            btnQuitarDocente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnQuitarDocente.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitarDocente.Location = new Point(1055, 353);
            btnQuitarDocente.Margin = new Padding(2);
            btnQuitarDocente.Name = "btnQuitarDocente";
            btnQuitarDocente.Size = new Size(114, 46);
            btnQuitarDocente.TabIndex = 15;
            btnQuitarDocente.Text = "Quitar";
            btnQuitarDocente.TextAlign = ContentAlignment.MiddleRight;
            btnQuitarDocente.UseVisualStyleBackColor = true;
            btnQuitarDocente.Click += btnQuitarDocente_Click;
            // 
            // cboTipoIntegrante
            // 
            cboTipoIntegrante.FormattingEnabled = true;
            cboTipoIntegrante.Location = new Point(453, 190);
            cboTipoIntegrante.Name = "cboTipoIntegrante";
            cboTipoIntegrante.Size = new Size(151, 28);
            cboTipoIntegrante.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(453, 163);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(156, 20);
            label9.TabIndex = 11;
            label9.Text = "Integra la mesa como:";
            // 
            // dataGridDetallesMesa
            // 
            dataGridDetallesMesa.AllowUserToAddRows = false;
            dataGridDetallesMesa.AllowUserToDeleteRows = false;
            dataGridDetallesMesa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridDetallesMesa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridDetallesMesa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDetallesMesa.Location = new Point(44, 236);
            dataGridDetallesMesa.Margin = new Padding(2);
            dataGridDetallesMesa.Name = "dataGridDetallesMesa";
            dataGridDetallesMesa.ReadOnly = true;
            dataGridDetallesMesa.RowHeadersWidth = 62;
            dataGridDetallesMesa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridDetallesMesa.Size = new Size(995, 241);
            dataGridDetallesMesa.TabIndex = 8;
            // 
            // btnAgregarDetalleMesa
            // 
            btnAgregarDetalleMesa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarDetalleMesa.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAgregarDetalleMesa.IconColor = Color.Black;
            btnAgregarDetalleMesa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarDetalleMesa.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarDetalleMesa.Location = new Point(919, 173);
            btnAgregarDetalleMesa.Margin = new Padding(2);
            btnAgregarDetalleMesa.Name = "btnAgregarDetalleMesa";
            btnAgregarDetalleMesa.Size = new Size(120, 46);
            btnAgregarDetalleMesa.TabIndex = 7;
            btnAgregarDetalleMesa.Text = "Agregar";
            btnAgregarDetalleMesa.TextAlign = ContentAlignment.MiddleRight;
            btnAgregarDetalleMesa.UseVisualStyleBackColor = true;
            btnAgregarDetalleMesa.Click += btnAgregarDetalleMesaExamen_Click;
            // 
            // cboDocentes
            // 
            cboDocentes.FormattingEnabled = true;
            cboDocentes.Location = new Point(46, 190);
            cboDocentes.Name = "cboDocentes";
            cboDocentes.Size = new Size(387, 28);
            cboDocentes.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 163);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(68, 20);
            label7.TabIndex = 5;
            label7.Text = "Docente:";
            // 
            // cboMaterias
            // 
            cboMaterias.FormattingEnabled = true;
            cboMaterias.Location = new Point(124, 37);
            cboMaterias.Name = "cboMaterias";
            cboMaterias.Size = new Size(438, 28);
            cboMaterias.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(884, 81);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(122, 57);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(884, 21);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(122, 57);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 42);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 0;
            label2.Text = "Materia:";
            // 
            // MesasExamenesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1253, 607);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "MesasExamenesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Horarios";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMesasExamenes).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDetallesMesa).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TabControl tabControl;
        private TabPage tabPageLista;
        private DataGridView dataGridMesasExamenes;
        private TabPage tabPageAgregarEditar;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton iconButtonSalir;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private Label label3;
        private TextBox txtFiltro;
        private Label label4;
        private ComboBox cboTurnosExamenes;
        private Label label5;
        private ComboBox cboCarreras;
        private Label label6;
        private ComboBox cboAniosCarreras;
        private ComboBox cboDocentes;
        private Label label7;
        private ComboBox cboMaterias;
        private DataGridView dataGridDetallesMesa;
        private FontAwesome.Sharp.IconButton btnAgregarDetalleMesa;
        private Label label9;
        private FontAwesome.Sharp.IconButton btnQuitarDocente;
        private FontAwesome.Sharp.IconButton BtnEditar;
        private ComboBox cboTipoIntegrante;
        private Label lblPrimerLlamado;
        private TextBox txtHorario;
        private Label label11;
        private DateTimePicker dateTime2doLlamado;
        private Label lbl2doLlamado;
        private DateTimePicker dateTime1erLlamado;
    }
}