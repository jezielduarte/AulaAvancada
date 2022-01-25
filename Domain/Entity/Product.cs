using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Product
    {
        public Product(string reference, string decription, decimal price)
        {
            Reference = reference;
            Decription = decription;
            Price = price;
            Errors = new List<BrokenRoles>();
        }

        public Guid Id { get; protected set; }

        public string Reference { get; protected set; }

        public string Decription { get; protected set; }

        public decimal Price { get; protected set; }

        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void SetProduct(string description, decimal price)
        {
            Decription = description;
            Price = price;
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new BrokenRoles(property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }

        public void ReleaseSave()
        {

            if (string.IsNullOrEmpty(Reference))
                AddError(nameof(Reference), "Reference can not null");

            if (Reference.Length < 3)
                AddError(nameof(Reference), "put at least 3 characters");

        }
        public void ReleaseUpdate()
        {
            if (string.IsNullOrEmpty(Reference))
                AddError(nameof(Reference), "Reference can not null");

            if (Reference.Length < 3)
                AddError(nameof(Reference), "put at least 3 characters");
        }
        public void ReleaseRemove()
        {
            if (string.IsNullOrEmpty(Reference))
                AddError(nameof(Reference), "Reference can not null");

            if (Reference.Length < 3)
                AddError(nameof(Reference), "put at least 3 characters");
        }

    }
}