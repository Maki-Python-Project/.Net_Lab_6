using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            ConsoleKey consoleKey;
            DateTime now = DateTime.Now;
            if (now.DayOfWeek != DayOfWeek.Sunday)
            {
                Console.WriteLine("Boy's name: ");
                string nameBoy = Console.ReadLine();

                Console.WriteLine("Boy's patronymic: ");
                string lastnameBoy = Console.ReadLine();

                Console.WriteLine("Girl's name: ");
                string nameGirl = Console.ReadLine();

                Console.WriteLine("Girl's patronymic: ");
                string lastnameGirl = Console.ReadLine();

                Human[] humans ={ new Student(nameBoy, lastnameBoy), new Botan(nameBoy, lastnameBoy), new Girl(nameGirl, lastnameGirl), new PrettyGirl(nameGirl, lastnameGirl), new SmartGirl(nameGirl, lastnameGirl) };

                do
                {
                    Random random = new Random();
                    var firstIndex = random.Next(humans.Length);
                    var secondIndex = random.Next(humans.Length);

                    
                    Console.WriteLine($"\nFirst human: {humans[firstIndex].GetType().GetProperty("Name").GetValue(humans[firstIndex])}\n");
                    Console.WriteLine($"Second human: {humans[secondIndex].GetType().GetProperty("Name").GetValue(humans[secondIndex])}\n");
                    if(Human.CheckCouple(humans[firstIndex], humans[secondIndex])){
                        Console.WriteLine("The sex of both people coincides");
                    }
                    else
                    {
                        IHasName child = Human.Couple(humans[firstIndex], humans[secondIndex]);
                        if (child != null)
                        {
                            Console.WriteLine($"\nName: {child.GetType().GetProperty("Name")?.GetValue(child)}");
                            Console.WriteLine($"Surname: {child.GetType().GetProperty(nameof(Human.Lastname))?.GetValue(child)}");
                            Console.WriteLine($"Child Type: {child}");
                        }
                        
                    }
                    consoleKey = Console.ReadKey(false).Key;
                } while (consoleKey != ConsoleKey.F10 && consoleKey != ConsoleKey.Q && consoleKey.ToString() != "q");
            }
            else
            {
                Console.WriteLine("Today's sunday!");
            }
        }
    }
}
