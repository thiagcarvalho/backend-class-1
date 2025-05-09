﻿namespace PetShop.Manager.Persistence.DataModels
{
    public abstract class DataModelBase
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
