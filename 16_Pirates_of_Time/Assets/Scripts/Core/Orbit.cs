using UnityEngine;
using System.Collections;


namespace RPG.Core
{
    public class Orbit : MonoBehaviour
    {

        public float turnSpeed = 4.0f;
        public Transform player;

        private Vector3 offset;

        void Start()
        {
            //offset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 7.0f);
            offset = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y, player.position.z - gameObject.transform.position.z);
        }

        private void Update()
        {
            transform.position = player.position - offset;
            transform.LookAt(player.position);
        }

        void LateUpdate()
        {
            if (Input.GetMouseButton(1))
            {
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;                                
            }            
        }

    }

}

