using UnityEngine;

public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// ����� �������� ����� ����
    /// </summary>
    public void buttone()
    {
        Loader.Load(Loader.Scene.Game);
    }

    /// <summary>
    /// ����� �������� ����� ����
    /// </summary>
    public void buttoneMenu()
    {
        Loader.Load(Loader.Scene.Menu);
    }
}
