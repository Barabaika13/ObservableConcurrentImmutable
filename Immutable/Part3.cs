using System.Collections.Immutable;

namespace Immutable
{
    internal class Part3
    {
        public ImmutableList<string> Poem { get; private set; }

        public Part3()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> part)
        {
            Poem = part.Add("А это веселая птица-синица,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\n" +
                "В доме,\r\nКоторый построил Джек.");
            return Poem;
        }
    }
}
