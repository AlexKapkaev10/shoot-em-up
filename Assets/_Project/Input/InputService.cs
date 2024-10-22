using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts.Input
{
    public interface IInputService : IInitializable, IDisposable
    {
        Vector2 Move { get; }
    }
    
    public class InputService : IInputService
    {
        private readonly InputServiceConfig _config;

        public Vector2 Move { get; private set; }

        [Inject]
        public InputService(InputServiceConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            _config.MoveReference.action.performed += OnMove;
            _config.MoveReference.action.canceled += OnMove;
        }

        public void Dispose()
        {
            _config.MoveReference.action.performed -= OnMove;
            _config.MoveReference.action.canceled -= OnMove;
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            Move = ctx.ReadValue<Vector2>();
        }
    }
}