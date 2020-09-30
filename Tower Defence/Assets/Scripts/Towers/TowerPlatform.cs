using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Managers;

namespace TowerDefence.Towers
{
    public class TowerPlatform : MonoBehaviour
    {
        //Need reference to tower
        [SerializeField]
        private Transform towerHolder;

        private Tower heldTower;

        //Method to check if tower exists so it can be purchased when the button has been clicked
        private void OnMouseUpAsButton()
        {
            if (heldTower == null)
            {
                TowerManager.instance.PurchaseTower(this);
            }
            
        }

        public void AddTower(Tower _tower)
        {
            //Fix error in TowerManager
            //Set this as child to Tower
            heldTower = _tower;

            _tower.transform.SetParent(towerHolder);
            //Check if tower is in right postition 
            _tower.transform.localPosition = Vector3.zero;
        }
    }
}


