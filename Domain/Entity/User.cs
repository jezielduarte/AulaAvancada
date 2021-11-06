using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class User
    {
        public Guid Id { get; protected set; }

        public User(string login, string pass, bool createCustomer = false, bool updateCustomer = false, bool deleteCustomer = false)
        {
            Login = login;
            Pass = pass;
            CreateCustomer = createCustomer;
            UpdateCustomer = updateCustomer;
            DeleteCustomer = deleteCustomer;
        }

        public string Login { get; protected set; }

        public string Pass { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public bool CreateCustomer { get; protected set; }

        public bool UpdateCustomer { get; protected set; }

        public bool DeleteCustomer { get; protected set; }


        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new BrokenRoles(property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
        public void ReleaseSave()
        {
            StartDate = DateTime.Today;

            if (string.IsNullOrEmpty(Login))
                AddError(nameof(Login), "login can not null");

            if (Login.Length < 3)
                AddError(nameof(Login), "put at least 3 characters");

        }
    }

    public enum NivelAcesso
    {
        ADM,
        MANAGENT
    }
}
