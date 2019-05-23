/// Author: Sergio Teodoro Vite
/// Creation date: 2018/09/02
/// Last updated: 2018/11/01
/// ARAnatomyExplorer
/// UNAM, 2018
/// /// <summary>
/// This program resets the models in the scene.
/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformModels : MonoBehaviour {
    
    
    public Button resetButton;

    private Vector3 initPosition;
    private Quaternion initRotation;
    private Vector3 initScale;

    public GameObject modelRoot;
    
    // Use this for initialization
    void Start () {

        initPosition = modelRoot.transform.position;
        initRotation = modelRoot.transform.rotation;
        initScale = modelRoot.transform.localScale;

        Button btnReset = resetButton.GetComponent<Button>();
        if (btnReset != null)
            btnReset.onClick.AddListener(OnModelsReset);

        
    }

    private void OnModelsReset()
    {

        modelRoot.transform.position = initPosition;
        modelRoot.transform.rotation = initRotation;
        modelRoot.transform.localScale = initScale;
    }
    

    // Update is called once per frame
    void Update () {
        
    }
}
