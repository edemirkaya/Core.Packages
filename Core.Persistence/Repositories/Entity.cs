namespace Core.Persistence.Repositories;

public class Entity<TId>
{
    public TId Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }

    public Entity()
    {
        Id = default;

    }
    public Entity(TId id)
    {
        Id = id;
    }
}
