using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void Level1()
    {
        Globals.SwitchScene("Level 1");
    }
    public void Level2()
    {
        Globals.SwitchScene("Level 2");
    }

    public void Menu()
    {
        Globals.SwitchScene("Menu");
    }
}
