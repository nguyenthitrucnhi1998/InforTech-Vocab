using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public enum EnumTermType {
        FE = 1,
        AP = 2
    }

    public class TermTypeBus {
        private readonly DatabaseContext _context;
        public TermTypeBus() {
            _context = clsGlobalVariables.DbContext;
        }

        public async Task<List<TermType>> GetAllAsync() {
            return await _context.TermTypes.AsNoTracking().ToListAsync();
        }
    }
}
