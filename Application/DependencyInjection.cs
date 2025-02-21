using Application.AutoMapper;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{


		var mapperConfig = new MapperConfiguration(mc =>
		{
			mc.AddProfile(new MappingProfile());
		});

		IMapper mapper = mapperConfig.CreateMapper();
		services.AddSingleton(mapper);


		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


		services.AddMediatR(Assembly.GetExecutingAssembly());
		return services;
	}
}
