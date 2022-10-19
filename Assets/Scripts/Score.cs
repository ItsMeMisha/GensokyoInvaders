using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class Score : MonoBehaviour
    {
        private int _score;
        public int CurScore
        {
            get { return _score; }
            private set { _score = value; OnChangeScore?.Invoke(); }
        }
        public System.Action OnChangeScore;

        // Start is called before the first frame update
        void Start()
        {
            CurScore = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore(int ScoreToAdd)
        {
            CurScore += ScoreToAdd;
        }
    }
}
