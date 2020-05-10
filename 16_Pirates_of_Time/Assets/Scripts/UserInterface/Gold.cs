using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPG.UserInterface
{
    public class Gold : MonoBehaviour
    {
        [SerializeField] int startingGold = 100;
        [SerializeField] TextMeshProUGUI goldText;

        private int gold;

        void Start()
        {           
            gold = startingGold;
            UpdateGoldText();
        }


        public void AddGold(int amount)
        {
            gold += amount;
            UpdateGoldText();
        }

        public bool PurchaseSomething(int price)
        {
            if (gold >= price)
            {
                gold -= price;
                UpdateGoldText();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateGoldText()
        {
            goldText.text = gold.ToString();
        }

    }
}

