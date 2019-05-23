/// Author: Sergio Teodoro Vite
/// Creation date: 2018/09/02
/// ARAnatomyExplorer
/// UNAM, 2018
/// /// <summary>
/// This program manages the general buttons in the scene.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralButtonsManager : MonoBehaviour {

    public Button exitButton;

    // Use this for initialization
    void Start () {
        // Buttons controls
        Button btnExit = exitButton.GetComponent<Button>();
        if (btnExit != null)
            btnExit.onClick.AddListener(OnClickExit);
    }

    void OnClickExit() {
        // save any game data here
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif

    }

    // Update is called once per frame
    void Update () {
		
	}
}
