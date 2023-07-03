using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public static class GlobalLogic
{
    static public List<Question> Questions = new List<Question>();
    static public int CountTrueAnswers;   
}

[System.Serializable]
public class Question
{
    public string TextQuestion;
    public List<Answer> Answers;

    public void AnswersMixer()//Тасование Фишера-Йетса
    {
        for (int i = 0; i < Answers.Count; i++)
        {
            Answer tmp = Answers[i];
            int randAnswer = Random.Range(0, Answers.Count);
            Answers[i] = Answers[randAnswer];
            Answers[randAnswer] = tmp;
        }
    }
}
[System.Serializable]
public class Answer
{
    public string Text;
    public int Value; // В зависимости от типа приложенияч (Тесты или Викторина) тспользовать ID или Value, для понятности.
}