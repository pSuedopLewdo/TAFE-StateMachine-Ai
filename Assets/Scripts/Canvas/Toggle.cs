using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject toggleGameObject;
    
    public void ToggleButton()
    {
        if (toggleGameObject != null)
        {
            bool isActive = toggleGameObject.activeSelf;
            toggleGameObject.SetActive(!isActive);
        }
    }
}
