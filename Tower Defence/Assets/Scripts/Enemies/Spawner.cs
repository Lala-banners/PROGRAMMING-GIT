using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Managers;

namespace TowerDefence.Enemies
{
    public class Spawner : MonoBehaviour
    {
        public float SpawnRate
        {
            get
            {
                return spawnRate;
            }
        }

        [SerializeField]
        private float spawnRate = 1;

        //Timer to make spawn rate in waves
        private float currentTime = 0;
        private EnemyManager enemyManager;
       
        void Start()
        {
            //Save typing
            enemyManager = EnemyManager.instance;
        }

        void Update()
        {
            //Incrament time by delta time if the current time is less than the SpawnRate
            if (currentTime < SpawnRate)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                //Reset time
                currentTime = 0;

                //Attempt to spawn the enemy
                if (enemyManager != null)
                {
                    enemyManager.SpawnEnemy(transform);
                }
            }
        }
    }
}
