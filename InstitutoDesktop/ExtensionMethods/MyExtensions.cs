
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Security.Cryptography;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.ExtensionMethods
{
    public static class MyExtensions
    {
        public static void CopyPropertiesTo<T>(this T source, T destination)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException("Objeto de origen o destino son nulos");
            }

            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source, null);
                    property.SetValue(destination, value, null);
                }
            }
        }
        public static string PropertiesToString<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Type type = typeof(T);

            string stringReturn = string.Empty;

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object? value = property.GetValue(source, null);
                    stringReturn += $"{property.Name}={value?.ToString() ?? "null"}{Environment.NewLine}";
                }
            }
            return stringReturn;
        }
        public static string GetHashSha256(this string textoAEncriptar)
        {
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textoAEncriptar));
            // Convert byte array to a string   
            StringBuilder hashObtenido = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                hashObtenido.Append(bytes[i].ToString("x2"));
            }
            return hashObtenido.ToString();
        }

        public static int IdSeleccionado(this ComboBox combo)
        {
            if (combo.SelectedValue != null && combo.SelectedValue.GetType() == typeof(int))
            {
                return (int)combo.SelectedValue;
            }
            else
                return 0;
        }
        public static string ObtenerColumna(this DataGridView grid, string columna)
        {
            if (grid.CurrentRow != null && grid.RowCount > 0)
                return grid.CurrentRow.Cells[columna].Value.ToString();
            else
                return "";
        }


        public static void MensajeAdvertenciaDeSalida(this Form form)
        {
            var respuesta = MessageBox.Show($"¿Está seguro que desea salir del formulario {form.Text}", "Atención", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
                form.Close();
        }
        public static int IdSeleccionado(this DataGridView grid)
        {
            return int.Parse(grid.CurrentRow.Cells[0].Value.ToString());
        }
        //método sobre las grillas que oculta las columnas que normalmente no se muestran




        public static void DarColorAFilas(this DataGridView grid, int nroColumna, Func<decimal, bool> condicion, Color color)
        {
            foreach (DataGridViewRow row in grid.Rows)
                if (row.Cells.Count > nroColumna &&
                    condicion(Convert.ToDecimal(row.Cells[nroColumna].Value)))
                {
                    row.DefaultCellStyle.BackColor = color;
                }
        }
        public static void SeleccionarFilaNuevaOEditada(this DataGridView grid, int id)
        {
            foreach (DataGridViewRow fila in grid.Rows)
            {
                if ((int)fila.Cells[0].Value == id)
                {
                    grid.CurrentCell = fila.Cells[0];
                    break;
                }
            }
        }

        public static void OcultarColumnas(this DataGridView grid, string[] columnasAOcultar)
        {
            //form.EstaVisible() &&
            if (grid.RowCount > 0)
            {
                //oculta siempre las columnas que terminan con Id, ejemplo UsuarioId
                foreach (string columnaAOcultar in columnasAOcultar)
                {
                    foreach (DataGridViewColumn columna in grid.Columns)
                    {
                        if (columna.Name == columnaAOcultar)
                        {
                            columna.Visible = false;
                        }
                    }
                }
            }
        }

        public static void SetWidthToColumn(this DataGridView grid, int nroColumna, int ancho)
        {
            if (grid.Visible && grid.RowCount > 0 && grid.ColumnCount > 0 && grid.Columns[nroColumna].Width!=ancho)
            {
                grid.Columns[nroColumna].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[nroColumna].Width = ancho;
            }
        }
        public static void SetWidthToColumn(this DataGridView grid, string nombreColumna, int ancho)
        {
            if (grid.Columns.Contains(nombreColumna))
            {
                grid.Columns[nombreColumna].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[nombreColumna].Width = ancho;
            }
        }

        public static void SetWidthToColumn<T>(this DataGridView grid, Expression<Func<T, object>> propertyExpression, int ancho)
        {
            var member = propertyExpression.Body as MemberExpression ?? ((UnaryExpression)propertyExpression.Body).Operand as MemberExpression;
            if (member != null)
            {
                string nameColumn = member.Member.Name;
                if (grid.Columns.Contains(nameColumn))
                {
                    if (grid.Columns.Contains(nameColumn))
                    {
                        grid.Columns[nameColumn].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        grid.Columns[nameColumn].Width = ancho;
                    }
                }
            }
        }


        public static void EstablecerAnchoDeColumnas(this DataGridView grid, int[] anchos)
        {
            if (grid.RowCount > 0 && grid.ColumnCount > 0)
            {
                int visibleColumnIndex = 0;
                for (int i = 0; i < anchos.Length; i++)
                {
                    // Encuentra la siguiente columna visible
                    while (visibleColumnIndex < grid.Columns.Count && !grid.Columns[visibleColumnIndex].Visible)
                    {
                        visibleColumnIndex++;
                    }

                    // Si no hay más columnas visibles, sal del bucle
                    if (visibleColumnIndex >= grid.Columns.Count)
                    {
                        break;
                    }

                    // Establece el ancho de la columna visible
                    grid.Columns[visibleColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    grid.Columns[visibleColumnIndex].Width = anchos[i];
                    visibleColumnIndex++;
                }
            }
        }

        public static void SetTitleToColumn<T>(this DataGridView grid, Expression<Func<T, object>> propertyExpression, string newTitle)
        {
            if (grid.ColumnCount > 0)
            {
                var member = propertyExpression.Body as MemberExpression ?? ((UnaryExpression)propertyExpression.Body).Operand as MemberExpression;
                if (member != null)
                {
                    string nameColumn = member.Member.Name;
                    if (grid.Columns.Contains(nameColumn))
                    {
                        grid.Columns[nameColumn].HeaderText = newTitle;
                    }
                }
            }
        }




        public static bool EstaVisible(this Form form)
        {
            return Application.OpenForms.OfType<Form>().Where(f => f.Name == form.Name).SingleOrDefault<Form>() != null;
        }

        public static void SetDataAndAutoComplete<T>(this ComboBox combo, List<T> dataSource) where T : class,IEntityIdNombre
        {
            combo.DataSource = dataSource.ToList();
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";

            AutoCompleteStringCollection autoCompleteEntitys = new AutoCompleteStringCollection();
            foreach (T entity in dataSource.ToList())
            {
                autoCompleteEntitys.Add(entity.Nombre.ToString());
            }
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            combo.AutoCompleteCustomSource = autoCompleteEntitys;
        }

        public static void SetDataAndAutoCompleteWithToString<T>(this ComboBox combo, List<T> dataSource) where T : class, IEntityWithId
        {
            combo.DataSource = dataSource.ToList();
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";

            AutoCompleteStringCollection autoCompleteEntitys = new AutoCompleteStringCollection();
            foreach (T entity in dataSource.ToList())
            {
                autoCompleteEntitys.Add(entity.ToString());
            }
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            combo.AutoCompleteCustomSource = autoCompleteEntitys;
        }

    }

}