using System.Collections.Immutable;

namespace Immutable
{
    internal class Part6
    {
        public ImmutableList<string> Poem { get; private set; }

        public Part6()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> part)
        {
            Poem = part.Add("А это корова безрогая,\r\nЛягнувшая старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\n" +
                "Который пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\n" +
                "Который построил Джек.");
            return Poem;
        }
    }
}
