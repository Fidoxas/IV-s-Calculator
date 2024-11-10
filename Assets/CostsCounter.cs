using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CostsCounter : MonoBehaviour
{
    private float pokemonCost = 0;
    private List<string> ivs;
    private List<string> ivsIncluded;
    
    [SerializeField] private TMPro.TextMeshProUGUI totalCostTmp;
    [SerializeField] private TMPro.TextMeshProUGUI pokemonCostTmp;
    [SerializeField] private TMPro.TextMeshProUGUI bandCostTmp;
    [SerializeField] private TMPro.TextMeshProUGUI bandCountTmp;
    [SerializeField] private TMPro.TextMeshProUGUI pokeCountTmp;
    [SerializeField] private TMPro.TextMeshProUGUI maleCountTmp;
    [SerializeField] private TMPro.TextMeshProUGUI femaleCountTmp;
    [SerializeField] private List<GameObject> bandsDispays;
    
    List<GameObject> bandsIncluded ;

    int pokemonsNeeded;
    void Start()
    {
        ivs = new List<string>();
        ivsIncluded = new List<string>();
        
        ivs.Add("HP");
        ivs.Add("ATK");
        ivs.Add("DEF");
        ivs.Add("SP_ATK");
        ivs.Add("SP_DEF");
        ivs.Add("SPEED");
        for (int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.GetInt(ivs[i]) != 0)
            {
                ivsIncluded.Add(ivs[i]);
            }
        }

        pokemonCost = PlayerPrefs.GetFloat(("pokemonCost"), 0f);
        Debug.Log(ivsIncluded.Count.ToString() + " ilości iv");

        CountCosts();
        Debug.Log(ivsIncluded.Count.ToString() + " ilości iv2");
    }

    void CountCosts()
    {
        int ivsCount = ivsIncluded.Count;
        float pokeCost = (int)Math.Pow(2, ivsCount - 1) * pokemonCost;
        int bandCost = (int)((Math.Pow(2, ivsCount) - 2) * 10000);
    
        pokemonCostTmp.text = (pokeCost / 1000).ToString() + "k";
        bandCostTmp.text = (bandCost / 1000).ToString() + "k";
        totalCostTmp.text = ((pokeCost + bandCost) / 1000).ToString() + "k";
        if (pokeCost == 0)
        {
            pokemonCostTmp.gameObject.transform.parent.gameObject.SetActive(false);
        }
        
        PokemonCost();
        BandCost();
        CountBands();
    }

    private void PokemonCost()
    {
        pokemonsNeeded = (int)Math.Pow(2, ivsIncluded.Count - 1);
        pokeCountTmp.text = pokemonsNeeded.ToString();
        int pokeSex = pokemonsNeeded / 2;
        maleCountTmp.text = pokeSex.ToString();
        femaleCountTmp.text = pokeSex.ToString();
    }

    private void CountBands()
    {
        Debug.Log(ivsIncluded.Count.ToString() + "warunek spełniony");
        TMPro.TextMeshProUGUI textMeshPro;
        int bandCount = (int)((Math.Pow(2, ivsIncluded.Count) - 2));
        bandCountTmp.text = bandCount.ToString();
        if (ivsIncluded.Count == 2)
        {
            foreach (var band in bandsIncluded)
            {
                textMeshPro = band.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                textMeshPro.text = 1.ToString();
            }
        }
        else if (ivsIncluded.Count == 3)
        {
            foreach (var band in bandsIncluded)
            {
                textMeshPro = band.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                textMeshPro.text = 2.ToString();
            }
        }
        else if (ivsIncluded.Count == 4)
        {
            bandsIncluded[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 4.ToString();
            bandsIncluded[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 4.ToString();
            bandsIncluded[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 3.ToString();
            bandsIncluded[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 3.ToString();
        }
        else if (ivsIncluded.Count == 5)
        {
            bandsIncluded[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 8.ToString();
            bandsIncluded[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 8.ToString();
            bandsIncluded[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 6.ToString();
            bandsIncluded[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 4.ToString();
            bandsIncluded[4].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 4.ToString();
        }
        else if (ivsIncluded.Count == 6)
        {
            bandsIncluded[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 16.ToString();
            bandsIncluded[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 16.ToString();
            bandsIncluded[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 12.ToString();
            bandsIncluded[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 8.ToString();
            bandsIncluded[4].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 5.ToString();
            bandsIncluded[5].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = 5.ToString();
        }
    }


    private void BandCost()
    {
        bandsIncluded = new List<GameObject>();
        int ivsCount = ivsIncluded.Count;
        int bandCount = (int)((Math.Pow(2, ivsCount) - 2));
        bandCountTmp.text = bandCount.ToString();

        foreach (var band in bandsDispays)
        {
            foreach (var iv in ivsIncluded)
            {
                if (band.name == iv)
                bandsIncluded.Add(band);
            }
        }
        
        UnableBands();
    }

    private void UnableBands()
    {
        foreach (var band in bandsIncluded)
        {
            band.SetActive(true);
        }
    }
}

