using DependencyInjectionLifetimes.Interfaces;
using System;

namespace DependencyInjectionLifetimes.Services
{
    public class ScopedService : IScopedService
    {
        private string id;

        public ScopedService()
        {
            id = Guid.NewGuid().ToString();
        }

        public string GetMessage()
        {
            return $"The scoped service id is    {id}";
        }
    }
}
