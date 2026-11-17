namespace VocabLearningApp.DAL.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TermType")]
    public partial class TermType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TermType()
        {
            Terms = new HashSet<Term>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermTypeId { get; set; }

        [StringLength(500)]
        public string TermTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Term> Terms { get; set; }
    }
}
