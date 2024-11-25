namespace InstitutoDesktop.Views
{
    partial class HorariosView
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
            label6 = new Label();
            cboAniosCarreras = new ComboBox();
            label5 = new Label();
            cboCarreras = new ComboBox();
            label4 = new Label();
            cboPeriodosHorarios = new ComboBox();
            label1 = new Label();
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            btnSalir = new FontAwesome.Sharp.IconButton();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            txtFiltro = new TextBox();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnModificar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            dataGridHorarios = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            btnEditarHora = new FontAwesome.Sharp.IconButton();
            cboAulas = new ComboBox();
            label10 = new Label();
            btnQuitarHora = new FontAwesome.Sharp.IconButton();
            btnQuitarDocente = new FontAwesome.Sharp.IconButton();
            dataGridHoras = new DataGridView();
            btnAgregarHora = new FontAwesome.Sharp.IconButton();
            cboDias = new ComboBox();
            label9 = new Label();
            cboHoras = new ComboBox();
            label8 = new Label();
            dataGridIntegrantes = new DataGridView();
            btnAgregarDocente = new FontAwesome.Sharp.IconButton();
            cboDocentes = new ComboBox();
            label7 = new Label();
            cboMaterias = new ComboBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHorarios).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHoras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridIntegrantes).BeginInit();
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
            panel1.Controls.Add(cboPeriodosHorarios);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1209, 60);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(980, 36);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 7;
            label6.Text = "Año carrera:";
            // 
            // cboAniosCarreras
            // 
            cboAniosCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboAniosCarreras.FormattingEnabled = true;
            cboAniosCarreras.Location = new Point(1075, 30);
            cboAniosCarreras.Name = "cboAniosCarreras";
            cboAniosCarreras.Size = new Size(119, 28);
            cboAniosCarreras.TabIndex = 6;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(510, 33);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 5;
            label5.Text = "Carrera:";
            // 
            // cboCarreras
            // 
            cboCarreras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCarreras.FormattingEnabled = true;
            cboCarreras.Location = new Point(576, 30);
            cboCarreras.Name = "cboCarreras";
            cboCarreras.Size = new Size(394, 28);
            cboCarreras.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(136, 37);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 3;
            label4.Text = "Período";
            // 
            // cboPeriodosHorarios
            // 
            cboPeriodosHorarios.FormattingEnabled = true;
            cboPeriodosHorarios.Location = new Point(202, 30);
            cboPeriodosHorarios.Name = "cboPeriodosHorarios";
            cboPeriodosHorarios.Size = new Size(302, 28);
            cboPeriodosHorarios.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 6);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 37);
            label1.TabIndex = 0;
            label1.Text = "Horarios";
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
            tabControl.Size = new Size(1209, 572);
            tabControl.TabIndex = 1;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnSalir);
            tabPageLista.Controls.Add(BtnBuscar);
            tabPageLista.Controls.Add(label3);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnAgregar);
            tabPageLista.Controls.Add(dataGridHorarios);
            tabPageLista.Location = new Point(4, 29);
            tabPageLista.Margin = new Padding(2);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(2);
            tabPageLista.Size = new Size(1201, 539);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.BackColor = Color.OrangeRed;
            btnSalir.ForeColor = Color.White;
            btnSalir.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            btnSalir.IconColor = Color.White;
            btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSalir.IconSize = 44;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(1072, 228);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(123, 54);
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
            BtnBuscar.Location = new Point(1075, 18);
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
            label3.Size = new Size(55, 20);
            label3.TabIndex = 12;
            label3.Text = "Buscar:";
            // 
            // txtFiltro
            // 
            txtFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFiltro.Location = new Point(97, 16);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(731, 27);
            txtFiltro.TabIndex = 11;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.DarkGray;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(1075, 176);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 46);
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
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(1075, 126);
            btnModificar.Margin = new Padding(2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 46);
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
            btnAgregar.Location = new Point(1075, 75);
            btnAgregar.Margin = new Padding(2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 46);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridHorarios
            // 
            dataGridHorarios.AllowUserToAddRows = false;
            dataGridHorarios.AllowUserToDeleteRows = false;
            dataGridHorarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHorarios.Location = new Point(6, 63);
            dataGridHorarios.Margin = new Padding(2);
            dataGridHorarios.Name = "dataGridHorarios";
            dataGridHorarios.ReadOnly = true;
            dataGridHorarios.RowHeadersWidth = 62;
            dataGridHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHorarios.Size = new Size(1060, 468);
            dataGridHorarios.TabIndex = 0;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(btnEditarHora);
            tabPageAgregarEditar.Controls.Add(cboAulas);
            tabPageAgregarEditar.Controls.Add(label10);
            tabPageAgregarEditar.Controls.Add(btnQuitarHora);
            tabPageAgregarEditar.Controls.Add(btnQuitarDocente);
            tabPageAgregarEditar.Controls.Add(dataGridHoras);
            tabPageAgregarEditar.Controls.Add(btnAgregarHora);
            tabPageAgregarEditar.Controls.Add(cboDias);
            tabPageAgregarEditar.Controls.Add(label9);
            tabPageAgregarEditar.Controls.Add(cboHoras);
            tabPageAgregarEditar.Controls.Add(label8);
            tabPageAgregarEditar.Controls.Add(dataGridIntegrantes);
            tabPageAgregarEditar.Controls.Add(btnAgregarDocente);
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
            tabPageAgregarEditar.Size = new Size(1201, 539);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // btnEditarHora
            // 
            btnEditarHora.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditarHora.BackColor = Color.LightGray;
            btnEditarHora.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            btnEditarHora.IconColor = Color.Black;
            btnEditarHora.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditarHora.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditarHora.Location = new Point(825, 386);
            btnEditarHora.Margin = new Padding(2);
            btnEditarHora.Name = "btnEditarHora";
            btnEditarHora.Size = new Size(113, 37);
            btnEditarHora.TabIndex = 19;
            btnEditarHora.Text = "Editar";
            btnEditarHora.TextAlign = ContentAlignment.MiddleRight;
            btnEditarHora.UseVisualStyleBackColor = false;
            btnEditarHora.Click += btnEditarHora_Click;
            // 
            // cboAulas
            // 
            cboAulas.FormattingEnabled = true;
            cboAulas.Location = new Point(90, 305);
            cboAulas.Name = "cboAulas";
            cboAulas.Size = new Size(204, 28);
            cboAulas.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(46, 308);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(42, 20);
            label10.TabIndex = 17;
            label10.Text = "Aula:";
            // 
            // btnQuitarHora
            // 
            btnQuitarHora.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarHora.BackColor = Color.OrangeRed;
            btnQuitarHora.ForeColor = Color.White;
            btnQuitarHora.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnQuitarHora.IconColor = Color.White;
            btnQuitarHora.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnQuitarHora.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitarHora.Location = new Point(825, 438);
            btnQuitarHora.Margin = new Padding(2);
            btnQuitarHora.Name = "btnQuitarHora";
            btnQuitarHora.Size = new Size(113, 46);
            btnQuitarHora.TabIndex = 16;
            btnQuitarHora.Text = "Quitar";
            btnQuitarHora.TextAlign = ContentAlignment.MiddleRight;
            btnQuitarHora.UseVisualStyleBackColor = false;
            btnQuitarHora.Click += btnQuitarHora_Click;
            // 
            // btnQuitarDocente
            // 
            btnQuitarDocente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarDocente.BackColor = Color.OrangeRed;
            btnQuitarDocente.ForeColor = Color.White;
            btnQuitarDocente.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnQuitarDocente.IconColor = Color.White;
            btnQuitarDocente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnQuitarDocente.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitarDocente.Location = new Point(824, 183);
            btnQuitarDocente.Margin = new Padding(2);
            btnQuitarDocente.Name = "btnQuitarDocente";
            btnQuitarDocente.Size = new Size(114, 46);
            btnQuitarDocente.TabIndex = 15;
            btnQuitarDocente.Text = "Quitar";
            btnQuitarDocente.TextAlign = ContentAlignment.MiddleRight;
            btnQuitarDocente.UseVisualStyleBackColor = false;
            btnQuitarDocente.Click += btnQuitarDocente_Click;
            // 
            // dataGridHoras
            // 
            dataGridHoras.AllowUserToAddRows = false;
            dataGridHoras.AllowUserToDeleteRows = false;
            dataGridHoras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridHoras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHoras.Location = new Point(44, 350);
            dataGridHoras.Margin = new Padding(2);
            dataGridHoras.Name = "dataGridHoras";
            dataGridHoras.ReadOnly = true;
            dataGridHoras.RowHeadersWidth = 62;
            dataGridHoras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHoras.Size = new Size(774, 175);
            dataGridHoras.TabIndex = 14;
            // 
            // btnAgregarHora
            // 
            btnAgregarHora.BackColor = Color.DarkGray;
            btnAgregarHora.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAgregarHora.IconColor = Color.Black;
            btnAgregarHora.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarHora.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarHora.Location = new Point(697, 292);
            btnAgregarHora.Margin = new Padding(2);
            btnAgregarHora.Name = "btnAgregarHora";
            btnAgregarHora.Size = new Size(120, 46);
            btnAgregarHora.TabIndex = 13;
            btnAgregarHora.Text = "Agregar";
            btnAgregarHora.TextAlign = ContentAlignment.MiddleRight;
            btnAgregarHora.UseVisualStyleBackColor = false;
            btnAgregarHora.Click += btnAgregarHora_Click;
            // 
            // cboDias
            // 
            cboDias.FormattingEnabled = true;
            cboDias.Location = new Point(339, 305);
            cboDias.Name = "cboDias";
            cboDias.Size = new Size(144, 28);
            cboDias.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(299, 310);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(35, 20);
            label9.TabIndex = 11;
            label9.Text = "Día:";
            // 
            // cboHoras
            // 
            cboHoras.FormattingEnabled = true;
            cboHoras.Location = new Point(547, 302);
            cboHoras.Name = "cboHoras";
            cboHoras.Size = new Size(140, 28);
            cboHoras.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(497, 308);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 9;
            label8.Text = "Hora:";
            // 
            // dataGridIntegrantes
            // 
            dataGridIntegrantes.AllowUserToAddRows = false;
            dataGridIntegrantes.AllowUserToDeleteRows = false;
            dataGridIntegrantes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridIntegrantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridIntegrantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridIntegrantes.Location = new Point(46, 144);
            dataGridIntegrantes.Margin = new Padding(2);
            dataGridIntegrantes.Name = "dataGridIntegrantes";
            dataGridIntegrantes.ReadOnly = true;
            dataGridIntegrantes.RowHeadersWidth = 62;
            dataGridIntegrantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridIntegrantes.Size = new Size(771, 118);
            dataGridIntegrantes.TabIndex = 8;
            // 
            // btnAgregarDocente
            // 
            btnAgregarDocente.BackColor = Color.DarkGray;
            btnAgregarDocente.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAgregarDocente.IconColor = Color.Black;
            btnAgregarDocente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarDocente.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregarDocente.Location = new Point(521, 67);
            btnAgregarDocente.Margin = new Padding(2);
            btnAgregarDocente.Name = "btnAgregarDocente";
            btnAgregarDocente.Size = new Size(120, 46);
            btnAgregarDocente.TabIndex = 7;
            btnAgregarDocente.Text = "Agregar";
            btnAgregarDocente.TextAlign = ContentAlignment.MiddleRight;
            btnAgregarDocente.UseVisualStyleBackColor = false;
            btnAgregarDocente.Click += btnAgregarDocente_Click;
            // 
            // cboDocentes
            // 
            cboDocentes.FormattingEnabled = true;
            cboDocentes.Location = new Point(122, 77);
            cboDocentes.Name = "cboDocentes";
            cboDocentes.Size = new Size(376, 28);
            cboDocentes.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 81);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(68, 20);
            label7.TabIndex = 5;
            label7.Text = "Docente:";
            // 
            // cboMaterias
            // 
            cboMaterias.FormattingEnabled = true;
            cboMaterias.Location = new Point(122, 18);
            cboMaterias.Name = "cboMaterias";
            cboMaterias.Size = new Size(376, 28);
            cboMaterias.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(821, 78);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(122, 57);
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
            btnGuardar.Location = new Point(821, 18);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(122, 57);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 22);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 0;
            label2.Text = "Materia:";
            // 
            // HorariosView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 634);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "HorariosView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Horarios";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHorarios).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHoras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridIntegrantes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        public TabControl tabControl;
        public TabPage tabPageLista;
        public DataGridView dataGridHorarios;
        public TabPage tabPageAgregarEditar;
        private Label label2;
        public FontAwesome.Sharp.IconButton btnCancelar;
        public FontAwesome.Sharp.IconButton btnGuardar;
        public FontAwesome.Sharp.IconButton btnAgregar;
        public FontAwesome.Sharp.IconButton btnModificar;
        public FontAwesome.Sharp.IconButton btnEliminar;
        public FontAwesome.Sharp.IconButton btnSalir;
        public FontAwesome.Sharp.IconButton BtnBuscar;
        private Label label3;
        public TextBox txtFiltro;
        private Label label4;
        public ComboBox cboPeriodosHorarios;
        private Label label5;
        public ComboBox cboCarreras;
        private Label label6;
        public ComboBox cboAniosCarreras;
        public ComboBox cboDocentes;
        private Label label7;
        public ComboBox cboMaterias;
        public ComboBox cboHoras;
        private Label label8;
        public DataGridView dataGridIntegrantes;
        public FontAwesome.Sharp.IconButton btnAgregarDocente;
        public DataGridView dataGridHoras;
        public FontAwesome.Sharp.IconButton btnAgregarHora;
        public ComboBox cboDias;
        private Label label9;
        public FontAwesome.Sharp.IconButton btnQuitarHora;
        public FontAwesome.Sharp.IconButton btnQuitarDocente;
        public ComboBox cboAulas;
        private Label label10;
        public FontAwesome.Sharp.IconButton btnEditarHora;

    }
}