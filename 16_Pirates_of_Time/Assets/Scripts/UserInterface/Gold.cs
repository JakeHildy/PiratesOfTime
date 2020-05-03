using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{

    [SerializeField] int startingGold = 100;
    [SerializeField] TextMeshProUGUI goldText;

    private int gold;

    void Start()
    {
        goldText.text = startingGold.ToString();
        gold = startingGold;
    }


}
