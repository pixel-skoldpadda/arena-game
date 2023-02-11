using System;
using System.Collections.Generic;

namespace Infrastructure.DI
{
    /**
     * Класс, описыващий контейнер внедрения зависимостей (сервис локатор).
     */
    public class DiContainer
    {
        private static DiContainer _instance;
        private static readonly Dictionary<Type, object> Dependencies = new();

        private DiContainer() {}

        public void Bind<TService>(TService implementaton) where TService : IService
        {
            Dependencies[typeof(TService)] = implementaton;
        }

        public TService Get<TService>() where TService : IService
        {
            return (TService) Dependencies[typeof(TService)];
        }

        public static DiContainer Container => _instance ??= new DiContainer();
    }
}