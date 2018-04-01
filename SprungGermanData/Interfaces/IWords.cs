using System.Collections.Generic;

namespace SprungGermanData.Interfaces
{
    public interface IWords
    {
        IEnumerable<Word> GetAll();
        Word GetWordById(int id);
        void AddWord(Word newWord);
    }
}