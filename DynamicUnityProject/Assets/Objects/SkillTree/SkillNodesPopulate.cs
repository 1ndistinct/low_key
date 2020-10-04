using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillNodesPopulate : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> Nodes;
    public Dictionary<string, GameObject> nodeDict = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Nodes.ForEach(node => {
            nodeDict.Add(node.transform.Find("ItemText").GetComponent<Text>().text.ToLower(), node);
        });

        PlayerController1.abilities.ForEach(ability => {
            nodeDict[ability].GetComponent<onClickNode>().setActive(true);

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
