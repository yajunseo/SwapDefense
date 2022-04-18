/* 
* Copyright (C) SundayToz Corp. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@sundaytoz.com>
* @created 2021/12/10
* @desc PopupManager
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PopupImportant : System.Attribute
{
    public string path, name;

    public PopupImportant(string name, string path){this.name = name;this.path = path;}
}
 
public class PopupManager : MonoBehaviour
{
    [SerializeField] public RectTransform PopupRootPos;
    [SerializeField] public GameObject Dimmed;
    [SerializeField] GameObject[] Popup_Prefabs;

    [HideInInspector] public string CurrentPopupState;
    [HideInInspector] public Dictionary<string, GameObject> PopupPrefabs;

    GameObject PopupPrefab;

    private static PopupManager instance = null;
        
    public static PopupManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if(instance)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        PopupPrefabs = new Dictionary<string, GameObject>();
    }
    
    public T PopupCreate <T> ()
    {
        // Use Reflection Attributes
        System.Attribute attrs = System.Attribute.GetCustomAttribute(typeof(T), typeof(PopupImportant));
        PopupImportant popup = (PopupImportant)attrs;

        foreach(GameObject popup_tmp in Popup_Prefabs)
            if(popup_tmp.name == popup.name)
            {
                PopupPrefab = popup_tmp;
                PopupPrefab.name = popup.name;
                CurrentPopupState = popup.name;
                PopupPrefabs.Add(PopupPrefab.name, (GameObject)Instantiate(PopupPrefab, PopupRootPos));
            }

        Dimmed.SetActive(true);
        Dimmed.transform.SetSiblingIndex(PopupPrefabs.Count - 1);

        return PopupPrefabs[PopupPrefab.name].GetComponent<T>();
    }
    public void PopupDestroy<T>()
    {
        //foreach(KeyValuePair<string, GameObject> item in PopupPrefabs) Debug.Log(item.Key + " / ");
        System.Attribute attrs = System.Attribute.GetCustomAttribute(typeof(T), typeof(PopupImportant));
        PopupImportant popup = (PopupImportant)attrs;
        
        if(PopupPrefabs.ContainsKey(popup.name))
        {   
            Destroy(PopupPrefabs[popup.name]);
            PopupPrefabs.Remove(popup.name);
            
            Dimmed.transform.SetSiblingIndex(PopupPrefabs.Count - 1);
            if(PopupPrefabs.Count == 0) 
            {
                Dimmed.SetActive(false);
            }
        }
        else
        {   // Dictionary 접근 시 KeyNotFound 예외
            Debug.Log("Popup Not Exist");
        }
    }

    public void PopupDestroy(string _popup)
    {
        if(PopupPrefabs.ContainsKey(_popup))
        {   
            Destroy(PopupPrefabs[_popup]);
            PopupPrefabs.Remove(_popup);
            
            Dimmed.transform.SetSiblingIndex(PopupPrefabs.Count - 1);
            if(PopupPrefabs.Count == 0) 
            {
                Dimmed.SetActive(false);
            }
        }
        else
        {   // Dictionary 접근 시 KeyNotFound 예외
            Debug.Log("Popup Not Exist");
        }
    }
}
