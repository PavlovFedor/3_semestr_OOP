using LR3_test;
namespace LR3
{
    public partial class Form1 : Form
    {
        PostgreSQL postgreSQL = new PostgreSQL { };
        Mysql mysql = new Mysql { };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = mysql.OpenConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = mysql.RequestExecution();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = mysql.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = postgreSQL.OpenConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = postgreSQL.RequestExecution();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = postgreSQL.CloseConnection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    
}