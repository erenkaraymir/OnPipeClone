using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FpsController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text fpsText;
    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        fpsText.text = fps.ToString();
    }
}
