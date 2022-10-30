using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class PlayerControls : MonoBehaviour
    {
        public float Speed = 0.1f;
        public float Slowdown = 0.5f;
        Shooter shooter;
        Rigidbody2D rigid;
        
        // Start is called before the first frame update
        void Start()
        {
            shooter = GetComponent<Shooter>();
            rigid = GetComponent<Rigidbody2D>();
            Health health = GetComponent<Health>();
            if (health != null)
            {
                health.OnDestroy += (GameObject go) => { GameManager.Restart(); };
                if (shooter != null)
                {
                    health.OnChangeHealth += () => 
                    { 
                        if (shooter.BulletNumber > 1)
                        {
                            shooter.BulletNumber--;
                        }
                    };
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            float SpeedMod = 1.0f;
            if (Input.GetButton("Slowdown"))
            {
                SpeedMod = Slowdown;
            }

            float slide = Input.GetAxis("Horizontal");
            var deltaX = slide * Speed * SpeedMod;
            if (rigid != null)
            {
                rigid.MovePosition(new Vector2(rigid.position.x + deltaX, 0.0f));
            }
            else
            {
                transform.Translate(deltaX, .0f, .0f);
            }
            

            if (shooter != null && Input.GetButton("Fire"))
            {
                shooter.Shoot();
            }
        }
    }
}
