using UnityEngine;

public class SpawnMenu : MonoBehaviour
{
    [SerializeField] GameObject charaSelect;
    
    void Start()
    {
        GameObject go = Instantiate(charaSelect);
    }
}
