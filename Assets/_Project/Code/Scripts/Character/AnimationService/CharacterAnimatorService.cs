using UnityEngine;
using VContainer;

namespace Project.Scripts
{
    public interface ICharacterAnimatorService
    {
        void SetAnimator(Animator animator);
        void SetAnimatorBoolByState(
            CharacterAnimationType animationType,
            bool isBoolValue = default);
        void SetFloatByState(
            CharacterAnimationType animationType,
            float value = default);
    }
    
    public sealed class CharacterAnimatorService : ICharacterAnimatorService
    {
        private readonly AnimationServiceConfig _config;
        private Animator _animator;

        [Inject]
        public CharacterAnimatorService(AnimationServiceConfig config)
        {
            _config = config;
        }

        public void SetAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetAnimatorBoolByState(CharacterAnimationType animationType, bool isBoolValue = default)
        {
            switch (animationType)
            {
                case CharacterAnimationType.Run:
                    _animator.SetBool(_config.IsRun, isBoolValue);
                    break;
                case CharacterAnimationType.Dead:
                    _animator.SetBool(_config.Dead, isBoolValue);
                    break;
            }
        }

        public void SetFloatByState(CharacterAnimationType animationType, float value = default)
        {
            switch (animationType)
            {
                case CharacterAnimationType.RunRange:
                    _animator.SetFloat(
                        _config.MoveRange, value);
                    break;
            }
        }
    }
    
    public enum CharacterAnimationType
    {
        Run,
        RunRange,
        Dead
    }
}