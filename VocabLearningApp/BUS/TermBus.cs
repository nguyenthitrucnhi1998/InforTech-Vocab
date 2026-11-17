using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public class TermBus {
        private readonly DatabaseContext _context;
        public TermBus() {
            _context = clsGlobalVariables.DbContext;
        }

        public async Task<List<Term>> GetAllAsync() {
            return await _context.Terms.AsNoTracking()
                .Include(x => x.Lesson)
                .Include(x => x.Lesson.Chapter)
                .Include(x => x.Lesson.Chapter.Category)
                .OrderBy(x => x.Lesson.Chapter.Category.SortOrder)
                .ThenBy(x => x.Lesson.Chapter.SortOrder)
                .ThenBy(x => x.Lesson.SortOrder)
                //.ThenBy(x => x.Pronounce)
                //.ThenBy(x => x.Pronounce ?? "ゟ")
                .ThenBy(x => x.TermName ?? "ゟ")
                //.ThenBy(x => x.TermName)
                .ToListAsync();
        }
        public async Task<Term> GetByIdAsync(int id) {
            return await _context.Terms.AsNoTracking().FirstOrDefaultAsync(x => x.TermId == id);
        }
        public async Task<List<Term>> GetByMultiIdsAsync(List<int> ids) {
            return await _context.Terms.AsNoTracking().Where(x => ids.Contains(x.TermId)).ToListAsync();
        }
        public async Task<bool> InsertAsync(Term newObj) {
            _context.Terms.Add(newObj);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Term updateObj) {
            var objToUpdate = await _context.Terms.FirstOrDefaultAsync(x => x.TermId == id);
            if (objToUpdate == null) throw new KeyNotFoundException();
            objToUpdate.TermTypeId = updateObj.TermTypeId;
            objToUpdate.LessonId = updateObj.LessonId;
            objToUpdate.TermName = updateObj.TermName;
            objToUpdate.Pronounce = updateObj.Pronounce;
            objToUpdate.Meaning = updateObj.Meaning;
            objToUpdate.MetaData = updateObj.MetaData;
            objToUpdate.ImageData = updateObj.ImageData;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id) {
            var objToDelete = await _context.Terms.FirstOrDefaultAsync(x => x.TermId == id);
            if (objToDelete == null) throw new KeyNotFoundException();
            _context.Terms.Remove(objToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsExistRefAsync(int id) {
            return await _context.VocabBookDetails.AsNoTracking().Where(x => x.TermId == id).AnyAsync();
        }
        public async Task<string> GetTermPathAsync(int id) {
            var term = await _context.Terms.AsNoTracking().FirstOrDefaultAsync(x => x.TermId == id);
            if (term == null) throw new KeyNotFoundException();

            var categoryName = term.Lesson.Chapter.Category.CategoryName;
            var chapterName = term.Lesson.Chapter.ChapterName;
            var lessonName = term.Lesson.LessonName;
            var termName = term.TermName;

            var termPath = $"{categoryName} / {chapterName} / {lessonName} / {termName}";
            return termPath;
        }
    }
}
