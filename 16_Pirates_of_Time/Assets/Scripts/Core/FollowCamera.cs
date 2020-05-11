using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float turnSpeed = 4.0f;




        void Update()
        {
            transform.position = target.position;
        }

    }
}

