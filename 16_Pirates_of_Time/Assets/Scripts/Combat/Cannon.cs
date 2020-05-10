using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.UserInterface;

namespace RPG.Combat
{
    public class Cannon : MonoBehaviour
    {

        [SerializeField] GameObject barrelLocation;
        [SerializeField] GameObject cannonBallPrefab;
        [SerializeField] bool aIControlled = false;

        Cannonballs cannonballs;

        public float shotPower = 100f;


        private void Start()
        {
            cannonballs = FindObjectOfType<Cannonballs>();
        }

        public void Shoot()
        {
            if (aIControlled || cannonballs.TryToUseCannonBall())
            {
                GameObject cannonBall;
                cannonBall = Instantiate(cannonBallPrefab, barrelLocation.transform.position, barrelLocation.transform.rotation) as GameObject;
                cannonBall.GetComponent<Rigidbody>().AddForce(barrelLocation.transform.forward * shotPower);
                Destroy(cannonBall, 5f);
                GetComponent<AudioSource>().Play();
            }

        }
    }
}

