﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{

    public List<UI_Class> UI_classes = new List<UI_Class>();

   
    private StateCMD _stateCMD;

    public Text textbox;

    //Input class that input events are reported to 
    InputClass _InputClass;

    private Sim sim;
    

    public void Start()
    {
        
        foreach (GameObject obj in GetChildren())
        {
            UI_classes.Add(new UI_Class(obj, obj.name));
        }

        
        _stateCMD = new StateCMD(textbox);

        //Get the input manager
        _InputClass = GameManager.Instance.GetInputClass();

        //Hide the action menu
        HideActionMenu();

        //subscribe to input classes
        //Pause event
        _InputClass.onTogglePause += HideMenu;

        sim = GameManager.Instance.GetSelectedSim();
    }

    private void Update()
    {

        
        //World state updated 
        _stateCMD.Process(sim.beliefs);
        //_stateCMD.Process(GameManager.Instance.GetWorld());

    }

    private GameObject[] GetChildren()
    {
        GameObject[] tempArray = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            tempArray[i] = this.transform.GetChild(i).gameObject;
        }

        return tempArray;
    }



    private void HideMenu()
    {
        SetActiveStateForUI("Menu");
    }

    private void HideActionMenu()
    {
        SetActiveStateForUI("ActionMenu");
    }

    

    public void SetActiveStateForUI(string UIname)
    {
        foreach(UI_Class ui in UI_classes)
        {
            if(ui.name == UIname)
            {
                ui.HideAllUI();
                return;
            }
        }

        Debug.Log("No ui object with name " + UIname);
    }




}
