using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class Health : MonoBehaviour
    {
        // Start is called before the first frame update
        public int MaxHP = 0;

        public System.Action<GameObject> OnDestroy;
        public System.Action OnChangeHealth;

        [SerializeField]
        private int _CurrentHP = 0;
        public int CurrentHP
        {
            get { return _CurrentHP; }
            private set { _CurrentHP = value < MaxHP ? value : MaxHP; }
        }

        void Start()
        {
            CurrentHP = MaxHP;
            OnDestroy += (GameObject go) => { Destroy(go); };
        }
        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;
            OnChangeHealth?.Invoke();
            if (CurrentHP <= 0.0f)
            {
                OnDestroy.Invoke(gameObject);
            }
        }

        public void Heal(int healingHP)
        {
            CurrentHP += healingHP;
            OnChangeHealth?.Invoke();
        }
    }
}