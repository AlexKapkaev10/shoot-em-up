using Project.Scripts.Input;
using Project.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Core
{
    public sealed class GameScope : LifetimeScope
    {
        [SerializeField] private CameraServiceConfig _cameraServiceConfig;
        [SerializeField] private FactoryConfig _factoryConfig;
        [SerializeField] private ViewServiceConfig _viewServiceConfig;
        [SerializeField] private InputServiceConfig _inputServiceConfig;
        [SerializeField] private AnimationServiceConfig _animationServiceConfig;

        [SerializeField] private CharacterConfig _characterConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(_characterConfig);
            RegisterFactory(builder);
            RegisterServices(builder);
        }

        private void RegisterFactory(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Factory>()
                .As<IFactory>()
                .WithParameter(_factoryConfig);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CameraService>()
                .As<ICameraService>()
                .WithParameter(_cameraServiceConfig);
            
            builder.RegisterEntryPoint<ViewService>()
                .As<IViewService>()
                .WithParameter(_viewServiceConfig);

            builder.RegisterEntryPoint<InputService>()
                .As<IInputService>()
                .WithParameter(_inputServiceConfig);
            
            builder.RegisterEntryPoint<CharacterAnimatorService>()
                .As<ICharacterAnimatorService>()
                .WithParameter(_animationServiceConfig);
        }
    }
}