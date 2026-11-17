namespace VocabLearningApp.DAL.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VocabBook")]
    public partial class VocabBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VocabBook()
        {
            VocabBookDetails = new HashSet<VocabBookDetail>();
        }

        public int VocabBookId { get; set; }

        [StringLength(500)]
        public string VocabBookName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VocabBookDetail> VocabBookDetails { get; set; }
    }
}
