namespace Core.Persistence.Repositories;

public class Entity
{
    // eğer Id guid,long vb. bir şeyse aşağıdakileri silebilirsin.Metodun içi boş kalsın.
    public int Id { get; set; }

    public Entity()
    {
    }

    public Entity(int id) : this()
    {
        Id = id;
    }
}