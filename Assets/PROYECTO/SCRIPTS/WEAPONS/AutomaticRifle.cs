using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AutomaticRifle : Weapon
    {
        public override void Shoot()
        {
            Debug.Log("Pum te disparo");
        }

        public override void Reload()
        {
            Shoot();
        }

        public void GranadeLaunch()
        {
            Debug.Log("Lanzando peras");
        }
    }
}

