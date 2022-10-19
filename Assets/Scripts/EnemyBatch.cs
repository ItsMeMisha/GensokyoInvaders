using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GensokyoInvaders
{

    public class EnemyBatch : MonoBehaviour
    {
        public EnemyPatternGenerator patternGenerator;
        public List<BasicEnemyBehaviour> Enemies = new List<BasicEnemyBehaviour>();

        public float Speed = 1.0f;
        public float SpeedIncrease = 1.0f;
        public float FallSpeed = 0.2f;

        public BasicEnemyBehaviour UFOType;
        public float UFOSpeed = 5.0f;
        public float UFOAtitude = 3.0f;
        public float UFOProbability = 0.5f;
        private bool UFOSpawned = false;
        private BasicEnemyBehaviour UFOObject;
        private float UFOSpawnTime = 0.0f;

        public float SymmetricMoveBound;

        public int KillsToSpeedUp = 5;

        private float RightBatchBound = 0.0f;
        private float LeftBatchBound = 0.0f;
        private bool MoveRight = true;
        private int CurrentKills = 0;
        private int CurrentAggression = 1;

        // Start is called before the first frame update
        void Start()
        {
            patternGenerator = GetComponent<EnemyPatternGenerator>();
            if (patternGenerator != null)
            {
                GenerateEnemyPattern();
            }

        }

        // Update is called once per frame
        void Update()
        {
            Move(Time.deltaTime);
        }

        void GenerateEnemyPattern()
        {
            Enemies = patternGenerator.GeneratePattern();
            foreach (var enemy in Enemies)
            {
                enemy.transform.SetParent(transform, true);
                enemy.AggressionLevel = CurrentAggression;

                Health enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.OnDestroy += OnEnemyDestroyed;
                }

            }

            RightBatchBound = patternGenerator.xLeft + patternGenerator.xGap * (patternGenerator.RowLength - 1);
            LeftBatchBound = patternGenerator.xLeft;
        }

        void Move(float deltaTIme)
        {
            if (UFOSpawned)
            {
                MoveUFO();
            }

            int moveMod = MoveRight ? 1 : -1;
            float newX = transform.position.x + moveMod * Speed * deltaTIme;
            
            if ((newX + RightBatchBound <= SymmetricMoveBound) && (newX + LeftBatchBound >= -SymmetricMoveBound))
            {
                transform.Translate(newX - transform.position.x, 0, 0);
            }
            else
            {
                MoveRight = !MoveRight;
                if (MoveRight)
                {
                    transform.Translate(0, -FallSpeed, 0);
                }
            }
        }

        void OnEnemyDestroyed(GameObject gameObject)
        {
            Enemies.Remove(gameObject.GetComponent<BasicEnemyBehaviour>());
            Destroy(gameObject);

            if (!UFOSpawned && Random.Range(0.0f, 1.0f) <= UFOProbability)
            {
                SpawnUFO();
            }

            CurrentKills++;
            if (CurrentKills >= KillsToSpeedUp)
            {
                Speed += SpeedIncrease;
                CurrentAggression++;
                foreach(var enemy in Enemies)
                {
                    enemy.AggressionLevel++;
                }
                CurrentKills = 0;
            }

            if (Enemies.Count == 0)
            {
                transform.Translate(-transform.position);
                GenerateEnemyPattern();
            }
        }

        void SpawnUFO()
        {
            UFOSpawned = true;
            Vector3 spawnpoint = new Vector3(0, UFOAtitude);
            UFOObject = Instantiate(UFOType, spawnpoint, transform.rotation);
            var UFOHealth = UFOObject.GetComponent<Health>();
            if (UFOHealth != null)
            {
                UFOHealth.OnDestroy += (GameObject go) => { 
                    Destroy(go);
                    UFOSpawned = false;
                };
            }
            UFOSpawnTime = Time.time;
        }

        void MoveUFO()
        {
            float newX = Mathf.Sin(UFOSpeed * (Time.time - UFOSpawnTime)) * SymmetricMoveBound;
            UFOObject.transform.Translate(newX - UFOObject.transform.position.x, 0, 0);
        }
    }
}
