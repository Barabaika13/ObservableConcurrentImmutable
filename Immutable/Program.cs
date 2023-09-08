using System.Collections.Immutable;

namespace Immutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImmutableList<string> poemCollection = ImmutableList<string>.Empty;
            Part1 part1 = new Part1();
            Part2 part2 = new Part2();
            Part3 part3 = new Part3();
            Part4 part4 = new Part4();
            Part5 part5 = new Part5();
            Part6 part6 = new Part6();
            Part7 part7 = new Part7();
            Part8 part8 = new Part8();
            Part9 part9 = new Part9();

            part1.AddPart(poemCollection);
            part2.AddPart(part1.Poem);
            part3.AddPart(part2.Poem);
            part4.AddPart(part3.Poem);
            part5.AddPart(part4.Poem);
            part6.AddPart(part5.Poem);
            part7.AddPart(part6.Poem);
            part8.AddPart(part7.Poem);
            part9.AddPart(part8.Poem);

            Console.WriteLine("Part 1: " + string.Join("\r\n", part1.Poem));
            Console.WriteLine("Part 2: " + string.Join("\r\n", part2.Poem));
            Console.WriteLine("Part 3: " + string.Join("\r\n", part3.Poem));
            Console.WriteLine("Part 4: " + string.Join("\r\n", part4.Poem));
            Console.WriteLine("Part 5: " + string.Join("\r\n", part5.Poem));
            Console.WriteLine("Part 6: " + string.Join("\r\n", part6.Poem));
            Console.WriteLine("Part 7: " + string.Join("\r\n", part7.Poem));
            Console.WriteLine("Part 8: " + string.Join("\r\n", part8.Poem));
            Console.WriteLine("Part 9: " + string.Join("\r\n", part9.Poem));
        } 
    }
}