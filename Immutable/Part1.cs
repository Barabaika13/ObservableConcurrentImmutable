using System.Collections.Immutable;

namespace Immutable
{
    internal class Part1
    {
        public ImmutableList<string> Poem { get; private set; }

        public Part1()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> part)
        {
            Poem = part.Add("Вот дом,\r\nКоторый построил Джек.");
            return Poem;
        }
    }
}
