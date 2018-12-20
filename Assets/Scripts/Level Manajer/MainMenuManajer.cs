using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuManajer : MonoBehaviour {
    [SerializeField]
    private Button ContinueBtn;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Current Level") <= 1)
        {
            ContinueBtn.interactable = false;
        }
    }


    public void ContinueGame()
    {
        int Level = PlayerPrefs.GetInt("Current Level");
        SceneManager.LoadScene(Level);

    }
}
