using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace asfdga
{
    public class Damage : MonoBehaviour, IDamageable
    {
        public void GetDamage(int damage)
        {
            damage = 5;
            Debug.Log("GOLEPPPP");
        }

    }
}


