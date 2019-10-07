using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class setsizetest : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider box;
    public Vector3 size;
    public TextMeshProUGUI text;
    public float MaxsizeofboxY=16.1f;
    public Renderer liquid;
    void Start()
    {
        box=GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float addmore=0;
        if(size.y>=3.5f)addmore=10;
        if(size.y>=7.5f)addmore=15;
        if(size.y>=8.5f)addmore=18;
        if(size.y>=11.1f)addmore=22;
        if(size.y>=12.1f)addmore=30;
        if(size.y>MaxsizeofboxY)size.y=MaxsizeofboxY; 
        box.size=new Vector3(size.x+size.x+1,size.y+size.y+1+addmore,size.z+size.z+1);
        box.center=size;
        // box.center=new Vector3(box.center.x,box.center.y+addmore,box.center.z);
        text.text=lange.setml()+size.y+" ml";
        liquid.material.SetFloat("_FillAmount",setLiquidML(size.y));
    }
    float setLiquidML(float ml){
        float addmore=.8f;
        float liquidml=liquid.material.GetFloat("_FillAmount");
        liquidml=7.5f-addmore*ml;
        return liquidml;
    }
}
