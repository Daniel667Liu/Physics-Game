using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungasControll : MonoBehaviour
{
    public Flowchart Flowchart;
    public GameObject GameUI;
    private ShipControll  shipControll;
    private ShipTransform shipAnimControll;
    // Start is called before the first frame update
    void Start()
    {
        shipAnimControll = FindObjectOfType<ShipTransform>().GetComponent<ShipTransform>();
        shipControll = FindObjectOfType<ShipControll>().GetComponent<ShipControll>();//find the controll component in the scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) 
        {
            Flowchart.ExecuteBlock("TestBlock");
        }
        UIControll(Flowchart.GetBooleanVariable("UI"));//get bool value from fungus chart
    }

    public void UIControll(bool a)
    {
        if (a)//show the ui and enable control
        {
            GameUI.SetActive(true);
            shipControll.enabled = true;
            shipAnimControll.enabled = true;
            
        }

        else //hide the ui and disable the control
        {
            GameUI.SetActive(false);
            shipControll.enabled = false;
            shipAnimControll.enabled = false;
        }
    }

    
}
