using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleProject.Program;

namespace ConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter("horocropevivod.csv", HoroWriter(StreamReader()));
        }
        public struct DateGor
        {

            public int Day;
            public int Month;
            public int Year;

            public DateGor(int Day, int Month, int Year)
            {
                this.Day = Day;
                this.Month = Month;
                this.Year = Year;

            }


        }
        public static List<string> HoroWriter(List<DateGor> date)
        {
            List<string> horo = new List<string>();

            foreach (DateGor dateGor in date)
            {            
                if (dateGor.Day != 0 && dateGor.Month != 0)
                {
                   
                    if (dateGor.Month > 0 && dateGor.Month < 12)
                    {
                        int day = DateTime.DaysInMonth(DateTime.Now.Year, dateGor.Month);
                        if ((day > dateGor.Day && dateGor.Day > 0))
                        {

                            switch (dateGor.Month)
                            {
                                case 1: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 20 ? "Козерог;" : "Водолей;")); break;
                                // слева правда ложь, справа ложь
                                case 2: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 19 ? "Водолей;" : "Рыбы;")); break;
                                case 3: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 20 ? "Рыбы;" : "Овен;")); break;
                                case 4: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 20 ? "Овен;" : "Телец;")); break;
                                case 5: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 21 ? "Телец;" : "Близнецы;")); break;
                                case 6: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 21 ? "Близнецы;" : "Рак;")); break;
                                case 7: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 22 ? "Рак;" : "Лев;")); break;
                                case 8: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 23 ? "Лев;" : "Дева;")); break;
                                case 9: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 23 ? "Дева;" : "Весы;")); break;
                                case 10: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 23 ? "Весы;" : "Скорпион;")); break;
                                case 11: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 22 ? "Скорпион;" : "Стрелец;")); break;
                                case 12: horo.Add("Ваш знак зодиака - " + (dateGor.Day <= 23 ? "Стрелец;" : "Козерог;")); break;
                            }

                        }
                        else
                        {
                            horo.Add("Не определен знак зодиака;");
                        }
                    }
                    else
                    {
                        horo.Add("Не определен знак зодиака;");
                    }



                }
                else
                {
                    horo.Add("Не определен знак зодиака;");
                }
                if (dateGor.Year != 0)
                {
                    int data = dateGor.Year;
                    data = Convert.ToInt32(dateGor.Year);
                    data %= 12;
                    data++;

                    switch (data)
                    {
                        case 1: horo[horo.Count - 1] += "Обезьяна;"; break; // обращаемся по индексу к элементу листа
                        case 2: horo[horo.Count - 1] += "Петух;"; break;
                        case 3: horo[horo.Count - 1] += "Собака;"; break;
                        case 4: horo[horo.Count - 1] += "Кабан;"; break;
                        case 5: horo[horo.Count - 1] += "Крыса;"; break;
                        case 6: horo[horo.Count - 1] += "Бык;"; break;
                        case 7: horo[horo.Count - 1] += "Тигр;"; break;
                        case 8: horo[horo.Count - 1] += "Кролик;"; break;
                        case 9: horo[horo.Count - 1] += "Дракон;"; break;
                        case 10: horo[horo.Count - 1] += "Змея;"; break;
                        case 11: horo[horo.Count - 1] += "Лошадь;"; break;
                        case 12: horo[horo.Count - 1] += "Овца;"; break;

                    }
                }
                else
                {
                    if (horo.Count != 0)
                    {
                          horo[horo.Count - 1] += "По восточному календарю знак зодиака не определен;";
                    }
                    else
                    {
                        horo.Add("По восточному календарю знак зодиака не определен;");
                    }
                     
                }
            }
            

            return horo;
        }
        public static List<DateGor> StreamReader()
        {
            string path = "horocropeinput.csv";

            List<DateGor> date = new List<DateGor>();


            using (StreamReader sr = new StreamReader(path, Encoding.Default))  
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {
                        string[] s2 = s.Split(';');
                        int[] array = new int[3];
                        if (s2[2] != "" || s2[2] != " ")
                        {
                            try // есть значения в ячейке год
                            {
                                array[2] = Convert.ToInt32(s2[2]);

                            }
                            catch
                            {
                                array[2] = 0;
                            }
                        }
                        if ((s2[0] != "" || s2[0] != " ") && (s2[1] != "" || s2[1] != " "))
                        {
                            try // есть значения в двух первых ячейках
                            {
                                array[0] = Convert.ToInt32(s2[0]);
                                array[1] = Convert.ToInt32(s2[1]);
                            }
                            catch
                            {
                                array[0] = 0;
                                array[1] = 0;
                            }
                        }
                        // создали структуру и инициализировали ее в лист
                         DateGor date1 = new DateGor(array[0], array[1], array[2]);
                        date.Add(date1);
                    }
                    catch
                    {
                    }
                    Console.WriteLine(s);
                }
            }
            return date;
        }

        public static void StreamWriter(string path1, List<string> date)
        {
            using (StreamWriter sw = new StreamWriter(path1, true,  Encoding.GetEncoding(1251)))
            {
                foreach (string u in date)
                {
                    sw.WriteLine(u.ToString());
                }
            }
        }

    }
}
