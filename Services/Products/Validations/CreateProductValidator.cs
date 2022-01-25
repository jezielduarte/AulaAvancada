using Domain.Repository;
using FluentValidation;
using Services.Products.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Product.Validations
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _repository;
        public CreateProductValidator(IProductRepository repository)
        {
            _repository = repository;
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição não pode ser vazio").NotNull().MinimumLength(5).MaximumLength(10);
            RuleFor(x => x.Reference).NotEmpty().NotNull().MinimumLength(7).MaximumLength(7).Must(ExistReference).WithMessage("Referencia ja existente");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Preço do produto é obrigatorio");
        }

        private bool ExistReference(string reference)
        {
            return !_repository.Exist(reference);
        }

    }
}
