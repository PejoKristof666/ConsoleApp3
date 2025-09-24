namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ManageMenu();
            }
        }

        static void ManageMenu()
        {
            WriteMenu();

            int num = GetNumber(1, 6);
            SwitchMenu(num);
            Console.ReadKey();
        }

        static void WriteMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Adatok listázása");
            Console.WriteLine("2. Adat létrehozásas");
            Console.WriteLine("3. Legnagyobb adat");
            Console.WriteLine("4. Legkisebb adat");
            Console.WriteLine("5. Adat törlése");
            Console.WriteLine("6. Kilépés");
        }

        static int GetNumber(int min = int.MinValue, int max = int.MaxValue)
        {
            Console.Write("Add meg a számot: ");
            string line = Console.ReadLine().Trim(' ',',','.');
            int result = 0;
            if (int.TryParse(line, out result))
            {
                if (result <= max && result >= min)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("A szám nem a megadott határértéken belül van"); 
                }
            }
            else
            {
                Console.WriteLine("Nem szám lett megadva");
            }
            result = GetNumber(min, max);
            return result;
            
        }   

        static void SwitchMenu(int num)
        {
            switch (num)
            {
                case 1: functionOne(); break;
                case 2: functionTwo(); break;
                case 3: functionThree(); break;
                case 4: functionFour(); break;
                case 5: functionFive(); break;
                case 6: functionSix(); break;
                default: Console.WriteLine("Hibás meneupont"); break;
            }
        }

        static void functionOne()
        {

        }
        static void functionTwo()
        {

        }
        static void functionThree()
        {

        }
        static void functionFour()
        {

        }
        static void functionFive()
        {

        }
        static void functionSix()
        {

        }
    }
}
