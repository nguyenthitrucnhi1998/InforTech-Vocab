using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public class LessonBus {
        private readonly DatabaseContext _context;
        public LessonBus() {
            _context = clsGlobalVariables.DbContext;
        }

        public async Task<List<Lesson>> GetAllAsync() {
            return await _context.Lessons.AsNoTracking()
                .Include(x => x.Chapter)
                .Include(x => x.Chapter.Category)
                .OrderBy(x => x.Chapter.Category.SortOrder)
                .ThenBy(x => x.Chapter.SortOrder)
                .ThenBy(x => x.SortOrder)
                .ToListAsync();
        }
        public async Task<Lesson> GetByIdAsync(int id) {
            return await _context.Lessons.AsNoTracking().FirstOrDefaultAsync(x => x.LessonId == id);
        }
        public async Task<bool> InsertAsync(Lesson newObj) {
            _context.Lessons.Add(newObj);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Lesson updateObj) {
            var objToUpdate = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == id);
            if (objToUpdate == null) throw new KeyNotFoundException();
            objToUpdate.ChapterId = updateObj.ChapterId;
            objToUpdate.SortOrder = updateObj.SortOrder;
            objToUpdate.LessonName = updateObj.LessonName;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id) {
            var objToDelete = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == id);
            if (objToDelete == null) throw new KeyNotFoundException();
            _context.Lessons.Remove(objToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsExistRefAsync(int id) {
            return await _context.Terms.AsNoTracking().Where(x => x.LessonId == id).AnyAsync();
        }
    }
}
