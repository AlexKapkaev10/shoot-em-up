using Project.Scripts.Health;
using UnityEngine;

namespace Project.Scripts
{
    [CreateAssetMenu(fileName = nameof(CharacterConfig), menuName = "Configs/Character")]
    public class CharacterConfig : ScriptableObject
    {
        [field: Header("Movement Settings")]
        [field: SerializeField] public float MoveSpeed { get; private set; } = 10f;
        
        [field: Header("Health Settings")]
        [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
        [field: SerializeField] public HealthBar HealthBarPrefab { get; private set; }
        
        [field: Header("Damage Settings")]
        [field: SerializeField] public float Damage { get; private set; } = 100f;
        
        public int IsRun => Animator.StringToHash("isRun");
        public int MoveRange => Animator.StringToHash("MoveRange");
        public int Dead => Animator.StringToHash("Dead");
        public float MinMoveMagnitude => 0.1f;
    }
}