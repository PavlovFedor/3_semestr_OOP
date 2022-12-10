
namespace Unit
{
    class Programm
    {

        static void Main()
        {
            int[] n = { 2, 4, 2, 4, 5, 5, 3, 3, 4, 5, 5, 5, 1, 4, 6 };
            int[] m = { 2, 4, 6, 2, 1, 4, 1, 6, 1, 5, 3, 2, 3, 6, 1 };

            double total1 = 0f, total2 = 0f;

            Console.WriteLine("n");
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == 1)
                {
                    total1 += Math.PI / 7;// малый круг
                }
                if (n[i] == 2)
                {
                    total1 += Math.PI / 23;// средний круг
                }
                if (n[i] == 3)
                {
                    total1 += Math.PI / 31;//большой круг
                }
                if (n[i] == 4)
                {
                    total1 += (Math.Sqrt(3) / 2) * 19;//малый треугольник
                }
                if (n[i] == 5)
                {
                    total1 += (Math.Sqrt(3) / 2) * 28;//большой треугольник
                }
                if (n[i] == 6)
                {
                    total1 += 67;
                }
                Console.WriteLine(total1 + " " + n[i]);//прямоугольник
            }

                Console.WriteLine("Total: "+total1);
                Console.WriteLine("\n\nm");
                for (int j = 0; j < m.Length; j++)
                {
                    if (m[j] == 1)
                    {
                        total2 += Math.PI / 7;
                    }
                    if (m[j] == 2)
                    {
                        total2 += Math.PI / 23;
                    }
                    if (m[j] == 3)
                    {
                        total2 += Math.PI / 31;
                    }
                    if (m[j] == 4)
                    {
                        total2 += (Math.Sqrt(3) / 2) * 19;
                    }
                    if (m[j] == 5)
                    {
                        total2 += (Math.Sqrt(3) / 2) * 28;
                    }
                    if (m[j] == 6)
                    {
                        total2 += 67;
                    }

                Console.WriteLine(total2+" " + m[j]);
            }
                Console.WriteLine("Total: "+total2);
        }
    }
}