using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Towers;

//namespaces - categories of things
//TowerDefence.Managers will have access to Managers
namespace TowerDefence.Managers
{
    public class TowerManager : MonoBehaviour
    {
        
        public static TowerManager instance = null;

        //Registered for each tower that we can spawn again
        [SerializeField]
        private List<Tower> spawnableTowers = new List<Tower>();

        private List<Tower> aliveTowers = new List<Tower>();
        private Tower towerToPurchase;

        //Whenever click on a new tower to spawn, a new system will be created for puchasing towers
        public void PurchaseTower(TowerPlatform _platform)
        {
            Player.instance.PurchaseTower(towerToPurchase);

            Tower newTower = Instantiate(towerToPurchase);
            _platform.AddTower(newTower);
            aliveTowers.Add(newTower);
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if(instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
        }

        // Start is called before the first frame update
        void Start()
        {
            towerToPurchase = spawnableTowers[0];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
