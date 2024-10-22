using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.UI.Views
{
    public class BaseView : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            
        }
    }
}