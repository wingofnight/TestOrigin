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
    public float timeDelayTrue = 1;
    public float timeDelayFalse = 2.5f;
    public int restrictionsQuestions = 0;
    
    private Color standartColor;
    private float timeDelay = 1;
    Question question;
        
    void Start()
    {
        GlobalLogic.CountTrueAnswers = 0;
        standartColor = buttons[0].GetComponent<Graphic>().color;
        TylerReik.Extraction(QuestionsList);
            foreach (var item in QuestionsList)
            {
              item.Mixer();//костыль
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
        //ищи здесь
        int rand = Random.Range(0, QuestionsList.Count);
        question = QuestionsList[rand];

        //Миксует необходимое количество вопросов в стеке.
        // question.AnswersMixer();
         QuestionsList.RemoveAt(rand);

        TextQuestion.text = question.TextQuestion;
       // TextQuestion.text = QuestionsList.TextQuestion;
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = question.Answers[i].Text;
        }

    }

    public void CheckAnswer(int index)
    {
        if (question.Answers[index].Value > 0)
        {
            timeDelay = timeDelayTrue;
            GlobalLogic.CountTrueAnswers += question.Answers[index].Value;// Прибавляет в счетчик правильных ответов значение. Некоторые ответы могут быть более ценны.
            print("Correct");
            buttons[index].GetComponent<Graphic>().color = correctAnswer;
        }
        else
        {
            timeDelay = timeDelayFalse;
            buttons[index].GetComponent<Graphic>().color = incorrectAnswer;
            print("incorrect");
            //сюда добавляем подсветку неправильного ответа
            
            buttons[SearchRightAnswer(question.Answers)].GetComponent<Graphic>().color = correctAnswer;
        }

        StartCoroutine(QuestionChanger());

    }

    //функция ищет правильный ответ и возвращает индекс кнопки
    private int SearchRightAnswer(List<Answer> answers)
    {
        int rightIndex = 0;
        foreach (var item in answers)
        {
            if (item.Value > 0)
            {
                return rightIndex;
            }
            rightIndex++;
        }
        return 0;
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
    