using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Towers
{
    //MachineGunTower has access to everything public in Tower script
    public class MachineGunTower : Tower
    {
        protected override void RenderAttackVisuals()
        {
            Debug.Log("My name is machine gun tower! You killed my father, prepare to die");
        }
    }
}


