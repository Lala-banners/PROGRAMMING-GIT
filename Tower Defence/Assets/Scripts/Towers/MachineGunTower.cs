using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Utilities;

namespace TowerDefence.Towers
{
    //MachineGunTower has access to everything public in Tower script
    public class MachineGunTower : Tower
    {

        [Header("Machine Gun Specifics")]
        [SerializeField]
        private Transform turret;
        [SerializeField]
        private Transform gunHolder;
        [SerializeField]
        private LineRenderer bulletLine; //visual of the bullet from the barrel of the gun
        [SerializeField]
        private Transform leftFirePoint;
        [SerializeField]
        private Transform rightFirePoint;

        private bool fireLeft = false;



        protected override void RenderAttackVisuals()
        {
            //Distance and direction between tower and TargetedEnemy
            MathUtils.DistanceAndDirection(out float distance, out Vector3 direction, gunHolder, TargetedEnemy.transform);

            //Gun barrels point at enemy
            gunHolder.rotation = Quaternion.LookRotation(direction);

            if (fireLeft)
            {
                RenderBulletLine(leftFirePoint);
            }
            else
            {
                RenderBulletLine(rightFirePoint);
            }

            fireLeft = !fireLeft;
        }

        private void RenderBulletLine(Transform _start)
        {
            //Spawns a line with two points from the start position to the Targeted Enemy position
            bulletLine.positionCount = 2;
            bulletLine.SetPosition(0, _start.position);
            bulletLine.SetPosition(1, TargetedEnemy.transform.position);

            
                
        }
    }
}


