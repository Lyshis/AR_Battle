using TMPro;
using UnityEngine;

public class ActionPoints : MonoBehaviour
{
    public PlayerMove player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = "Vie : " + player.health;
    }
}
