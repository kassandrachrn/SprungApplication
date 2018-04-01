using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SprungGermanData;
using SprungGermanData.Interfaces;
using SprungGermanData.Models;

namespace SprungGermanServices
{
    public class WordService : IWords
    {
        private SprungDbContext _context;

        public WordService(SprungDbContext context)
        {
            _context = context;
        }

        public void AddWord(Word newWord)
        {
            _context.Add(newWord);
            _context.SaveChanges();
        }

        public IEnumerable<Word> GetAll()
        {
            return _context.Words;
        }

        public Word GetWordById(int id)
        {   
            return _context.Words.FirstOrDefault(word => word.Id == id);
        }
    }
}
