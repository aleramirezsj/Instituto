namespace Presentacion
{
    partial class FrmListadosdeLibros
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
            this.RdbImprimirTodos = new System.Windows.Forms.RadioButton();
            this.RdbSeleccionarPorGeneros = new System.Windows.Forms.RadioButton();
            this.RdbSeleccionarPorMaterias = new System.Windows.Forms.RadioButton();
            this.CboGeneros = new System.Windows.Forms.ComboBox();
            this.CboMaterias = new System.Windows.Forms.ComboBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RdbImprimirTodos
            // 
            this.RdbImprimirTodos.AutoSize = true;
            this.RdbImprimirTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbImprimirTodos.Location = new System.Drawing.Point(68, 47);
            this.RdbImprimirTodos.Name = "RdbImprimirTodos";
            this.RdbImprimirTodos.Size = new System.Drawing.Size(212, 33);
            this.RdbImprimirTodos.TabIndex = 0;
            this.RdbImprimirTodos.TabStop = true;
            this.RdbImprimirTodos.Text = "Imprimir Todos";
            this.RdbImprimirTodos.UseVisualStyleBackColor = true;
            // 
            // RdbSeleccionarPorGeneros
            // 
            this.RdbSeleccionarPorGeneros.AutoSize = true;
            this.RdbSeleccionarPorGeneros.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbSeleccionarPorGeneros.Location = new System.Drawing.Point(68, 107);
            this.RdbSeleccionarPorGeneros.Name = "RdbSeleccionarPorGeneros";
            this.RdbSeleccionarPorGeneros.Size = new System.Drawing.Size(326, 33);
            this.RdbSeleccionarPorGeneros.TabIndex = 1;
            this.RdbSeleccionarPorGeneros.TabStop = true;
            this.RdbSeleccionarPorGeneros.Text = "Seleccionar por Géneros";
            this.RdbSeleccionarPorGeneros.UseVisualStyleBackColor = true;
            // 
            // RdbSeleccionarPorMaterias
            // 
            this.RdbSeleccionarPorMaterias.AutoSize = true;
            this.RdbSeleccionarPorMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbSeleccionarPorMaterias.Location = new System.Drawing.Point(68, 163);
            this.RdbSeleccionarPorMaterias.Name = "RdbSeleccionarPorMaterias";
            this.RdbSeleccionarPorMaterias.Size = new System.Drawing.Size(326, 33);
            this.RdbSeleccionarPorMaterias.TabIndex = 2;
            this.RdbSeleccionarPorMaterias.TabStop = true;
            this.RdbSeleccionarPorMaterias.Text = "Seleccionar por Materias";
            this.RdbSeleccionarPorMaterias.UseVisualStyleBackColor = true;
            // 
            // CboGeneros
            // 
            this.CboGeneros.FormattingEnabled = true;
            this.CboGeneros.Location = new System.Drawing.Point(507, 107);
            this.CboGeneros.Name = "CboGeneros";
            this.CboGeneros.Size = new System.Drawing.Size(121, 24);
            this.CboGeneros.TabIndex = 3;
            // 
            // CboMaterias
            // 
            this.CboMaterias.FormattingEnabled = true;
            this.CboMaterias.Location = new System.Drawing.Point(507, 163);
            this.CboMaterias.Name = "CboMaterias";
            this.CboMaterias.Size = new System.Drawing.Size(121, 24);
            this.CboMaterias.TabIndex = 4;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(452, 299);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(149, 43);
            this.BtnCancelar.TabIndex = 23;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Location = new System.Drawing.Point(245, 299);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(149, 43);
            this.BtnImprimir.TabIndex = 22;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            // 
            // FrmListadosdeLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.CboMaterias);
            this.Controls.Add(this.CboGeneros);
            this.Controls.Add(this.RdbSeleccionarPorMaterias);
            this.Controls.Add(this.RdbSeleccionarPorGeneros);
            this.Controls.Add(this.RdbImprimirTodos);
            this.Name = "FrmListadosdeLibros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados de Libros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RdbImprimirTodos;
        private System.Windows.Forms.RadioButton RdbSeleccionarPorGeneros;
        private System.Windows.Forms.RadioButton RdbSeleccionarPorMaterias;
        private System.Windows.Forms.ComboBox CboGeneros;
        private System.Windows.Forms.ComboBox CboMaterias;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnImprimir;
    }
}