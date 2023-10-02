using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System;
using UnityEngine.UIElements;
using UnityEditor;

public class MousePoint : MonoBehaviour
{
   // public delegate void Click();
   // public static event Click Pose;

    public int missiles;

    public string skillOne;
    public string skillTwo;
    public string skillThree;
    public string skillFour;
    public bool skill1;
    public bool skill2;
    public bool skill3;
    public bool skill4;
    public GameObject shooter;
    public bool Missile;
    public bool Homing;
    public bool Hinged;
    public bool Ground;
    public bool Bomb;
    public bool Mine;

    public bool hold;
    // public bool rotating;


    public Transform targetPos;
    public Transform shooterPos;
    
    public GameObject target;

    public GameObject homing;
    public GameObject missile;
    public GameObject hinged;
    public GameObject bomb;
    public GameObject mine;
    public GameObject ground;

    public GameObject castEffect;
    public GameObject clickedObject;
    public GameObject pointer;
    public Vector3 newPosition;
    public Vector3 direction;

    public AI_Behaviour playerCommand;
    public GameObject player;
   // public float rotatetime;
   // public float timer;
   // public float angle;


    void Start()
    {
        newPosition = transform.position;
        player = shooter;
       // playerCommand = player.GetComponent<AI_Behaviour>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //moving pointer
                newPosition = hit.point;
                pointer.transform.position = newPosition;
                clickedObject = hit.transform.gameObject;
                if (clickedObject.layer == 6)
                { 
                    playerCommand.agent.stoppingDistance = 0;
                    Instantiate(castEffect, pointer.transform.position, Quaternion.Euler(270, 0, 0));
                    pointer.transform.position = new Vector3(pointer.transform.position.x, pointer.transform.position.y + 0.5f, pointer.transform.position.z);
                    if (Missile) { transform.LookAt(pointer.transform.position); }
                    playerCommand.target = pointer;
                    float actrange = Vector3.Distance(pointer.transform.position, transform.position);

                    if (hold)
                    {
                        if (actrange < playerCommand.unitstats.attack_range)
                        {
                            playerCommand.point = pointer.transform;
                            playerCommand.Turn();
                            if(playerCommand.unitstats.attack_type == "ranged")
                            {
                                playerCommand.Shoot();
                            }
                            if (playerCommand.unitstats.attack_type == "magic")
                            {
                                playerCommand.Magic();
                            }
                        }
                    } else
                    {
                        playerCommand.Move();
                    }
                }
                if (clickedObject != null && clickedObject.layer == 8)
                {
                    playerCommand.agent.stoppingDistance = 2;
                    //target locking

                    transform.LookAt(pointer.transform.position);
                    //moving pointer & spell effect
                    pointer.transform.position = clickedObject.transform.position;
                    playerCommand.target = clickedObject;
                    playerCommand.targetstats = clickedObject.GetComponent<Character_Stats>();
                    float actrange = Vector3.Distance(pointer.transform.position, transform.position);
                    if (actrange < (playerCommand.unitstats.attack_range+0.5))
                    {
                        playerCommand.point = pointer.transform;
                        playerCommand.Turn();
                        if(playerCommand.unitstats.attack_type == "melee")
                        {
                            playerCommand.Strike();
                        }

                        
                        if (playerCommand.unitstats.attack_type == "range")
                        {
                            playerCommand.Shoot();
                        }
                        if (playerCommand.unitstats.attack_type == "magic")
                        {
                            playerCommand.Magic();
                        }
                        
                        // Instantiate(castEffect, pointer.transform.position, Quaternion.Euler(270, 0, 0));
                    }
                    else
                    {
                        // if(Vector3.Distance(target.transform.position, transform.position) < actrange) { playerCommand.Turn(); }

                        playerCommand.Turn();
                        playerCommand.Move();
                       // Debug.Log(0);
                    }

                   
                }



            }



            //triggers for shooting
                if (clickedObject.layer == 8 && Homing) {
                    GameObject instantiated = Instantiate(homing, shooter.transform.position, shooter.transform.rotation);
                   Homing home = instantiated.GetComponent<Homing>();
                   home.target = clickedObject;
                }
            if (clickedObject.layer == 6 && Missile)
            {
                Instantiate(missile, shooter.transform.position, shooter.transform.rotation);
            }
            if (clickedObject.layer == 8 && Missile)
            {
                GameObject instantiated = Instantiate(missile, shooter.transform.position, shooter.transform.rotation);
                Missile predict = instantiated.GetComponent<Missile>();
                predict.target = clickedObject;
            }
            if (Hinged)
            { Instantiate(hinged, shooter.transform.position, shooter.transform.rotation); }
            if (Ground)
            { Instantiate(ground, shooter.transform.position, shooter.transform.rotation); }
            if (Bomb)
            {newPosition = new Vector3(pointer.transform.position.x, pointer.transform.position.y + 10, pointer.transform.position.z);
            Instantiate(bomb, newPosition, pointer.transform.rotation); }
            if (Mine)
            { newPosition = new Vector3(pointer.transform.position.x, pointer.transform.position.y + 1, pointer.transform.position.z);
            Instantiate(mine, newPosition, pointer.transform.rotation); }
            }
        








        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //moving pointer
                newPosition = hit.point;
                pointer.transform.position = newPosition;
                clickedObject = hit.transform.gameObject;
                if (clickedObject.layer == 6)
                {
                    playerCommand.agent.stoppingDistance = 0;
                    Instantiate(castEffect, pointer.transform.position, Quaternion.Euler(270, 0, 0));
                    pointer.transform.position = new Vector3(pointer.transform.position.x, pointer.transform.position.y + 0.5f, pointer.transform.position.z);
                    if (Missile) { transform.LookAt(pointer.transform.position); }
                    playerCommand.target = pointer;
                    float actrange = Vector3.Distance(pointer.transform.position, transform.position);

                    //hold doesn't work!!!
                    if (hold)
                    {
                        if (actrange < playerCommand.unitstats.attack_range)
                        {
                            playerCommand.point = pointer.transform;
                            playerCommand.Turn();
                            if (playerCommand.unitstats.attack_type == "ranged")
                            {
                                playerCommand.Magic();
                            }
                            if (playerCommand.unitstats.attack_type == "magic")
                            {
                                playerCommand.Magic();
                            }
                        }
                    }
                    else
                    {
                        playerCommand.Magic();
                    }
                }
                if (clickedObject != null && clickedObject.layer == 8)
                {
                    playerCommand.agent.stoppingDistance = 2;
                    //target locking

                    transform.LookAt(pointer.transform.position);
                    //moving pointer & spell effect
                    pointer.transform.position = clickedObject.transform.position;
                    playerCommand.target = clickedObject;
                    playerCommand.targetstats = clickedObject.GetComponent<Character_Stats>();
                    float actrange = Vector3.Distance(pointer.transform.position, transform.position);
                    if (actrange < (playerCommand.unitstats.attack_range + 0.5))
                    {
                        playerCommand.point = pointer.transform;
                        playerCommand.Turn();
                        if (playerCommand.skill_type == "melee")
                        {
                            playerCommand.Magic();
                        }


                        if (playerCommand.skill_type == "range")
                        {
                            playerCommand.Magic();
                        }
                        if (playerCommand.skill_type == "magic")
                        {
                            playerCommand.Magic();
                        }

                        // Instantiate(castEffect, pointer.transform.position, Quaternion.Euler(270, 0, 0));
                    }
                    else
                    {
                        // if(Vector3.Distance(target.transform.position, transform.position) < actrange) { playerCommand.Turn(); }

                        playerCommand.Turn();
                        playerCommand.Magic();
                        // Debug.Log(0);
                    }


                }



            }



        }






    }




}
