using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerControl : MonoBehaviour
{
    public LayerMask ground;
    public GameObject portraitHolder;
    public GameObject abilityHolder;
    public GameObject[] portraits; 
    public GameObject[] frames;
    public GameObject marker;
    //public AI_Behaviour partymate1; //behaviour of the main hero
    public UnitData[] matestats; //stats of the main hero
    //public UnitData matestats2; //stats of the first ally
    //public UnitData matestats3; //stats of the second ally
    public UnitData chosenstats; //stats of the noncontrolled bot
    public UnitData botstats; //stats of the noncontrolled bot
    public TextMeshProUGUI charname;//displayed name of character
    public TextMeshProUGUI life;//displayed current & maximum HP of character
    public TextMeshProUGUI mana;//displayed current & maximum MP of character
    public Image[] lifebar;
    public Image[] manabar;

    //textures for spells
    public Texture[] textures_large;
    public Texture[] textures_small;
    public Sprite[] cast_images;

    //images of spells and orders of chosen character
    public Image[] casts; //1 - base attack, 2 - special attack, 3-6 - primary abilities
    public Image castmask1;
    public Image castmask2;
    public Image castmask3;
    public Image castmask4;

    //cooldowns of all heroes spells
    public Image[] castmask;
    public Image castmask1_2;
    public Image castmask1_3;
    public Image castmask1_4;



    public TextMeshProUGUI castcharge1;
    public TextMeshProUGUI castcharge2;
    public TextMeshProUGUI castcharge3;
    public TextMeshProUGUI castcharge4;


    public TextMeshProUGUI [] castcd;
    public TextMeshProUGUI castcd2;
    public TextMeshProUGUI castcd3;
    public TextMeshProUGUI castcd4;

    public Texture2D cursorTexture; //current cursor
    public Texture2D baseTexture; //default cursor;
    public Texture2D attackTexture; //attack cursor;
    public Texture2D castTexture; //cast cursor;
    public Texture2D nocastTexture; //no cast cursor;



    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    [SerializeField] public Gradient healthBarColor;
    [SerializeField] public Gradient manaBarColor;


    public Camera mainCamera;
    public Transform currectMouse;
    //public Image selectRect;

    //graphical part of selection
    [SerializeField]
    RectTransform dragVisual;
    Vector2 startDrag;
    Vector2 endDrag;

    //logical part of selection
    Rect selectionBox;

    //keys that we press
    public KeyCode menu;
    public KeyCode journal;
    public KeyCode map;
    public KeyCode hero1;
    public KeyCode hero2;
    public KeyCode hero3;
    public KeyCode heroes;
    public KeyCode basic;
    public KeyCode special;
    public KeyCode spell1;
    public KeyCode spell2;
    public KeyCode spell3;
    public KeyCode spell4;
    public KeyCode spell5;
    public KeyCode spell6;
    public KeyCode spell7;
    public KeyCode spell8;
    public KeyCode use;
    public KeyCode target;
    public KeyCode hitzone;
    public KeyCode follow;
    public KeyCode sprint;
    public KeyCode run;
    public KeyCode walk;
    public KeyCode crouch;
    public KeyCode crawl;
    public KeyCode potion;
    public KeyCode weapon;
    public KeyCode behave;
    public KeyCode slow;
    public KeyCode unitdata;
    public KeyCode portal;
    public KeyCode inventory;
    public KeyCode skilltree;
    public KeyCode forceattack;

    public bool char1; //if true, main hero is chosen
    public bool char2; //if true, first ally is chosen
    public bool char3; //if true, second ally is chosen
    public bool bot; //if true, uncontrolled character is chosen
    public bool attackorder;
    public bool hoverenemy;
    public bool castmode;
    public bool casttarget;
    public int curspell;
    public int curunit;



    private List<GameObject> overlappedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        
        mainCamera = Camera.main;
        startDrag= Vector2.zero;
        endDrag = Vector2.zero;
        curspell = 0;


        chosenstats = matestats[0];
        char1 = true;
        curunit = 1;
        ChangeUnits();
        ChangeSpells();
        //Debug.Log(matestats1.unitname);
        charname.text = matestats[0].unitname;
        life.text = matestats[0].health_cur.ToString()+"/"+ matestats[0].health_max.ToString();
        //DrawVisualRect();

        //Check of icons array
        for(int i = 0; i < textures_large.Length; i++) 
        {
            if (textures_large[i].name == "image001") 
            { 
                Debug.Log("Fire arrow"); 

            }
        }

    }

    // Update is called once per frame
    void Update()  
    {
        if (char1 && !char2 && !char3) { curunit = 1; }
        if (!char1 && char2 && !char3) { curunit = 2; }
        if (!char1 && !char2 && char3) { curunit = 3; }
        if(char1 && char2 && !char3) { curunit = 0; }
        if (!char1 && char2 && char3) { curunit = 0; }
        if (char1 && !char2 && char3) { curunit = 0; }
        if (char1 && char2 && char3) { curunit = 0; }
        if(curunit == 0 ) { abilityHolder.SetActive(false); } else { abilityHolder.SetActive(true); }

        if (castmode)
        {
            Cursor.SetCursor(castTexture, hotSpot, cursorMode);
        }
        if (attackorder || hoverenemy)
        {
            Cursor.SetCursor(attackTexture, hotSpot, cursorMode);
        }
        //if(!castmode && !attackorder && !hoverenemy) { Cursor.SetCursor(baseTexture, hotSpot, cursorMode); }
        if (!attackorder && !castmode && !hoverenemy)
        {
            Cursor.SetCursor(baseTexture, hotSpot, cursorMode); hoverenemy = false;
        }
        


        for (int i = 0; i < matestats.Length; i++)
        {
            if (matestats[i] != null)
            {
                lifebar[i].fillAmount = matestats[i].health_cur / matestats[i].health_max;
                manabar[i].fillAmount = matestats[i].mana_cur / matestats[i].mana_max;
                lifebar[i].color = healthBarColor.Evaluate(lifebar[i].fillAmount);
                manabar[i].color = manaBarColor.Evaluate(manabar[i].fillAmount);
            }
            
        }
        for (int i = 0; i < castmask.Length; i++)
        {
            castmask[i].fillAmount = matestats[0].abilities_cd_cur[i] / matestats[0].abilities_cd_max[i];
            if (matestats[0].abilities_cd_cur[i] > 0) { castcd[i].text = matestats[0].abilities_cd_cur[i].ToString("F0"); } else { castcd[i].text = " "; }

        }




        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100);
        if (hit.transform.gameObject.layer != 6 && hit.transform.gameObject != null) //if mouse doesn't hover on any unit, we display information of the controllable unit
        {
            currectMouse = hit.transform;
            //MARKER
            //marker.transform.position = hit.transform.position;


            charname.text = chosenstats.unitname;
            life.text = Mathf.Round(chosenstats.health_cur).ToString() + "/" + chosenstats.health_max.ToString();
            mana.text = Mathf.Round(chosenstats.mana_cur).ToString() + "/" + chosenstats.mana_max.ToString();
            float colorGreen;
            float colorRed;
            if (chosenstats.health_cur / chosenstats.health_max >= 0.5)
            {
                colorGreen = 1;
                colorRed = (1 - (chosenstats.health_cur / chosenstats.health_max)) * 2;
            }
            else
            {
                colorRed = 1;
                colorGreen = 1 * ((chosenstats.health_cur / chosenstats.health_max) * 2);
            }
            life.color = new Color(colorRed, colorGreen, 0);
            botstats = null;
            
            

        } else //if mouse hover on unit that is not chosen player, we display information of it
        {
            
            botstats = hit.transform.gameObject.GetComponent<UnitData>();
            //charname.text = botstats.unitname; TURN ON LATER!
            life.text = Mathf.Round(botstats.health_cur).ToString() + "/" + botstats.health_max.ToString();
            mana.text = Mathf.Round(botstats.mana_cur).ToString() + "/" + botstats.mana_max.ToString();
            float colorGreen;
            float colorRed;
            if (botstats.health_cur / botstats.health_max >= 0.5)
            {
                colorGreen = 1;
                colorRed = (1 - (botstats.health_cur / botstats.health_max)) * 2;
            }
            else
            {
                colorRed = 1;
                colorGreen = 1 * ((botstats.health_cur / botstats.health_max) * 2);
            }
            life.color = new Color(colorRed, colorGreen, 0);
            if(botstats.clan != chosenstats.clan) { hoverenemy = true; }
        } 
        
        

            



        if (Input.GetMouseButtonDown(0))
        {
            startDrag = Input.mousePosition;
            dragVisual.position = Input.mousePosition;
            selectionBox = new Rect();
            Ray myRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay, out hitInfo, 100, ground))
            {
                if(!attackorder && !castmode)
                {
                    if (curunit != 0)
                    {
                        if (matestats[0] != null && char1) { matestats[0].Move(hitInfo.point); }
                        if (matestats[1] != null && char2) { matestats[1].Move(hitInfo.point); }
                        if (matestats[2] != null && char3) { matestats[2].Move(hitInfo.point); }
                    }
                    else
                    {
                        Vector3 displaceX = new Vector3(1f, 0, 0);
                        Vector3 displaceZ = new Vector3(0, 0, 1f);
                        if (char1 && char2 && !char3) { matestats[0].Move(hitInfo.point + displaceX); matestats[1].Move(hitInfo.point - displaceX); }
                        if (!char1 && char2 && char3) { matestats[1].Move(hitInfo.point + displaceX); matestats[2].Move(hitInfo.point - displaceX); }
                        if (char1 && !char2 && char3) { matestats[0].Move(hitInfo.point + displaceX); matestats[2].Move(hitInfo.point - displaceX); }
                        if (char1 && char2 && char3) { matestats[0].Move(hitInfo.point + (displaceX / 1.5f) + (displaceZ / 1.5f)); matestats[1].Move(hitInfo.point - (displaceX / 1.5f) - (displaceZ / 1.5f)); matestats[2].Move(hitInfo.point - displaceZ); }
                    }
                }
            }
        }


        if (Input.GetMouseButton(0)) //LMB click
        {
            endDrag = Input.mousePosition;
            DrawVisualRect();
            DrawSelection();
            //Debug.Log(dragVisual.sizeDelta);
            Vector3 uiScreenPos = RectTransformUtility.WorldToScreenPoint(mainCamera, dragVisual.position);
            Ray ray1 = mainCamera.ScreenPointToRay(uiScreenPos);

            //RaycastHit hitInfo;
            //  Debug.Log("UI element overlaps with the 3D object1.");
            // Raycast from UI to 3D object

            




        }

        if (Input.GetMouseButtonUp(0))
        {
            startDrag = Vector2.zero;
            endDrag = Vector2.zero;
            dragVisual.sizeDelta = new Vector2(0,0);



        }


        if (Input.GetMouseButtonDown(1)) //LMB click
        {
            
           
            
        }
            

        

        if (Input.GetKey(menu))
            Debug.Log("Pressed " + menu);

        if (Input.GetKey(journal))
            Debug.Log("Pressed " + journal);

        if (Input.GetKey(map))
            Debug.Log("Pressed " + map);

        if (Input.GetKey(hero1)) 
        {
            castmode = false;
            curspell = 0;
            chosenstats = matestats[0];
            char1 = true;
            char2 = false;
            char3 = false;
            ChangeUnits();
            ChangeSpells();
        }

        if (Input.GetKey(hero2)) 
        {
            castmode = false;
            curspell = 0;
            chosenstats = matestats[1];
            char1 = false;
            char2 = true;
            char3 = false;
            ChangeUnits();
            ChangeSpells();
        }

        if (Input.GetKey(hero3)) 
        {
            castmode = false;
            curspell = 0;
            chosenstats = matestats[2];
            char1 = false;
            char2 = false;
            char3 = true;
            ChangeUnits();
            ChangeSpells();
        }

        if (Input.GetKey(heroes)) 
        {
            castmode = false;
            curspell = 0;
            chosenstats = matestats[0];
            char1 = true;
            char2 = true;
            char3 = true;
            ChangeUnits();
            ChangeSpells();
        }

        if (Input.GetKey(forceattack))
        {
            attackorder = true;
            Debug.Log("Holded " + forceattack);
        }
        else
        {
            attackorder = false;
        }
            

        if (Input.GetKeyDown(spell1))
        {
            if (curunit != 0 && matestats[curunit - 1].ability1_name != "")
            {
                if (!castmode | curspell != 1)
                {
                    castmode = true;
                    curspell = 1;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }
            

        if (Input.GetKeyDown(spell2))
        {
            if (curunit != 0 && matestats[curunit - 1].ability2_name != "")
            {
                if (!castmode | curspell != 2)
                {
                    castmode = true;
                    curspell = 2;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }

        if (Input.GetKeyDown(spell3))
        {
            if (curunit != 0 && matestats[curunit - 1].ability3_name != "")
            {
                if (!castmode | curspell != 3)
                {
                    castmode = true;
                    curspell = 3;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }

        if (Input.GetKeyDown(spell4))
        {
            if (curunit != 0 && matestats[curunit - 1].ability4_name != "")
            {
                if (!castmode | curspell != 4)
                {
                    castmode = true;
                    curspell = 4;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }

        if (Input.GetKey(spell5))
        {
            if (curunit != 0 && matestats[curunit - 1].ability5_name != "")
            {
                if (!castmode | curspell != 5)
                {
                    castmode = true;
                    curspell = 5;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }

        if (Input.GetKey(spell6))
        {
            if (curunit != 0 && matestats[curunit - 1].ability6_name != "")
            {
                if (!castmode | curspell != 6)
                {
                    castmode = true;
                    curspell = 6;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }

        if (Input.GetKey(spell7))
        {
            if (curunit != 0 && matestats[curunit - 1].ability7_name != "")
            {
                if (!castmode | curspell != 7)
                {
                    castmode = true;
                    curspell = 7;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }

        if (Input.GetKey(spell8))
        {
            if (curunit != 0 && matestats[curunit - 1].ability8_name != "")
            {
                if (!castmode | curspell != 8)
                {
                    castmode = true;
                    curspell = 8;
                }
                else
                {
                    castmode = false;
                    curspell = 0;
                }
            }
        }


        if (Input.GetKey(use))
            Debug.Log("Pressed " + use);

        if (Input.GetKey(target))
            Debug.Log("Pressed " + target);

        if (Input.GetKey(hitzone))
            Debug.Log("Pressed " + hitzone);

        if (Input.GetKey(follow))
            Debug.Log("Pressed " + follow);

        if (Input.GetKey(sprint))
            Debug.Log("Pressed " + sprint);

        if (Input.GetKey(run))
        {
            if (char1) 
            {
                if(matestats[0].movetype == 2) { matestats[0].agent.speed = matestats[0].speed_run; } 
                matestats[0].movetype = 3;
                matestats[0].ChangePose(3);
            }
            if (char2)
            {
                if (matestats[1].movetype == 2) { matestats[1].agent.speed = matestats[1].speed_run; }
                matestats[1].movetype = 3;
                matestats[1].ChangePose(3);
            }
            if (char3)
            {
                if (matestats[2].movetype == 2) { matestats[2].agent.speed = matestats[2].speed_run; }
                matestats[2].movetype = 3;
                matestats[2].ChangePose(3);
            }
        }


        if (Input.GetKey(walk)) 
        {
            if (char1) //at this moment only player one is active
            {
                if (matestats[0].movetype < 2) { matestats[0].agent.speed = 0; } else { matestats[0].agent.speed = matestats[0].speed_walk; }   
                matestats[0].movetype = 2;
                matestats[0].ChangePose(2);
            }
            if (char2) //at this moment only player one is active
            {
                if (matestats[1].movetype < 2) { matestats[1].agent.speed = 0; } else { matestats[1].agent.speed = matestats[1].speed_walk; }
                matestats[1].movetype = 2;
                matestats[1].ChangePose(2);
            }
            if (char3) //at this moment only player one is active
            {
                if (matestats[2].movetype < 2) { matestats[2].agent.speed = 0; } else { matestats[2].agent.speed = matestats[2].speed_walk; }
                matestats[2].movetype = 2;
                matestats[2].ChangePose(2);
            }
        }

        if (Input.GetKey(crouch))
        {
            if (char1) //at this moment only player one is active
            {
                if (matestats[0].movetype != 1) { matestats[0].agent.speed = 0; } else { matestats[0].agent.speed = matestats[0].speed_crouch; }
                matestats[0].movetype = 1;
                matestats[0].ChangePose(1);
            }
            if (char2) //at this moment only player one is active
            {
                if (matestats[1].movetype != 1) { matestats[1].agent.speed = 0; } else { matestats[1].agent.speed = matestats[1].speed_crouch; }
                matestats[1].movetype = 1;
                matestats[1].ChangePose(1);
            }
            if (char3) //at this moment only player one is active
            {
                if (matestats[2].movetype != 1) { matestats[2].agent.speed = 0; } else { matestats[2].agent.speed = matestats[2].speed_crouch; }
                matestats[2].movetype = 1;
                matestats[2].ChangePose(1);
            }
        }

        if (Input.GetKey(crawl))
            Debug.Log("Pressed " + crawl);

        if (Input.GetKey(potion))
            Debug.Log("Pressed " + potion);

        if (Input.GetKey(weapon))
            Debug.Log("Pressed " + weapon);

        if (Input.GetKey(behave))
            Debug.Log("Pressed " + behave);

        if (Input.GetKey(slow))
            Debug.Log("Pressed " + slow);

        if (Input.GetKey(unitdata))
            Debug.Log("Pressed " + unitdata);

        if (Input.GetKeyDown(portal))
            Debug.Log("Holded " + portal);

        if (Input.GetKey(inventory))
            Debug.Log("Pressed " + inventory);

        if (Input.GetKey(skilltree))
            Debug.Log("Pressed " + skilltree);
    }

    void DrawVisualRect()
    {
        dragVisual.position = new Vector2(startDrag.x-((startDrag.x-endDrag.x)/2), startDrag.y - (startDrag.y - endDrag.y)/2);
        Vector2 boxStart = startDrag;
        Vector2 boxEnd = endDrag;
        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        selectionBox.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x),Mathf.Abs(boxStart.y - boxEnd.y));
        dragVisual.sizeDelta = boxSize;

    }
    void DrawSelection()
    {
        if(Input.mousePosition.x < startDrag.x) 
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startDrag.x;
        } 
        else 
        {
            selectionBox.xMin = startDrag.x;
            selectionBox.xMax = Input.mousePosition.x;
            
        }

        if (Input.mousePosition.y < startDrag.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startDrag.y;
        }
        else
        {
            selectionBox.yMin = startDrag.y;
            selectionBox.yMax = Input.mousePosition.y;
        }


    }

    void DisplayData()
    {
        if (char1)
        {

        }

    }

    void ChangeUnits()
    {
        int teamsize = 0;
        List<UnitData> teamUnits = new List<UnitData>();
        for (int i = 0; i < matestats.Length; i++) { frames[i].SetActive(false); }
        for (int i = 0; i < matestats.Length; i++) { if (matestats[i] != null) { teamsize += 1; teamUnits.Add(matestats[i]); } }
        for (int i = 0; i < matestats.Length; i++) { matestats[i] = null; }
        for (int i = 0; i < teamUnits.Count; i++) { matestats[i] = teamUnits[i]; portraits[i].SetActive(true); }
        RectTransform rectTransform = portraitHolder.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2 (-48 * (teamUnits.Count - 1), 0);
        if (char1) { frames[0].SetActive(true); }
        if (char2) { frames[1].SetActive(true); }
        if (char3) { frames[2].SetActive(true); }
    }

    void ChangeSpells()
    {
        if (curunit != 0) 
        {
            abilityHolder.SetActive(true);
            for (int i = 0; i < 8; i++){casts[i].gameObject.SetActive(false);}
            List<Sprite> sprites = new List<Sprite>();
            int num = 0;
            for (int j = 0; j < cast_images.Length; j++)
            {
                string elementName = cast_images[j].name;
                if (chosenstats.ability1_name == elementName) { casts[0].sprite = cast_images[j]; num++; }
                if (chosenstats.ability2_name == elementName) { casts[1].sprite = cast_images[j]; num++; }
                if (chosenstats.ability3_name == elementName) { casts[2].sprite = cast_images[j]; num++; }
                if (chosenstats.ability4_name == elementName) { casts[3].sprite = cast_images[j]; num++; }
                if (chosenstats.ability5_name == elementName) { casts[4].sprite = cast_images[j]; num++; }
                if (chosenstats.ability6_name == elementName) { casts[5].sprite = cast_images[j]; num++; }
                if (chosenstats.ability7_name == elementName) { casts[6].sprite = cast_images[j]; num++; }
                if (chosenstats.ability8_name == elementName) { casts[7].sprite = cast_images[j]; num++; }
            }
            //sprites.Reverse();
            for (int i = 0; i < num; i++) 
            {
                casts[i].gameObject.SetActive(true);
                casts[i].sprite = casts[i].sprite;  
            }
            Debug.Log(sprites.Count);
        } else { abilityHolder.SetActive(false); }


    }






}
