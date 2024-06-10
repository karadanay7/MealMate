namespace LifeCoach.Domain;

public interface IModifiedByEntity
{
      DateTimeOffset? ModifiedOn { get; set; }
        string? ModifiedByUserId { get; set; }
}
