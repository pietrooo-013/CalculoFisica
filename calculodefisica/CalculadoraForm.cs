
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace calculodefisica
{
    public class CalculadoraForm : Form
    {
        private readonly string formula;
        private readonly List<TextBox> campos = new List<TextBox>();
        private readonly Label resultado = new Label();

        public CalculadoraForm(string formula)
        {
            this.formula = formula;

            Text = formula;
            Size = new Size(420, 430);
            StartPosition = FormStartPosition.CenterScreen;

            MontarTela();
        }

        private void MontarTela()
        {
            string[] nomes;

            switch (formula)
            {
                case "Velocidade Média":
                    nomes = new[] { "Deslocamento (m)", "Tempo (s)" };
                    break;

                case "Aceleração":
                    nomes = new[] {
                        "Velocidade final (m/s)",
                        "Velocidade inicial (m/s)",
                        "Tempo (s)"
                    };
                    break;

                case "Força":
                    nomes = new[] { "Massa (kg)", "Aceleração (m/s²)" };
                    break;

                case "Força de Atrito":
                    nomes = new[] {
                        "Coeficiente de atrito",
                        "Força normal (N)"
                    };
                    break;

                case "Peso":
                    nomes = new[] { "Massa (kg)", "Gravidade (m/s²)" };
                    break;

                case "Lei de Ohm":
                    nomes = new[] { "Resistência (Ω)", "Corrente elétrica (A)" };
                    break;

                default:
                    nomes = Array.Empty<string>();
                    break;
            }

            Label titulo = new Label
            {
                Text = formula,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };

            Controls.Add(titulo);

            int y = 55;

            foreach (string nome in nomes)
            {
                Label label = new Label
                {
                    Text = nome,
                    AutoSize = true,
                    Location = new Point(20, y)
                };

                TextBox campo = new TextBox
                {
                    Location = new Point(20, y + 20),
                    Width = 340
                };

                Controls.Add(label);
                Controls.Add(campo);
                campos.Add(campo);

                y += 65;
            }

            if (formula == "Peso")
                campos[1].Text = "9,8";

            Button calcular = new Button
            {
                Text = "Calcular",
                Location = new Point(20, y),
                Width = 120,
                Height = 32
            };

            calcular.Click += Calcular_Click;
            Controls.Add(calcular);

            resultado.Text = "Resultado:";
            resultado.AutoSize = true;
            resultado.Font = new Font("Segoe UI", 11);
            resultado.Location = new Point(20, y + 45);

            Controls.Add(resultado);
        }

        private void Calcular_Click(object sender, EventArgs e)
        {
            double[] valores = new double[campos.Count];
            CultureInfo cultura = CultureInfo.GetCultureInfo("pt-BR");

            for (int i = 0; i < campos.Count; i++)
            {
                if (!double.TryParse(campos[i].Text,
                    NumberStyles.Float, cultura, out valores[i]) ||
                    double.IsNaN(valores[i]) ||
                    double.IsInfinity(valores[i]))
                {
                    MessageBox.Show("Preencha todos os campos com números válidos.");
                    campos[i].Focus();
                    return;
                }
            }

            double r;
            string unidade;

            switch (formula)
            {
                case "Velocidade Média":
                    if (valores[1] == 0)
                    {
                        MessageBox.Show("O tempo não pode ser zero.");
                        return;
                    }
                    r = valores[0] / valores[1];
                    unidade = "m/s";
                    break;

                case "Aceleração":
                    if (valores[2] == 0)
                    {
                        MessageBox.Show("O tempo não pode ser zero.");
                        return;
                    }
                    r = (valores[0] - valores[1]) / valores[2];
                    unidade = "m/s²";
                    break;

                case "Força":
                    r = valores[0] * valores[1];
                    unidade = "N";
                    break;

                case "Força de Atrito":
                    r = valores[0] * valores[1];
                    unidade = "N";
                    break;

                case "Peso":
                    r = valores[0] * valores[1];
                    unidade = "N";
                    break;

                case "Lei de Ohm":
                    r = valores[0] * valores[1];
                    unidade = "V";
                    break;

                default:
                    return;
            }

            resultado.Text = "Resultado: " +
                r.ToString("0.##", cultura) + " " + unidade;
        }
    }
}
