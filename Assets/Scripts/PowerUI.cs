using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GensokyoInvaders
{
    public class PowerUI : MonoBehaviour
    {
        private Shooter _shooter;
        private TMPro.TextMeshProUGUI _text;
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TMPro.TextMeshProUGUI>();
            _shooter = FindObjectOfType<PlayerControls>().GetComponent<Shooter>();
            _text.text = string.Format("Health {0}", _shooter.BulletNumber);
            _shooter.OnBulletNumberChanged += () => 
            {
                if (_shooter.BulletNumber >= _shooter.MaxBulletNumber)
                {
                    _text.text = string.Format("POWER MAX");
                } else {
                    _text.text = string.Format("POWER {0}", _shooter.BulletNumber);
                }
            };
        }

    }
}
