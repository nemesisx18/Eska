using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerUI : NetworkBehaviour
{
    private NetworkManager networkManager;
    
    [SerializeField]
    RectTransform healthBarFill;

    [SerializeField]
    private Image content;

    [SerializeField]
    Text ammoText;

    [SerializeField]
    Text magAmmoText;
    
    [SerializeField]
    GameObject pauseMenu;
    
    [SerializeField]
    GameObject scoreboard;

    [SerializeField]
    private Color fullColor;

    [SerializeField]
    private Color lowColor;

    [SerializeField] private Player player;
    private PlayerController controller;
    private WeaponManager weaponManager;

    public void SetPlayer (Player _player)
    {
        player = _player;
        controller = player.GetComponent<PlayerController>();
        weaponManager = player.GetComponent<WeaponManager>();
    }

    void Start()
    {
        networkManager = NetworkManager.singleton;
        
        PauseMenu.IsOn = false;
    }

    void Update()
    {
        SetHealthAmount(player.GetHealthPct());

        content.color = Color.Lerp(lowColor, fullColor, player.GetHealthPct());

        SetAmmoAmount(weaponManager.GetCurrentWeapon().bullets);
        SetMagAmount(weaponManager.GetCurrentWeapon().magBullets);
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            scoreboard.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            scoreboard.SetActive(false);
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }

    void SetHealthAmount (float _amount)
    {
        healthBarFill.localScale = new Vector3(1f, _amount, 1f);
    }

    void SetAmmoAmount (int _amount)
    {
        ammoText.text = _amount.ToString();
    }

    void SetMagAmount (int _amount)
    {
        magAmmoText.text = _amount.ToString();
    }

    public void DisconnectGame()
    {
        if (!isLocalPlayer)
        {
            NetworkManager.singleton.StopHost();
        }

        if (isLocalPlayer)
        {
            NetworkManager.singleton.StopClient();
        }
        SceneManager.LoadScene("MainMenu");
    }
}
