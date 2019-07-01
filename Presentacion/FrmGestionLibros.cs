using Modelos;
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
        BibliotecaContext bibliotecaContext = new BibliotecaContext();
        public FrmGestionLibros()
        {
            InitializeComponent();
            dataGridView1.DataSource = bibliotecaContext.Libros.ToList();
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection celdasFilaActual = dataGridView1.CurrentRow.Cells;
            Int32 idSeleccionado = (Int32)celdasFilaActual[0].Value;
            String libroSeleccionado = (string)celdasFilaActual[1].Value;

            string mensaje = "¿Está seguro que desea eliminar el libro: " + libroSeleccionado + "?";
            string titulo = "Eliminación de un libro";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (respuesta == DialogResult.Yes)
            {
                var libro = bibliotecaContext.Libros.Find(idSeleccionado);
                bibliotecaContext.Libros.Remove(libro);
                bibliotecaContext.SaveChanges();

                dataGridView1.DataSource = bibliotecaContext.Libros.ToList();
            }
        }
    }
}
