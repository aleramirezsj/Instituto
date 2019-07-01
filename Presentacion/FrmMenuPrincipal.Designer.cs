namespace Presentacion
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeLibrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.nuevoPrestamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDePrestamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosDeLibosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosDePersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosDePrestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.listadosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(650, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoLibroToolStripMenuItem,
            this.gestiónDeLibrosToolStripMenuItem,
            this.toolStripSeparator1,
            this.nToolStripMenuItem,
            this.nuevaToolStripMenuItem,
            this.toolStripSeparator2,
            this.nuevoPrestamoToolStripMenuItem,
            this.gestiónDePrestamoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoLibroToolStripMenuItem
            // 
            this.nuevoLibroToolStripMenuItem.Name = "nuevoLibroToolStripMenuItem";
            this.nuevoLibroToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.nuevoLibroToolStripMenuItem.Text = "Nuevo Libro";
            this.nuevoLibroToolStripMenuItem.Click += new System.EventHandler(this.nuevoLibroToolStripMenuItem_Click);
            // 
            // gestiónDeLibrosToolStripMenuItem
            // 
            this.gestiónDeLibrosToolStripMenuItem.Name = "gestiónDeLibrosToolStripMenuItem";
            this.gestiónDeLibrosToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.gestiónDeLibrosToolStripMenuItem.Text = "Gestión de Libros";
            this.gestiónDeLibrosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeLibrosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // nToolStripMenuItem
            // 
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.nToolStripMenuItem.Text = "Nueva Persona";
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.nuevaToolStripMenuItem.Text = "Gestión de Personas";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(224, 6);
            // 
            // nuevoPrestamoToolStripMenuItem
            // 
            this.nuevoPrestamoToolStripMenuItem.Name = "nuevoPrestamoToolStripMenuItem";
            this.nuevoPrestamoToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.nuevoPrestamoToolStripMenuItem.Text = "Nuevo Prestamo";
            // 
            // gestiónDePrestamoToolStripMenuItem
            // 
            this.gestiónDePrestamoToolStripMenuItem.Name = "gestiónDePrestamoToolStripMenuItem";
            this.gestiónDePrestamoToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.gestiónDePrestamoToolStripMenuItem.Text = "Gestión de Prestamos";
            // 
            // listadosToolStripMenuItem
            // 
            this.listadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadosDeLibosToolStripMenuItem,
            this.listadosDePersonasToolStripMenuItem,
            this.listadosDePrestamosToolStripMenuItem});
            this.listadosToolStripMenuItem.Name = "listadosToolStripMenuItem";
            this.listadosToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.listadosToolStripMenuItem.Text = "Listados";
            // 
            // listadosDeLibosToolStripMenuItem
            // 
            this.listadosDeLibosToolStripMenuItem.Name = "listadosDeLibosToolStripMenuItem";
            this.listadosDeLibosToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.listadosDeLibosToolStripMenuItem.Text = "Listados de Libros";
            this.listadosDeLibosToolStripMenuItem.Click += new System.EventHandler(this.listadosDeLibosToolStripMenuItem_Click);
            // 
            // listadosDePersonasToolStripMenuItem
            // 
            this.listadosDePersonasToolStripMenuItem.Name = "listadosDePersonasToolStripMenuItem";
            this.listadosDePersonasToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.listadosDePersonasToolStripMenuItem.Text = "Listados de Personas";
            // 
            // listadosDePrestamosToolStripMenuItem
            // 
            this.listadosDePrestamosToolStripMenuItem.Name = "listadosDePrestamosToolStripMenuItem";
            this.listadosDePrestamosToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.listadosDePrestamosToolStripMenuItem.Text = "Listados de Prestamos";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem1});
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(113, 26);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instituto Nº20 - Biblioteca";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeLibrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem nuevoPrestamoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDePrestamoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadosDeLibosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadosDePersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadosDePrestamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
    }
}

