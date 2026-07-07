using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace CMS.Application.Common
{
    public class ValidationBehavior<TRequest, TReponse> : IPipelineBehavior<TRequest, TReponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;

        }
        public async Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var validatorResult = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

            var failuers = validatorResult
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failuers.Any())
            {
                throw new ValidationException(failuers);
            }

            return await next();



        }
    }
}
