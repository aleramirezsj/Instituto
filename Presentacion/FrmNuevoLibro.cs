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
    public partial class FrmNuevoLibro : Form
    {
        
        BibliotecaContext bibliotecaContext = new BibliotecaContext();

        public FrmNuevoLibro()
        {
            InitializeComponent();
            
        }



       

        private void TxtPaginas_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TxtGenero_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtAutor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //instancio un objeto basado en la clase Libro y le almaceno
            //los datos cargados en el formulario
            Libro libro = new Libro();
            libro.Nombre = TxtNombre.Text;
            libro.Autor = TxtAutor.Text;
            libro.Genero = TxtGenero.Text;
            libro.Paginas = Convert.ToInt32(TxtPaginas.Text);
            //agrego ese objeto a la tabla libros administrada automáticamente
            //por Entity Framework
            bibliotecaContext.Libros.Add(libro);
            bibliotecaContext.SaveChanges();
        }
    }
}
