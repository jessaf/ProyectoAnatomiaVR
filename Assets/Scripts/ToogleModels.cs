/// Author: Sergio Teodoro Vite
/// Creation date: 2018/09/02
/// Last updated: 2018/11/01
/// ARAnatomyExplorer
/// UNAM, 2018
/// /// <summary>
/// This program enable or disable the models in the scene.
/// </summary>

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToogleModels : MonoBehaviour {

    public int firstIntLabel = 1;    // first index of the labeling
    public int lastIntLabel = 7;     // last index of the labeling
    
    public Button myPrevButton;  // previous canvas button
    public Button myNextButton;  // next canvas button

    public GameObject modelRoot;  // game object to preocess

    private int currentIndex;   // index model controller

	// Start function
	void Start () {

        // Disable all models except the first
        for (int i = 0; i < modelRoot.transform.childCount; i++)
        {
            Transform child = modelRoot.transform.GetChild(i);
            string childName = child.gameObject.name;
            int parsedLabel = int.Parse(childName.Split('_')[0]);
            if ( parsedLabel != firstIntLabel )
                child.gameObject.SetActive(false);
        }
        currentIndex = firstIntLabel;

        // Buttons controls
        Button btnPrev = myPrevButton.GetComponent<Button>();
        if ( btnPrev != null )
            btnPrev.onClick.AddListener(OnClickPrev);

        Button btnNext = myNextButton.GetComponent<Button>();
        if ( btnNext != null )
            btnNext.onClick.AddListener(OnClickNext);
        
    }

    

    void OnClickPrev()
    {
        SwapModels(-1);
    }

    void OnClickNext()
    {
        SwapModels(1);
    }

    void SwapModels(int direction)
    {
        // increase current index
        currentIndex+=direction;

        // verify visualization sequence
        if (currentIndex > lastIntLabel)
            currentIndex = firstIntLabel;

        if (currentIndex < firstIntLabel)
            currentIndex = lastIntLabel;

        // Enable models selected
        for (int i = 0; i < modelRoot.transform.childCount; i++)
        {
            Transform child = modelRoot.transform.GetChild(i);
            string childName = child.gameObject.name;
            int parsedLabel = int.Parse(childName.Split('_')[0]);
            if (parsedLabel == currentIndex )
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }
        
    }

    // Update function is called once per frame
    void Update () {
        
    }
}
