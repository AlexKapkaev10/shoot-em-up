using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Core
{
    public interface IFactory : IInitializable
    {
        
    }
    
    public class Factory : IFactory
    {
        private readonly FactoryConfig _config;
        private readonly IObjectResolver _resolver;

        private ICharacter _character;

        [Inject]
        public Factory(IObjectResolver resolver, FactoryConfig config)
        {
            _resolver = resolver;
            _config = config;
        }

        public void Initialize()
        {
            _character = _resolver.Instantiate(_config.CharacterPrefab, null);
        }
    }
}