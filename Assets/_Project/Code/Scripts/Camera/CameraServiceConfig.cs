using Cinemachine;
using UnityEngine;

namespace Project.Scripts
{
    [CreateAssetMenu(fileName = nameof(CameraServiceConfig), menuName = "Configs/Services/Camera")]
    public class CameraServiceConfig : ScriptableObject
    {
        [field: SerializeField] public CinemachineBrain CinemachineBrainPrefab { get; private set; }
        [field: SerializeField] public UserCamera UserCameraPrefab { get; private set; }
    }
}