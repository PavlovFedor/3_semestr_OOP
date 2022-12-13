namespace LR5_test
{
    class Interface
    {
        public double score = 0;

    }
    class AnswerOne : Interface
    {
        public  AnswerOne(string qua)
        {
            Console.WriteLine(qua);
            string a = Console.ReadLine();
            if (a == "q")
            {
                score++;
            }
        }
    }
    class AnswerMany : Interface
    {
       
        public AnswerMany(string qua, string ans)
        {
            double scoreForAns = 1.0/ans.Length;
            Console.WriteLine(qua);
            string userAns = Console.ReadLine();
            
            char[] ansToCharArray = ans.ToCharArray();
            char[] userAnsToCharArray = userAns.ToCharArray();

            for (int i = 0; i < ansToCharArray.Length; i++)//check answer
            {
                for (int j = 0; j < userAnsToCharArray.Length; j++)
                {
                    if(ansToCharArray[i] == userAnsToCharArray[j])
                    {
                        if (ansToCharArray[i] != '0')
                        {
                            score += scoreForAns; 
                        }
                    }
                }
            }
        }
    }
    class AnswerText : Interface
    {
        public AnswerText(string qua, string ans)
        {
            Console.WriteLine(qua);
            string a = Console.ReadLine();
            if (a == ans)
            {
                score+=2;
            }
        }
    }
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
}