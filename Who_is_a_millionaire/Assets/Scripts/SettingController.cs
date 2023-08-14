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
        PlayerPrefs.SetInt("SetLv", (int)lv.value);
        PlayerPrefs.SetInt("SetTime", (int)time.value);
        SceneManager.LoadScene((int)SceneIndex.menu);
    }
}
