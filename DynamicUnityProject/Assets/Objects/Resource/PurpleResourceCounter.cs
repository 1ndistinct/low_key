using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleResourceCounter : MonoBehaviour
{
    public Text PRText;
    // Start is called before the first frame update
    void Start()
    {
        PRText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        PRText.text = GameManager.ResourcePurple.ToString();
    }
}
