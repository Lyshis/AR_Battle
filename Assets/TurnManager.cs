using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    static Dictionary<string, List<TacticsMove>> units = new Dictionary<string, List<TacticsMove>>();
    static Queue<string> turnKey = new Queue<string>();
    static Queue<TacticsMove> turnTeam = new Queue<TacticsMove>();

    public static PlayerMove player1;
    public static PlayerMove player2;

    // Use this for initialization
    void Start()
    {
        player1 = GameObject.Find("Player").GetComponent<PlayerMove>();
        player2 = GameObject.Find("Player (1)").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnTeam.Count == 0)
        {
            InitTeamTurnQueue();
        }
    }

    static void InitTeamTurnQueue()
    {
        List<TacticsMove> teamList = units[turnKey.Peek()];

        foreach (TacticsMove unit in teamList)
        {
            turnTeam.Enqueue(unit);
        }

        StartTurn();
    }

    public static void StartTurn()
    {
        foreach (var player in turnTeam)
        {
            player.actualMove = player.move;
            player.state = 0;
        }

        if (turnTeam.Count > 0)
        {
            turnTeam.Peek().BeginTurn();
        }
    }

    public static void EndTurn()
    {
        TacticsMove unit = turnTeam.Dequeue();
        unit.EndTurn();

        if (turnTeam.Count > 0)
        {
            StartTurn();
        }
        else
        {
            string team = turnKey.Dequeue();
            turnKey.Enqueue(team);
            InitTeamTurnQueue();
        }
    }

    public static void AddUnit(TacticsMove unit)
    {
        List<TacticsMove> list;

        if (!units.ContainsKey(unit.tag))
        {
            list = new List<TacticsMove>();
            units[unit.tag] = list;

            if (!turnKey.Contains(unit.tag))
            {
                turnKey.Enqueue(unit.tag);
            }
        }
        else
        {
            list = units[unit.tag];
        }

        list.Add(unit);
    }

    public static void SetState(int nb)
    {
        turnTeam.Peek().state = nb;

        switch (nb)
        {
            case 0:
                break;
            case 1:
                turnTeam.Peek().range = 1;
                break;
            case 2:
                turnTeam.Peek().range = 3;
                break;
            case 3:
                turnTeam.Peek().range = 0;
                turnTeam.Peek().actualMove += 2;
                turnTeam.Peek().actionPoints -= 1;
                break;
            case 4:
                turnTeam.Peek().range = 7;
                break;
        }

        turnTeam.Peek().FindSelectableTiles(turnTeam.Peek().actualMove);
    }

    public static void Hit(int spell, Tile t)
    {
        if (turnTeam.Peek().actionPoints > 0)
        {
            RaycastHit hit;
            Ray r = new Ray(t.transform.position, t.transform.up);
            if (Physics.Raycast(r, out hit))
            {
                switch (spell)
                {
                    case 1:
                        Debug.Log(spell, t);
                        if (turnTeam.Peek().name == "Player")
                            player1.health -= 10;
                        else
                        {
                            player2.health -= 10;
                        }

                        turnTeam.Peek().actionPoints -= 1;
                        break;
                    case 2:
                        if (turnTeam.Peek().name == "Player")
                            player1.health -= 5;
                        else
                        {
                            player2.health -= 5;
                        }

                        turnTeam.Peek().actionPoints -= 1;
                        break;
                    case 3:
                        turnTeam.Peek().actionPoints -= 1;
                        break;
                }
            }
            else if (spell == 4)
            {
                t.walkable = false;
            }
        }
    }
}