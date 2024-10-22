using UnityEngine;

namespace Project.Scripts
{
    internal interface IEnemy
    {
        Transform Transform { get; }
        void OnDetected(Transform target);
        void OnLost();
    }
    
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Transform _body;
        private Transform _target;
        private Vector3 _targetDirection;
        
        public Transform Transform => transform;

        private void Update()
        {
            if (!_target)
            {
                return;
            }
            
            _targetDirection = _target.position - _body.position;
            _targetDirection.y = 0;
            
            _body.localRotation = Quaternion.Slerp(
                _body.rotation, 
                Quaternion.LookRotation(
                    _targetDirection, Vector3.up),
                Time.deltaTime * 10f);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void OnDetected(Transform target)
        {
            SetTarget(target);
            Debug.Log("OnDetected");
        }

        public void OnLost()
        {
            SetTarget(null);
            Debug.Log("OnLost");
        }
    }
}