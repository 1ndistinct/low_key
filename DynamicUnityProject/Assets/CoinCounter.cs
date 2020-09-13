using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text CoinText;
    // Start is called before the first frame update
    void Start()
    {
        CoinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = GameManager.Coins.ToString();
    }
}
