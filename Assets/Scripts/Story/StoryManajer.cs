using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManajer : MonoBehaviour {
    [SerializeField]
    Animator Anim;
    [SerializeField]
    private GameObject[] StoryPanel;
    int index = 0;
    public GameObject NextBtn;
    public string LevelToLoadLater;
    private void Start()
    {
        for (int i = 1; i < StoryPanel.Length; i++)
        {
            StoryPanel[i].SetActive(false);
        }
    }

    public void PlayTransition()
    {
        StartCoroutine(StoryTransition());
    }
    public IEnumerator StoryTransition()
    {
        Anim.SetTrigger("End");
        NextBtn.SetActive(false);
        yield return new WaitForSeconds(5f);

        StoryPanel[index].SetActive(false);
        index++;
        if (index < StoryPanel.Length)
        {
       
            StoryPanel[index].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(LevelToLoadLater);
        }

        Anim.SetTrigger("Start");
        yield return new WaitForSeconds(3f);
        NextBtn.SetActive(true);
        Debug.Log("LOLI Is The Best");
    }
}
