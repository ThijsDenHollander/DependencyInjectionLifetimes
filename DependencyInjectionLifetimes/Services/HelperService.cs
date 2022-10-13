using DependencyInjectionLifetimes.Interfaces;

namespace DependencyInjectionLifetimes.Services
{
    public class HelperService : IHelperService
    {
        private readonly ITransientService transientService;
        private readonly IScopedService scopedService;

        public HelperService(ITransientService transientService, IScopedService scopedService)
        {
            this.transientService = transientService;
            this.scopedService = scopedService;
        }

        public string GetMessage()
        {
            return "From the helper service: \r\n" + this.transientService.GetMessage() + ", which is different from the other transient service\r\n" + scopedService.GetMessage() + ", which is the same for the 'other' scoped service";
        }
    }
}
