using UnityEngine;

namespace Project.Scripts.UI.Views
{
    public sealed class HealthBarView : BaseView
    {
        public Transform playerTransform;
        public Camera mainCamera;
        public RectTransform healthBar;

        private void LateUpdate()
        {
            if (!playerTransform || !mainCamera)
            {
                return;
            }
            
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(playerTransform.position + Vector3.up);
            healthBar.position = screenPosition;
        }
    }
}