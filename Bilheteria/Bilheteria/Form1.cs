using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bilheteria
{
    public partial class Form1 : Form
    {
        const int NUM_FILEIRAS = 15;
        const int POLTRONAS_POR_FILEIRA = 40;
        Button[,] poltronas = new Button[NUM_FILEIRAS, POLTRONAS_POR_FILEIRA];
        int lugaresOcupados = 0;
        float valorTotal = 0;

        public Form1()
        {
            InitializeComponent();
            CriarPoltronas();
        }

        private void CriarPoltronas()
        {
            int largura = 60;
            int altura = 40;
            int espaco = 5;

            // Ajusta o tamanho do painel para acomodar todas as poltronas
            panelPoltronas.AutoScroll = true;

            for (int i = 0; i < NUM_FILEIRAS; i++)
            {
                for (int j = 0; j < POLTRONAS_POR_FILEIRA; j++)
                {
                    Button poltrona = new Button();
                    poltrona.Size = new Size(largura, altura);
                    poltrona.Location = new Point(j * (largura + espaco), i * (altura + espaco));
                    poltrona.Text = $"{i + 1}-{j + 1}";
                    poltrona.BackColor = Color.LightGreen;
                    poltrona.Click += new EventHandler(ReservarPoltrona);

                    panelPoltronas.Controls.Add(poltrona);
                }
            }
        }

        private void ReservarPoltrona(object sender, EventArgs e)
        {
            Button poltrona = (Button)sender;

            if (poltrona.BackColor == Color.Red)
            {
                MessageBox.Show("Esta poltrona já está ocupada!");
                return;
            }

            poltrona.BackColor = Color.Red;
            lugaresOcupados++;

            int fileira = int.Parse(poltrona.Text.Split('-')[0]);
            float valor;
            if (fileira >= 1 && fileira <= 5)
                valor = 50.00f;
            else if (fileira >= 6 && fileira <= 10)
                valor = 30.00f;
            else
                valor = 15.00f;

            valorTotal += valor;
            AtualizarFaturamento();
        }

        private void AtualizarFaturamento()
        {
            labelLugaresOcupados.Text = $"Lugares Ocupados: {lugaresOcupados}";
            labelValorTotal.Text = $"Faturamento: R$ {valorTotal:0.00}";
        }

        private void buttonMostrarFaturamento_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Lugares Ocupados: {lugaresOcupados}\nFaturamento: R$ {valorTotal:0.00}", "Faturamento");
        }
    }
}
