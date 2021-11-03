using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button loadButton;
    // Start is called before the first frame update
    public event EventHandler StartGameEvent;
    void Start()
    {
        startButton.onClick.AddListener(StartButtnClick);
        loadButton.onClick.AddListener(LoadButtonClick);
    }

    void LoadButtonClick() { }

    void StartButtnClick() {
        StartGameEvent?.Invoke(this, EventArgs.Empty);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
