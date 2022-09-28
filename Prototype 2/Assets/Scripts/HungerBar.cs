using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider bar;

    public void SetHunger(int hunger)
    {
        bar.value = hunger;
    }

    public void SetMaxHunger(int maxHunger)
    {
        bar.maxValue = maxHunger;
    }
}
