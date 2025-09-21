using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ConsciousbetApp.UI
{
    partial class Form1
    {
        private IContainer components = null;
        private Button btnUsuarios;
        private Button btnApostas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnUsuarios = new Button();
            this.btnApostas = new Button();
            this.SuspendLayout();

            // btnUsuarios
            this.btnUsuarios.Location = new System.Drawing.Point(50, 50);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(150, 40);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Gerenciar Usuários";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new EventHandler(this.btnUsuarios_Click);

            // btnApostas
            this.btnApostas.Location = new System.Drawing.Point(50, 120);
            this.btnApostas.Name = "btnApostas";
            this.btnApostas.Size = new System.Drawing.Size(150, 40);
            this.btnApostas.TabIndex = 1;
            this.btnApostas.Text = "Gerenciar Apostas";
            this.btnApostas.UseVisualStyleBackColor = true;
            this.btnApostas.Click += new EventHandler(this.btnApostas_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btnApostas);
            this.Controls.Add(this.btnUsuarios);
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ConsciousBet - Menu Principal";
            this.ResumeLayout(false);
        }
    }
}