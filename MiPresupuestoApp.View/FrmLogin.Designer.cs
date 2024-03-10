namespace MiPresupuestoApp.View
{
    partial class FrmLogin
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            txtCorreo = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegistrarse = new Button();
            btnOlvidarClave = new Button();
            bsUserLogin = new BindingSource(components);
            userLoginDtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bsUserLogin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userLoginDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 94);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Correo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 132);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // txtCorreo
            // 
            txtCorreo.DataBindings.Add(new Binding("Text", userLoginDtoBindingSource, "Correo", true));
            txtCorreo.Location = new Point(156, 94);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(191, 27);
            txtCorreo.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.DataBindings.Add(new Binding("Text", userLoginDtoBindingSource, "Password", true));
            txtPassword.Location = new Point(156, 127);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(191, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(54, 180);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(154, 180);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(115, 29);
            btnRegistrarse.TabIndex = 5;
            btnRegistrarse.Text = "REGISTRARSE";
            btnRegistrarse.UseVisualStyleBackColor = true;
            // 
            // btnOlvidarClave
            // 
            btnOlvidarClave.BackColor = Color.Transparent;
            btnOlvidarClave.ImageAlign = ContentAlignment.BottomCenter;
            btnOlvidarClave.Location = new Point(54, 215);
            btnOlvidarClave.Name = "btnOlvidarClave";
            btnOlvidarClave.Size = new Size(215, 29);
            btnOlvidarClave.TabIndex = 6;
            btnOlvidarClave.Text = "Olvidaste la contraseña?";
            btnOlvidarClave.TextAlign = ContentAlignment.MiddleLeft;
            btnOlvidarClave.UseVisualStyleBackColor = false;
            // 
            // userLoginDtoBindingSource
            // 
            userLoginDtoBindingSource.DataSource = typeof(Models.DTO.UserLoginDto);
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOlvidarClave);
            Controls.Add(btnRegistrarse);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtCorreo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmLogin";
            Text = "LOGIN";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)bsUserLogin).EndInit();
            ((System.ComponentModel.ISupportInitialize)userLoginDtoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCorreo;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegistrarse;
        private Button btnOlvidarClave;
        private BindingSource bsUserLogin;
        private BindingSource userLoginDtoBindingSource;
    }
}