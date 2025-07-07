using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Handgun : Weapon
    {
        public override void Shoot()
        {
            RaycastHit hit;
            currentAmmo--;
            

            if (Physics.Raycast(bulletOrigin[0].transform.position, Vector3.forward, out hit, range, layers))
            {
                Debug.Log("Golpeo");

                if (hit.collider.TryGetComponent<IDamageable>(out IDamageable target))
                {
                    Debug.Log("Golpeo (Segundo If)");
                    target.GetDamage(damage);
                    Fogonazo.Play();
                    GameObject Impacto = Instantiate(Agujero, hit.point, Quaternion.LookRotation(Vector3.up, hit.normal));

                    Impacto.transform.position += Impacto.transform.forward / 1000;
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        hit.transform.GetComponent<Enemigo>().Danio(damage);
                    }
                }

                

                canShoot = false;

                StartCoroutine(FireRateCooldown());
            }

            






        }

        public override void Reload()
        {
            
        }

        public IEnumerator FireRateCooldown()
        {
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }
    }
}


