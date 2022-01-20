using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Customer
    {
        public Customer(string name, string city, string postCod)
        {
            Name = name;
            City = city;
            PostCod = postCod;
            Errors = new List<BrokenRoles>();
        }

        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string City { get; protected set; }

        public string PostCod { get; protected set; }

        public DateTime StartDate { get; protected set; }

        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }
        
        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void SetAderess(string city, string postCode)
        {
            City = city;
            PostCod = postCode;
        }
        public void SetName(string name)
        {
            Name = name;
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new BrokenRoles(property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
        public void ReleaseSave()
        {
            StartDate = DateTime.Today;

            if (string.IsNullOrEmpty(Name))
                AddError(nameof(Name), "name can not null");

            if (Name.Length < 3)
                AddError(nameof(Name), "put at least 3 characters");

        }
        public void ReleaseUpdate()
        {
            if (string.IsNullOrEmpty(Name))
                AddError(nameof(Name), "name can not null");

            if (Name.Length < 3)
                AddError(nameof(Name), "put at least 3 characters");
        }
        public void ReleaseRemove()
        {
            if (string.IsNullOrEmpty(Name))
                AddError(nameof(Name), "name can not null");

            if (Name.Length < 3)
                AddError(nameof(Name), "put at least 3 characters");
        }
    }
}
