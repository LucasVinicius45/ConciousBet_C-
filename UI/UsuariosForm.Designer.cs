using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ConsciousbetApp.UI
{
    partial class UsuariosForm
    {
        private IContainer components = null;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtSenha;
        private Button btnSalvar;
        private Button btnAtualizar;
        private Button btnExcluir;
        private Button btnCancelar;
        private Button btnNovo;
        private DataGridView dgvUsuarios;
        private Label lblNome;
        private Label lblEmail;
        private Label lblSenha;
        private Label lblTitulo;
        private GroupBox grpDados;
        private GroupBox grpAcoes;

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
            this.txtNome = new TextBox();
            this.txtEmail = new TextBox();
            this.txtSenha = new TextBox();
            this.btnSalvar = new Button();
            this.btnAtualizar = new Button();
            this.btnExcluir = new Button();
            this.btnCancelar = new Button();
            this.btnNovo = new Button();
            this.dgvUsuarios = new DataGridView();
            this.lblNome = new Label();
            this.lblEmail = new Label();
            this.lblSenha = new Label();
            this.lblTitulo = new Label();
            this.grpDados = new GroupBox();
            this.grpAcoes = new GroupBox();
            ((ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grpDados.SuspendLayout();
            this.grpAcoes.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 20);
            this.lblTitulo.Text = "Gerenciamento de Usuários";

            // grpDados
            this.grpDados.Controls.Add(this.lblNome);
            this.grpDados.Controls.Add(this.txtNome);
            this.grpDados.Controls.Add(this.lblEmail);
            this.grpDados.Controls.Add(this.txtEmail);
            this.grpDados.Controls.Add(this.lblSenha);
            this.grpDados.Controls.Add(this.txtSenha);
            this.grpDados.Location = new System.Drawing.Point(20, 50);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(300, 140);
            this.grpDados.Text = "Dados do Usuário";

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(15, 25);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.Text = "Nome:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(15, 45);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(270, 20);
            this.txtNome.TabIndex = 0;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(15, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(270, 20);
            this.txtEmail.TabIndex = 1;

            // lblSenha
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(15, 115);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(71, 13);
            this.lblSenha.Text = "Senha (deixe vazio para manter):";

            // txtSenha
            this.txtSenha.Location = new System.Drawing.Point(180, 112);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(105, 20);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.UseSystemPasswordChar = true;

            // grpAcoes
            this.grpAcoes.Controls.Add(this.btnNovo);
            this.grpAcoes.Controls.Add(this.btnSalvar);
            this.grpAcoes.Controls.Add(this.btnAtualizar);
            this.grpAcoes.Controls.Add(this.btnExcluir);
            this.grpAcoes.Controls.Add(this.btnCancelar);
            this.grpAcoes.Location = new System.Drawing.Point(340, 50);
            this.grpAcoes.Name = "grpAcoes";
            this.grpAcoes.Size = new System.Drawing.Size(200, 140);
            this.grpAcoes.Text = "Ações";

            // btnNovo
            this.btnNovo.Location = new System.Drawing.Point(15, 25);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(170, 25);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new EventHandler(this.btnNovo_Click);

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(15, 55);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(170, 25);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar (Novo)";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);

            // btnAtualizar
            this.btnAtualizar.Location = new System.Drawing.Point(15, 85);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(80, 25);
            this.btnAtualizar.TabIndex = 5;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Enabled = false;
            this.btnAtualizar.Click += new EventHandler(this.btnAtualizar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(105, 85);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(80, 25);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Click += new EventHandler(this.btnExcluir_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(15, 115);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(170, 25);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // dgvUsuarios
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 210);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(520, 200);
            this.dgvUsuarios.TabIndex = 8;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;

            // UsuariosForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.grpAcoes);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "UsuariosForm";
            this.Text = "Gerenciar Usuários";
            this.StartPosition = FormStartPosition.CenterScreen;
            ((ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.grpAcoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}