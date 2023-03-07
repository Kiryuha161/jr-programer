using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }

    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void StartNew(int scene)
    {
        SceneManager.LoadScene(scene); //1 - индекс сцены
    }

    public void Exit()
    {
#if UNITY_EDITOR   //# - условная компиляция, т.е. компиляция или пропуск части кода в зависимости от того существует ли условие или нет. Все строки с # не являются кодом. Они не будут 
        //выполнены вообще, если не выполнено условие, его как будто не существует. Это инструкция для компилятора. Ещё это называют препроцессорами. Код 
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
   
    }
}
