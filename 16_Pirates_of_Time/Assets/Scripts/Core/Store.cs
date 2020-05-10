using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.UserInterface;


namespace RPG.Core
{
    public class Store : MonoBehaviour
    {
        [SerializeField] string portName;
        [SerializeField] StoreControl store;

        

        private bool inPort = false;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (inPort == false)
                {
                    inPort = true;
                    Debug.Log("Player At Port " + portName);
                    store.EnterStore(this);
                    store.SetTitle(portName);
                    
                }
            }
        }

        public void LeavePort()
        {
            inPort = false;            
        }



    }
}


