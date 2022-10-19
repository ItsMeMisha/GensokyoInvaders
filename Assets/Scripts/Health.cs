using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class Health : MonoBehaviour
    {
        // Start is called before the first frame update
        public float MaxHP = 0.0f;

        public System.Action<GameObject> OnDestroy;
        [SerializeField]
        private float _CurrentHP;
        public float CurrentHP
        {
            get { return _CurrentHP; }
            private set { _CurrentHP = value < MaxHP ? value : MaxHP; }
        }

        void Start()
        {
            CurrentHP = MaxHP;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void TakeDamage(float damage)
        {
            CurrentHP -= damage;
            if (CurrentHP <= 0.0f)
            {
                OnDestroy(gameObject);
            }
        }

        public void Heal(float healingHP)
        {
            CurrentHP += healingHP;
        }
    }
}