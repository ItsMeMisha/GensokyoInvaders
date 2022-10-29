using System.Collections;
using UnityEngine;

namespace GensokyoInvaders
{
    public class Shooter : MonoBehaviour
    {
        public BulletComponent BulletType;

        private float ShotCooldownLeft = 0.0f;
        public float ShotCooldown = 0.3f;
        public Vector3 RelativeSpawnpoint = Vector2.zero;
        public Vector3 ShootDirection = new Vector3(0.0f, 1.0f, 0.0f);
        public float BulletSpeed = 15.0f;

        // Update is called once per frame
        void Update()
        {
            if (ShotCooldownLeft > 0) ShotCooldownLeft -= Time.deltaTime;
        }

        public void Shoot()
        {
            if (ShotCooldownLeft <= 0.0f) 
            {
                var Spawnpoint = RelativeSpawnpoint + transform.position;
                ShotCooldownLeft = ShotCooldown;
                var NewBullet = Instantiate(BulletType, Spawnpoint, transform.rotation);
                ShootDirection.Normalize();
                NewBullet.Velocity = ShootDirection * BulletSpeed;
            }
        }
    }
}