using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class HealthUI : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI _text;
        private Health _playerHealth;
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TMPro.TextMeshProUGUI>();
            _playerHealth = FindObjectOfType<PlayerControls>().GetComponent<Health>();
            _text.text = string.Format("Health {0}", _playerHealth.MaxHP);
            _playerHealth.OnChangeHealth += () => { _text.text = string.Format("Health {0}", _playerHealth.CurrentHP); };
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
