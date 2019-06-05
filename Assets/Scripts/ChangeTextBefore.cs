using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextBefore : MonoBehaviour
{

    public Text changingText;

    public GameObject changingTextTwo;

    void Start()
    {
    }
    void Update()
    {
    }

    public void TextChangeBefore()
    {
        changingText.text = "2";
        changingTextTwo.GetComponent<Text>().text = "2";

    }
}
