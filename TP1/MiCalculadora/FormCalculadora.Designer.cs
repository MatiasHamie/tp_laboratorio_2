namespace MiCalculadora
{
    partial class FormCalculadora
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
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero1
            // 
            this.txtNumero1.Location = new System.Drawing.Point(31, 32);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(101, 20);
            this.txtNumero1.TabIndex = 0;
            // 
            // txtNumero2
            // 
            this.txtNumero2.Location = new System.Drawing.Point(265, 32);
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(100, 20);
            this.txtNumero2.TabIndex = 2;
            // 
            // cmbOperador
            // 
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cmbOperador.Location = new System.Drawing.Point(138, 31);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(121, 21);
            this.cmbOperador.TabIndex = 3;
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(31, 71);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(101, 23);
            this.btnOperar.TabIndex = 4;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(138, 71);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(121, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(265, 71);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(31, 100);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(156, 36);
            this.button6.TabIndex = 7;
            this.button6.Text = "Convertir a Binario";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(209, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 36);
            this.button4.TabIndex = 8;
            this.button4.Text = "Convertir a Decimal";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(311, 9);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(55, 13);
            this.lblResultado.TabIndex = 9;
            this.lblResultado.Text = "Resultado";
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 153);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.cmbOperador);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.txtNumero1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Matias Hamie del curso 2°C";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblResultado;
    }
}

