using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(1, 20)]
    [SerializeField] string question = "Eneter new question text here";
    [SerializeField] string[] answer = {"A", "B", "C", "D"};
    [Range(0, 3)]
    [SerializeField] int key = 0;
}
