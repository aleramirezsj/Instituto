using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void nuevoLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoLibro frmNuevoLibro = new FrmNuevoLibro();
            frmNuevoLibro.ShowDialog();

        }

        private void listadosDeLibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadosdeLibros frmListadosdeLibros = new FrmListadosdeLibros();
            frmListadosdeLibros.ShowDialog();

        }

        private void gestiónDeLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionLibros frmGestionLibros = new FrmGestionLibros();
            frmGestionLibros.ShowDialog();

        }
    }
}
