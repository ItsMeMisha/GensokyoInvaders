using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    abstract public class EnemyPatternGenerator : MonoBehaviour
    {
        public  float xLeft;
        public float yLow;

        public float xGap;
        public float yGap;

        public int RowLength;
       abstract public List<BasicEnemyBehaviour> GeneratePattern();
    }
}
