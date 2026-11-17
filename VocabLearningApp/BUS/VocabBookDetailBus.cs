using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public class VocabBookDetailBus {
        private readonly DatabaseContext _context;
        public VocabBookDetailBus() {
            _context = clsGlobalVariables.DbContext;
        }

        public async Task<List<FlatTermInVocabBookDetailDTO>> GetAllAsync(int vocabBookId) {
            return await _context.VocabBookDetails.AsNoTracking()
                .Include(x => x.Term)
                .Where(x => x.VocabBookId == vocabBookId)
                .OrderBy(x => x.CreatedDate)
                .Select(x => new FlatTermInVocabBookDetailDTO {
                    TermId = x.Term.TermId,
                    TermTypeId = x.Term.TermTypeId,

                    CategoryId = x.Term.Lesson.Chapter.Category.CategoryId,
                    ChapterId = x.Term.Lesson.Chapter.ChapterId,
                    LessonId = x.Term.LessonId,

                    CategoryName = x.Term.Lesson.Chapter.Category.CategoryName,
                    ChapterName = x.Term.Lesson.Chapter.ChapterName,
                    LessonName = x.Term.Lesson.LessonName,
                    TermName = x.Term.TermName,

                    Pronounce = x.Term.Pronounce,
                    Meaning = x.Term.Meaning,

                    CreatedDate = x.CreatedDate
                })
                .ToListAsync();
        }
        public async Task<bool> IsTermAleardyExistedInVocabBook(int vocabBookId, int termId) {
            var obj = await _context.VocabBookDetails.AsNoTracking().FirstOrDefaultAsync(x => x.VocabBookId == vocabBookId && x.TermId == termId);
            return obj != null;
        }
        public async Task<bool> InsertAsync(VocabBookDetail newObj) {
            newObj.CreatedDate = DateTime.Now;
            _context.VocabBookDetails.Add(newObj);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int vocabBookId, int termId) {
            var objToDelete = await _context.VocabBookDetails.FirstOrDefaultAsync(x => x.VocabBookId == vocabBookId && x.TermId == termId);
            if (objToDelete == null) throw new KeyNotFoundException();
            _context.VocabBookDetails.Remove(objToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
