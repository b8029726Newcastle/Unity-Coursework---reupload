using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to access component "Text"

public class CollectablesCounter : MonoBehaviour
{
    public GameObject collectablesCounterText;
    public static int count, totalCount;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        totalCount = 50; //do a count of how  many ccollectables I have at the start of the game
    }


    // Update is called once per frame
    void Update()
    {
        collectablesCounterText.GetComponent<Text>().text = $"Collectibles: {count}/{totalCount}"; //interpolated string to substitute values depending on count
    }


}
