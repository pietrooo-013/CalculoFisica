namespace calculodefisica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Text = "Velocidade Média";
            button2.Text = "Aceleração";
            button3.Text = "Força";
            button4.Text = "Força de Atrito";
            button5.Text = "Peso";
            button6.Text = "Lei de Ohm";

            button1.Click += (s, e) =>
                new CalculadoraForm("Velocidade Média").ShowDialog();

            button2.Click += (s, e) =>
                new CalculadoraForm("Aceleração").ShowDialog();

            button3.Click += (s, e) =>
                new CalculadoraForm("Força").ShowDialog();

            button4.Click += (s, e) =>
                new CalculadoraForm("Força de Atrito").ShowDialog();

            button5.Click += (s, e) =>
                new CalculadoraForm("Peso").ShowDialog();

            button6.Click += (s, e) =>
                new CalculadoraForm("Lei de Ohm").ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
