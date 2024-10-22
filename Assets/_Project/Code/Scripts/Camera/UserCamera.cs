using Cinemachine;
using UnityEngine;

namespace Project.Scripts
{
    public class UserCamera : MonoBehaviour
    {
        [field: SerializeField] public CinemachineVirtualCamera VirtualCamera { get; private set; }
        [field: SerializeField] public Camera Camera { get; private set; }
    }
}