using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public bool CreateCustomer { get; set; }

        public bool UpdateCustomer { get; set; }

        public bool DeleteCustomer { get; set; }
    }

    public enum NivelAcesso
    {
        ADM,
        MANAGENT
    }
}
