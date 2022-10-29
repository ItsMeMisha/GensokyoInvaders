using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders {
    public class BasicEnemyBehaviour : MonoBehaviour
    {

        private Shooter shooter;
        private Rigidbody2D rigid;

        [SerializeField]
        private int _AggressionLevel = 1;
        public float ShootingDelay = 4.0f;
        public float ShootProbability = 0.5f;

        public int Score;
        public int AggressionLevel
        {
            get { return _AggressionLevel; }

            set
            {
                if (value <= 0)
                {
                    return;
                }
                ShootingDelay *= _AggressionLevel;
                
                _AggressionLevel = value;
                
                ShootingDelay /= _AggressionLevel;
                if (rigid != null)
                {
                    rigid.velocity *= _AggressionLevel;
                }
                
            }
        }
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            shooter = GetComponent<Shooter>();
            if (shooter != null)
            {
                shooter.ShotCooldown = 0.0f;
                shooter.ShootDirection.Set(0.0f, -1.0f, 0.0f);
            }
            ShootingDelay /= AggressionLevel;
            
            if (shooter != null)
            {
                Invoke("Shoot", ShootingDelay + Random.Range(0.0f, ShootingDelay));
            }


        }
        public void IncreaseAggresion() 
        {
            AggressionLevel++;
        }

        public void DecreaseAggresion()
        {
            AggressionLevel--;
        }

        public void Shoot()
        {
            if (shooter != null)
            {
                if (ShootProbability >= Random.Range(0.0f, 1.0f))
                {
                    shooter.Shoot();
                }
                Invoke("Shoot", ShootingDelay);
            }
        }

        public void Move(Vector2 deltaPosition)
        {
            if (rigid != null)
            {
                rigid.MovePosition(rigid.position + deltaPosition);
            }
            else
            {
                transform.position.Set(transform.position.x + deltaPosition.x, 
                                       transform.position.y + deltaPosition.y, transform.position.z);
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Finish")
            {
                GameManager.Restart();
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.Restart();
            }
        }
    }

}
