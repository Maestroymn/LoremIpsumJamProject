using InputSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeybindScript : MonoBehaviour
{
    public KeyboardListener keyboardListener;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TMP_Text first, second, third, fourth, fifth, sixth;

    private GameObject currentKey;
    void Awake()
    {
        keys.Add("First", keyboardListener.FirstKey);
        keys.Add("Second", keyboardListener.SecondKey);
        keys.Add("Third", keyboardListener.ThirdKey);
        keys.Add("Fourth", keyboardListener.FourthKey);
        keys.Add("Fifth", keyboardListener.FifthKey);
        keys.Add("Sixth", keyboardListener.SixthKey);

        first.text = keys["First"].ToString();
        second.text = keys["Second"].ToString();
        third.text = keys["Third"].ToString();
        fourth.text = keys["Fourth"].ToString();
        fifth.text = keys["Fifth"].ToString();
        sixth.text = keys["Sixth"].ToString();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(keys["First"]))
        {
            Debug.Log("First");
        }

        if (Input.GetKeyDown(keys["Second"]))
        {
            Debug.Log("Second");
        }

        if (Input.GetKeyDown(keys["Third"]))
        {
            Debug.Log("Third");
        }

        if (Input.GetKeyDown(keys["Fourth"]))
        {
            Debug.Log("Fourth");
        }

        if (Input.GetKeyDown(keys["Fifth"]))
        {
            Debug.Log("Fifth");
        }

        if (Input.GetKeyDown(keys["Sixth"]))
        {
            Debug.Log("Sixth");
        }

    }

    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                keyboardListener.FirstKey = keys["First"];
                keyboardListener.SecondKey = keys["Second"];
                keyboardListener.ThirdKey = keys["Third"];
                keyboardListener.FourthKey = keys["Fourth"];
                keyboardListener.FifthKey = keys["Fifth"];
                keyboardListener.SixthKey = keys["Sixth"];
                currentKey.transform.GetChild(0).GetComponent<TMP_Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
