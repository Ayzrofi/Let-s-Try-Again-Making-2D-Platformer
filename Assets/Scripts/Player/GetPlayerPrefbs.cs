using UnityEngine;
using UnityEngine.SceneManagement;

public class GetPlayerPrefbs : MonoBehaviour {
    public static int Index;

    private void Awake()
    {
        SaveGame();
        //DeleteSaveGame();
    }
    public static void SaveGame()
    {
        Index = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Current Level", Index);
        Debug.Log(PlayerPrefs.GetInt("Current Level"));
    }

    public static void DeleteSaveGame()
    {
        PlayerPrefs.DeleteKey("Current Level");
        Debug.Log(PlayerPrefs.GetInt("Current Level"));
    }
}
