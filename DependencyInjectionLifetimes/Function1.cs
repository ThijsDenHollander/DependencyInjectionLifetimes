using DependencyInjectionLifetimes.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace DependencyInjectionLifetimes
{
    public class Function1
    {
        private readonly ITransientService transientService;
        private readonly IScopedService scopedService;
        private readonly ISingletonService singletonService;
        private readonly IHelperService helperService;

        public Function1(ITransientService transientService, IScopedService scopedService, ISingletonService singletonService, IHelperService helperService)
        {
            this.transientService = transientService;
            this.scopedService = scopedService;
            this.singletonService = singletonService;
            this.helperService = helperService;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            // De services zetten allemaal in hun constructor een guid.
            // Omdat de singleton service maar 1x wordt aangemaakt is deze guid elke 10 seconden hetzelfde
            // De transient en scoped services zijn bij elk request verschillend, deze guids zijn dus elke 10 seconden anders
            log.LogInformation(transientService.GetMessage());
            log.LogInformation(scopedService.GetMessage());
            log.LogInformation(singletonService.GetMessage());
            
            // Om het verschil tussen scoped en transient aan te geven, is er een helperservice aangemaakt.
            // Deze krijgt ook een transient service en een scoped service geinjecteerd.
            // Omdat we nog steeds in hetzelfde request zitten, wordt de scoped service 'hergebruikt', deze heeft dus hetzelfde id
            // De transient service zal een andere transient service zijn dan die hier is geinjecteerd, met een ander id.
            log.LogInformation(helperService.GetMessage());
        }
    }
}
