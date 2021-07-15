using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponArsenalManager : MonoBehaviour
{
    public void Arsenal()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void WeaponArsenal()
    {
        SceneManager.LoadScene("WeaponArsenal");
    }

    public void Mag4()
    {
        SceneManager.LoadScene("Mag-4");
    }

    public void Ak47()
    {
        SceneManager.LoadScene("Ak47");
    }

    public void SSV()
    {
        SceneManager.LoadScene("SSV");
    }
}
