using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionGenerate : MonoBehaviour
{
    [Header("Set in Inspector")]
    public string FinalScene;
    public Text TextQuestion;
    public List<Question> QuestionsList = new List<Question>();
    public List<Button> buttons;
    public Color correctAnswer = Color.green;
    public Color incorrectAnswer = Color.red;
    public float timeDelay = 1;

    private Color standartColor;
    Question question;
        
    void Start()
    {
        GlobalLogic.CountTrueAnswers = 0;
        standartColor = buttons[0].GetComponent<Graphic>().color;
        foreach (var item in QuestionsList)
        {
            GlobalLogic.Questions.Add(item);
        }
        ShowQuest();
    }

   
   public void ShowQuest()
    {
        foreach (var item in buttons)
        {
            item.GetComponent<Graphic>().color = standartColor;
        }

        int rand = Random.Range(0, QuestionsList.Count);
        question = QuestionsList[rand];
        question.AnswersMixer();
        QuestionsList.RemoveAt(rand);

        TextQuestion.text = question.TextQuestion;
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = question.Answers[i].Text;
        }

    }

    public void CheckAnswer(int index)
    {
        if (question.Answers[index].Value > 0)
        {
            GlobalLogic.CountTrueAnswers += question.Answers[index].Value;// Прибавляет в счетчик правильных ответов значение. Некоторые ответы могут быть более ценны.
            print("Correct");
            buttons[index].GetComponent<Graphic>().color = correctAnswer;
        }
        else
        {
            buttons[index].GetComponent<Graphic>().color = incorrectAnswer;
            print("incorrect");
        }

        StartCoroutine(QuestionChanger());

    }
   
    public void TakeAnswer(int index)
    {
        //GlobalLogic. Abstract Result[index] +  question.Answers[index].ID;
    }

    IEnumerator QuestionChanger()
    {
        yield return new WaitForSeconds(timeDelay);
        if (QuestionsList.Count > 0)
        {
            ShowQuest();
        }
        else
        {
            SceneManager.LoadScene(FinalScene);
        }
    }
}
    