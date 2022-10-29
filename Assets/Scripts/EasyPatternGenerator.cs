using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{
    public class EasyPatternGenerator : EnemyPatternGenerator
    {
        public BasicEnemyBehaviour GhostType;
        public BasicEnemyBehaviour FairyType;
        public BasicEnemyBehaviour OrbType;

        public override List<BasicEnemyBehaviour> GeneratePattern() { 
            var enemies = new List<BasicEnemyBehaviour>();
        
            float curY = yLow;
            //Two rows of ghosts
            for (int j = 0; j < 2; j++)
            {
                AddRow(GhostType, xLeft, curY + j * yGap, xGap, RowLength, enemies);
            }
            //Two rows of fairies
            curY += 2 * yGap;
            for (int j = 0; j < 2; j++)
            {
                AddRow(FairyType, xLeft, curY + j * yGap, xGap, RowLength, enemies);
            }

            //ONe row of orbs
            curY += 2 * yGap;
            AddRow(OrbType, xLeft, curY, xGap, RowLength, enemies);

            return enemies;
        }

        private void AddRow(BasicEnemyBehaviour enemyType, float xLeft, float y, float xGap, int num, List<BasicEnemyBehaviour> enemies)
        {
            for (int i = 0; i < num; i++)
            {
                var spawnpoint = new Vector3(xLeft + xGap * i, y, 0);
                enemies.Add(Instantiate(enemyType, spawnpoint, transform.rotation));
            }
        }
    }
}