using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

// Loads Sample Scenes
public class StartMenu : MonoBehaviour
{   
    public OVROverlay overlay;
    public OVROverlay text;
    public OVRCameraRig vrRig;
    private Text sliderText;

    void Start()
    {
        DebugUIBuilder.instance.AddLabel("Selecciona una modalidad");
        DebugUIBuilder.instance.AddButton("Aprendizaje libre", LoadAprendizaje);
        DebugUIBuilder.instance.AddButton("Prueba de aprendizaje", LoadPrueba);
        var sliderPrefab = DebugUIBuilder.instance.AddSlider("Slider", 1.0f, 10.0f, SliderPressed, true);
        var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        sliderText = textElementsInSlider[1];
        Assert.IsNotNull(sliderText, "No text component on slider prefab");
        sliderText.text = sliderPrefab.GetComponentInChildren<Slider>().value.ToString();

        DebugUIBuilder.instance.Show();
    }

    // Can't guarantee build order won't change, so use strings for loading
    void LoadScene(string sceneName)
    {
        DebugUIBuilder.instance.Hide();
        StartCoroutine(ShowOverlayAndLoad(sceneName));
    }

    public void SliderPressed(float f)
    {
        Debug.Log("Slider: " + f);
        sliderText.text = f.ToString();
    }

    IEnumerator ShowOverlayAndLoad(string sceneName)
    {
        text.transform.position = vrRig.centerEyeAnchor.position + Vector3.ProjectOnPlane(vrRig.centerEyeAnchor.forward, Vector3.up).normalized * 3f;
        overlay.enabled = true;
        text.enabled = true;
        // Waiting to prevent "pop" to new scene
        yield return new WaitForSeconds(1f);
        // Load Scene and wait til complete
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        yield return null;
    }

    #region Scene Load Callbacks
    void LoadAprendizaje()
    {
        LoadScene("LerningScene");
    }
    void LoadPrueba()
    {
        LoadScene("TestScene");
    }
    
    #endregion
}
