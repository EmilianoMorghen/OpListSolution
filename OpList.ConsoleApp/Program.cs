namespace OpList.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            OpList<int> opList = new OpList<int>(5);
            opList.Add(1);
            opList.Add(2);
            opList.Add(3);

            Console.WriteLine("Lista completa " + opList);

            opList.Add(1, 4);
            Console.WriteLine("Add at 1 value 4 " + opList);

            opList.Add(-1, 6);
            Console.WriteLine("Add at -1 value 6 " + opList);

            Console.WriteLine("Print list[2] " + opList[2]);

            opList[2] = 10;
            Console.WriteLine("Replacte list[2] " + opList);

            opList[-1] = 11;
            Console.WriteLine("Assegnazione con indice negativo -1 value 11 " + opList);

            opList.Remove(0);
            Console.WriteLine("Rimuovi il primo " + opList);

            foreach(int i in opList)
            {
                Console.WriteLine(i);
            }

            foreach(bool i in opList.Select(i => i == 3)){
                Console.WriteLine(i);
            }

            OpList<string> stringList = new OpList<string>("ciao mamma");

            stringList.Add("sono un bravo programmatore");
            stringList.Add(-1, "faccio cose strane");

            Console.WriteLine(stringList);

            stringList[-2] = "OH MY D:";
            Console.WriteLine(stringList);
        }
    }
}