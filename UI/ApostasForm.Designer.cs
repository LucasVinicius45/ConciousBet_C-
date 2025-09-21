using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ConsciousbetApp.UI
{
    partial class ApostasForm
    {
        private IContainer components = null;
        private TextBox txtValor;
        private TextBox txtResultado;
        private ComboBox cmbUsuario;
        private Button btnSalvar;
        private Button btnAtualizar;
        private Button btnExcluir;
        private Button btnCancelar;
        private Button btnNovo;
        private Button btnEstatisticas;
        private DataGridView dgvApostas;
        private Label lblValor;
        private Label lblResultado;
        private Label lblUsuario;
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
            this.txtValor = new TextBox();
            this.txtResultado = new TextBox();
            this.cmbUsuario = new ComboBox();
            this.btnSalvar = new Button();
            this.btnAtualizar = new Button();
            this.btnExcluir = new Button();
            this.btnCancelar = new Button();
            this.btnNovo = new Button();
            this.btnEstatisticas = new Button();
            this.dgvApostas = new DataGridView();
            this.lblValor = new Label();
            this.lblResultado = new Label();
            this.lblUsuario = new Label();
            this.lblTitulo = new Label();
            this.grpDados = new GroupBox();
            this.grpAcoes = new GroupBox();
            ((ISupportInitialize)(this.dgvApostas)).BeginInit();
            this.grpDados.SuspendLayout();
            this.grpAcoes.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 20);
            this.lblTitulo.Text = "Gerenciamento de Apostas";

            // grpDados
            this.grpDados.Controls.Add(this.lblValor);
            this.grpDados.Controls.Add(this.txtValor);
            this.grpDados.Controls.Add(this.lblResultado);
            this.grpDados.Controls.Add(this.txtResultado);
            this.grpDados.Controls.Add(this.lblUsuario);
            this.grpDados.Controls.Add(this.cmbUsuario);
            this.grpDados.Location = new System.Drawing.Point(20, 50);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(300, 140);
            this.grpDados.Text = "Dados da Aposta";

            // lblValor
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(15, 25);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.Text = "Valor:";

            // txtValor
            this.txtValor.Location = new System.Drawing.Point(15, 45);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 0;

            // lblResultado
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(130, 25);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(58, 13);
            this.lblResultado.Text = "Resultado:";

            // txtResultado
            this.txtResultado.Location = new System.Drawing.Point(130, 45);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(155, 20);
            this.txtResultado.TabIndex = 1;

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(15, 75);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.Text = "Usuário:";

            // cmbUsuario
            this.cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUsuario.Location = new System.Drawing.Point(15, 95);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(270, 21);
            this.cmbUsuario.TabIndex = 2;

            // grpAcoes
            this.grpAcoes.Controls.Add(this.btnNovo);
            this.grpAcoes.Controls.Add(this.btnSalvar);
            this.grpAcoes.Controls.Add(this.btnAtualizar);
            this.grpAcoes.Controls.Add(this.btnExcluir);
            this.grpAcoes.Controls.Add(this.btnCancelar);
            this.grpAcoes.Controls.Add(this.btnEstatisticas);
            this.grpAcoes.Location = new System.Drawing.Point(340, 50);
            this.grpAcoes.Name = "grpAcoes";
            this.grpAcoes.Size = new System.Drawing.Size(200, 140);
            this.grpAcoes.Text = "Ações";

            // btnNovo
            this.btnNovo.Location = new System.Drawing.Point(15, 20);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(170, 25);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.Text = "Nova Aposta";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new EventHandler(this.btnNovo_Click);

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(15, 50);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(170, 25);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);

            // btnAtualizar
            this.btnAtualizar.Location = new System.Drawing.Point(15, 80);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(80, 25);
            this.btnAtualizar.TabIndex = 5;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Enabled = false;
            this.btnAtualizar.Click += new EventHandler(this.btnAtualizar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(105, 80);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(80, 25);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Click += new EventHandler(this.btnExcluir_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(15, 110);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 25);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // btnEstatisticas
            this.btnEstatisticas.Location = new System.Drawing.Point(105, 110);
            this.btnEstatisticas.Name = "btnEstatisticas";
            this.btnEstatisticas.Size = new System.Drawing.Size(80, 25);
            this.btnEstatisticas.TabIndex = 8;
            this.btnEstatisticas.Text = "Estatísticas";
            this.btnEstatisticas.UseVisualStyleBackColor = true;
            this.btnEstatisticas.Click += new EventHandler(this.btnEstatisticas_Click);

            // dgvApostas
            this.dgvApostas.Location = new System.Drawing.Point(20, 210);
            this.dgvApostas.Name = "dgvApostas";
            this.dgvApostas.Size = new System.Drawing.Size(520, 200);
            this.dgvApostas.TabIndex = 9;
            this.dgvApostas.ReadOnly = true;
            this.dgvApostas.AllowUserToAddRows = false;
            this.dgvApostas.AllowUserToDeleteRows = false;

            // ApostasForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.grpAcoes);
            this.Controls.Add(this.dgvApostas);
            this.Name = "ApostasForm";
            this.Text = "Gerenciar Apostas";
            this.StartPosition = FormStartPosition.CenterScreen;
            ((ISupportInitialize)(this.dgvApostas)).EndInit();
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.grpAcoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}