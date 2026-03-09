using MedicalAssistant.Domain.Contracts;
using MedicalAssistant.Persistance.Repositories;
using MedicalAssistant.Services.Services;
using MedicalAssistant.Services_Abstraction.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAssistant.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers application services for the Patient module (repositories + services).
        /// </summary>
        public static IServiceCollection AddPatientModule(this IServiceCollection services)
        {
            // Unit of Work + repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IPatientService, PatientService>();

            return services;
        }
    }
}
