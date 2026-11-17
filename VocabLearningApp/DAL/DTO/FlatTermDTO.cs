using System;

namespace VocabLearningApp.DAL.DTO {
    public class FlatTermDTO {
        public int TermId { get; set; }
        public int? TermTypeId { get; set; }
        public int? CategoryId { get; set; }
        public int? ChapterId { get; set; }
        public int? LessonId { get; set; }

        public string CategoryName { get; set; }
        public string ChapterName { get; set; }
        public string LessonName { get; set; }
        public string TermName { get; set; }
        
        public string Pronounce { get; set; }
        public string Meaning { get; set; }
    }

    public class FlatTermInVocabBookDetailDTO : FlatTermDTO {
        public DateTime? CreatedDate { get; set; }
    }
}
