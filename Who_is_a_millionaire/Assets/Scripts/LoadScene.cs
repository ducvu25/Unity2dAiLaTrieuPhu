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
    int index = 0;
    public void SetScene(int index)
    {
        this.index = index;
        Invoke("Load", 0.5f);
    }
    void Load()
    {
        if (index != (int)SceneIndex.quit)
            SceneManager.LoadScene(index);
        else
            Application.Quit();
    }
}
