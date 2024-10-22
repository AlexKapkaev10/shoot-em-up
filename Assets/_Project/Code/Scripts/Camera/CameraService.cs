using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scripts
{
    public interface ICameraService : IInitializable
    {
        void SetFollowTarget(Transform target);
        Quaternion GetCameraRotation();
    }
    
    public class CameraService : ICameraService
    {
        private readonly CameraServiceConfig _config;

        private UserCamera _userCamera;

        [Inject]
        public CameraService(CameraServiceConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            Object.Instantiate(_config.CinemachineBrainPrefab, null);
        }

        public void SetFollowTarget(Transform target)
        {
            _userCamera = Object.Instantiate(_config.UserCameraPrefab, null);
            _userCamera.VirtualCamera.Follow = target;
        }

        public Quaternion GetCameraRotation()
        {
            return _userCamera.Camera.transform.localRotation;
        }
    }
}