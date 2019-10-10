using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liquidsetvolume : MonoBehaviour
{
    Renderer ren;
    public float volume=0,maxVolume=250;
    float ml50=4f;
    float ml100=2.8f;
    float ml200=2.210598f;
    float ml250=-2.8f;
    float m0=5.0026f;
    // Start is called before the first frame update
    void Start()
    {
        ren=GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if(volume<=50)
        ren.material.SetFloat("_FillAmount",m0-volume*(m0-ml50)/50);
        if(volume<=200 && volume>50)
        ren.material.SetFloat("_FillAmount",m0-volume*(m0-ml100)/200);
        if(volume<250&&volume>200)
        ren.material.SetFloat("_FillAmount",m0-volume*(m0-ml250)/250);
        */
        volume=Mathf.Clamp(volume,0,maxVolume);
        if(volume<=200)
        ren.material.SetFloat("_FillAmount",m0-volume*(m0-ml200)/200);
        else
        {
          ren.material.SetFloat("_FillAmount",m0-(200*(m0-ml200)/200+(volume-200)/10.1f));
        }
    }
}
