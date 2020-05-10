using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPG.UserInterface
{
    public class Cannonballs : MonoBehaviour
    {
        [SerializeField] int startingCannonballs = 50;
        [SerializeField] TextMeshProUGUI cannonballText;

        private int cannonballs;

        void Start()
        {
            cannonballs = startingCannonballs;
            UpdateCannonballText();
        }


        public void AddCannonBalls(int amount)
        {
            cannonballs += amount;
            UpdateCannonballText();
        }

        public bool TryToUseCannonBall()
        {
            if (cannonballs > 0)
            {
                cannonballs--;
                UpdateCannonballText();
                return true;
            }
            else
            {
                Debug.Log("Out of Cannonballs!");
                return false;
            }

        }

        private void UpdateCannonballText()
        {
            cannonballText.text = cannonballs.ToString();
        }

    }
}

