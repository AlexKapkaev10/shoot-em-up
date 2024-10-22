using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;

namespace Project.Scripts.UI.Views
{
    public class JoystickView : BaseView
    {
        [SerializeField] private RectTransform _rectTransformJoystick;
        [SerializeField] private OnScreenStick _screenStick;

        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = _rectTransformJoystick.position;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            _rectTransformJoystick.position = eventData.position;
            _screenStick.OnPointerDown(eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            _screenStick.OnDrag(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            _rectTransformJoystick.position = _startPosition;
            _screenStick.OnPointerUp(eventData);
        }
    }
}