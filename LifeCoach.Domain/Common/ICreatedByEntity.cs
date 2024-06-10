namespace LifeCoach.Domain;

public interface ICreatedByEntity
{
         DateTimeOffset CreatedOn { get; set; }
        string CreatedByUserId { get; set; }

}
