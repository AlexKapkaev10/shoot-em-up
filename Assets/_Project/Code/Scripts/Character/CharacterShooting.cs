using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public sealed class CharacterShooting : CharacterAction
    {
        [SerializeField] private LayerMask _detectionLayer;
        [SerializeField] private float _detectionRadius = 5f;
        
        private readonly List<IEnemy> _detectedEnemies = new List<IEnemy>();
        private readonly HashSet<IEnemy> _enemySet = new HashSet<IEnemy>();

        public override void Tick()
        {
            DetectEnemies();
            LostEnemies();
        }
        
        private void DetectEnemies()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadius, _detectionLayer);
            
            foreach (Collider hitCollider in hitColliders)
            {
                IEnemy enemy = hitCollider.GetComponent<IEnemy>();
                
                if (enemy != null && !_enemySet.Contains(enemy))
                {
                    _detectedEnemies.Add(enemy);
                    _enemySet.Add(enemy);
                    enemy.OnDetected(transform);
                }
            }
        }
        
        private void LostEnemies()
        {
            for (int i = _detectedEnemies.Count - 1; i >= 0; i--)
            {
                IEnemy enemy = _detectedEnemies[i];
                
                if (Vector3.Distance(transform.position, enemy.Transform.position) > _detectionRadius + 2)
                {
                    _detectedEnemies.RemoveAt(i);
                    _enemySet.Remove(enemy);
                    enemy.OnLost();
                }
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        }

        /*public override void Tick()
        {
            DetectEnemies();
        }
        
        private void DetectEnemies()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadius, _detectionLayer);
            
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<IEnemy>();
                enemy?.OnDetected();
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        }*/
    }
}