using System.Collections;
using Project.Scripts.Health;
using UnityEngine;
using VContainer;

namespace Project.Scripts
{
    public interface ICharacter
    {
        void HitDamage(float damage);
        bool IsDead { get; }
    }
    
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private Animator _characterAnimator;
        
        [SerializeField] private CharacterMovement _characterMovement;

        private CharacterConfig _config;
        private IHealthSystem _healthSystem;

        public bool IsDead { get; private set; }

        [Inject]
        private void Construct(
            ICameraService cameraService, 
            ICharacterAnimatorService animatorService,
            CharacterConfig config)
        {
            _config = config;
            
            cameraService.SetFollowTarget(transform);
            
            var healthBar = Instantiate(_config.HealthBarPrefab, transform);
            healthBar.SetRotation(cameraService.GetCameraRotation());
            
            _healthSystem = new HealthSystem(healthBar);
            _healthSystem.SetMaxHealth(_config.MaxHealth);
            
            animatorService.SetAnimator(_characterAnimator);
            _characterMovement.SetAnimationService(animatorService);
        }

        private void OnEnable()
        {
            _healthSystem.Dead += OnDead;
        }

        private void OnDisable()
        {
            _healthSystem.Dead -= OnDead;
        }

        private void Update()
        {
            if (IsDead)
            {
                return;
            }
            
            _characterMovement.Tick();
        }

        public void HitDamage(float damage)
        {
            _healthSystem.Hit(damage);
        }

        private void OnDead()
        {
            IsDead = true;
            
            _characterMovement.SetDead(IsDead);
            _healthSystem.DisplayHealthBar(false);
        }

        private IEnumerator HitAsync()
        {
            ICharacter character = this;
            while (true)
            {
                yield return new WaitForSeconds(2);
                character.HitDamage(_config.Damage);
            }
        }
    }
}