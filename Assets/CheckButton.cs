using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckButton : MonoBehaviour
{
    [SerializeField] string stat;
    [SerializeField] private GameObject check;
    private bool active;
    private int value;
    void Start()
    {
        LoadValues();
    }

    void LoadValues()
    {
         value = PlayerPrefs.GetInt(stat, 1);
         active = value != 0;
         check.SetActive(active);
    }

    public void Check()
    {
        Debug.Log("BUTTON CLICKED");
        check.SetActive(!active);
        active = !active;
       if(active)
           value = 1;
        else
           value = 0;
        
        PlayerPrefs.SetInt(stat, value);
        Debug.Log(stat+ value);
    }
}
