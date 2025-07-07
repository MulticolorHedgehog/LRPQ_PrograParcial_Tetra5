using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Shotgun : Weapon
    {
        public override void Shoot()
        {
            throw new System.NotImplementedException();
        }

        public override void Reload()
        {
            Shoot();
        }
    }
}


