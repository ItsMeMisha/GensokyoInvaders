using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class ScoreUI : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI _text;
        private Score _playerScore;
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TMPro.TextMeshProUGUI>();
            _playerScore = FindObjectOfType<PlayerControls>().GetComponent<Score>();
            _playerScore.OnChangeScore += () => { _text.text = string.Format("Score {0}", _playerScore.CurScore); };
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}