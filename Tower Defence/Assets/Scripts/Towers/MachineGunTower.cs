using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Utilities;
using TowerDefence.Managers;

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

        private float resetTime = 0;
        private bool hasResetVisuals = false;

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
            hasResetVisuals = false;
        }

        protected override void RenderLevelUpVisuals()
        {
            Debug.Log("I am leveling up!");
        }

        protected override void Update()
        {
            base.Update();

            //Detect if we have no enemy AND that we havent already reset the visuals
            if (TargetedEnemy == null && !hasResetVisuals)
            {
                //Check if the current time us less than the fire rate
                if (resetTime < fireRate)
                {
                    //Add to the current time
                    resetTime += Time.deltaTime;
                }
                else
                {
                    //Disable line renderer 
                    //Reset timer to 0
                    //Set reset visuals flag to true
                    bulletLine.positionCount = 0;
                    resetTime = 0;
                    hasResetVisuals = true;
                }
                //Done so the code doesn't have to keep going
            }
                

                    

           
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


