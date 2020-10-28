using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Managers;
using UnityEngine.Events; //wrapper class for events (also different to Unity Events, can be serialized)

namespace TowerDefence.Enemies
{
    public class Spawner : MonoBehaviour
    {
        [System.Serializable]
        //Unity Event
        public class AttackEvent : UnityEvent<float> { }
        public AttackEvent onAttackEvent; 

        //Delegate
        public delegate float AttackDelegate();
        public AttackDelegate onAttack; //By default onAttack is null.

        public float MeleeAttack()
        {
            print("Melee Attack!"); //use instead of debug.log
            return 100f;
        }

        public float ShootAttack()
        {
            print("Shoot Attack!");
            return 50f;
        }

        public float SpawnRate { get { return spawnRate; } }

        [SerializeField]
        private float spawnRate = 1;

        //Timer to make spawn rate in waves
        private float currentTime = 0;
        private EnemyManager enemyManager;
       
        void Start()
        {
            //Save typing
            enemyManager = EnemyManager.instance;

            onAttack += MeleeAttack;
            onAttack += MeleeAttack;
            onAttack += ShootAttack; //Will call MeleeAttack twice and ShootAttack once.
            onAttack();
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
