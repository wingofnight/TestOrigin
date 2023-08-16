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

  public void Mixer() { 

       TylerReik.Extraction(Answers);
    }

    
    

   /*  public void AnswersMixer()//Тасование Фишера-Йетса
     {
         for (int i = 0; i < Answers.Count; i++)
         {
             Answer tmp = Answers[i];
             int randAnswer = Random.Range(0, Answers.Count);
             Answers[i] = Answers[randAnswer];
             Answers[randAnswer] = tmp;
         }
     }*/
}

[System.Serializable]
public class Answer
{
    public string Text;
    public int Value; // В зависимости от типа приложения (Тесты или Викторина) тспользовать ID или Value, для понятности.
}

public static class TylerReik
{
   /* public static void Extraction(object array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            
            object tmp = array[i];
            int randAnswer = Random.Range(0, array.Count);
            array[i] = array[randAnswer];
            array[randAnswer] = tmp;
        }

    }*/

    public static void Extraction<T>(List<T> array )
     {
         for (int i = 0; i < array.Count; i++)
         {
             T tmp = array[i];
             int randAnswer = Random.Range(0, array.Count);
             array[i] = array[randAnswer];
             array[randAnswer] = tmp;
         }

     }

    /* public static List<Answer> Extraction(List<Answer> array)//Тасование Фишера-Йетса
      {
          for (int i = 0; i < array.Count; i++)
          {
              Answer tmp = array[i];
              int randAnswer = Random.Range(0, array.Count);
              array[i] = array[randAnswer];
              array[randAnswer] = tmp;
          }
          return array;
      }

      public static List<Question> Extraction(List<Question> array)//Тасование Фишера-Йетса
      {
          for (int i = 0; i < array.Count; i++)
          {
              Question tmp = array[i];
              int randAnswer = Random.Range(0, array.Count);
              array[i] = array[randAnswer];
              array[randAnswer] = tmp;
          }
          return array;
      }*/
}