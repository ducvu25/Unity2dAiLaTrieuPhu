using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class CreateAQuestion : MonoBehaviour
{
    [SerializeField] TMP_InputField question;
    [SerializeField] TMP_InputField[] answers;
    [SerializeField] TMP_InputField name;
    [SerializeField] GameObject Check;
    int key = -1;
    private void Start()
    {
        NewCreateAQuestion();
    }
    void NewCreateAQuestion()
    {
        Check.SetActive(false);
        key = -1;
        question.text = "Enter the question!";
        for(int i=0; i<answers.Length; i++)
        {
            answers[i].text = "Answer " + (char)('A' + i);
        }
        name.text = "Enter name question...";
    }
    // Start is called before the first frame update
    public void Create()
    {
        if (key == -1)
        {
            name.text = "Error! You have not entered the answer to the question.";
        }
        else
        {
            string filePath = "Assets/Resources/Questions/" + name.text + ".asset"; // Đường dẫn tệp tin bạn muốn kiểm tra

            if (File.Exists(filePath))
            {
                name.text = "Error! Filename already exists.";
            }
            else
            {
                string[] strings = { answers[0].text, answers[1].text, answers[2].text, answers[3].text };
                QuestionSO questionSO = ScriptableObject.CreateInstance<QuestionSO>();
                questionSO.Set(question.text, strings, key);
                //questionSO.name = name.text;
                string savePath = filePath;
                UnityEditor.AssetDatabase.CreateAsset(questionSO, savePath);
                UnityEditor.AssetDatabase.SaveAssets();

                name.text = "Create success!";
                Invoke("NewCreateAQuestion", 1f);
            }
        }
    }
    public void SetKey(int value)
    {
        key = value;
    }
}
