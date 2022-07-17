using UnityEngine;

public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// Метод загрузки сцены игры
    /// </summary>
    public void buttone()
    {
        Loader.Load(Loader.Scene.Game);
    }

    /// <summary>
    /// Метод загрузки сцены меню
    /// </summary>
    public void buttoneMenu()
    {
        Loader.Load(Loader.Scene.Menu);
    }
}
