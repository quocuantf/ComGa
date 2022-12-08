using ComGa.Data;
using Microsoft.EntityFrameworkCore;
namespace ComGa.Repository {
    public class GenericRepository<TEntity> : IGenericReposity<TEntity> where TEntity : class {
        private readonly ComGaContext _conetxt;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(ComGaContext context) {
            _conetxt = context;
            _dbSet = context.Set<TEntity>();
        } 

        public async Task add(TEntity entity) {
            _dbSet.Add(entity);
            await _conetxt.SaveChangesAsync();
        }

        public async Task delete(TEntity entity) {
            _dbSet.Remove(entity);
            await _conetxt.SaveChangesAsync();
        }

        public async Task update(TEntity entity) {
            _dbSet.Update(entity);
            await _conetxt.SaveChangesAsync();
            // throw new NotImplementedException();
        }

        public IEnumerable<TEntity> getAll() {
            return _dbSet.ToList();
        }

        public TEntity? getByID(object primaryKey) {
            return _dbSet.Find(primaryKey);
            
        }

        public bool isExits(object primaryKey) {
            var result = _dbSet.Find(primaryKey);
            return result == null ? false : true;
        }

        public async Task<bool> saveChange() {
            try {
                await _conetxt.SaveChangesAsync();
                return true;
            } 
            catch {
                return false;
            }
        }


    }
}