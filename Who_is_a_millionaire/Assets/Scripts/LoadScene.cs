using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum SceneIndex
{
    loading,
    menu,
    play,
    createAQuestion,
    setting,
    quit
}
public class LoadScene : MonoBehaviour
{
    public void SetScene(int index)
    {
        if(index != (int)SceneIndex.quit)
            SceneManager.LoadScene(index);
        else
            Application.Quit();
    }
}
