//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

////Vitalii, [04.11.2022 17:23]
//namespace ConsoleApp10
//{
//    internal class Program
//    {
//        static void Main()
//        {
//            List<ElectricityConsumption<char, double>> firstCompany
//                = new List<ElectricityConsumption<char, double>>();
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'a', 500, 3720));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'b', 500, 3490));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'c', 500, 3500.5));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'd', 500, 3520));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'e', 500, 3450));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'f', 500, 3450));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'g', 500, 3460.7));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'h', 550, 3470));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'i', 550, 3445));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'j', 550, 4020));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'k', 550, 4120.5));
//            firstCompany.Add(new ElectricityConsumption<char, double>("Буква", 'l', 550, 4500));
//            double first_sum = 0;
//            foreach (ElectricityConsumption<char, double> c in firstCompany)
//            {
//                first_sum += c.Electr();
//            }
//            Console.WriteLine($"Перше підтриємство за рік спожило електроенергії на суму {first_sum}");
//            List<ElectricityConsumption<string, double>> secondCompany =
//                new List<ElectricityConsumption<string, double>>();
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "січень", 650, 5620));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "лютий", 650, 5670.3));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "березень", 650, 5620));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "квітень", 650, 5790));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "травень", 650, 5890));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "червень", 650, 5550.2));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "липень", 650, 5405));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "серпень", 650, 5303));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "вересень", 700, 5505));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "жовтень", 700, 5623.1));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "листопад", 700, 5721));
//            secondCompany.Add(new ElectricityConsumption<string, double>("Слово", "грудень", 700, 5874));
//            double second_sum = 0;
//            foreach (ElectricityConsumption<string, double> c in secondCompany)
//            {
//                second_sum += c.Electr();
//            }
//            Console.WriteLine($"Друге підтриємство за рік спожило електроенергії на суму {second_sum}");
//            List<ElectricityConsumption<uint, uint>> thirdCompany =
//                new List<ElectricityConsumption<uint, uint>>();
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 1, 550, 5620));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 2, 550, 5620));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 3, 550, 5720));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 4, 550, 5520));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 5, 550, 5120));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 6, 550, 5320));

//            //Vitalii, [04.11.2022 17:23]

//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 7, 550, 5520));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 8, 550, 5820));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 9, 550, 5920));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 10, 550, 5220));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 11, 560, 5120));
//            thirdCompany.Add(new ElectricityConsumption<uint, uint>("Число", 12, 580, 5620));
//            double third_sum = 0;
//            foreach (ElectricityConsumption<uint, uint> c in thirdCompany)
//            {
//                third_sum += c.Electr();
//            }
//            Console.WriteLine($"Третє підтриємство за рік спожило електроенергії на суму {third_sum}");
//        }

//        class ElectricityConsumption<MonthType, ActualConsumptionType>
//        {
//            private string name;
//            public string Name
//            {
//                get { return name; }
//                set { name = value; }
//            }
//            private MonthType month;
//            public MonthType Month
//            {
//                get { return month; }
//                set
//                {
//                    month = SetMonth(value);
//                }
//            }
//            private double coefficient;
//            public double Coefficient
//            {
//                get { return coefficient; }
//                set { coefficient = value; }
//            }
//            private double perKilowatt;
//            public double PerKilowatt
//            {
//                get { return perKilowatt; }
//                set { perKilowatt = value; }
//            }
//            private double actualConsumption;
//            public double ActualConsumption
//            {
//                get { return actualConsumption; }
//                set { actualConsumption = value; }
//            }

//            public ElectricityConsumption(string _name, MonthType _month,
//                double per, double actual)
//            {
//                Name = _name;
//                Month = _month;
//                PerKilowatt = per;
//                ActualConsumption = actual;
//            }

//            public void Print()
//            {
//                Console.WriteLine($"Підприємство {Name} в місяці" +
//                    $" {Month} спожило {ActualConsumption} кіловат" +
//                    $" з коефіцієнтом {Coefficient} і ціною {Electr()}");
//            }

//            public double Electr()
//            {
//                if (ActualConsumption < 5000)
//                {
//                    return Coefficient * PerKilowatt * ActualConsumption;
//                }
//                else
//                {
//                    return 1.3 * Coefficient * PerKilowatt * ActualConsumption;
//                }
//            }

//            //Vitalii, [04.11.2022 17:23]


//            private MonthType SetMonth(MonthType value)
//            {
//                Type t = typeof(MonthType);
//                object o = (object)value;
//                uint season = 0;
//                if (t == typeof(uint) && (uint)o >= 1 && (uint)o <= 12)
//                {
//                    if ((uint)o == 12 || (uint)o == 1 || (uint)o == 2)
//                    {
//                        season = 1;
//                    }
//                    if ((uint)o >= 3 && (uint)o <= 5)
//                    {
//                        season = 2;
//                    }
//                    if ((uint)o >= 6 && (uint)o <= 8)
//                    {
//                        season = 3;
//                    }
//                    if ((uint)o >= 9 && (uint)o <= 11)
//                    {
//                        season = 4;
//                    }
//                }
//                else if (t == typeof(char) && (char)o >= 'a' && (char)o <= 'l')
//                {
//                    if ((char)o == 'l' || (char)o == 'a' || (char)o == 'b')
//                    {
//                        season = 1;
//                    }
//                    if ((char)o >= 'c' && (char)o <= 'e')
//                    {
//                        season = 2;
//                    }
//                    if ((char)o >= 'f' && (char)o <= 'h')
//                    {
//                        season = 3;
//                    }
//                    if ((char)o >= 'i' && (char)o <= 'k')
//                    {
//                        season = 4;
//                    }
//                }
//                else if (t == typeof(string))
//                {
//                    if ((string)o == "грудень" || (string)o == "січень" || (string)o == "лютий")
//                    {
//                        season = 1;
//                    }
//                    if ((string)o == "березень" || (string)o == "квітень" || (string)o == "травень")
//                    {
//                        season = 2;
//                    }
//                    if ((string)o == "червень" || (string)o == "липень" || (string)o == "серпень")
//                    {
//                        season = 3;
//                    }
//                    if ((string)o == "вересень" || (string)o == "жовтень" || (string)o == "листопад")
//                    {
//                        season = 4;
//                    }
//                }
//                else
//                {
//                    throw new Exception("Неправильний тип або номер місяця.");
//                }
//                switch (season)
//                {
//                    case 1:
//                        this.Coefficient = 2;
//                        break;
//                    case 2:
//                        this.Coefficient = 1.5;
//                        break;
//                    case 3:
//                        this.Coefficient = 1;
//                        break;
//                    case 4:
//                        this.Coefficient = 1.5;
//                        break;
//                    default:
//                        throw new Exception("Неправильна пора року. Ймовірно місяць введено неправильно.");
//                }
//                return value;
//            }
//        }
//    }
//}