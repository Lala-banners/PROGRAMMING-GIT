﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Enemies;

//namespaces - categories of things
//TowerDefence.Managers will have access to TowerDefence.Enemies because there is an EnemyManager
namespace TowerDefence.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        //Make a singleton to spawn enemies from everywhere 
        public static EnemyManager instance = null;

        [SerializeField]
        private GameObject enemyPrefab;

        //List to create new enemies
        private List<Enemy> aliveEnemies = new List<Enemy>();

        //Function to spawn enemies
        public void SpawnEnemy(Transform _spawner)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, _spawner.position, enemyPrefab.transform.rotation);
            aliveEnemies.Add(newEnemy.GetComponent<Enemy>());
        }

        public void KillEnemy(Enemy _enemy)
        {
            //Attempt to find the enemy in the list and IndexOf gives 0 if enemy isn't found
            int enemyIndex = aliveEnemies.IndexOf(_enemy);
            if (enemyIndex != -1)
            {
                //The enemy exists and we can kill it and rmeove from the list
                Destroy(_enemy.gameObject);
                aliveEnemies.RemoveAt(enemyIndex);
            }
        }

        /// <summary>
        /// Loops through all aliveEnemies in the game and finds the closest enemies within a certain range
        /// </summary>
        /// <param name="_target">The object we are comparing the distance to.</param>
        /// <param name="_maxRange">The range we are finding enemies with.</param>
        /// <param name="_minRange">The range the enemies must at least be from the target.</param>
        /// <returns>The list of enemies within the given range</returns>
        public Enemy[] GetClosestEnemies(Transform _target, float _maxRange, float _minRange = 0)
        {
            //Want the info out of this function to be static
            //Start by adding them all then return the converted array []
            List<Enemy> closeEnemies = new List<Enemy>();

            foreach (Enemy enemy in aliveEnemies)
            {
                //Detects if the enemy is within range, if so, add to the list
                float distance = Vector3.Distance(enemy.transform.position, _target.position);
                if (distance < _maxRange && distance > _minRange)
                {
                    closeEnemies.Add(enemy);
                }
            }
            //Convert list to array
            return closeEnemies.ToArray();
        }

        //Set up singleton instance in Awake() so that it is ready to use
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
