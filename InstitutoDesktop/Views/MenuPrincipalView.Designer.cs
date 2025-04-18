namespace InstitutoDesktop
{
    partial class MenuPrincipalView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipalView));
            menuStrip1 = new MenuStrip();
            menuPrincipal = new FontAwesome.Sharp.IconMenuItem();
            subMenuCiclosLectivos = new FontAwesome.Sharp.IconMenuItem();
            subMenuAulas = new FontAwesome.Sharp.IconMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            subMenuAlumnos = new FontAwesome.Sharp.IconMenuItem();
            subMenuDocentes = new FontAwesome.Sharp.IconMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            subMenuCarreras = new FontAwesome.Sharp.IconMenuItem();
            subMenuAñosCarreras = new FontAwesome.Sharp.IconMenuItem();
            subMenuMaterias = new FontAwesome.Sharp.IconMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            subMenuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            iconMenuDatosInstitucion = new FontAwesome.Sharp.IconMenuItem();
            menuHorarios = new FontAwesome.Sharp.IconMenuItem();
            subMenuHoras = new FontAwesome.Sharp.IconMenuItem();
            subMenuPeriodosHorarios = new FontAwesome.Sharp.IconMenuItem();
            subMenuHorarios = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            subMenuPeriodosInscripciones = new FontAwesome.Sharp.IconMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            menuMesasExamenes = new FontAwesome.Sharp.IconMenuItem();
            subMenuTurnosExámenes = new FontAwesome.Sharp.IconMenuItem();
            subMenuConformacionMesasExamenes = new FontAwesome.Sharp.IconMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            subMenuInscripciones = new FontAwesome.Sharp.IconMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            menuInformes = new FontAwesome.Sharp.IconMenuItem();
            subMenuInformeDocentes = new FontAwesome.Sharp.IconMenuItem();
            menuSalir = new FontAwesome.Sharp.IconMenuItem();
            subMenuSalirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            toolStrip1 = new ToolStrip();
            ToolButtonHorarios = new FontAwesome.Sharp.IconToolStripButton();
            ToolButtonMesasExamenes = new FontAwesome.Sharp.IconToolStripButton();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuPrincipal, menuHorarios, iconMenuItem2, menuMesasExamenes, menuInformes, menuSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 2, 0, 2);
            menuStrip1.Size = new Size(1364, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.Visible = false;
            // 
            // menuPrincipal
            // 
            menuPrincipal.DropDownItems.AddRange(new ToolStripItem[] { subMenuCiclosLectivos, subMenuAulas, toolStripSeparator1, subMenuAlumnos, subMenuDocentes, toolStripSeparator2, subMenuCarreras, subMenuAñosCarreras, subMenuMaterias, toolStripSeparator4, subMenuUsuarios, iconMenuDatosInstitucion });
            menuPrincipal.IconChar = FontAwesome.Sharp.IconChar.House;
            menuPrincipal.IconColor = Color.Black;
            menuPrincipal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuPrincipal.IconSize = 40;
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(118, 36);
            menuPrincipal.Text = "Principal";
            // 
            // subMenuCiclosLectivos
            // 
            subMenuCiclosLectivos.IconChar = FontAwesome.Sharp.IconChar.Hourglass2;
            subMenuCiclosLectivos.IconColor = Color.Black;
            subMenuCiclosLectivos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuCiclosLectivos.Name = "subMenuCiclosLectivos";
            subMenuCiclosLectivos.Size = new Size(291, 34);
            subMenuCiclosLectivos.Text = "Ciclos Lectivos";
            subMenuCiclosLectivos.Click += subMenuCiclosLectivos_Click;
            // 
            // subMenuAulas
            // 
            subMenuAulas.IconChar = FontAwesome.Sharp.IconChar.ShopLock;
            subMenuAulas.IconColor = Color.Black;
            subMenuAulas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuAulas.Name = "subMenuAulas";
            subMenuAulas.Size = new Size(291, 34);
            subMenuAulas.Text = "Aulas";
            subMenuAulas.Click += subMenuAulas_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(288, 6);
            // 
            // subMenuAlumnos
            // 
            subMenuAlumnos.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            subMenuAlumnos.IconColor = Color.Black;
            subMenuAlumnos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuAlumnos.Name = "subMenuAlumnos";
            subMenuAlumnos.Size = new Size(291, 34);
            subMenuAlumnos.Text = "Alumnos";
            subMenuAlumnos.Click += subMenuAlumnos_Click;
            // 
            // subMenuDocentes
            // 
            subMenuDocentes.IconChar = FontAwesome.Sharp.IconChar.User;
            subMenuDocentes.IconColor = Color.Pink;
            subMenuDocentes.IconFont = FontAwesome.Sharp.IconFont.Solid;
            subMenuDocentes.Name = "subMenuDocentes";
            subMenuDocentes.Size = new Size(291, 34);
            subMenuDocentes.Text = "Docentes";
            subMenuDocentes.Click += subMenuDocentes_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(288, 6);
            // 
            // subMenuCarreras
            // 
            subMenuCarreras.IconChar = FontAwesome.Sharp.IconChar.MortarBoard;
            subMenuCarreras.IconColor = Color.Black;
            subMenuCarreras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuCarreras.Name = "subMenuCarreras";
            subMenuCarreras.Size = new Size(291, 34);
            subMenuCarreras.Text = "Carreras";
            subMenuCarreras.Click += subMenuCarreras_Click;
            // 
            // subMenuAñosCarreras
            // 
            subMenuAñosCarreras.IconChar = FontAwesome.Sharp.IconChar.Table;
            subMenuAñosCarreras.IconColor = Color.Black;
            subMenuAñosCarreras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuAñosCarreras.Name = "subMenuAñosCarreras";
            subMenuAñosCarreras.Size = new Size(291, 34);
            subMenuAñosCarreras.Text = "Años de las carreras";
            subMenuAñosCarreras.Click += subMenuAñosCarreras_Click;
            // 
            // subMenuMaterias
            // 
            subMenuMaterias.IconChar = FontAwesome.Sharp.IconChar.Readme;
            subMenuMaterias.IconColor = Color.Black;
            subMenuMaterias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuMaterias.Name = "subMenuMaterias";
            subMenuMaterias.Size = new Size(291, 34);
            subMenuMaterias.Text = "Materias";
            subMenuMaterias.Click += subMenuMaterias_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(288, 6);
            // 
            // subMenuUsuarios
            // 
            subMenuUsuarios.IconChar = FontAwesome.Sharp.IconChar.PeopleArrowsLeftRight;
            subMenuUsuarios.IconColor = Color.Black;
            subMenuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuUsuarios.Name = "subMenuUsuarios";
            subMenuUsuarios.Size = new Size(291, 34);
            subMenuUsuarios.Text = "Usuarios";
            subMenuUsuarios.Click += subMenuUsuarios_Click;
            // 
            // iconMenuDatosInstitucion
            // 
            iconMenuDatosInstitucion.IconChar = FontAwesome.Sharp.IconChar.House;
            iconMenuDatosInstitucion.IconColor = Color.Black;
            iconMenuDatosInstitucion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuDatosInstitucion.Name = "iconMenuDatosInstitucion";
            iconMenuDatosInstitucion.Size = new Size(291, 34);
            iconMenuDatosInstitucion.Text = "Datos de la Institución";
            iconMenuDatosInstitucion.Click += iconMenuDatosInstitucion_Click;
            // 
            // menuHorarios
            // 
            menuHorarios.DropDownItems.AddRange(new ToolStripItem[] { subMenuHoras, subMenuPeriodosHorarios, subMenuHorarios });
            menuHorarios.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            menuHorarios.IconColor = Color.Black;
            menuHorarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuHorarios.Name = "menuHorarios";
            menuHorarios.Size = new Size(120, 36);
            menuHorarios.Text = "Horarios";
            // 
            // subMenuHoras
            // 
            subMenuHoras.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            subMenuHoras.IconColor = Color.Black;
            subMenuHoras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuHoras.Name = "subMenuHoras";
            subMenuHoras.Size = new Size(278, 34);
            subMenuHoras.Text = "Horas";
            subMenuHoras.Click += subMenuHoras_Click;
            // 
            // subMenuPeriodosHorarios
            // 
            subMenuPeriodosHorarios.IconChar = FontAwesome.Sharp.IconChar.Calendar;
            subMenuPeriodosHorarios.IconColor = Color.Black;
            subMenuPeriodosHorarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuPeriodosHorarios.Name = "subMenuPeriodosHorarios";
            subMenuPeriodosHorarios.Size = new Size(278, 34);
            subMenuPeriodosHorarios.Text = "Periodos de horarios";
            subMenuPeriodosHorarios.Click += subMenuPeriodosHorarios_Click;
            // 
            // subMenuHorarios
            // 
            subMenuHorarios.IconChar = FontAwesome.Sharp.IconChar.PersonChalkboard;
            subMenuHorarios.IconColor = Color.Black;
            subMenuHorarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuHorarios.Name = "subMenuHorarios";
            subMenuHorarios.Size = new Size(278, 34);
            subMenuHorarios.Text = "Horarios";
            subMenuHorarios.Click += subMenuHorarios_Click;
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { subMenuPeriodosInscripciones, toolStripSeparator6, iconMenuItem1 });
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(240, 36);
            iconMenuItem2.Text = "Inscripciones a materias";
            // 
            // subMenuPeriodosInscripciones
            // 
            subMenuPeriodosInscripciones.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            subMenuPeriodosInscripciones.IconColor = Color.Black;
            subMenuPeriodosInscripciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuPeriodosInscripciones.Name = "subMenuPeriodosInscripciones";
            subMenuPeriodosInscripciones.Size = new Size(428, 34);
            subMenuPeriodosInscripciones.Text = "Períodos de inscripciones a materias";
            subMenuPeriodosInscripciones.Click += subMenuPeriodosInscripciones_Click_1;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(425, 6);
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.PenClip;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(428, 34);
            iconMenuItem1.Text = "Inscripciones a materias de los alumnos";
            iconMenuItem1.Click += subMenuInscripcionesMaterias_Click;
            // 
            // menuMesasExamenes
            // 
            menuMesasExamenes.DropDownItems.AddRange(new ToolStripItem[] { subMenuTurnosExámenes, subMenuConformacionMesasExamenes, toolStripSeparator3, subMenuInscripciones, toolStripSeparator5 });
            menuMesasExamenes.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            menuMesasExamenes.IconColor = Color.Black;
            menuMesasExamenes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuMesasExamenes.Name = "menuMesasExamenes";
            menuMesasExamenes.Size = new Size(210, 36);
            menuMesasExamenes.Text = "Mesas de exámenes";
            // 
            // subMenuTurnosExámenes
            // 
            subMenuTurnosExámenes.IconChar = FontAwesome.Sharp.IconChar.CalendarDays;
            subMenuTurnosExámenes.IconColor = Color.Black;
            subMenuTurnosExámenes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuTurnosExámenes.Name = "subMenuTurnosExámenes";
            subMenuTurnosExámenes.Size = new Size(491, 34);
            subMenuTurnosExámenes.Text = "Turnos de exámenes";
            subMenuTurnosExámenes.Click += subMenuTurnosExámenes_Click;
            // 
            // subMenuConformacionMesasExamenes
            // 
            subMenuConformacionMesasExamenes.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            subMenuConformacionMesasExamenes.IconColor = Color.Black;
            subMenuConformacionMesasExamenes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuConformacionMesasExamenes.Name = "subMenuConformacionMesasExamenes";
            subMenuConformacionMesasExamenes.Size = new Size(491, 34);
            subMenuConformacionMesasExamenes.Text = "Conformación de Mesas de exámenes";
            subMenuConformacionMesasExamenes.Click += subMenuConformacionMesasExamenes_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(488, 6);
            // 
            // subMenuInscripciones
            // 
            subMenuInscripciones.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            subMenuInscripciones.IconColor = Color.Black;
            subMenuInscripciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuInscripciones.Name = "subMenuInscripciones";
            subMenuInscripciones.Size = new Size(491, 34);
            subMenuInscripciones.Text = "Inscripciones a mesas de exámenes de alumnos";
            subMenuInscripciones.Click += subMenuInscripciones_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(488, 6);
            // 
            // menuInformes
            // 
            menuInformes.DropDownItems.AddRange(new ToolStripItem[] { subMenuInformeDocentes });
            menuInformes.IconChar = FontAwesome.Sharp.IconChar.Print;
            menuInformes.IconColor = Color.Black;
            menuInformes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuInformes.Name = "menuInformes";
            menuInformes.Size = new Size(123, 36);
            menuInformes.Text = "Informes";
            // 
            // subMenuInformeDocentes
            // 
            subMenuInformeDocentes.IconChar = FontAwesome.Sharp.IconChar.User;
            subMenuInformeDocentes.IconColor = Color.Pink;
            subMenuInformeDocentes.IconFont = FontAwesome.Sharp.IconFont.Solid;
            subMenuInformeDocentes.Name = "subMenuInformeDocentes";
            subMenuInformeDocentes.Size = new Size(188, 34);
            subMenuInformeDocentes.Text = "Docentes";
            subMenuInformeDocentes.Click += mnuDocentes_Click;
            // 
            // menuSalir
            // 
            menuSalir.DropDownItems.AddRange(new ToolStripItem[] { subMenuSalirDelSistema });
            menuSalir.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            menuSalir.IconColor = Color.Black;
            menuSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(85, 36);
            menuSalir.Text = "Salir";
            // 
            // subMenuSalirDelSistema
            // 
            subMenuSalirDelSistema.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            subMenuSalirDelSistema.IconColor = Color.Black;
            subMenuSalirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuSalirDelSistema.Name = "subMenuSalirDelSistema";
            subMenuSalirDelSistema.Size = new Size(241, 34);
            subMenuSalirDelSistema.Text = "Salir del sistema";
            subMenuSalirDelSistema.Click += iconMenuItem4_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { ToolButtonHorarios, ToolButtonMesasExamenes });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1364, 84);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.Visible = false;
            // 
            // ToolButtonHorarios
            // 
            ToolButtonHorarios.IconChar = FontAwesome.Sharp.IconChar.PersonChalkboard;
            ToolButtonHorarios.IconColor = Color.Black;
            ToolButtonHorarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ToolButtonHorarios.IconSize = 40;
            ToolButtonHorarios.ImageScaling = ToolStripItemImageScaling.None;
            ToolButtonHorarios.ImageTransparentColor = Color.Magenta;
            ToolButtonHorarios.Name = "ToolButtonHorarios";
            ToolButtonHorarios.Size = new Size(84, 79);
            ToolButtonHorarios.Text = "Horarios";
            ToolButtonHorarios.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // ToolButtonMesasExamenes
            // 
            ToolButtonMesasExamenes.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            ToolButtonMesasExamenes.IconColor = Color.Black;
            ToolButtonMesasExamenes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ToolButtonMesasExamenes.IconSize = 40;
            ToolButtonMesasExamenes.ImageScaling = ToolStripItemImageScaling.None;
            ToolButtonMesasExamenes.ImageTransparentColor = Color.Magenta;
            ToolButtonMesasExamenes.Name = "ToolButtonMesasExamenes";
            ToolButtonMesasExamenes.Size = new Size(149, 79);
            ToolButtonMesasExamenes.Text = "Mesas Exámenes";
            ToolButtonMesasExamenes.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1364, 828);
            Controls.Add(menuStrip1);
            Controls.Add(toolStrip1);
            DoubleBuffered = true;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "MenuPrincipalView";
            Text = "Instituto Superior de Profesorado Nº20";
            Activated += MenuPrincipalView_Activated;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem menuPrincipal;
        private FontAwesome.Sharp.IconMenuItem subMenuConformacionMesasExamenes;
        private FontAwesome.Sharp.IconMenuItem menuSalir;
        private FontAwesome.Sharp.IconMenuItem subMenuSalirDelSistema;


        private FontAwesome.Sharp.IconMenuItem menuInformes;
        private FontAwesome.Sharp.IconMenuItem subMenuInformeDocentes;
        private FontAwesome.Sharp.IconMenuItem menuHorarios;
        private FontAwesome.Sharp.IconMenuItem subMenuHoras;
        private FontAwesome.Sharp.IconMenuItem subMenuHorarios;
        private FontAwesome.Sharp.IconMenuItem menuMesasExamenes;
        private FontAwesome.Sharp.IconMenuItem subMenuPeriodosHorarios;
        private FontAwesome.Sharp.IconMenuItem subMenuCiclosLectivos;
        private FontAwesome.Sharp.IconMenuItem subMenuAlumnos;
        private FontAwesome.Sharp.IconMenuItem subMenuAulas;
        private ToolStripSeparator toolStripSeparator1;
        private FontAwesome.Sharp.IconMenuItem subMenuDocentes;
        private ToolStripSeparator toolStripSeparator2;
        private FontAwesome.Sharp.IconMenuItem subMenuMaterias;
        private FontAwesome.Sharp.IconMenuItem subMenuCarreras;
        private FontAwesome.Sharp.IconMenuItem subMenuAñosCarreras;
        private FontAwesome.Sharp.IconMenuItem subMenuTurnosExámenes;
        private ToolStripSeparator toolStripSeparator3;
        private FontAwesome.Sharp.IconMenuItem subMenuInscripciones;
        private ToolStripSeparator toolStripSeparator4;
        private FontAwesome.Sharp.IconMenuItem subMenuUsuarios;
        private ToolStrip toolStrip1;
        private FontAwesome.Sharp.IconToolStripButton ToolButtonHorarios;
        private FontAwesome.Sharp.IconToolStripButton ToolButtonMesasExamenes;
        private ToolStripSeparator toolStripSeparator5;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem subMenuPeriodosInscripciones;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private ToolStripSeparator toolStripSeparator6;
        private FontAwesome.Sharp.IconMenuItem iconMenuDatosInstitucion;
    }
}
