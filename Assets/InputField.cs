using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputField : MonoBehaviour
{
    private TMP_InputField tmp;
    private void Start()
    {
        tmp = GetComponent<TMP_InputField>();

        float savedPokemonCost = PlayerPrefs.GetFloat("pokemonCost");

        if (savedPokemonCost != 0)
        {
            tmp.text = savedPokemonCost.ToString();
        }
    }

    public void LoadValue()
    {
        if (decimal.TryParse(tmp.text, out decimal pokemoncost))
        {
            PlayerPrefs.SetFloat("pokemonCost", (float)pokemoncost);
        }
    }
}
