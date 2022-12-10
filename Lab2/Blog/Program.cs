
namespace Lab2
{
    class Programm
    {
        class Blog
        {
            private string title = "none", content = "none";
            private DateTime data = new DateTime();
            private double rating = 0;
            private List<Blog> blogList = new List<Blog>();
            public void Create(string title1, string content1, double rating1, DateTime data1)
            {
                Blog blog = new Blog();
                blog.title = title1;
                blog.content = content1;
                blog.rating = rating1;
                blog.data = data1;
                blogList.Add(blog);
            }
            public void Show()
            {
                foreach (Blog x in blogList)
                {
                    Console.WriteLine(x.title + "\t" + x.rating + "\t" + x.data);
                    Console.WriteLine(x.content + "\n");
                }
            }
            public void SortBlog()
            {
                Blog temp = new Blog();
                int  n = blogList.Count() ;
                for (int i = 0; i < n - 1; i++)
                {
                    
                    for (int j = i; j < n; j++)
                    {
                        if (blogList[i].rating < blogList[j].rating)
                        {
                            temp = blogList[i];
                            blogList[i] = blogList[j];
                            blogList[j] = temp;
                        }
                    }
                }
            }
        }
        static void Main()
        {
            Blog test = new Blog();
            DateTime dateTemp = new DateTime();

            dateTemp = new DateTime(2017, 8, 28, 12, 12, 59);
            test.Create("Три в ряд", "Игры в жанре головоломок, способные увлечь целиком своей простотой", 9.6, dateTemp);
            
            dateTemp = new DateTime(2018, 4, 20, 22, 2, 19);
            test.Create("Triple A Projects", "На них ушло слишком много сил, но это того стоило, а может ...", 9.5, dateTemp);

            dateTemp = new DateTime(2022, 9, 8, 9, 0, 0);
            test.Create("Frostpunk", "Навсегда останется в твоем сеердце", 10.0, dateTemp);
            
            test.Show();

            string nameB, contentB;
            int rateB;
            Console.WriteLine("Введите имя статьи:\n");
            nameB = Console.ReadLine();
            
            Console.WriteLine("Введите контент:\n");
            contentB = Console.ReadLine();
            
            Console.WriteLine("Введите рейтинг:\n");
            rateB = int.Parse(Console.ReadLine());

            dateTemp = DateTime.Now;

            test.Create(nameB,contentB,rateB,dateTemp);

            test.Show();

            Console.WriteLine("\n\n\n Sort: \n\n\n");

            test.SortBlog();

            test.Show();
        }
    }
}