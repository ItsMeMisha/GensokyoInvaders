using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class PowerUpDropper : MonoBehaviour
    {
        public PowerUp PowerUpItem;

        private void Start()
        {
            var characterHealth = gameObject.GetComponent<Health>();
            if (characterHealth != null)
            {
                characterHealth.OnDestroy += (GameObject go) =>
                {
                    Instantiate(PowerUpItem, go.transform.position, go.transform.rotation);
                };
            }
        }
    }
}
