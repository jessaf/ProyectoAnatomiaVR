using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationScenes : MonoBehaviour {
    
    public Button loadSceneButton;
    public string nameOfTheSceneToLoad;
    public Canvas mainCanvas;
    public Canvas waitCanvas;

    // Use this for initialization
    void Start () {
        Button btn = loadSceneButton.GetComponent<Button>();
        if (btn != null)
            btn.onClick.AddListener(OnClickButton);

        if (waitCanvas != null)
            waitCanvas.gameObject.SetActive(false);
    }

    private void OnClickButton()
    {
        if (mainCanvas != null)
            mainCanvas.gameObject.SetActive(false);

        if (waitCanvas != null)
            waitCanvas.gameObject.SetActive(true);

        if (loadSceneButton != null)
            loadSceneButton.interactable = false;

        SceneManager.LoadScene(nameOfTheSceneToLoad);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
