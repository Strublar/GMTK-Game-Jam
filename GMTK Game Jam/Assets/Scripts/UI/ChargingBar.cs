using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBar : MonoBehaviour
{

    [SerializeField] private GameObject barFolder, chargingBar;

    public void UpdateChargingBar(bool isCharging,float currentCharge, float minCharge, float maxCharge )
    {
        if(isCharging)
        {
            barFolder.SetActive(true);
            chargingBar.transform.localScale = new Vector3(0.30849f *Mathf.Clamp01( currentCharge / maxCharge), 0.5f, 1);
            if(currentCharge<minCharge)
            {
                chargingBar.GetComponent<Renderer>().material.color = Color.white;
            }
            else if (currentCharge > maxCharge)
            {
                chargingBar.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else 
            {
                chargingBar.GetComponent<Renderer>().material.color = Color.green;
            }
        }
        else
        {
            barFolder.SetActive(false);
        }
    }
}
