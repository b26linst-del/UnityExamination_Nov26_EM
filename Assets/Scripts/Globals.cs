using UnityEngine;
using UnityEngine.SceneManagement;

public static class Globals
{
    public static int Coins;
    public static bool Key;
    
    public static void SwitchScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
