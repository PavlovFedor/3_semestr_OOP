using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Threading;
using System.Threading.Channels;

namespace LR3_test
{
    // абстрактный класс фигуры
    abstract class DataBase
    {
        // открытие подключения
        public abstract string OpenConnection();
        // закрытие подключения
        public abstract string CloseConnection();
        // выполнение запроса
        public abstract string RequestExecution();

    }
    // производный класс прямоугольника
    class Mysql : DataBase
    {
        public Mysql()
        {
            //   Console.WriteLine($"Конструктор MySql вызван");
        }

        bool timerActiveMySQL = false;
        DateTime start = DateTime.Now;
        DateTime end = DateTime.Now;
        TimeSpan ts = TimeSpan.Zero;

        public override string OpenConnection()
        {
            timerActiveMySQL = true;
            start = DateTime.Now;
            return "Подключились к MySQL";
        }
        public override string RequestExecution()
        {
            if (timerActiveMySQL)
            {
                end = DateTime.Now;
                ts = (end - start);
                if (ts.TotalMilliseconds < 10001)
                {
                    start = DateTime.Now;
                    return "Запрос MySQL выполнен";

                }
                else
                {
                    timerActiveMySQL = false;
                    return "Связь оборвана. Прошло больше 10 секунд";
                }
            }
            else
                return "Сначало подключитесь к MySQL";

        }
        public override string CloseConnection()
        {
            if (timerActiveMySQL)
            {
                timerActiveMySQL = false;
                return "Отключились от MySQL";
            }
            else
                return "Сначало подключитесь к MySQL";

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
            //Console.WriteLine($"Конструктор PostgreSQL вызван");
        }
        public override string OpenConnection()
        {
            start = DateTime.Now;
            timerActivePostgreSQL = true;
            return "Подключились к PostgreSQL";
        }
        public override string RequestExecution()
        {
            if (timerActivePostgreSQL)
            {
                end = DateTime.Now;
                ts = (end - start);
                if (ts.TotalMilliseconds < 10001)
                {
                    start = DateTime.Now;
                    return "Запрос PostgreSQL выполнен";
                }
                else
                {
                    timerActivePostgreSQL = false;
                    return "Связь оборвана. Прошло больше 10 секунд";
                }
            }
            else
                return "Сначало подключитесь к PostgreSQL";
        }
        public override string CloseConnection()
        {
            if (timerActivePostgreSQL)
            {
                timerActivePostgreSQL = false;
                return "Отключились от PostgreSQL";
            }
            else
                return "Сначало подключитесь к PostgreSQL";
        }
    }

}