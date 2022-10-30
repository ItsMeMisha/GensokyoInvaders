using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class PowerUp : BulletComponent
    {
        private void Start()
        {
            Damage = 0;
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null && collision.tag == TargetTag)
            {
                var shooter = collision.gameObject.GetComponent<Shooter>();
                if (shooter != null)
                {
                    if (shooter.BulletNumber < shooter.MaxBulletNumber)
                    {
                        shooter.BulletNumber++;
                    }
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
