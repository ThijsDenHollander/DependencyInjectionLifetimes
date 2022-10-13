using DependencyInjectionLifetimes.Interfaces;
using System;

namespace DependencyInjectionLifetimes.Services
{
    public class TransientService : ITransientService
    {
        private string id;

        public TransientService()
        {
            id = Guid.NewGuid().ToString();
        }

        public string GetMessage()
        {
            return $"The transient service id is {id}";
        }
    }
}
