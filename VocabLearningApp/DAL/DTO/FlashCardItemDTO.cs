namespace VocabLearningApp.DAL.DTO {
    public class FlashCardItemDTO {
        public int TermId { get; set; }
        public string FrontText { get; set; } // TermName
        public string BackText { get; set; } // Meaning
        public string Pronounce { get; set; }
    }
}
