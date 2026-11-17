namespace VocabLearningApp.DAL.DTO {
    public class LessonOptionDTO {
        public int LessonId { get; set; }
        public int ChapterId { get; set; }
        public string CategoryName { get; set; }
        public string ChapterName { get; set; }
        public int LessonSortOrder { get; set; }
        public string LessonName { get; set; }
        public string LessonPath { get; set; }
    }
}
