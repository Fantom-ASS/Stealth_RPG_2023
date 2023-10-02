using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using UnityEngine.XR;
using TMPro;

public class UnitData : MonoBehaviour
{
    public string unitname; //displayable name of unit
    public string race; //race of unit
    public int clan; //unit of the same clan is ally, any another clan for a safe of clan 0 is hostile
    public int[] loyalty; //list of allied clans
    public bool alive; //unit is alive
    public int action_cur; //what's unit doing now: 0 - nothing, 1 - move, 2 - attack, 3 - cast, 4 - cinematic, 5 - stunned, 6 - frozen, 7 - dying
    public float turnspeed; //changing facing angle speed
    public int player; //checking if unit is controlled by player, if 0 - it's not controlled, 1+ means the ID if player

    //visual stats
    public int pow; // visual strength
    public int dex; // visual agility
    public int imagic; // visual intelligence


    public float health_max; //maximum health
    public float health_cur; //currect health
    public int bodytype; //0 - humanoid, 1 - quadruped, 2 - creature, 3 - bodyhead, 4 - amorphous
    public string[] bodyparts_name; //list of body parts
    public float[] bodyparts_health_display; //list of each body part health
    public float[] bodyparts_health_max; //list of each body part health
    public float[] bodyparts_resist; //ability of each body part to absorb part of damage
    public float[] regen_delay; //list of each body part regeneration
    public int damagedparts;


    public string[] abilities_name = new string[4]; //list of abilities names
    public float[] abilities_cd_max = new float[4]; //list of abilities cooldown time
    public float[] abilities_cd_cur = new float[4]; //list of cooldown time left

    public float regen_total;
    public float mana_max;
    public float mana_cur;
    public float recover;

    public float hearing_range; //range on which unit can hear you
    public float vision_range; //range on which unit can see you
    public float vision_angle; //angle of unit's vision
    public float nightvision_change; //penalty or bonus to unit's vision at night and in dungeons - NOT READY
    public float feeling_range; //range on which creatures such as banshee and zombie can feel living units - NOT READY
    public float smelling_range; //range on which animals can smell other units - NOT READY
    public float trailing_range; //range on which unit can see trails - NOT READY

    public float speed_crawl;
    public float speed_crouch;
    public float speed_walk;
    public float speed_run;

    public float noise_radius; //radius on which other units can hear this one
    public float look_radius; //radius on which other units can see this one
    public float feel_radius; //radius on which other units can feel this one





    public int attack_type; //0 - none, 1 - melee, 2 - ranged, 3 - magic
    public float attack_distance; //range on which unit is ready to attack enemy
    public string damage_type; //type of damage, dealt by unit - slash/pierce/blunt/fire/storm/poison
    public float attack_speed; //the faster it is, the shorter are pauses between physical attacks
    public float cast_speed; //the faster it is, the shorter are pauses between casts and magic attacks
    public float damage_min; //minimum damage after successful attack
    public float damage_max; //maximum damage after successful attack
    public float attack; //chance to hit enemy during melee or ranged attack
    public float defence; //chance to evade enemy's melee or ranged attack
    public float block_melee; //chance to block melee attack
    public float block_ranged; //chance to block missiles
    public float repel_cast; //chance to repel enemy magic
    public float curse_resist; //penalty to debuff magic time

    //arrays of armor that protects different bodyparts. 0 - slashing, 1 - piercing, 2 - blunding, 3 - fire, 4 - lighting, 5 - acid
    public float[] armor_head; //damage absorb of head
    public float[] armor_body; //damage absorb of body
    public float[] armor_arms; //damage absorb of arms
    public float[] armor_legs; //damage absorb of legs
    public float totalarmor;
    public float resist_fire;
    public float resist_lighting;
    public float resist_acid;
    public float resist_magic;

    //according to all unit abilities they have a string name and array of their parameters, which are in such order: effect_min, effect_max, range, AoE, duration, charges, mana, cooldown
    public string abilitymove_name;
    public float[] abilitymove;
    public string attackbase_name;
    public float[] attackbase;
    public string attackspec_name;
    public float[] attackspec;
    public string ability1_name;
    public float[] ability1;
    public string ability2_name;
    public float[] ability2;
    public string ability3_name;
    public float[] ability3;
    public string ability4_name;
    public float[] ability4;
    public string ability5_name;
    public float[] ability5;
    public string ability6_name;
    public float[] ability6;
    public string ability7_name;
    public float[] ability7;
    public string ability8_name;
    public float[] ability8;
    public int curcast;

    //arrays with parameters of abilities: charges left, cooldown left, priorities. Abilities with higher priority preferable
    public float[] charges;
    public float[] cooldowns;
    public float[] priorities;

    //lists of unit buffs and debuffs
    public List<string> buffName; //names of all buffs that unit has
    public List<float> buffEffect; //strength of all buffs that unit has
    public List<float> buffTime; //time left of all buffs that unit has
    public List<int> buffStuck; //quantity of stackable effects
    public List<float> maxEffects; //top strongest stackable effects
    public List<string> buffVisual; //list of buff particle effects

    //public float sixth;
    //public List<float> buff = new List<float>();
    public float[,] effect = new float[32, 16];
    public float[] experiment = new float[16];


    public Transform point; //a point which unit will try to reach when he's alerted, fighting of escaping
    public Animator animator; //animator of character
    public NavMeshAgent agent;

    
    public Transform[] patrol; //array of points that unit visits when he's state is calm
    public float[] rotations; //array of points rotations during the patrol
    public string[] action; //array of activities that unit starts when he visit the patrol point
    public float[] pauses; //time which unit stays at point after reaching it
    public int curpoint; //number of current visited point
    public int alerttime; //length of pauses between checking points during alert
    public int alertpoints; //quantity of points, that unit will check during alert
    public float alertrange; //distance in which unit will check points during alert
    public float escapetime; //time between checking in enemy approaching 
    public float escaperange; //distance in which unit will check points during alert

    private StateMachine _SM;

    private CalmState _calmState; //default state for NPCs in playable zone
    private AlertState _alertState; //used for NPCs to check noise source of to check position of runaway enemy
    private EscapeState _escapeState; //used for NPCs to escape from enemies if he's frightened
    private FightState _fightState; //used for NPCs to chase & fight visible enemies
    private CutsceneState _cutsceneState; //randomly used for NPCs when it's safe

    private IdleState _idleState; //default state of player's unit
    private MoveState _moveState; //used by player & NPCs to reach destination point using the chosen movetype ignoring enemies
    private AdvanceState _advanceState; //used by player & NPCs to reach destination point using the chosen movetype and fighting with enemies
    private AttackState _attackState; //used by player to chase and fight certain unit ignoring everything else
    private FollowState _followState; //used by player & NPCs to follow certaing unit keeping small distance, attacking all enemies if agressive mode is on
    private InteractState _interactState; //used by player to steal and use interactable objects
    private DeathState _deathState; //used to kill the unit and turn off all regens, buffs and orders

    public string unitstate;

    public float distance; //distance that unit keeps to followed target
    public bool crouched; //unit's movement type, if true, unit moves crouched, if false, he walks or runs depends on location and path type;
    public bool aggressive; //unit's reaction on enemies, if true, unit attacks all enemies who attacks him or his allies, if false he only defends himself;
    public int priority; //target priority, 0 - the weakest enemy, 1 - strongest, 2 - closest, 3 - farthest, 4 - central (best target for AoE abilities)
    public int bodypart; //part of enemy body to aim in, 0 - body, 1 - head, 2 - hands, 3 - legs, 4 - random, not actual for magic-type damage

    public bool fear; //if it's true, when unit will see the enemy he will run away instead of fighting
    public bool alert; //happens if unit spot an enemy of hear suspicious noise
    public bool agressive; //used for player-controlled units to auto-attack enemies in idle mode
    public int behaviour; //0 - calm, 1 - suspence, 2 - flee, 3 - chase, 4 - attack, 5 - spell, 6 - lookaround //NOT USED YET
    public int movetype; //0 - crouch, 1 - walkdamage, 2 - walk, 3 - run


    public float totalPower;
    public float attackPower;
    public float defencePower;


    public List<GameObject> unitsAround; //all units that are near the character
    public List<GameObject> unitsAttackable; //units which can be attacked by character
    public List<GameObject> unitsEnemies; //hostile visible units
    public List<GameObject> unitsAllies; //allied visible units
    List<float> enemiesDistances = new List<float>(); //sums of distances between attackable enemies
    public GameObject enemyClosest;
    public GameObject enemyFurthest;
    public GameObject enemyCentral;
    public GameObject enemyWeakest;
    public GameObject enemyStrongest;

    public GameObject enemyChaseTarget;
    //public List<float> powerList;
    public GameObject DamagePrefab;
    public GameObject[] spawnMissiles; //0-7 abilities, 8 - base attack, 9 - special attack

    private GameObject instantiatedTextDamage;

    System.Random random = new System.Random();



    // Start is called before the first frame update
    void Start()
    {
        int rows = effect.GetLength(0);
        int cols = effect.GetLength(1);
        movetype = 2;
        animator.SetInteger("movetype", 2);
        agent.speed = speed_walk;
        if(armor_body.Length == 0) { armor_body = new float[6]; } 
        if (bodytype == 0)
        {
            bodyparts_name = new string[] { "body", "head", "armleft", "armright", "legleft", "legright" };
            bodyparts_health_display = new float[6] { health_max, health_max, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
            bodyparts_health_max = new float[6] { health_max, health_max, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
            if (armor_head.Length == 0) { armor_head = new float[6]; }
            if (armor_arms.Length == 0) { armor_arms = new float[6]; }
            if (armor_legs.Length == 0) { armor_legs = new float[6]; }

        }
        else if (bodytype == 1)
        {
            bodyparts_name = new string[] { "body", "head", "armleft", "armright", "legleft", "legright" };
            bodyparts_health_display = new float[6] { health_max, health_max, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
            bodyparts_health_max = new float[6] { health_max, health_max, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
            if (armor_head.Length == 0) { armor_head = new float[6]; }
            if (armor_arms.Length == 0) { armor_arms = new float[6]; }
            if (armor_legs.Length == 0) { armor_legs = new float[6]; }
        }
        else if (bodytype == 2)
        {
            bodyparts_name = new string[] { "body", "head", "armleft", "armright", "legleft", "legright" };
            bodyparts_health_display = new float[6] { health_max, health_max / 3, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
            bodyparts_health_max = new float[6] { health_max, health_max / 3, health_max / 3, health_max / 3, health_max / 3, health_max / 3 };
            if (armor_head.Length == 0) { armor_head = new float[6]; }
            if (armor_arms.Length == 0) { armor_arms = new float[6]; }
            if (armor_legs.Length == 0) { armor_legs = new float[6]; }
        }
        else if (bodytype == 3)
        {
            bodyparts_name = new string[] { "body", "head" };
            bodyparts_health_display = new float[2] { health_max, health_max };
            bodyparts_health_max = new float[2] { health_max, health_max };
            if (armor_head.Length == 0) { armor_head = new float[6]; }
        }
        else if (bodytype == 4)
        {
            bodyparts_name = new string[] { "body" };
            bodyparts_health_display = new float[1] { health_max };
            bodyparts_health_max = new float[1] { health_max };
        }

        agent = GetComponent<NavMeshAgent>(); //finding navmesh agent of this unit
        if(GetComponent<Rigidbody>() != null) { animator = GetComponent<Animator>(); } //FIXER FOR MAIN HERO

        //initializing state machine & all states
        _SM = new StateMachine();
        _calmState = new CalmState(this);
        _alertState = new AlertState(this);
        _escapeState = new EscapeState(this);
        _fightState = new FightState(this);
        _idleState = new IdleState(this);
        _moveState = new MoveState(this);
        _advanceState = new AdvanceState(this);
        _attackState = new AttackState(this);
        _interactState = new InteractState(this);
        _deathState = new DeathState(this);


        if (player == 0) { _SM.Initialize(_calmState); } else { _SM.Initialize(_idleState); }
        if(_SM.CurrentState == _calmState) { animator.SetBool("move", true); } //FIXER
        //animator.SetBool("move", true); //FIXER
        CheckArmor();
        


    }

    // Update is called once per frame
    void Update()
    {
        _SM.CurrentState.Update();
        unitstate = _SM.CurrentState.ToString();

        //CHECKING HEALTH OF UNIT AND IS HE ALIVE
        damagedparts = 0;
        if (health_cur > 0) { alive = true; } else { alive = false; Death(); }


        List <GameObject> checkAttackable = new List<GameObject>(); //we copy a list of attackable units to check later if something changed with it
        if(unitsAttackable.Count > 0)
        {
            foreach (GameObject element in unitsAttackable)
            {
                checkAttackable.Add(element);
            }
        }

        //CHECKING POWER
        attackPower = ((damage_min + damage_max) / 2) * attack_speed * attack;
        defencePower = health_max * regen_total + totalarmor + defence + ((block_melee + block_ranged) / 2);
        totalPower = attackPower * defencePower;

        //limits health and mana
        bodyparts_health_max[0] = health_max;
        bodyparts_health_display[0] = Mathf.Clamp(bodyparts_health_display[0],0, bodyparts_health_max[0]);
        //if (bodyparts_health[0] > 0) { bodyparts_health[0] += (regen_total/6) * Time.deltaTime; }
        if (bodytype == 0)
        {
            bodyparts_health_max[1] = health_max;
            bodyparts_health_display[1] = Mathf.Clamp(bodyparts_health_display[1], 0, health_max);
            for (int j = 2; j < bodyparts_name.Length; j++) { bodyparts_health_max[j] = health_max / 3; }
            for (int j = 0; j < bodyparts_name.Length; j++) { if (j > 1) bodyparts_health_display[j] = Mathf.Clamp(bodyparts_health_display[j], 0, bodyparts_health_max[j]); }
            health_cur = health_max - (health_max - bodyparts_health_display[0]) - (health_max - bodyparts_health_display[1]) - ((health_max / 3) - bodyparts_health_display[2]) - ((health_max / 3) - bodyparts_health_display[3]) - ((health_max / 3) - bodyparts_health_display[4]) - ((health_max / 3) - bodyparts_health_display[5]);
            for (int j = 0; j < bodyparts_name.Length; j++)
            {
                if (bodyparts_health_display[j] > 0 && bodyparts_health_display[j] < bodyparts_health_max[j])
                    damagedparts += 1;
            }
        }
        else if (bodytype == 1)
        {
            bodyparts_health_max[1] = health_max;
            bodyparts_health_display[1] = Mathf.Clamp(bodyparts_health_display[1], 0, health_max);
            for (int j = 2; j < bodyparts_name.Length; j++) { bodyparts_health_max[j] = health_max / 3; }
            for (int j = 0; j < bodyparts_name.Length; j++) { if (j > 1) bodyparts_health_display[j] = Mathf.Clamp(bodyparts_health_display[j], 0, bodyparts_health_max[j]); }
            health_cur = health_max - (health_max - bodyparts_health_display[0]) - (health_max - bodyparts_health_display[1]) - ((health_max / 3) - bodyparts_health_display[2]) - ((health_max / 3) - bodyparts_health_display[3]) - ((health_max / 3) - bodyparts_health_display[4]) - ((health_max / 3) - bodyparts_health_display[5]);
            for (int j = 0; j < bodyparts_name.Length; j++)
            {
                if (bodyparts_health_display[j] > 0 && bodyparts_health_display[j] < bodyparts_health_max[j])
                    damagedparts += 1;
            }
        }
        else if (bodytype == 2)
        {
            for (int j = 1; j < bodyparts_name.Length; j++) { bodyparts_health_max[j] = health_max / 3; }
            for (int j = 0; j < bodyparts_name.Length; j++) { if (j > 0) bodyparts_health_display[j] = Mathf.Clamp(bodyparts_health_display[j], 0, bodyparts_health_max[j]); }
            health_cur = health_max - (health_max - bodyparts_health_display[0]) - ((health_max/3) - bodyparts_health_display[1]) - ((health_max / 3) - bodyparts_health_display[2]) - ((health_max / 3) - bodyparts_health_display[3]) - ((health_max / 3) - bodyparts_health_display[4]) - ((health_max / 3) - bodyparts_health_display[5]);
            for (int j = 0; j < bodyparts_name.Length; j++)
            {
                if (bodyparts_health_display[j] > 0 && bodyparts_health_display[j] < bodyparts_health_max[j])
                    damagedparts += 1;
            }
        }
        else if (bodytype == 3)
        {
            bodyparts_health_max[1] = health_max;
            bodyparts_health_display[1] = Mathf.Clamp(bodyparts_health_display[1], 0, health_max);
            health_cur = health_max - (health_max - bodyparts_health_display[0]) - (health_max - bodyparts_health_display[1]);
            for (int j = 0; j < bodyparts_name.Length; j++)
            {
                if (bodyparts_health_display[j] > 0 && bodyparts_health_display[j] < bodyparts_health_max[j])
                    damagedparts += 1;
            }
        }
        else if (bodytype == 4)
        {
            health_cur = health_max - (health_max - bodyparts_health_display[0]);
            if (bodyparts_health_display[0] > 0 && bodyparts_health_display[0] < bodyparts_health_max[0])
                damagedparts += 1;
        }
        //regeneration, starts when at least one bodypart is damaged and unit is alive
        for (int i = 0; i< bodyparts_name.Length; i++)
        {
            if(damagedparts > 0 && bodyparts_health_display[i]> 0 && alive)
                bodyparts_health_display[i] += regen_total * Time.deltaTime / damagedparts;
        }
        //health_cur += regen_total * Time.deltaTime;
        health_cur = Mathf.Clamp(health_cur, 0, health_max);
        mana_cur += recover * Time.deltaTime;
        mana_cur = Mathf.Clamp(mana_cur, 0, mana_max);

        //VISION AND LISTS OF UNITS AROUND

        //removing dead enemies from list
        if (unitsEnemies.Count > 0)
        {
            for (int d = 0; d < unitsEnemies.Count; d++)
            {
                UnitData unitdata = unitsEnemies[d].GetComponent<UnitData>();
                if (!unitdata.alive) { unitsEnemies.Remove(unitsEnemies[d]); }
            }
        }
        //removing dead allies from list
        if (unitsAllies.Count > 0)
        {
            for (int d = 0; d < unitsAllies.Count; d++)
            {
                UnitData unitdata = unitsAllies[d].GetComponent<UnitData>();
                if (!unitdata.alive) { unitsAllies.Remove(unitsAllies[d]); }
            }
        }

        //checking units around
        List<GameObject> unitsAll = GameObject.FindGameObjectsWithTag("unit").ToList();
        for (int i = 0; i < unitsAll.Count; i++)
        {
            UnitParameters charstats1 = unitsAll[i].GetComponent<UnitParameters>();
            if (!unitsAround.Contains(unitsAll[i]) && Vector3.Distance(this.transform.position, unitsAll[i].transform.position) <= vision_range + 0.5)
            {
                unitsAround.Add(unitsAll[i]);
            }
        }

        if (unitsAround.Count > 0) //if there is at least one unit around charachter, he checks the list
        {
            for (int i = 0; i < unitsAround.Count; i++)
            {
                if (unitsAround[i] == null) { unitsAround.RemoveAt(i); } //if object is removed it leaves the list
                if (Vector3.Distance(this.transform.position, unitsAround[i].transform.position) > vision_range + 0.5) { unitsAround.RemoveAt(i); } //if object is too far it leaves the list
                if (unitsAround[i] == this.gameObject) { unitsAround.RemoveAt(i); } // if it's unit himself, he leaves the list
            }
            for (int i = 0; i < unitsAround.Count; i++) //checking units enemies
            {
                //checking can character see around units or not
                Vector3 visionDir1 = (new Vector3(unitsAround[i].transform.position.x, transform.position.y, unitsAround[i].transform.position.z)) - transform.position; //vector to target
                Vector3 vision1 = transform.forward; //checking unit's facing angle
                float visangle1 = Vector3.SignedAngle(visionDir1, vision1, Vector3.up); //checking is around unit is in front of character or behind him
                float visrange1 = Vector3.Distance(unitsAround[i].transform.position, transform.position); //checking range between character and anound units
                UnitParameters charstats1 = unitsAround[i].GetComponent<UnitParameters>(); //character needs access to unit's clan to check is it hostile or not
                List<GameObject> objectsHit = new List<GameObject>();
                //check distance from position of this unit to unit from around units list
                if (visrange1 < vision_range)
                {
                    //check difference between this unit facing angle and position of unit from around units list
                    if (visangle1 < vision_angle && visangle1 > -vision_angle)
                    {
                        GameObject obstacle1 = null; //we need an obstacle to compare distance
                        RaycastHit[] hits;
                        hits = Physics.RaycastAll(transform.position, unitsAround[i].transform.position - transform.position, visrange1);
                        LayerMask mask = 7;
                        for (int k = 0; k < hits.Length; k++)
                        {
                            if (hits[k].transform.gameObject.layer != 6) // check are there any obstacles on way
                            {
                                obstacle1 = hits[k].transform.gameObject; //this is our obstacle
                                                                          // Debug.Log(0);
                                float[] distances = new float[hits.Length];
                                for (int l = 0; l < hits.Length; l++)
                                {
                                    distances[l] = hits[l].distance;
                                }
                                Array.Sort(distances, hits); //sorting list of hits if there is an obstacle
                                                             //   Debug.Log((distances.Min()));
                            }
                        }
                        for (int j = 0; j < hits.Length; j++)
                        {
                            if (hits[j].transform.gameObject.layer != 6) //working with already sorted list
                            {
                                for (int n = j; n < hits.Length; n++)
                                {
                                    if (unitsEnemies.Contains(hits[n].transform.gameObject))//if there is a unit behind the obstacle, it should be remove from list        //HERE
                                    {
                                        unitsEnemies.Remove(hits[n].transform.gameObject);
                                        return;
                                    }
                                }
                            }
                        }
                        for (int z = 0; z < hits.Length; z++)
                        {
                            if (hits[z].transform.gameObject == unitsAround[i])
                            {
                                UnitData unitdata = hits[z].transform.gameObject.GetComponent<UnitData>();
                                if (!unitsEnemies.Contains(unitsAround[i]) && unitdata.clan != clan && unitdata.alive) //if unit has the wrong clan and is alive, it's added to list
                                {
                                    if (obstacle1 == null)
                                    {
                                        unitsEnemies.Add(unitsAround[i]);
                                    }
                                }
                            }
                        }
                    }//border of visible angle
                    else
                    {
                        if (unitsEnemies.Count > 0) { unitsEnemies.Remove(unitsAround[i]); } //if enemy list is empty it's no one to remove
                    }
                }
                else
                {
                    if (unitsEnemies.Count > 0) { unitsEnemies.Remove(unitsAround[i]); } //if enemy list is empty it's no one to remove
                }
            }
            for (int i = 0; i < unitsAround.Count; i++) //checking units allies
            {
                //checking can character see around units or not
                Vector3 visionDir1 = (new Vector3(unitsAround[i].transform.position.x, transform.position.y, unitsAround[i].transform.position.z)) - transform.position; //vector to target
                Vector3 vision1 = transform.forward; //checking unit's facing angle
                float visangle1 = Vector3.SignedAngle(visionDir1, vision1, Vector3.up); //checking is around unit is in front of character or behind him
                float visrange1 = Vector3.Distance(unitsAround[i].transform.position, transform.position); //checking range between character and anound units
                UnitParameters charstats1 = unitsAround[i].GetComponent<UnitParameters>(); //character needs access to unit's clan to check is it hostile or not
                List<GameObject> objectsHit = new List<GameObject>();
                //check distance from position of this unit to unit from around units list
                if (visrange1 < vision_range)
                {
                    //check difference between this unit facing angle and position of unit from around units list
                    if (visangle1 < vision_angle && visangle1 > -vision_angle)
                    {
                        GameObject obstacle1 = null; //we need an obstacle to compare distance
                        RaycastHit[] hits;
                        hits = Physics.RaycastAll(transform.position, unitsAround[i].transform.position - transform.position, visrange1);
                        LayerMask mask = 7;
                        for (int k = 0; k < hits.Length; k++)
                        {
                            if (hits[k].transform.gameObject.layer != 6) // check are there any obstacles on way
                            {
                                obstacle1 = hits[k].transform.gameObject; //this is our obstacle
                                float[] distances = new float[hits.Length];
                                for (int l = 0; l < hits.Length; l++)
                                {
                                    distances[l] = hits[l].distance;
                                }
                                Array.Sort(distances, hits); //sorting list of hits if there is an obstacle
                                                             //   Debug.Log((distances.Min()));
                            }
                        }
                        for (int j = 0; j < hits.Length; j++)
                        {
                            if (hits[j].transform.gameObject.layer != 6) //working with already sorted list
                            {
                                for (int n = j; n < hits.Length; n++)
                                {
                                    if (unitsAllies.Contains(hits[n].transform.gameObject))//if there is a unit behind the obstacle, it should be removed from list
                                    {
                                        unitsAllies.Remove(hits[n].transform.gameObject);
                                        return;
                                    }
                                }
                            }
                        }
                        for (int z = 0; z < hits.Length; z++)
                        {
                            if (hits[z].transform.gameObject == unitsAround[i])
                            {
                                UnitData unitdata = hits[z].transform.gameObject.GetComponent<UnitData>();
                                if (!unitsAllies.Contains(unitsAround[i]) && unitdata.clan == clan)
                                {
                                    if (obstacle1 == null)
                                    {
                                        unitsAllies.Add(unitsAround[i]);
                                    }
                                }
                            }
                        }
                    }//border of visible angle
                    else
                    {
                        if (unitsAllies.Count > 0) { unitsAllies.Remove(unitsAround[i]); } //if enemy list is empty it's no one to remove
                    }
                }
                else
                {
                    if (unitsAllies.Count > 0) { unitsAllies.Remove(unitsAround[i]); } //if enemy list is empty it's no one to remove

                }
            }
            for (int i = 0; i < unitsEnemies.Count; i++) //checking attackable units
            {
                float range1 = Vector3.Distance(unitsEnemies[i].transform.position, transform.position); //checking range between character and his enemies
                if (range1 <= attack_distance)
                {
                    if (!unitsAttackable.Contains(unitsEnemies[i]))
                    {
                        unitsAttackable.Add(unitsEnemies[i]);
                        enemiesDistances.Add(0);
                    }
                }
                else
                {
                    if (unitsAttackable.Contains(unitsEnemies[i]))
                    {
                        unitsAttackable.Remove(unitsEnemies[i]); //need to remove attackable units which aren't seen
                        enemiesDistances.Remove(enemiesDistances[i]);
                    }
                }
            }
            for (int i = 0; i < unitsAttackable.Count; i++) 
            {
                if (!unitsEnemies.Contains(unitsAttackable[i])) 
                { 
                    unitsAttackable.Remove(unitsAttackable[i]);
                    enemiesDistances.Remove(enemiesDistances[i]);
                }
            }


        }
        if(unitsAttackable.Count > 0) 
        {
            FindClosestEnemy();
            FindFurthestEnemy();
            FindAoEtgtEnemy();
            FindThreatLevel();
        } else { 
            enemyClosest = null;
            enemyFurthest = null;
            enemyCentral = null;
            enemyStrongest = null;
            enemyWeakest = null;
        }
        
        //THIS PART CHANGES THE STATE, IT SHOULD BE IN THE STATES, NOT IN THE MAIN SCRIPT
        if(unitsEnemies.Count > 0 && alive)
        {
            if(_SM.CurrentState == _calmState)
            {
                FindChaseTarget(); //finding the closest enemy to us, doesn't matter can we attack him or not
                if (fear) { Escape(); } else { Fight(); }
            }

            if(_SM.CurrentState == _fightState | _SM.CurrentState == _attackState)
            {
                FindChaseTarget();
            }
        } else
        {
            enemyChaseTarget = null; //EXPERIMENT
        }



        //OPERATIONS WITH BUFFS ON UNIT
        if (buffName != null)
        {
            for (int i = 0; i < buffName.Count; i++)
            {
                if (buffTime[i] > 0) { buffTime[i] -= Time.deltaTime; } //after time runs out we check how the value will be changed
                else
                {
                    if (buffName[i] == "shieldfire") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[3, j] < 0.0000001f && (buffEffect[i] / 100) - effect[3, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[3, j];
                                effect[3, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[3, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[3, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[3, buffStuck[i] - 1];
                                if (effect[3, buffStuck[i] - 1] == 0) { resist_fire -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { resist_fire -= (buffEffect[i] / 100); resist_fire += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "shieldlighting") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[4, j] < 0.0000001f && (buffEffect[i] / 100) - effect[4, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[4, j];
                                effect[4, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[4, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[4, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[4, buffStuck[i] - 1];
                                if (effect[4, buffStuck[i] - 1] == 0) { resist_lighting -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { resist_lighting -= (buffEffect[i] / 100); resist_lighting += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "shieldacid") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[5, j] < 0.0000001f && (buffEffect[i] / 100) - effect[5, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[5, j];
                                effect[5, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[5, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[5, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[5, buffStuck[i] - 1];
                                if (effect[5, buffStuck[i] - 1] == 0) { resist_acid -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { resist_acid -= (buffEffect[i] / 100); resist_acid += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "shieldmagic") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[6, j] < 0.0000001f && (buffEffect[i] / 100) - effect[6, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[6, j];
                                effect[6, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[6, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[6, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[6, buffStuck[i] - 1];
                                if (effect[6, buffStuck[i] - 1] == 0) { resist_magic -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { resist_magic -= (buffEffect[i] / 100); resist_magic += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "haste") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[7, j] < 0.0000001f && (buffEffect[i] / 100) - effect[7, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[7, j];
                                effect[7, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[7, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[7, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[7, buffStuck[i] - 1];
                                if (effect[7, buffStuck[i] - 1] == 0) { attack_speed -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { attack_speed -= (buffEffect[i] / 100); attack_speed += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "slowdown") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[8, j] < 0.0000001f && (buffEffect[i] / 100) - effect[8, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[8, j];
                                effect[8, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[8, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[8, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[8, buffStuck[i] - 1];
                                if (effect[8, buffStuck[i] - 1] == 0) { attack_speed += (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { attack_speed += (buffEffect[i] / 100); attack_speed -= newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "weaken") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[9, j] < 0.0000001f && (buffEffect[i] / 100) - effect[9, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[9, j];
                                effect[9, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[9, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[9, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[9, buffStuck[i] - 1];
                                if (effect[9, buffStuck[i] - 1] == 0) { health_max += (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { health_max += (buffEffect[i] / 100); health_max -= newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "strengthen") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[10, j] < 0.0000001f && (buffEffect[i] / 100) - effect[10, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[10, j];
                                effect[10, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[10, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[10, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[10, buffStuck[i] - 1];
                                if (effect[10, buffStuck[i] - 1] == 0) { health_max -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { health_max -= (buffEffect[i] / 100); health_max += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    
                    if (buffName[i] == "regeneration") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[11, j] < 0.0000001f && (buffEffect[i] / 100) - effect[11, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[11, j];
                                effect[11, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[11, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[11, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[11, buffStuck[i] - 1];
                                if (effect[11, buffStuck[i] - 1] == 0) { regen_total -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { regen_total -= (buffEffect[i] / 100); regen_total += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    //FIELDOFVIEW
                    if (buffName[i] == "nightvision") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[13, j] < 0.0000001f && (buffEffect[i] / 100) - effect[13, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[13, j];
                                effect[13, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[13, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[13, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[13, buffStuck[i] - 1];
                                if (effect[13, buffStuck[i] - 1] == 0) { nightvision_change -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { nightvision_change -= (buffEffect[i] / 100); nightvision_change += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "silentstep") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[14, j] < 0.0000001f && (buffEffect[i] / 100) - effect[14, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[14, j];
                                effect[14, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[14, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[14, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[14, buffStuck[i] - 1];
                                if (effect[14, buffStuck[i] - 1] == 0) { noise_radius += (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { noise_radius += (buffEffect[i] / 100); noise_radius -= newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "eaglesight") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[15, j] < 0.0000001f && (buffEffect[i] / 100) - effect[15, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[15, j];
                                effect[15, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[15, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[15, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[15, buffStuck[i] - 1];
                                if (effect[15, buffStuck[i] - 1] == 0) { vision_range -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { vision_range -= (buffEffect[i] / 100); vision_range += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "invisibility") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[16, j] < 0.0000001f && (buffEffect[i] / 100) - effect[16, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[16, j];
                                effect[16, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[16, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[16, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[16, buffStuck[i] - 1];
                                if (effect[16, buffStuck[i] - 1] == 0) { look_radius += (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { look_radius += (buffEffect[i] / 100); look_radius -= newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    if (buffName[i] == "deadsight") //algorithm for strengthen effect
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if ((buffEffect[i] / 100) - effect[17, j] < 0.0000001f && (buffEffect[i] / 100) - effect[17, j] > -0.0000001f) //if array effect is similar to list, it's what we need
                            {
                                float oldEff1 = effect[17, j];
                                effect[17, j] = 0; //zeroing the expired effect and resorting the array
                                float[] targetArray = new float[16]; //creating a new array to sort values of 2nd dimension
                                for (int k = 0; k < 16; k++) { targetArray[k] = effect[17, k]; } //filling new array with values of effect
                                System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
                                for (int k = 0; k < 16; k++) { effect[17, k] = targetArray[k]; } //refilling out 2-dimensional array with new values
                                float newEff1 = effect[17, buffStuck[i] - 1];
                                if (effect[17, buffStuck[i] - 1] == 0) { feeling_range -= (buffEffect[i] / 100); }
                                else
                                { if (j < buffStuck[i]) { feeling_range -= (buffEffect[i] / 100); feeling_range += newEff1; } }
                                break;
                            }
                            else { continue; }
                        }
                    }
                    //UNDEAD
                    //PARALIZE


                    buffName.Remove(buffName[i]);
                    buffTime.Remove(buffTime[i]);
                    buffEffect.Remove(buffEffect[i]);
                    buffStuck.Remove(buffStuck[i]);
                    if(buffVisual.Count > 0)
                    {
                        foreach (string item in buffVisual)
                        {
                            if (!buffName.Contains(item))
                            {
                                buffVisual.Remove(item);
                            }
                        }
                    }


                }
            }
        }



















    }

    //still not used
    void ReplaceSkills()
    {

        GameObject list = GameObject.Find("AbilitiesList");
        AbilitiesList abilitiesList = list.GetComponent<AbilitiesList>();
        // Debug.Log(900);
        for (int i = 0; i < abilities_name.Length; i++)
        {

            for (int j = 0; j < abilitiesList.skills_name.Length; j++)
            {

                if (abilities_name[i] == abilitiesList.skills_name[j])
                {
                    Debug.Log("A" + j);
                    abilities_name[i] = abilitiesList.skills_name[j];
                    abilities_cd_max[i] = abilitiesList.skills_cd[j];
                }
            }
        }
    }

    public void TurnPatrol()
    {
       // Quaternion angle = Quaternion.Euler(0, rotations[curpoint], 0);
       // Quaternion rotation = Quaternion.Slerp(transform.rotation, angle, turnspeed * Time.deltaTime);
       // rotation.x = 0;
       // rotation.z = 0;
       // transform.rotation = rotation;
    }

    public void NoiseSource()
    {
        float range = noise_radius;
        //List<GameObject> unitsNear = null;

        for (int i = 0; i < unitsAround.Count; i++)
        {
            if (Vector3.Distance(transform.position, unitsAround[i].transform.position) <= range)
            {
                UnitData unitdata = unitsAround[i].GetComponent<UnitData>();
                if (clan != unitdata.clan && unitdata.unitstate != "FightState" && unitdata.alive) //if chosen unit is hostile
                {
                    if (unitdata.alert == false)  //if unit was calm runs to the noise source to check it
                    {
                        Debug.Log(unitsAround[i].name + " is alerted!");
                        unitdata.alert = true; 
                        unitdata.point = transform; 
                        unitdata.agent.SetDestination(unitdata.point.transform.position);
                        unitdata.Alert();
                    }
                    else
                    {
                        Debug.Log(unitsAround[i].name + " was already alerted!");
                        unitdata.alert = true; 
                        unitdata.point = transform; 
                        unitdata.agent.SetDestination(unitdata.point.transform.position); 
                        unitdata.Alert();
                    }
                }
            }
        }


    }

    //HELP & SEARCHRANDOM WILL BE MOVED TO STATES LATER
    public void CallToHelp()
    {
        float range = noise_radius;
        for (int i = 0; i < unitsAround.Count; i++)
        {
            UnitData unitdata = unitsAround[i].GetComponent<UnitData>();
            if (unitdata.clan == clan && unitdata.alive && unitdata.unitstate != "FightState" && unitdata.player == 0) //we check the list of all units around and if unit is friendly, we tell him the position of enemy and the list of enemies
            {
                Debug.Log(unitsAround[i].name + " is called to help!");
                if (unitdata.alert == false)  //if unit was calm runs to the noise source to check it
                {
                    unitdata.alert = true; 
                    unitdata.point = enemyChaseTarget.transform;
                    unitdata.agent.SetDestination(unitdata.point.transform.position);
                    unitdata.Alert();
                }
                else
                {
                    unitdata.alert = true;
                    unitdata.point = enemyChaseTarget.transform;
                    unitdata.agent.SetDestination(unitdata.point.transform.position);
                    unitdata.Alert();
                }

            }
        }
        
    }

    public bool SearchRandom(Vector3 center, float range, out Vector3 result)
    {
        range = random.Next(2, 5);
        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public void FindChaseTarget() //on this moment chase target it's closest enemy
    {
        //Debug.Log("BOOM");
        enemyChaseTarget = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject obj in unitsEnemies)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                enemyChaseTarget = obj;
            }
        }
    }

    public void FindClosestEnemy()
    {
        enemyClosest = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject obj in unitsAttackable)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                enemyClosest = obj;
            }
        }
    }
    public void FindFurthestEnemy()
    {
        enemyFurthest = null;
        float closestDistance = 0;
        foreach (GameObject obj in unitsAttackable)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance > closestDistance)
            {
                closestDistance = distance;
                enemyFurthest = obj;
            }
        }
    }
    public void FindAoEtgtEnemy()
    {
        enemyCentral = null;
        for (int i = 0; i < unitsAttackable.Count; i++)
        {
            float sumOfDistances = 0;
            foreach (GameObject obj in unitsAttackable)
            {
                float distance = Vector3.Distance(unitsAttackable[i].transform.position, obj.transform.position);
                sumOfDistances += distance;

            }
            enemiesDistances[i] = sumOfDistances;
        }
        float idealrange = Mathf.Infinity; //summ of ranges from checked unit to other
        for (int i = 0; i < unitsAttackable.Count; i++)
        {
            if (enemiesDistances[i] < idealrange)
            {
                idealrange = enemiesDistances[i];
                enemyCentral = unitsAttackable[i];
            }
        }

    }
    public void FindThreatLevel()
    {
        //GameObject weakest = null;
        //GameObject strongest = null;
        UnitData unitdata;
        float strong = 0;
        float weak = Mathf.Infinity;
        for(int i = 0; i<unitsAttackable.Count; i++)
        {
            unitdata = unitsAttackable[i].GetComponent<UnitData>();
            if (unitdata.totalPower < weak)
            {
                weak = unitdata.totalPower;
                enemyWeakest = unitsAttackable[i];
            }

        }
        for (int i = 0; i < unitsAttackable.Count; i++)
        {
            unitdata = unitsAttackable[i].GetComponent<UnitData>();
            if (unitdata.totalPower > strong)
            {
                strong = unitdata.totalPower;
                enemyStrongest = unitsAttackable[i];
            }
        }
        


    }

    public void CheckArmor()
    {
        float armor = 0f;
        for (int i = 0; i < armor_head.Length; i++)
        { armor += armor_head[i]; }
        float totalhead = armor / 6;
        armor = 0f;
        for (int i = 0; i < armor_body.Length; i++)
        { armor += armor_body[i]; }
        float totalbody = armor / 6;
        armor = 0f;
        for (int i = 0; i < armor_legs.Length; i++)
        { armor += armor_legs[i]; }
        float totallegs = armor / 6;
        armor = 0f;
        for (int i = 0; i < armor_arms.Length; i++)
        { armor += armor_arms[i]; }
        float totalarms = armor / 6;
        totalarmor = (totalhead + totalbody + totallegs + totalarms) / 4;
    }





    public void Idle()
    {
        _SM.ChangeState(_idleState);
    }
    public void Alert()
    { 
        _SM.ChangeState(_alertState);
    }
    public void Calm()
    {
        _SM.ChangeState(_calmState);
    }
    public void Escape()
    {
        _SM.ChangeState(_escapeState);
    }
    public void Fight()
    {
        _SM.ChangeState(_fightState);
    }
    public void Cutscene()
    {
        _SM.ChangeState(_cutsceneState);
    }
    public void Move(Vector3 where)
    {
        agent.SetDestination(where);
        _SM.ChangeState(_moveState);
    }
    public void Advance(Vector3 where)
    {
        agent.SetDestination(where);
        _SM.ChangeState(_advanceState);
    }
    public void Attack()
    {
        //agent.SetDestination(who.transform.position);
        _SM.ChangeState(_attackState);
    }
    public void Death()
    {
        _SM.ChangeState(_deathState);
    }

    public void AttackMelee()
    {
        if (alive) 
        { 
            CallToHelp(); 
            NoiseSource(); 
        }


        if (attack_type == 1) 
        {
            if(enemyChaseTarget == null) { FindChaseTarget(); }
            if (enemyChaseTarget != null) 
            {
                UnitData target = enemyChaseTarget.GetComponent<UnitData>();
                float hitchance = ((attack - target.defence) + 50) / 100;
                hitchance = Mathf.Clamp(hitchance, 0, 1);
                float damage = UnityEngine.Random.Range(damage_min, damage_max);
                float hit_test = UnityEngine.Random.Range(0, 1f);
                if (hitchance >= hit_test)
                {
                    target.bodyparts_health_display[0] -= damage; Debug.Log("BANG");
                    instantiatedTextDamage = Instantiate(DamagePrefab, enemyChaseTarget.transform.position, Quaternion.identity);
                    TextMeshPro textMeshPro = instantiatedTextDamage.GetComponent<TextMeshPro>();
                    textMeshPro.text = Mathf.RoundToInt(damage).ToString();
                }
            }
            
        }
    }

    public void CastMagic()
    {
        agent.speed = 0;
        agent.destination = transform.position;
        animator.SetBool("move", false);
        animator.SetBool("channel", false);
        animator.SetBool("attack", false);
        animator.SetBool("interact", false);
        animator.SetTrigger("spellcast");
    }

    public void ChangePose(int pose)
    {
        animator.SetInteger("movetype", pose);
    }

    public void ChangeSpeed()
    {
        Debug.Log("99");
        if (movetype == 1) { agent.speed = speed_crouch; }
        if (movetype == 2) { agent.speed = speed_walk ; }
        if (movetype == 3) { agent.speed = speed_run; }
    }

    public void SpawnMissile()
    {
        if(curcast == 0) 
        { 
            
        }
    }








}
