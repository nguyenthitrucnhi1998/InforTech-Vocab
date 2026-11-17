using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VocabLearningApp.DAL.EntityModels;

namespace VocabLearningApp.BUS {
    public class CategoryBus {
        private readonly DatabaseContext _context;
        public CategoryBus() {
            _context = new DatabaseContext();
        }

        public async Task<List<Category>> GetAllAsync() {
            return await _context.Categories.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();
        }
        public async Task<Category> GetByIdAsync(int id) {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == id);
        }
        public async Task<bool> InsertAsync(Category newObj) {
            _context.Categories.Add(newObj);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Category updateObj) {
            var objToUpdate = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (objToUpdate == null) throw new KeyNotFoundException();
            objToUpdate.SortOrder = updateObj.SortOrder;
            objToUpdate.CategoryName = updateObj.CategoryName;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id) {
            var objToDelete = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (objToDelete == null) throw new KeyNotFoundException();
            _context.Categories.Remove(objToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsExistRefAsync(int id) {
            return await _context.Chapters.AsNoTracking().Where(x => x.CategoryId == id).AnyAsync();
        }
    }
}
