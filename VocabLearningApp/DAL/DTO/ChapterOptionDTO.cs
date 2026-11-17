namespace VocabLearningApp.DAL.DTO {
    public class ChapterOptionDTO {
        public int ChapterId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ChapterSortOrder { get; set; }
        public string ChapterName { get; set; }
        public string ChapterPath { get; set; }
    }
}
