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
        public float BulletsGap = 0.5f;
        public System.Action OnBulletNumberChanged;

        public int MaxBulletNumber = 4;
        private int _bulletNumber = 1;
        public int BulletNumber
        {
            get { return _bulletNumber; }

            set 
            { 
                _bulletNumber = value;
                OnBulletNumberChanged?.Invoke();
            }
        }

        private void Start()
        {
            BulletNumber = 1;           
        }
        // Update is called once per frame
        void Update()
        {
            if (ShotCooldownLeft > 0) ShotCooldownLeft -= Time.deltaTime;
        }

        public void Shoot()
        {
            if (ShotCooldownLeft <= 0.0f) 
            {
                for (int i = 0; i < BulletNumber; i++)
                {   //Shift x point of spawnpoint for BulletsGap/2 for each new bullet
                    var Spawnpoint = RelativeSpawnpoint + transform.position + new Vector3(-BulletsGap/2 * (BulletNumber - 1) + i * BulletsGap, 0.0f, 0.0f);
                    ShotCooldownLeft = ShotCooldown;
                    var NewBullet = Instantiate(BulletType, Spawnpoint, transform.rotation);
                    ShootDirection.Normalize();
                    NewBullet.Velocity = ShootDirection * BulletSpeed;
                }
            }
        }
    }
}