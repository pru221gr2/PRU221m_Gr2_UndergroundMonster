using Assets.Scripts.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Turret
{
    public class EnemyScanner : MonoBehaviour
    {
        [SerializeField]
        public float range = 5f;

        private Transform CurrentEnemyTarget;

        private void Update()
        {
            //visible scan range
            float visibleRange = range * 1.35f;
            transform.localScale = new Vector2(visibleRange, visibleRange);
        }

        public void updateNearestEnemy()
        {
            Transform currentNearestEnemy = null;
            float distance = Mathf.Infinity;
            foreach (GameObject enemy in EnemiesCounter.enemiesCount)
            {
                if (enemy != null)
                {
                    float _distance = (transform.position - enemy.transform.position).magnitude;
                    if (_distance < distance)
                    {
                        distance = _distance;
                        currentNearestEnemy = enemy.transform;
                    }
                }
            }
            if (distance <= range)
            {
                CurrentEnemyTarget = currentNearestEnemy;
            }
            else
            {
                CurrentEnemyTarget = null;
            }
        }
        public bool IsTargetFound()
        {
            return CurrentEnemyTarget != null;
        }

        public Transform GetTarget()
        {
            return CurrentEnemyTarget;  
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
