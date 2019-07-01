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
    public partial class FrmGestionLibros : Form
    {
        public FrmGestionLibros()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoLibro frmNuevoLibro = new FrmNuevoLibro();
            frmNuevoLibro.ShowDialog();

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            FrmModificarLibro frmModificarLibro = new FrmModificarLibro();
            frmModificarLibro.ShowDialog();

        }
    }
}
