namespace Bilheteria
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelPoltronas;
        private System.Windows.Forms.Label labelLugaresOcupados;
        private System.Windows.Forms.Label labelValorTotal;
        private System.Windows.Forms.Button buttonMostrarFaturamento;

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
            panelPoltronas = new Panel();
            labelLugaresOcupados = new Label();
            labelValorTotal = new Label();
            buttonMostrarFaturamento = new Button();
            SuspendLayout();
            // 
            // panelPoltronas
            // 
            panelPoltronas.Location = new Point(74, 14);
            panelPoltronas.Name = "panelPoltronas";
            panelPoltronas.Size = new Size(1000, 600);
            panelPoltronas.TabIndex = 0;
            // 
            // labelLugaresOcupados
            // 
            labelLugaresOcupados.AutoSize = true;
            labelLugaresOcupados.Location = new Point(273, 630);
            labelLugaresOcupados.Name = "labelLugaresOcupados";
            labelLugaresOcupados.Size = new Size(146, 20);
            labelLugaresOcupados.TabIndex = 1;
            labelLugaresOcupados.Text = "Lugares Ocupados: 0";
            // 
            // labelValorTotal
            // 
            labelValorTotal.AutoSize = true;
            labelValorTotal.Location = new Point(272, 660);
            labelValorTotal.Name = "labelValorTotal";
            labelValorTotal.Size = new Size(147, 20);
            labelValorTotal.TabIndex = 2;
            labelValorTotal.Text = "Faturamento: R$ 0.00";
            // 
            // buttonMostrarFaturamento
            // 
            buttonMostrarFaturamento.Location = new Point(694, 630);
            buttonMostrarFaturamento.Name = "buttonMostrarFaturamento";
            buttonMostrarFaturamento.Size = new Size(200, 50);
            buttonMostrarFaturamento.TabIndex = 3;
            buttonMostrarFaturamento.Text = "Mostrar Faturamento";
            buttonMostrarFaturamento.UseVisualStyleBackColor = true;
            buttonMostrarFaturamento.Click += buttonMostrarFaturamento_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1134, 692);
            Controls.Add(buttonMostrarFaturamento);
            Controls.Add(labelValorTotal);
            Controls.Add(labelLugaresOcupados);
            Controls.Add(panelPoltronas);
            Name = "Form1";
            Text = "Bilheteria";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
