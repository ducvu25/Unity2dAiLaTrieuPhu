using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathController : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI txtQuestion;
    [SerializeField] TextMeshProUGUI txtNumber;
    [SerializeField] TextMeshProUGUI txtResult;
    int result;

    [Header("Answer")]
    [SerializeField] TMP_InputField answer;

    [Header("Time")]
    [SerializeField] GameObject goTime;
    [SerializeField] float time = 20f;
    float m_time, m_time2, setTime;

    [Header("Progress")]
    [SerializeField] Slider progress;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtScore2;
    int score;

    [Header("End")]
    [SerializeField] GameObject end;

    AudioController audioController;

    Vector2 rangeValue = new Vector2(-1, 1);
    bool choose;
    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindWithTag("AudioController").GetComponent<AudioController>();
        score = 0;
        progress.value = 0;
        int y = PlayerPrefs.GetInt("SetLv");
        progress.maxValue = y*5 + 5;
        int x = (int)Mathf.Pow(10, y) ;
        setTime = PlayerPrefs.GetInt("SetTime", 1);
        rangeValue = rangeValue*x;
        end.SetActive(false);
        txtScore.text = "Score: " + score.ToString();
        ResetQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (end.activeSelf || choose)
            return;

        if (m_time >= 0)
        {
            m_time -= Time.deltaTime;
            goTime.GetComponent<Image>().fillAmount = m_time / time;
            if (m_time < 3)
            {
                audioController.PlaySound((int)EffectAudio.time);
            }
            if (m_time < time / 2 + setTime*2)
                return;
            if (m_time2 > 0)
            {
                m_time2 -= Time.deltaTime;
            }
            else
            {
                m_time2 = (time/2 - setTime*2) *1.0f / progress.maxValue;
                int x = (int)Random.Range(rangeValue.x, rangeValue.y);
                result += x;
                Debug.Log(result.ToString());
                if (x >= 0)
                {
                    if(txtQuestion.text != "")
                        txtQuestion.text += " + " + x.ToString();
                    else
                        txtQuestion.text += x.ToString();
                }
                else
                {
                    if (txtQuestion.text != "")
                        txtQuestion.text += " - " + (-x).ToString();
                    else
                        txtQuestion.text += x.ToString();
                }
                txtNumber.text = x.ToString();
            }
        }
        else
        {
            choose = true;
            if (result.ToString() == answer.text)
            {
                audioController.Play((int)EffectAudio.O);
                score++;
                progress.value++;
                txtScore.text = "Score: " + score.ToString();
                Invoke("ResetQuestion", 1f);
            }
            else
            {
                audioController.Play((int)EffectAudio.X);
                txtResult.text = result.ToString();
                txtResult.gameObject.SetActive(true);
                Invoke("EndGame", 0.3f);
            }
        }
    }

    private void ResetQuestion()
    {
        if(progress.value == progress.maxValue)
        {
            Invoke("EndGame", 0.3f);
            return;
        }
        txtQuestion.text = "";
        txtNumber.text = "";
        answer.text = "";
        m_time = time;
        m_time2 = (time - 3) * 1.0f / progress.maxValue;
        result = 0;
        choose = false;
    }
    void EndGame()
    {
        end.SetActive(true);
        txtScore2.text = "Score: " + score.ToString();
    }
}
