using UnityEngine;
using Mirror;

public class Minimap : NetworkBehaviour
{
    [SerializeField] Transform playerLoc;
    [SerializeField] Transform playerRemote;
    [SerializeField] private GameObject cam;

    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void LateUpdate()
    {
        //cam = GameObject.FindGameObjectWithTag("MinimapCam");

        if (isLocalPlayer)
        {
            playerLoc = player.transform;

            Vector3 newPosition = playerLoc.position;
            newPosition.y = cam.transform.position.y;
            cam.transform.position = newPosition;

            cam.transform.rotation = Quaternion.Euler(90f, playerLoc.eulerAngles.y, 0f);
        }

        if (!isLocalPlayer)
        {
            playerRemote = player.transform;

            Vector3 newPosition = playerRemote.position;
            newPosition.y = cam.transform.position.y;
            cam.transform.position = newPosition;

            cam.transform.rotation = Quaternion.Euler(90f, playerRemote.eulerAngles.y, 0f);
        }

        
    }
}
