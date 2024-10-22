using System;
using UnityEngine;

namespace Project.Scripts.Health
{
    public interface IHealthSystem
    {
        event Action Dead;
        void SetMaxHealth(float maxValue);
        void Hit(float damage);
        void DisplayHealthBar(bool isVisible);
    }
    
    public sealed class HealthSystem : IHealthSystem
    {
        private readonly IHealthBar _healthBar;
        
        private float _maxHealth;
        private float _currentHealth;
        private float _inverseMaxHealth;
        
        public event Action Dead;

        public HealthSystem(IHealthBar healthBar)
        {
            _healthBar = healthBar;
        }

        public void SetMaxHealth(float maxValue)
        {
            _maxHealth = maxValue;
            _currentHealth = maxValue;
            _inverseMaxHealth = 1f / _maxHealth;
        }

        public void Hit(float damage)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            
            _healthBar.UpdateSlider(CalculateSliderValue());
            
            if (_currentHealth <= 0)
            {
                Dead?.Invoke();
            }
        }

        public void DisplayHealthBar(bool isVisible)
        {
            _healthBar.Display(isVisible);
        }

        private float CalculateSliderValue()
        {
            return _currentHealth * _inverseMaxHealth;
        }
    }
}