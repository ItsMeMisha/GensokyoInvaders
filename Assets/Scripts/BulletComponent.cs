using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class BulletComponent : MonoBehaviour
    {
        public Vector3 Velocity;
        public int Damage = 1;
        public string TargetTag = "Enemy";

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Velocity * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null && collision.tag == TargetTag) {
               Health enemyHealth = collision.gameObject.GetComponent<Health>();
               if (enemyHealth != null)
               {
                    enemyHealth.TakeDamage(Damage);
               }
               Destroy(gameObject);
            }

            if (collision != null && collision.tag == "Bound") 
            {
                Destroy(gameObject);
            }
        }
    }
}