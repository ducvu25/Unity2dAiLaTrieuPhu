using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingController : MonoBehaviour
{
    [Header("Lv")]
    [SerializeField] Slider lv;
    [SerializeField] TextMeshProUGUI txtLv;

    [Header("Time")]
    [SerializeField] Slider time;
    // Start is called before the first frame update
    void Start()
    {
        lv.value = PlayerPrefs.GetInt("SetLv", 1);
        txtLv.text = "LV: " + lv.value.ToString();
        time.value = PlayerPrefs.GetInt("SetTime", 1);
    }
    public void Out()
    {
        Invoke("OutScene", 0.5f);
    }
    void OutScene()
    {
       /* Debug.Log(PlayerPrefs.GetInt("SetLv"));*/
        PlayerPrefs.SetInt("SetLv", (int)lv.value);
        //Debug.Log(PlayerPrefs.GetInt("SetLv"));
        PlayerPrefs.SetInt("SetTime", (int)time.value);
        SceneManager.LoadScene((int)SceneIndex.menu);
    }
}
