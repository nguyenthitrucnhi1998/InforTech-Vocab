namespace VocabLearningApp.DAL.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Term")]
    public partial class Term
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Term()
        {
            VocabBookDetails = new HashSet<VocabBookDetail>();
        }

        public int TermId { get; set; }

        public int? TermTypeId { get; set; }

        public int? LessonId { get; set; }

        [StringLength(500)]
        public string TermName { get; set; }

        [StringLength(500)]
        public string Pronounce { get; set; }

        [StringLength(500)]
        public string Meaning { get; set; }

        public string MetaData { get; set; }

        public byte[] ImageData { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual TermType TermType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VocabBookDetail> VocabBookDetails { get; set; }
    }
}
