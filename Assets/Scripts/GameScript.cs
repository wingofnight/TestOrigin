using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public QuestionsList[] Questions;
    public Text[] AnswersText;
    public Text qText;

    List<object> qList;
    QuestionsList crntQ;
    int randQ;
    public void OnClickGo()
    {
        qList = new List<object>(Questions);
        QuestionGenerate();
    }
    public void QuestionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionsList;
            qText.text = crntQ.Question;
            List<string> Answers = new List<string>(crntQ.Answers);
            for (int i = 0; i < crntQ.Answers.Length; i++)
            {
                int rand = Random.Range(0, Answers.Count);
                AnswersText[i].text = Answers[rand];
                Answers.RemoveAt(rand);
            }
        }
        else
        {
            print("the end");
        }
        
    }
public void answrsBuutons(int index)
    {
        if (AnswersText[index].text.ToString() == crntQ.Answers[0]) print("Correct");
        else print("incorrect");
        qList.RemoveAt(randQ);
        QuestionGenerate();
    }
}
[System.Serializable]
public class QuestionsList
{
    public string Question;
    public string[] Answers = new string[3];
}
 