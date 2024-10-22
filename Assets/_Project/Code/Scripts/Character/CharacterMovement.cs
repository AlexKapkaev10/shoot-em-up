using Project.Scripts.Input;
using UnityEngine;
using VContainer;

namespace Project.Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _body;
        [SerializeField] private Transform _target;

        private CharacterConfig _config;
        private IInputService _inputService;
        private ICharacterAnimatorService _animatorService;
        
        private Vector3 _moveDirection;
        private Vector3 _targetDirection;
        
        private bool _isRun;

        [Inject]
        private void Construct(IInputService inputService, CharacterConfig config)
        {
            _config = config;
            _inputService = inputService;
        }

        public void SetAnimationService(ICharacterAnimatorService animatorService)
        {
            _animatorService = animatorService;
        }
        
        public void Tick()
        {
            CalculateMoveDirection();
            Look();

            if (!TryRun())
            {
                return;
            }

            Move();
        }

        public void SetDead(bool isDead)
        {
            _animatorService
                .SetAnimatorBoolByState(CharacterAnimationType.Dead, isDead);
            SetRun(false);
        }

        private void Move()
        {
            if (!_isRun)
            {
                SetRun(true);
            }

            _characterController.Move(
                _moveDirection * (_config.MoveSpeed * Time.deltaTime));
            
            _animatorService
                .SetAnimatorBoolByState(CharacterAnimationType.RunRange, _isRun);
        }

        private void Look()
        {
            if (_target)
            {
                CalculateTargetDirection();

                _body.localRotation = Quaternion.Slerp(
                    _body.rotation, 
                    Quaternion.LookRotation(
                        _targetDirection, Vector3.up),
                    Time.deltaTime * 10f);
            }
            else
            {
                if (!TryRun())
                {
                    return;
                }
                
                _body.rotation = Quaternion.Slerp(
                    _body.rotation, 
                    Quaternion.LookRotation(
                        _moveDirection, Vector3.up),
                    Time.deltaTime * 10f);
            }
        }

        private void SetRun(bool isRun)
        {
            if (_isRun == isRun)
            {
                return;
            }
                
            _isRun = isRun;

            _animatorService
                .SetAnimatorBoolByState(CharacterAnimationType.Run, _isRun);
            
            _animatorService
                .SetFloatByState(CharacterAnimationType.RunRange, _moveDirection.magnitude);
            
        }

        private void CalculateMoveDirection()
        {
            _moveDirection.x = _inputService.Move.x;
            _moveDirection.z = _inputService.Move.y;
        }        
        
        private void CalculateTargetDirection()
        {
            _targetDirection = _target.position - _body.position;
            _targetDirection.y = 0;
        }

        private bool TryRun()
        {
            if (_isRun)
            {
                SetRun(false);
            }
            
            return _moveDirection.magnitude > _config.MinMoveMagnitude;
        }
    }
}