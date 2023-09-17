using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Task_3();
            p.Task_4();
            p.Task_5();
            p.Task_6();
            p.Task_7();
            Console.ReadKey();
        }

        /*
              Пользователь вводит с клавиатуры четыре цифры.
        Необходимо создать число, содержащее эти цифры. Например, 
        если с клавиатуры введено 1, 5, 7, 8 тогда нужно
        сформировать число 1578.
         */
        public void Task_3()
        {
            Console.WriteLine("Task 3.");
            int number;
            string str;
            string result="";

            do
            {
                str = "";
                Console.Write("Введите цифру: ");
                str = Console.ReadLine();
                result += str;
            } while (str.Length != 0);
            number = Convert.ToInt32(result);

            Console.WriteLine("Результат: " + number);
        }

        /*
            Пользователь вводит шестизначное число. После чего
        пользователь вводит номера разрядов для обмена цифр.
        Например, если пользователь ввёл один и шесть — это
        значит, что надо обменять местами первую и шестую
        цифры.
        Число 723895 должно превратиться в 523897.
        Если пользователь ввел не шестизначное число требуется
        вывести сообщение об ошибке.
        */
        public void Task_4()
        {
            Console.WriteLine("\nTask 4.");
            int number;
            Console.Write("Введите шестизначное число: ");
            string str = Console.ReadLine();
            number = Convert.ToInt32(str);
            if(number > 99999 && number < 1000000)
            {
                int dig1;
                int dig2;
                bool first = true;
                do {
                    if (!first)
                    {
                        Console.WriteLine("Ошибка ввода. Выход за границы диапазона.");
                    }
                    first = false;
                    Console.Write("Введите номер цифры в числе: ");
                    dig1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите номер цифры в числе: ");
                    dig2 = Convert.ToInt32(Console.ReadLine());
                } while (dig1 < 1 || dig1 > 6 || dig2 < 1 || dig2 > 6);
                
                string dig1_;
                string dig2_;
                dig1_ = str.Substring(dig1 - 1, 1);
                dig2_ = str.Substring(dig2 - 1, 1);
                str = str.Remove(dig1-1, 1);
                str = str.Insert(dig1-1, dig2_);
                str = str.Remove(dig2-1, 1);
                str = str.Insert(dig2-1, dig1_);
                number = Convert.ToInt32(str);
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Введённое число не шестизначное!");
            }

        }

        /*
            Пользователь вводит с клавиатуры дату. 
        Приложение должно отобразить название сезона и дня недели.
        Например, если введено 22.12.2021, приложение должно
        отобразить Winter Wednesday.
        */
        private void Task_5()
        {
            Console.WriteLine("\nTask 5.");
            Console.Write("Введите дату в формате ДД.ММ.ГГ: ");
            string Date = Console.ReadLine();
            char Separator = '.';
            string[] words = Date.Split('.');
            int day = Convert.ToInt32(words[0]);
            int month = Convert.ToInt32(words[1]);
            int year = Convert.ToInt32(words[2]);
            DateTime someDate = new DateTime(year, month, day);
            if(month > 0 && month < 3)
            {
                Console.WriteLine("Winter " + someDate.DayOfWeek);
            }else if (month > 2 && month < 6)
            {
                Console.WriteLine("Spring " + someDate.DayOfWeek);
            }else if (month > 5 && month < 9)
            {
                Console.WriteLine("Summer " + someDate.DayOfWeek);
            }else if(month > 8 && month < 13)
            {
                Console.WriteLine("Autumn " + someDate.DayOfWeek);
            }
           

        }

        /*
            Пользователь вводит с клавиатуры показания температуры. 
         В зависимости от выбора пользователя программа переводит 
         температуру из Фаренгейта в Цельсий или наоборот.
        */
        private void Task_6()
        {
            Console.WriteLine("\nTask 6.");
            Console.Write("Введите значение температуры c указанием единицы измерения (С/F): ");
            string temperature = Console.ReadLine();
            
            if(temperature.IndexOf('C')  >= 0) 
            {
                temperature = temperature.Trim('C');
                double temp = Convert.ToDouble(temperature);
                double TempFahrengeit = temp * 1.8 + 32;
                Console.WriteLine("Значение введённой температуры в градусах Фаренгейта будет равно: " + TempFahrengeit + " F");
            }
            else if(temperature.IndexOf('F')  >= 0)
            {
                temperature = temperature.Trim('F');
                double temp = Convert.ToDouble(temperature);
                double TempCelsius = (temp - 32)/1.8;
                Console.WriteLine("Значение введённой температуры в градусах Цельсия будет равно: " + TempCelsius + " C");
            }
            else
            {
                Console.WriteLine("Ошибка ввода.");
            }
        }


        /*
            Пользователь вводит с клавиатуры два числа. Нужно
        показать все четные числа в указанном диапазоне. Если
        границы диапазона указаны неправильно требуется произвести 
        нормализацию границ. Например, пользователь ввел 20 и 11, 
        требуется нормализация, после которой начало диапазона 
        станет равно 11, а конец 20.
        */
        private void Task_7()
        {
            Console.WriteLine("\nTask 7.");
            Console.Write("Введите два числа, обозначающие границу диапазона: ");
            string num = Console.ReadLine();
            int num_1 = Convert.ToInt32(num);
            num = Console.ReadLine();
            int num_2 = Convert.ToInt32(num);
            if(num_1 > num_2)
            {
                int tmp = num_1;
                num_1 = num_2;
                num_2 = tmp;
            }
            for(int i = num_1; i <= num_2; i++)
            {
               
                if((i&1) != 1)
                {
                    if(i == num_2 || i == num_2 - 1)
                    {
                        Console.Write(i + "\n");
                        continue;
                    }
                    Console.Write(i + ", ");
                }
            }
            
        }

    }


}
