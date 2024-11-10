using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ExpandButton : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject triangle;
    bool expanded;



    public void Expand()
    {
        expanded = !expanded;
        panel.SetActive(expanded);
        triangle.SetActive(!expanded);
    }

}
