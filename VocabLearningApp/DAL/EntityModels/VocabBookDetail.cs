namespace VocabLearningApp.DAL.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VocabBookDetail")]
    public partial class VocabBookDetail
    {
        public int VocabBookDetailId { get; set; }

        public int? VocabBookId { get; set; }

        public int? TermId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        public virtual Term Term { get; set; }

        public virtual VocabBook VocabBook { get; set; }
    }
}
