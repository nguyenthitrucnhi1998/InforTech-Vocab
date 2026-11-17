using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.DTO;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public enum EnumDataSourceType {
        FromLearningData = 1,
        FromVocabBook = 2
    }

    public class DataSourceBus {
        private readonly DatabaseContext _context;
        private const string ROOT_NODE_ID = "0";
        private const string ROOT_NODE_PARENT_ID = "";

        public DataSourceBus() {
            _context = clsGlobalVariables.DbContext;
        }

        private TreeNodeDTO RootNode() {
            return new TreeNodeDTO {
                Id = ROOT_NODE_ID,
                ParentId = ROOT_NODE_PARENT_ID,
                Name = "(-- Select All --)",
            };
        }

        public async Task<List<TreeNodeDTO>> GetTreeDataToLessons() {
            var dataCategory = await _context.Categories.AsNoTracking().ToListAsync();
            var dataChapter = await _context.Chapters.AsNoTracking().ToListAsync();
            var dataLesson = await _context.Lessons.AsNoTracking().ToListAsync();
            List<TreeNodeDTO> result = new();
            result.Add(RootNode());

            foreach (var iCategory in dataCategory) {
                var nodeCategory = new TreeNodeDTO {
                    Id = $"{ROOT_NODE_ID}.{iCategory.CategoryId}",
                    ParentId = ROOT_NODE_ID,
                    Name = iCategory.CategoryName,
                };
                result.Add(nodeCategory);

                foreach (var iChapter in dataChapter.Where(x => x.CategoryId == iCategory.CategoryId)) {
                    var nodeChapter = new TreeNodeDTO {
                        Id = $"{nodeCategory.Id}.{iChapter.ChapterId}",
                        ParentId = nodeCategory.Id,
                        Name = iChapter.ChapterName,
                    };
                    result.Add(nodeChapter);

                    foreach (var iLesson in dataLesson.Where(x => x.ChapterId == iChapter.ChapterId)) {
                        var nodeLesson = new TreeNodeDTO {
                            Id = $"{nodeChapter.Id}.{iLesson.LessonId}",
                            ParentId = $"{nodeChapter.Id}",
                            Name = iLesson.LessonName,
                        };
                        result.Add(nodeLesson);
                    }
                }
            }
            return result;
        }

        public async Task<List<TreeNodeDTO>> GetTreeDataToVocabBooks() {
            var data = await _context.VocabBooks.AsNoTracking().OrderBy(x => x.CreatedDate).ToListAsync();
            List<TreeNodeDTO> result = new();
            result.Add(RootNode());

            foreach (var item in data) {
                var node = new TreeNodeDTO {
                    Id = $"{ROOT_NODE_ID}.{item.VocabBookId}",
                    ParentId = ROOT_NODE_ID,
                    Name = item.VocabBookName,
                };
                result.Add(node);
            }
            return result;
        }

        public async Task<List<FlatTermDTO>> GetTermsBySelectedLessons(List<int> lessonIds) {
            return await _context.Terms
                .AsNoTracking()
                .Where(x => lessonIds.Contains((int)x.LessonId))
                .Select(x => new FlatTermDTO {
                    TermId = x.TermId,
                    TermTypeId = x.TermTypeId,
                    TermName = x.TermName,
                    Pronounce = x.Pronounce,
                    Meaning = x.Meaning
                })
                .ToListAsync();
        }

        public async Task<List<FlatTermDTO>> GetTermsBySelectedVocabBooks(List<int> vocabBookIds) {
            var termIds = await _context.VocabBookDetails
                .AsNoTracking()
                .Where(x => vocabBookIds.Contains((int)x.VocabBookId))
                .Select(x => (int)x.TermId)
                .Distinct()
                .ToListAsync();

            return await _context.Terms
                .AsNoTracking()
                .Where(x => termIds.Contains(x.TermId))
                .Select(x => new FlatTermDTO {
                    TermId = x.TermId,
                    TermTypeId = x.TermTypeId,
                    TermName = x.TermName,
                    Pronounce = x.Pronounce,
                    Meaning = x.Meaning
                })
                .ToListAsync();
        }

        public static void Shuffle<T>(IList<T> list) {
            var rng = new Random();
            for (int i = list.Count - 1; i > 0; i--) {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
