using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker colorPicker;

    public void NewColorSelected(Color color)
    {
        MainManager.instance.teamColor = color;
    }

    private void Start()
    {
        colorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        colorPicker.onColorChanged += NewColorSelected;
        colorPicker.SelectColor(MainManager.instance.teamColor);
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        MainManager.instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
