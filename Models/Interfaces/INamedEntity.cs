﻿namespace BrandsService.Models.Interfaces;

public interface INamedEntity : IEntity
{
    string Name { get; set; }
}