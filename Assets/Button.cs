using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnClickStartButton()
    {
        Destroy(gameObject);
    }
}
