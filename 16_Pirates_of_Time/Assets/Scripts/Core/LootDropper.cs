using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropper : MonoBehaviour
{

    [SerializeField] GameObject dropOnDeath;
    [SerializeField] int minGoldDropChestValue;
    [SerializeField] int maxGoldDropChestValue;

    public void DropItem()
    {
        GameObject item;
        item = Instantiate(dropOnDeath, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        item.GetComponent<Rigidbody>().AddExplosionForce(550f, (gameObject.transform.position - gameObject.transform.right * 0.3f - gameObject.transform.up * 0.6f), 1f);
        item.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
        item.GetComponent<GoldChest>().SetDropValue(minGoldDropChestValue, maxGoldDropChestValue);
    }    
      
}
