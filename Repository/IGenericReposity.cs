namespace ComGa.Repository{
    public interface IGenericReposity<TEntity> where TEntity : class {
        public Task<bool> saveChange();
        public IEnumerable<TEntity> getAll();
        public TEntity? getByID(object primaryKey);
        public bool isExits(object primaryKey);
        //Modify function
        public Task add(TEntity entity);
        public Task update(TEntity entity);
        public Task delete(TEntity entity);        
    }
}