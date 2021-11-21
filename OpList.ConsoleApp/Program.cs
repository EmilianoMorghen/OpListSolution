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

            Console.WriteLine(opList.ToString());

            opList.Add(1, 4);
            Console.WriteLine(opList.ToString());

            opList.Add(-1, 6);
            Console.WriteLine(opList.ToString());

            Console.WriteLine(opList[2].ToString());

            opList[2] = 10;
            Console.WriteLine(opList.ToString());

            opList[-1] = 11;
            Console.WriteLine(opList.ToString());

            opList.Remove(0);
            Console.WriteLine(opList.ToString());

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

            Console.WriteLine(stringList.ToString());

            stringList[-2] = "OH MY D:";
            Console.WriteLine(stringList);
        }
    }
}