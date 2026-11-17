using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public class ChapterBus {
        private readonly DatabaseContext _context;
        public ChapterBus() {
            _context = clsGlobalVariables.DbContext;
        }

        public async Task<List<Chapter>> GetAllAsync() {
            return await _context.Chapters.AsNoTracking()
                .Include(x => x.Category)
                .OrderBy(x => x.Category.SortOrder)
                .ThenBy(x => x.SortOrder)
                .ToListAsync();
        }
        public async Task<Chapter> GetByIdAsync(int id) {
            return await _context.Chapters.AsNoTracking().FirstOrDefaultAsync(x => x.ChapterId == id);
        }
        public async Task<bool> InsertAsync(Chapter newObj) {
            _context.Chapters.Add(newObj);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Chapter updateObj) {
            var objToUpdate = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == id);
            if (objToUpdate == null) throw new KeyNotFoundException();
            objToUpdate.CategoryId = updateObj.CategoryId;
            objToUpdate.SortOrder = updateObj.SortOrder;
            objToUpdate.ChapterName = updateObj.ChapterName;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id) {
            var objToDelete = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == id);
            if (objToDelete == null) throw new KeyNotFoundException();
            _context.Chapters.Remove(objToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsExistRefAsync(int id) {
            return await _context.Lessons.AsNoTracking().Where(x => x.ChapterId == id).AnyAsync();
        }
    }
}
