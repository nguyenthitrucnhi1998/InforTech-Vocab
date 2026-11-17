using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public class DictionaryBus {
        private readonly DatabaseContext _context;
        public DictionaryBus() {
            _context = clsGlobalVariables.DbContext;
        }

        public async Task<List<FlatTermDTO>> GetAllAsync(int? categoryId, int? chapterId, int? lessonId) {
            using var _context = new DatabaseContext();
            var query = _context.Terms.AsNoTracking()
                .Include(x => x.Lesson)
                .Include(x => x.Lesson.Chapter)
                .Include(x => x.Lesson.Chapter.Category)
                .AsQueryable();

            if (categoryId.HasValue) {
                query = query.Where(x => x.Lesson.Chapter.Category.CategoryId == categoryId);
            }
            if (chapterId.HasValue) {
                query = query.Where(x => x.Lesson.Chapter.ChapterId == chapterId);
            }
            if (lessonId.HasValue) {
                query = query.Where(x => x.LessonId == lessonId);
            }

            return await query.Select(x => new FlatTermDTO {
                TermId = x.TermId,
                TermTypeId = x.TermTypeId,

                CategoryId = x.Lesson.Chapter.Category.CategoryId,
                ChapterId = x.Lesson.Chapter.ChapterId,
                LessonId = x.LessonId,

                CategoryName = x.Lesson.Chapter.Category.CategoryName,
                ChapterName = x.Lesson.Chapter.ChapterName,
                LessonName = x.Lesson.LessonName,
                TermName = x.TermName,

                Pronounce = x.Pronounce,
                Meaning = x.Meaning
            })
            //.OrderBy(x => x.Pronounce ?? "ゟ")
            //.ThenBy(x => x.TermName)
            .OrderBy(x => x.TermName ?? "ゟ")
            .ToListAsync();
        }
    }
}
