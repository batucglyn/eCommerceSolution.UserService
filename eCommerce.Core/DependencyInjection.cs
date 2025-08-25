using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core;

public static class DependencyInjection
{

    public static IServiceCollection AddCore(this IServiceCollection services)
    {

        services.AddTransient<IUsersService, UsersService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}
