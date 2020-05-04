using System;
using RPG.UserInterface;
using UnityEngine;

namespace RPG.Core
{
    public class GoldChest : MonoBehaviour
    {
        [SerializeField] [Range(1, 999)] int chestValue = 5;

        Gold gold;

        private void Start()
        {
            gold = FindObjectOfType<Gold>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PickupChest();
            }
        }

        private void PickupChest()
        {
            gold.AddGold(chestValue);
            Destroy(gameObject);
        }

        public void SetDropValue(int minValue, int maxValue)
        {
            int dropValue = UnityEngine.Random.Range(minValue, maxValue);
            chestValue = dropValue; 
        }
    }
}

