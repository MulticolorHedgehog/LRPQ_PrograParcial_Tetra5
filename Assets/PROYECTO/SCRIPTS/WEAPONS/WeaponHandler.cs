using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Weapon[] weapons;
        [SerializeField] private Weapon actualWeapon;

        
        private int currentWeaponIndex;

        private Action Shoot;
        private Action SpecialAction;

        private void Start()
        {
            
            actualWeapon = weapons[currentWeaponIndex];
            Shoot = AutomaticShoot;

           
        }

        private void Update()
        {
            SwitchWeapon();
            Shoot();
            TriggerSpecialAction();
        }

        private void AutomaticShoot()
        {
            Debug.Log(actualWeapon.CheckAmmo());
            if (actualWeapon.CheckAmmo() && Input.GetMouseButton(0))
            {
                
                Debug.Log("Disparo");
                actualWeapon.Shoot();
                
            }
        }

        private void SemiAutomaticShoot()
        {
            Debug.Log(actualWeapon.CheckAmmo());
            if (actualWeapon.CheckAmmo() && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Disparo");
                
                actualWeapon.Shoot();
                
            }
        }

        private void SetweaponActions()
        {
            switch (actualWeapon)
            {
                case AutomaticRifle automaticRifle:
                    {
                        Shoot = AutomaticShoot;
                        SpecialAction = automaticRifle.GranadeLaunch;
                        break;
                    }

                case Handgun:
                    {
                        Shoot = SemiAutomaticShoot;
                        break;
                    }

                case Shotgun:
                    {
                        Shoot = SemiAutomaticShoot;
                        break;
                    }
            }
        }

        private void TriggerSpecialAction()
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                SpecialAction();
            }
        }
        private void SwitchWeapon()
        {
            
            if(MouseScroll() > 0)
            {
                currentWeaponIndex++;
                currentWeaponIndex = currentWeaponIndex >= weapons.Length ? 0 : currentWeaponIndex;
                actualWeapon = weapons[currentWeaponIndex];
                Debug.Log("Intentando acceder al índice: " + currentWeaponIndex);

                if (currentWeaponIndex >= 0 && currentWeaponIndex < weapons.Length)
                {
                    actualWeapon = weapons[currentWeaponIndex];
                }
                else
                {
                    Debug.LogError("Índice fuera de rango: " + currentWeaponIndex);
                }
                SetweaponActions();
            }
            else if(MouseScroll() < 0)
            {
                
                currentWeaponIndex--; // 0 : -1
                currentWeaponIndex = currentWeaponIndex >= weapons.Length ? 0 : currentWeaponIndex;
                actualWeapon = weapons[currentWeaponIndex];
                Debug.Log("Intentando acceder al índice: " + currentWeaponIndex);
                if (currentWeaponIndex >= 0 && currentWeaponIndex < weapons.Length)
                {
                    actualWeapon = weapons[currentWeaponIndex];
                }
                else
                {
                    Debug.LogError("Índice fuera de rango: " + currentWeaponIndex);
                }
                SetweaponActions();
            }
        }

        private int MouseScroll()
        {
            float input = Input.GetAxis("Mouse ScrollWheel");
            return input == 0 ? 0 : input > 0 ? 1 : -1;
        }

    }
}

