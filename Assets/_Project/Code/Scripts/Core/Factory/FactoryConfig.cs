using UnityEngine;

namespace Project.Scripts.Core
{
    [CreateAssetMenu(fileName = nameof(FactoryConfig), menuName = "Configs/Factory")]
    public class FactoryConfig : ScriptableObject
    {
        [field: SerializeField] public Character CharacterPrefab { get; private set; }
        [field: SerializeField] public CharacterConfig CharacterConfig { get; private set; }
    }
}