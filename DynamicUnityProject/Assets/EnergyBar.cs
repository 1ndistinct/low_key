using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class EnergyBar : MonoBehaviour
{
    public Slider slider;
  
    // Start is called before the first frame update

    public void setMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
        
        
    }
    public void setEnergy(float energy)
    {
        slider.value = energy;
        
    }
}
