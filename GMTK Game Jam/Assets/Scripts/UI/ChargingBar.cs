using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBar : MonoBehaviour
{

    [SerializeField] private GameObject barFolder, chargingBar;

    public void UpdateChargingBar(float currentCooldown, float maxCooldown )
    {
        if(currentCooldown>0)
        {
            barFolder.SetActive(true);
            chargingBar.transform.localScale = new Vector3(0.30849f *Mathf.Clamp01( currentCooldown / maxCooldown), 0.5f, 1);

            chargingBar.GetComponent<Renderer>().material.color = Color.Lerp(Color.green, Color.red, currentCooldown / maxCooldown) ;
            

        }
        else
        {
            barFolder.SetActive(false);
        }
    }
}
