using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [Header("load")]
    [SerializeField] GameObject load;
    [SerializeField] Slider[] sliders;
    [SerializeField] Color32 color;

    [Header("Node")]
    [SerializeField] TextMeshProUGUI text;

    float time_delay;
    string[] mess = { "If I fail, I try again and again, and again.", 
        "You値l never be brave if you do not get hurt. You値l never learn if you do not make mistakes.\n\rYou値l never be successful if you do not encounter failure.",
        "I値l always choose a lazy person痴 job� because he値l find an easy way to do it.",
        "Never stop learning because life never stops teaching.",
        "Once you stop learning, you will start dying.",
        "On The Way To Success, There Is No Trace Of Lazy Men.",
        "Education is the most powerful weapon we use to change the world.",
        " The most beautiful thing about learning is that no one takes that away from you."};

    // Start is called before the first frame update
    void Start()
    {
        time_delay = Random.Range(0.3f, 0.7f);
        text.text = mess[(int)Random.Range(0, mess.Length - 1)];
        sliders[0].maxValue = load.transform.childCount;
        sliders[1].maxValue = load.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(time_delay > 0)
        {
            time_delay -= Time.deltaTime;
        }
        else
        {
            if (sliders[0].value == sliders[0].maxValue)
            {
                SceneManager.LoadScene((int)SceneIndex.menu);
                return;
            }
            load.transform.GetChild((int)(sliders[0].maxValue - sliders[0].value) - 1).gameObject.GetComponent<Image>().color = color;
            time_delay = Random.Range(0.3f, 0.7f);
            sliders[0].value++;
            sliders[1].value++;
        }
    }
}
