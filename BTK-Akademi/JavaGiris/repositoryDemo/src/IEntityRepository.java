public interface IEntityRepository<T extends IEntity> {
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
