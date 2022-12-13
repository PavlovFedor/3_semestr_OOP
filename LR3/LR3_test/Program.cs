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
            public abstract void RequestExecution();

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
            public override void RequestExecution()
            {
                if (timerActiveMySQL)
                {
                    end = DateTime.Now;
                    ts = (end - start);
                    if (ts.TotalMilliseconds < 10001)
                    {
                        start = DateTime.Now;
                        Console.WriteLine("Запрос MySQL выполнен ");

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
            public override void RequestExecution()
            {
                if (timerActivePostgreSQL)
                {
                    end = DateTime.Now;
                    ts = (end - start);
                    if (ts.TotalMilliseconds < 10001)
                    {
                        start = DateTime.Now;
                        Console.WriteLine("Запрос PostgreSQL выполнен");
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

        static void Main()
        {
            var postgreSQL = new PostgreSQL { };
            var mysql = new Mysql { };

            Console.WriteLine("\nMySQL: q - подключиться, w - запрос, e - отключиться\n" +
                              "PostrgreSQL: r - подключиться, t - запрос, y - отключиться\nh - закрыть\n");
            while (true)
            {
                string? v = Console.ReadLine();
                switch (v)
                {
                    case "q": 
                        mysql.OpenConnection();
                        break;
                    case "w":
                        mysql.RequestExecution();
                        break;
                    case "e":
                        mysql.CloseConnection();
                        break;
                    case "r":
                        postgreSQL.OpenConnection();
                        break;
                    case "t":
                        postgreSQL.RequestExecution();
                        break;
                    case "y":
                        postgreSQL.CloseConnection();
                        break;
                    case "h":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }
    }
}