using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public string weaponName;

        public int damage; //Daño del arma
        public float range; //Alcance del arma
        public float fireRate; //cadencia del arma
        public float accuracy; //Punteria: que tanto se mueve el arma o dispara hacia donde apuntas

        public int currentAmmo; //municion de mi cargador actual
        public int currentMaxAmmo; //Capacidad maxima del cargador
        public int ammo; //municion disponible en la reserva
        public int maxAmmo; //capacidad maxima de mi reserva

        public abstract void Shoot();

        public abstract void Reload();

        public bool CheckAmmo()
        {
            return currentAmmo <= 0 && ammo <= 0;
        }
    }
}

namespace Enemy.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public string weaponName;

        public int damage; //Daño del arma
        public float range; //Alcance del arma
        public float fireRate; //cadencia del arma
        public float accuracy; //Punteria: que tanto se mueve el arma o dispara hacia donde apuntas

        public int currentAmmo; //municion de mi cargador actual
        public int currentMaxAmmo; //Capacidad maxima del cargador
        public int ammo; //municion disponible en la reserva
        public int maxAmmo; //capacidad maxima de mi reserva

        public abstract void Shoot();

        public abstract void Reload();

        public bool CheckAmmo()
        {
            return currentAmmo <= 0 && ammo <= 0;
        }
    }
}

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    
    public int damage; //Daño del arma
    public float range; //Alcance del arma
    public float fireRate; //cadencia del arma (Cooldown)
    public float accuracy; //Punteria: que tanto se mueve el arma o dispara
                           //hacia donde apuntas

    public int currentAmmo; //municion de mi cargador actual
    public int currentMaxAmmo; //Capacidad maxima del cargador
    public int ammo; //municion disponible en la reserva
    public int maxAmmo; //capacidad maxima de mi reserva

    public LayerMask layers;

    public ParticleSystem Fogonazo;

    public AudioSource Disparo;

    public GameObject Agujero;

    public Transform[] bulletOrigin; //La posicion 0 seria para armas de 1 solo impacto

    public bool canShoot;

    public abstract void Shoot();

    public abstract void Reload();

    public bool CheckAmmo()
    {
        return (currentAmmo > 0 && ammo > 0);
    }
}
