using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResults : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Text TextResults;
    public string[] Results;

    int Range;
    int MaxScores;

    private void Awake()
    {
        Matematic();
        ShowResult();
    }
    void Matematic()
    {
        foreach (Question question in GlobalLogic.Questions)
        {
            foreach (var answer in question.Answers)
            {
                MaxScores += answer.Value;
            }
        }
        Range = MaxScores/ Results.Length;
    }

    void ShowResult()
    {
        int rangeLogic = Range;
       
        foreach (var item in Results)
        {
            if (GlobalLogic.CountTrueAnswers <= rangeLogic || item == Results[Results.Length - 1])
            {
                TextResults.text = $"Ваш результат - {item}\nВы набрали - {GlobalLogic.CountTrueAnswers} балла!";
                break;
            }
            else
            {
                rangeLogic += Range;
            }
        }
    }
    

}
