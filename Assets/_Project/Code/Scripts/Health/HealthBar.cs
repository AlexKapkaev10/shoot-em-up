using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Health
{
    public interface IHealthBar
    {
        void Display(bool isVisible);
        void SetRotation(Quaternion rotation);
        void UpdateSlider(float currentValue);
    }
    
    public sealed class HealthBar : MonoBehaviour, IHealthBar
    {
        [SerializeField] private Image _bar;
        [SerializeField] private Image _imageSlider;
        
        public void SetRotation(Quaternion rotation)
        {
            transform.localRotation = rotation;
        }

        public void Display(bool isVisible)
        {
            _bar.DOFade(isVisible.GetHashCode(), 0.25f)
                .SetEase(Ease.Linear);
        }

        public void UpdateSlider(float currentValue)
        {
            _imageSlider.fillAmount = currentValue;
        }
    }
}