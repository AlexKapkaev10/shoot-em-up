using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.Input
{
    [CreateAssetMenu(fileName = nameof(InputServiceConfig), menuName = "Configs/Services/Input")]
    public class InputServiceConfig : ScriptableObject
    {
        [field: SerializeField] public InputActionReference MoveReference { get; private set; }
    }
}