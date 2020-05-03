using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Cannon : MonoBehaviour
    {

        [SerializeField] GameObject barrelLocation;
        [SerializeField] GameObject cannonBallPrefab;

        public float shotPower = 100f;


        public void Shoot()
        {
            GameObject cannonBall;
            cannonBall = Instantiate(cannonBallPrefab, barrelLocation.transform.position, barrelLocation.transform.rotation) as GameObject;
            cannonBall.GetComponent<Rigidbody>().AddForce(barrelLocation.transform.forward * shotPower);
            Destroy(cannonBall, 5f);
            GetComponent<AudioSource>().Play();
        }
    }
}

