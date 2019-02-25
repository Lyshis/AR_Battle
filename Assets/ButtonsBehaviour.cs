using UnityEngine;
using UnityEngine.UI;

public class ButtonsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        switch (this.gameObject.name)
        {
            case "Move":
                TurnManager.SetState(0);
                break;
            case "Spell1":
                TurnManager.SetState(1);
                break;
            case "Spell2":
                TurnManager.SetState(2);
                break;
            case "Spell3":
                TurnManager.SetState(3);
                break;
            case "Spell4":
                TurnManager.SetState(4);
                break;
            case "EndTurn":
                TurnManager.EndTurn();
                break;
        }
    }

    public void Visibility(string name, bool value)
    {
        if (name == "Move")
        {
            if (this.gameObject.name == "Move") this.gameObject.GetComponent<Button>().interactable = value;
        }
        else if (name == "Spell")
        {
            if (this.gameObject.name == "Spell1") this.gameObject.GetComponent<Button>().interactable = value;
            if (this.gameObject.name == "Spell2") this.gameObject.GetComponent<Button>().interactable = value;
            if (this.gameObject.name == "Spell3") this.gameObject.GetComponent<Button>().interactable = value;
            if (this.gameObject.name == "Spell4") this.gameObject.GetComponent<Button>().interactable = value;
        }
    }
}
