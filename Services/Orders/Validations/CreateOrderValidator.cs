using FluentValidation;
using Services.Orders.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Orders.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(order => order.Items).NotNull().Must(x=> x.Count > 0);
        }
    }
}
