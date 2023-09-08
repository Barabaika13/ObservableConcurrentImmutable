using System.Collections.Immutable;

namespace Immutable
{
    internal class Part5
    {
        public ImmutableList<string> Poem { get; private set; }

        public Part5()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> part)
        {
            Poem = part.Add("Вот пес без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\n" +
                "Которая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.");
            return Poem;
        }
    }
}
