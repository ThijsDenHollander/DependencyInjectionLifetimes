using DependencyInjectionLifetimes.Interfaces;
using System;

namespace DependencyInjectionLifetimes.Services
{
    public class SingletonService : ISingletonService
    {
        private string id;

        public SingletonService()
        {
            id = Guid.NewGuid().ToString();
        }

        public string GetMessage()
        {
            return $"The singleton service id is {id}";
        }
    }
}
