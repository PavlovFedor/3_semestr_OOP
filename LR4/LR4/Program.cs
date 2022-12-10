using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Threading;
using System.Threading.Channels;

namespace LR2
{
    class Programm
    {
        // абстрактный класс фигуры
        abstract class DataBase
        {
            // открытие подключения
            public abstract void OpenConnection();
            // закрытие подключения
            public abstract void CloseConnection();
            // выполнение запроса
            public abstract void RequestExecution(string s);

        }
        // производный класс прямоугольника
        class Mysql : DataBase
        {
            public Mysql()
            {
                Console.WriteLine($"Конструктор MySql вызван");
            }

            bool timerActiveMySQL = false;
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            TimeSpan ts = TimeSpan.Zero;

            public override void OpenConnection()
            {
                timerActiveMySQL = true;
                start = DateTime.Now;
                Console.WriteLine("Подключились к MySQL");
            }
            public override void RequestExecution(string s)
            {
                if (timerActiveMySQL)
                {
                    end = DateTime.Now;
                    ts = (end - start);
                    if (ts.TotalMilliseconds < 10001)
                    {
                        start = DateTime.Now;
                        Console.WriteLine("Запрос MySQL выполнен ");
                        Console.WriteLine("Отправлен запрос: " + s);
                    }
                    else
                    {
                        Console.WriteLine("Связь оборвана. Прошло больше 10 секунд");
                        timerActiveMySQL = false;

                    }
                }
                else
                    Console.WriteLine("Сначало подключитесь к MySQL");

            }
            public override void CloseConnection()
            {
                if (timerActiveMySQL)
                {
                    Console.WriteLine("Отключились от MySQL");
                    timerActiveMySQL = false;
                }
                else
                    Console.WriteLine("Сначало подключитесь к MySQL");

            }
            
        }
        class PostgreSQL : DataBase
        {

            bool timerActivePostgreSQL = false;
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            TimeSpan ts = TimeSpan.Zero;
            public PostgreSQL()
            {
                Console.WriteLine($"Конструктор PostgreSQL вызван");
            }
            public override void OpenConnection()
            {
                start = DateTime.Now;
                timerActivePostgreSQL = true;
                Console.WriteLine("Подключились к PostgreSQL");
            }
            public override void RequestExecution(string s)
            {
                if (timerActivePostgreSQL)
                {
                    end = DateTime.Now;
                    ts = (end - start);
                    if (ts.TotalMilliseconds < 10001)
                    {
                        start = DateTime.Now;
                        Console.WriteLine("Запрос PostgreSQL выполнен");
                        Console.WriteLine("Отправлен запрос: " + s);
                    }
                    else
                    {
                        Console.WriteLine("Связь оборвана. Прошло больше 10 секунд");
                        timerActivePostgreSQL = false;
                    }
                }
                else
                    Console.WriteLine("Сначало подключитесь к PostgreSQL");
            }
            public override void CloseConnection()
            {
                if (timerActivePostgreSQL)
                {
                    Console.WriteLine("Отключились от PostgreSQL");
                    timerActivePostgreSQL = false;
                }
                else
                    Console.WriteLine("Сначало подключитесь к PostgreSQL");
            }
        }

        class Request
        {
            string lastReq;
            public Request(Mysql db, string s)
            {
                Console.WriteLine("Вызов конструктора класса запросов");
            }
            public Request(PostgreSQL db, string s)
            {
                Console.WriteLine("Вызов конструктора класса запросов");
            }
            public void RequestDB(Mysql db, string s)
            {
                bool flag = true;
                while (flag)
                {
                    RequestSend(db, s);
                    Console.WriteLine("\nПовторить запрос? q-да, остальное нет");
                    string n = Console.ReadLine();
                    if(n == "q")
                        flag = true;
                    else
                        flag = false;
                }
            }
            public void RequestDB(PostgreSQL db, string s)
            {
                bool flag = true;
                while (flag)
                {
                    RequestSend(db, s);
                    Console.WriteLine("\nПовторить запрос? q-да, остальное нет");
                    string n = Console.ReadLine();
                    if (n == "q")
                        flag = true;
                    else
                        flag = false;
                }
            }
            public void RequestSend(Mysql db, string s)
            {
                Console.WriteLine("Изменить текст перед отправкой? q - отказ, остальное изменит");
                string n = Console.ReadLine();
                if (n != null)
                {
                    if (n != "q")
                        s = n;
                    db.OpenConnection();
                    db.RequestExecution(s);
                    lastReq = s;
                    db.CloseConnection();
                }
                else
                {
                    Console.WriteLine("Введено null");
                    Environment.Exit(0);
                }
            }
            public void RequestSend(PostgreSQL db, string s)
            {
                Console.WriteLine("Изменить текст перед отправкой? q - отказ, остальное изменит");
                string n = Console.ReadLine();
                if (n != null)
                {
                    if (n != "q")
                        s = n;
                    db.OpenConnection();
                    db.RequestExecution(s);
                    lastReq = s;
                    db.CloseConnection();
                }
                else
                {
                    Console.WriteLine("Введено null");
                    Environment.Exit(0);
                }
            }
        }


        static void Main()
        {
            var postgreSQL = new PostgreSQL { };
            var mysql = new Mysql { };

            Console.WriteLine("Введите запрос для обоих БД, его можно будет изменить");
            string r = Console.ReadLine();

            var req = new Request(postgreSQL, r);

            req.RequestDB(postgreSQL, r);
            req.RequestDB(mysql, r);

        }
    }
}