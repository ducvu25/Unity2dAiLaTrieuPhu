using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(1, 20)]
    [SerializeField] string question = "Eneter new question text here";
    [SerializeField] string[] answers = {"A", "B", "C", "D"};
    [Range(0, 3)]
    [SerializeField] int key = 0;
    public void Set(string question, string[] answers, int key )    {
        this.question = question;
        this.answers = answers;
        this.key = key;
    }

    public string GetQuestion() { return question; }
    public int GetKey() { return key; }
    public string GetAnswer(int index) { return answers[index]; }
}
