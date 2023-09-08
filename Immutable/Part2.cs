using System.Collections.Immutable;

namespace Immutable
{
    internal class Part2
    {
        public ImmutableList<string> Poem { get; private set; }

        public Part2()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> part)
        {
            Poem = part.Add("А это пшеница,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.");
            return Poem;
        }
    }
}
