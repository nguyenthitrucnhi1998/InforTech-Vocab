using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VocabLearningApp.DAL.EntityModels {
    public partial class DatabaseContext : DbContext {
        public DatabaseContext()
            : base("name=DatabaseContext") {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<TermType> TermTypes { get; set; }
        public virtual DbSet<VocabBook> VocabBooks { get; set; }
        public virtual DbSet<VocabBookDetail> VocabBookDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
