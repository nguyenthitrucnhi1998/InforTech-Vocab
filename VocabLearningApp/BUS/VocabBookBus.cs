using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.EntityModels;
using VocabLearningApp.GUI.Common;

namespace VocabLearningApp.BUS {
    public class VocabBookBus {
        private readonly DatabaseContext _context;
        public VocabBookBus() {
            _context = clsGlobalVariables.DbContext;
        }

        public async Task<List<VocabBook>> GetAllAsync() {
            return await _context.VocabBooks.AsNoTracking().OrderBy(x => x.CreatedDate).ToListAsync();
        }
        public async Task<VocabBook> GetByIdAsync(int id) {
            return await _context.VocabBooks.AsNoTracking().FirstOrDefaultAsync(x => x.VocabBookId == id);
        }
        public async Task<bool> InsertAsync(VocabBook newObj) {
            newObj.CreatedDate = DateTime.Now;
            _context.VocabBooks.Add(newObj);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, VocabBook updateObj) {
            var objToUpdate = await _context.VocabBooks.FirstOrDefaultAsync(x => x.VocabBookId == id);
            if (objToUpdate == null) throw new KeyNotFoundException();
            objToUpdate.VocabBookName = updateObj.VocabBookName;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id) {
            using var trans = _context.Database.BeginTransaction();
            try {
                var objToDelete = await _context.VocabBooks.FirstOrDefaultAsync(x => x.VocabBookId == id);
                if (objToDelete == null) throw new KeyNotFoundException();

                var objDetails = await _context.VocabBookDetails.Where(x => x.VocabBookId == id).ToListAsync();

                _context.VocabBookDetails.RemoveRange(objDetails);
                _context.VocabBooks.Remove(objToDelete);

                await _context.SaveChangesAsync();
                trans.Commit();
                return true;
            }
            catch {
                trans.Rollback();
                throw;
            }
        }
    }
}
