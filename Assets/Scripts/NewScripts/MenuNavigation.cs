using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuNavigation : MonoBehaviour
{
    //массив кнопок с адресами сцен
    [Header("Set In Inspector")]

    public List<ButtonNavigation> buttonsNavigation = new List<ButtonNavigation>();
    public List<Button> buttons;

    [Header("Set in dynamicly")]
    public List<Button> buttonsPage;
    

    private int page = 1;
    private bool lastPage = false;
    private void Start()
    {
        getButtons();
        print("count = " + buttons.Count);
        
    }

    private void Update()
    {
      
    }

    public void getButtons()
    {
        int x = buttons.Count * page;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
        for (int i = 0; i < buttons.Count; i++)
            {
            if ((x - 4) + i == buttonsNavigation.Count)
            {
                lastPage = true;
                break;
            }
            buttons[i].GetComponentInChildren<Text>().text = buttonsNavigation[(x - 4)+i].title;
                print("Test : " + i + " - " + buttons[i].GetComponentInChildren<Text>().text);
            buttons[i].gameObject.SetActive(true);
            
            }
        
       
        if(page == 1)
        {
            buttonsPage[0].gameObject.SetActive(false);
        }
        else
        {
            buttonsPage[0].gameObject.SetActive(true);
        }

        if(lastPage == true)
        {
            buttonsPage[1].gameObject.SetActive(false);
        }
        else
        {
            buttonsPage[1].gameObject.SetActive(true);
        }

    }

    public void NextPage()
    {   if(buttons.Count > 0 && lastPage == false)
        {
            page++;
        }
        print("Page = " + page + " x = " + buttons.Count * page);
        getButtons();


    }
    public void PrevPage()
    {
        if (page > 1)
        {
            page--;
            lastPage = false;
        }
        getButtons();
    }
}
[System.Serializable]
public class ButtonNavigation
{
    public string adress;
    public string title;

    bool access = false;

    void Access()
    {
        access = true;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(title);
    }

}
