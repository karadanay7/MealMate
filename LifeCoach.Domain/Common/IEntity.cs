﻿namespace LifeCoach.Domain;

public interface IEntity<TKey>
{
       public TKey Id { get; set; }

}
