namespace ConsoleApp3
{
    internal class Program
    {
        static ServerConnection server = new ServerConnection("http://localhost:3000");
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
            //Subject-re az összes
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

        static async Task SwitchMenu(int num)
        {
            switch (num)
            {
                case 1: await functionOne(); break;
                case 2: await functionTwo(); break;
                case 3: await functionThree(); break;
                case 4: await functionFour(); break;
                case 5: await functionFive(); break;
                case 6: functionSix(); break;
                default: Console.WriteLine("Hibás meneupont"); break;
            }
        }

        static async Task functionOne()
        {
            var subjects = await server.GetSubjects();
            foreach (var s in subjects)
            {
                Console.WriteLine($"{s.id}: {s.name}");
            }
        }
        static async Task functionTwo()
        {
            Console.Write("Add meg a tantárgy nevét: ");
            string name = Console.ReadLine();
            var message = await server.PostSubject(name);
        }
        static async Task functionThree()
        {
            var subject = await server.BiggestSubject();
            if (subject != null) Console.WriteLine($"Legnagyobb tantárgy: {subject.id} - {subject.name}");
            else Console.WriteLine("Nincs tantárgy");
        }
        static async Task functionFour()
        {
            var subject = await server.SmallestSubject();
            if (subject != null) Console.WriteLine($"Legkisebb tantárgy: {subject.id} - {subject.name}");
            else Console.WriteLine("Nincs tantárgy");
        }
        static async Task functionFive()
        {
            Console.Write("Add meg a törlendő tantárgy ID-ját: ");
            int id = GetNumber(1);
            var message = await server.DeleteSubject(id);
        }
        static void functionSix()
        {
            Console.WriteLine("Kilépés...");
            Environment.Exit(0);
        }
    }
}
