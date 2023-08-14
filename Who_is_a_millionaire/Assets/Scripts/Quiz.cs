using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    List<QuestionSO> questions;
    
    // Start is called before the first frame update
    public void Play()
    {
        questions = new List<QuestionSO>();
        QuestionSO[] loadedQuestions = Resources.LoadAll<QuestionSO>("Questions");
        foreach (QuestionSO question in loadedQuestions)
        {
            questions.Add(question);
        }
       // Debug.Log(questions.Count);
    }
    public QuestionSO NewQuestion()
    {
        //Debug.Log(questions.Count);
        if (questions.Count > 0)
        {
            int index = (int)Random.Range(0, questions.Count - 1);
            QuestionSO t = questions[index];
            //questions.Remove(t);
            questions.RemoveAt(index);
            //Debug.Log(index);
            //Debug.Log(questions.Count);
            return t;
        }
        return null;
    }
    public int MaxLength()
    {
        return questions.Count;
    }   
}
