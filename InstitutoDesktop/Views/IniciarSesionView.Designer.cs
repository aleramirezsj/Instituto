namespace InstitutoDesktop.Views
{
    partial class IniciarSesionView
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
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnIngresar = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            chkVerContraseña = new CheckBox();
            btnIngresarConGoogle = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.File;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnCancelar.IconSize = 24;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(333, 209);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(127, 40);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.IconChar = FontAwesome.Sharp.IconChar.File;
            btnIngresar.IconColor = Color.Black;
            btnIngresar.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnIngresar.IconSize = 24;
            btnIngresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnIngresar.Location = new Point(170, 209);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(127, 40);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 58);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 10;
            label1.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(234, 58);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 27);
            txtEmail.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 112);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 12;
            label2.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(234, 112);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(240, 27);
            txtPassword.TabIndex = 13;
            // 
            // chkVerContraseña
            // 
            chkVerContraseña.AutoSize = true;
            chkVerContraseña.Location = new Point(234, 158);
            chkVerContraseña.Margin = new Padding(2);
            chkVerContraseña.Name = "chkVerContraseña";
            chkVerContraseña.Size = new Size(128, 24);
            chkVerContraseña.TabIndex = 14;
            chkVerContraseña.Text = "Ver contraseña";
            chkVerContraseña.UseVisualStyleBackColor = true;
            chkVerContraseña.CheckedChanged += chkVerContraseña_CheckedChanged;
            // 
            // btnIngresarConGoogle
            // 
            btnIngresarConGoogle.IconChar = FontAwesome.Sharp.IconChar.File;
            btnIngresarConGoogle.IconColor = Color.Black;
            btnIngresarConGoogle.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnIngresarConGoogle.IconSize = 24;
            btnIngresarConGoogle.ImageAlign = ContentAlignment.MiddleLeft;
            btnIngresarConGoogle.Location = new Point(222, 268);
            btnIngresarConGoogle.Margin = new Padding(3, 4, 3, 4);
            btnIngresarConGoogle.Name = "btnIngresarConGoogle";
            btnIngresarConGoogle.Size = new Size(192, 40);
            btnIngresarConGoogle.TabIndex = 15;
            btnIngresarConGoogle.Text = "Ingresar con google";
            btnIngresarConGoogle.UseVisualStyleBackColor = true;
            btnIngresarConGoogle.Click += btnIngresarConGoogle_Click;
            // 
            // IniciarSesionView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 337);
            Controls.Add(btnIngresarConGoogle);
            Controls.Add(chkVerContraseña);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Margin = new Padding(2);
            Name = "IniciarSesionView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IniciarSesion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnIngresar;
        private Label label1;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtPassword;
        private CheckBox chkVerContraseña;
        private FontAwesome.Sharp.IconButton btnIngresarConGoogle;
    }
}