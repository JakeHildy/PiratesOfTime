using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RPG.Movement;
using RPG.Core;


namespace RPG.UserInterface
{
    public class StoreControl : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI titleText;
        [SerializeField] GameObject player;

        private Gold gold;
        private Cannonballs cannonballs;

        private Store currentStore;


        private void Start()
        {
            gold = FindObjectOfType<Gold>();
            cannonballs = FindObjectOfType<Cannonballs>();
        }

        public void SetTitle(string text)
        {
            titleText.text = text;
        }

        public void EnterStore(Store store)
        {
            gameObject.SetActive(true);
            currentStore = store;
            player.GetComponent<Mover>().DisableMover();
        }

        public void ExitStore()
        {
            Debug.Log("Exit Store Button Pressed");
            gameObject.SetActive(false);
            player.GetComponent<Mover>().EnableMover();
            currentStore.LeavePort();
        }

        public void BuyOneCannonball()
        {
            if (gold.PurchaseSomething(1))
            {
                cannonballs.AddCannonBalls(1);
            }
        }

        public void BuyFiveCannonballs()
        {
            if (gold.PurchaseSomething(5))
            {
                cannonballs.AddCannonBalls(5);
            }
        }

        public void BuyFiftyCannonballs()
        {
            if (gold.PurchaseSomething(40))
            {
                cannonballs.AddCannonBalls(50);
            }
        }

        public void BuyOneHundredCannonballs()
        {
            if (gold.PurchaseSomething(70))
            {
                cannonballs.AddCannonBalls(100);
            }
        }
    }

}
