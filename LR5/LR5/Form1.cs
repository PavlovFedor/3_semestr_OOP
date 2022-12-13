using static System.Formats.Asn1.AsnWriter;

namespace LR5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double allScore = 0;
        private int count = 0;
        private void AnswerOne(string ans)
        {
            if(ans == "q")
            {
                allScore++;
            }
            richTextBox4.Text = "Score: " + allScore.ToString();
        }
        private void AnswerMany(string ans, string usAns)
        {
            double scoreForAns = 1.0 / ans.Length;
            char[] ansToCharArray = ans.ToCharArray();
            char[] userAnsToCharArray = usAns.ToCharArray();
            
            for (int i = 0; i < ansToCharArray.Length; i++)//check answer
            {
                for (int j = 0; j < userAnsToCharArray.Length; j++)
                {
                    if (ansToCharArray[i] == userAnsToCharArray[j])
                    {
                        allScore += scoreForAns;
                    }
                }
            }
            richTextBox4.Text = "Score: " + allScore.ToString();
        }
        private void AnswerText(string ans, string userAns)
        { 
            if(userAns == ans)
            {
                allScore += 2;
            }
            richTextBox4.Text = "Score: " + allScore.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            if (count == 1)
            {
                AnswerOne(textBox2.Text);
                richTextBox3.Text = "Who is animals?\nq-zebra, w-cat, e-zero, r-table";
            }
            if (count == 2)
            {
                AnswerMany("qw", textBox2.Text);
                richTextBox3.Text = "Arrange by magnification!\nq-elephant, w-cat, e-horse";
            }
            if (count == 3)
            {
                AnswerText("weq", textBox2.Text);
                richTextBox3.Text = "The End";
                richTextBox4.Text += "/4";
            }
            if (count > 3)
                richTextBox3.Text = "The End";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    /*
    class Program
    {
        static void Main()
        {
            double allScore = 0;
            AnswerOne z = new AnswerOne("5>4? \nq - yes, other - no");
            Console.WriteLine("Score in 1q : " + z.score);
            allScore += z.score;
            AnswerMany x = new AnswerMany("\nWho is animals?\nq-zebra, w-cat, e-zero, r-table", "qw");
            Console.WriteLine("Score in 2q : " + x.score);
            allScore += x.score;
            AnswerText c = new AnswerText("\nArrange by magnification!\nq-elephant, w-cat, e-horse", "weq");
            Console.WriteLine("Score in 2q : " + c.score);
            allScore += c.score;

            Console.WriteLine("Result: " + allScore);
        }
    }
    */
}