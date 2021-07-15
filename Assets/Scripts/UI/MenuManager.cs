using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPopUp;
    public GameObject HomeMenu;
    public GameObject ArsenalMenu;
    public GameObject StatsMenu;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level Subway");
    }

    public void Arsenal()
    {
        SceneManager.LoadScene("Arsenal");
    }

    public void WeaponArsenal()
    {
        SceneManager.LoadScene("WeaponArsenal");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsPopUpTrue()
    {
        optionsPopUp.SetActive(true);
    }

    public void OptionsPopUpFalse()
    {
        optionsPopUp.SetActive(false);
    }

    public void HomePopUpTrue()
    {
        HomeMenu.SetActive(true);
        ArsenalMenu.SetActive(false);
        StatsMenu.SetActive(false);
    }

   

    public void ArsenalPopUpTrue()
    {
        HomeMenu.SetActive(false);
        ArsenalMenu.SetActive(true);
        StatsMenu.SetActive(false);
    }

    

    public void StatsPopUPTrue()
    {
        HomeMenu.SetActive(false);
        ArsenalMenu.SetActive(false);
        StatsMenu.SetActive(true);
    }

   
}
