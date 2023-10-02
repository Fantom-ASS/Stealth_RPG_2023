using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clan_Data : MonoBehaviour
{
    public GameObject unit1;
    public GameObject unit2;

    public Character_Stats stats1;
    public Character_Stats stats2;


    public int[] fraction1 = { 0, 1, 2 };
    public int[] fraction2 = { 3, 4, 5 };
    public int[] loyalty1 = { 2, 0, 1 };
    public int[] loyalty2 = { 0, 2, 1 };


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (unit1 != null && unit2 != null)
            {
                stats1 = unit1.GetComponent<Character_Stats>();
                stats2 = unit2.GetComponent<Character_Stats>();
                if (stats1.unit_clan <= 2 && stats2.unit_clan <= 2)
                {
                    Debug.Log(stats1.unit_name + " is friendly to " + stats2.unit_name);
                }
                if (stats1.unit_clan > 2 && stats2.unit_clan > 2)
                {
                    Debug.Log(stats1.unit_name + " is friendly to " + stats2.unit_name);
                }
                if (stats1.unit_clan <= 2 && stats2.unit_clan > 2)
                {
                    Debug.Log(stats1.unit_name + " is hostile to " + stats2.unit_name);
                }
                if (stats1.unit_clan > 2 && stats2.unit_clan <= 2)
                {
                    Debug.Log(stats1.unit_name + " is hostile to " + stats2.unit_name);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (unit1 != null)
            {
                stats1 = unit1.GetComponent<Character_Stats>();
                bool alive = stats1.unit_alive;
                bool organic = stats1.unit_organic;
                bool undead = (stats1.unit_race == "undead");
                if (alive && organic && undead) {Debug.Log(stats1.unit_name + " is alive organic undead enemy");}
                if (alive && organic && !undead) { Debug.Log(stats1.unit_name + " is alive organic living enemy"); }


            }


        }
    }
}