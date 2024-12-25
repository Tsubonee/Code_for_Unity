using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("Assets/Hiromu/Scene/Man/Mountain_1pp.unity");
    }
}