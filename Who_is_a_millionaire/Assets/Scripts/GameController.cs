using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI txtQuestion;

    [Header("Answer")]
    [SerializeField] GameObject[] answers;
    [SerializeField] Color32 correctAnswerColor;
    [SerializeField] Color32 defaultAnswerColor;

    [Header("Time")]
    [SerializeField] GameObject goTime;
    [SerializeField] float time = 10f;
    float m_time;

    [Header("Progress")]
    [SerializeField] Slider progress;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtScore2;
    int score;

    [Header("End")]
    [SerializeField] GameObject end;

    Quiz quiz;
    QuestionSO question;
    // Start is called before the first frame update
    void Start()
    {
        quiz = GetComponent<Quiz>();
        quiz.Play();
        score = 0;
        progress.value = 0;
        progress.maxValue = quiz.MaxLength();
        NewQuestion();
        end.SetActive(false);
        txtScore.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (end.activeSelf)
            return;
        if (m_time >= 0)
        {
            m_time -= Time.deltaTime;
            goTime.GetComponent<Image>().fillAmount = m_time / time;
        }
        else
        {
            TimeOut();
        }
    }
    void NewQuestion()
    {
        if (progress.value == progress.maxValue)
        {
            end.SetActive(true);
            txtScore2.text = "Score: " + score.ToString();
        }
        else
        {
            progress.value++;
            question = quiz.NewQuestion();
            m_time = time;
            goTime.GetComponent<Image>().fillAmount = m_time / time;
            SetButtonState(true);
            DisplayQuestion();
        }
    }
    void DisplayQuestion()
    {
        txtQuestion.text = question.GetQuestion();
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
            answers[i].GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
            answers[i].transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //answers[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i); // neu la con truc tiep
        }
    }
    void SetButtonState(bool value = true)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].GetComponent<Button>().interactable = value;
        }
    }
    void TimeOut()
    {
        answers[question.GetKey()].GetComponent<Button>().image.color = correctAnswerColor;
        answers[question.GetKey()].transform.GetChild(1).GetComponent<Image>().color = correctAnswerColor;
        SetButtonState(false);
    }
    public void ChooseAnswer(int index)
    {
        answers[question.GetKey()].GetComponent<Button>().image.color = correctAnswerColor;
        answers[question.GetKey()].transform.GetChild(1).GetComponent<Image>().color = correctAnswerColor;
        if (index != question.GetKey())
        {
            answers[index].GetComponent<Button>().image.color = defaultAnswerColor;
            answers[index].transform.GetChild(1).GetComponent<Image>().color = defaultAnswerColor;
        }
        else
        {
            score++;
            txtScore.text = "Score: " + score.ToString();
        }
        SetButtonState(false);
        Invoke("NewQuestion", 0.5f);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        SceneManager.LoadScene((int)SceneIndex.menu);
    }
}
