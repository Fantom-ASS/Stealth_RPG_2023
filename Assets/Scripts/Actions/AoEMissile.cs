using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AoEMissile : MonoBehaviour
{
    //values that compute the effect on targets
    public int mask; //0 - all, 1 - hostile, 2 - friendly
    public int clan; //clan of the caster
    public int stuck; //how much times effect can summ
    public float duration; //how long effect lasts
    public float effect_max; //maximum effect
    public float effect_min; //minimum effect
    public float effect; //result effect
    public string buff; //which spell is used

    //values that are used to compute the flight tragectory
    public float hypotenuse;
    public float time;
    public float rangeX;
    public float rangeZ;
    public float way;
    public float adjacent;
    public float opposite;
    public float speed;
    public float height;
    public bool hinged;
    public bool collision;

    [SerializeField] private UnitData master; //unit who spawned effect
    [SerializeField] private UnitData curTarget; //currect target with which effect operates
    [SerializeField] private  List<GameObject> hitTargets; //targets that were already hit by effect
    [SerializeField] private GameObject buffPrefab; //particle that releases on hitting the target
    [SerializeField] private GameObject hitPrefab; //particle that releases on the ground or obstacle collision
    public Transform hitzone; //final destination coordinates
    private GameObject instantiatedTextDamage; //visual damage amount that spell causes
    public GameObject DamagePrefab;

    //terminal properties
    public float AoE; //maxumum area
    public float spread; //speed of checking area
    public float range; //current influence area

    // Start is called before the first frame update
    void Start()
    {
        collision = false;
        hitzone = GameObject.Find("Male_Shape").transform; //JUST FOR TEST
        transform.LookAt(hitzone.transform.position += new Vector3(0, 0, 0));
        Destroy(this.gameObject, 7);
        if(hinged) 
        { 
            transform.Rotate(-45, 0, 0);
            rangeX = transform.position.x - hitzone.transform.position.x;
            if (rangeX < 0) rangeX = - rangeX;
            rangeZ = transform.position.z - hitzone.transform.position.z;
            if (rangeZ < 0) rangeZ = -rangeZ;
            adjacent = Mathf.Sqrt(Mathf.Pow(rangeX, 2f) + Mathf.Pow(rangeZ, 2f));
            opposite = transform.position.y - hitzone.transform.position.y;
            height = transform.position.y - hitzone.transform.position.y;
            if (opposite < 0) opposite = -opposite;
            hypotenuse = Mathf.Sqrt(Mathf.Pow(adjacent, 2f) + Mathf.Pow(opposite, 2f));
            way = (float)hypotenuse;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (hinged && !collision)
        {
            rangeX = transform.position.x - hitzone.transform.position.x;
            if (rangeX < 0) rangeX = -rangeX;
            rangeZ = transform.position.z - hitzone.transform.position.z;
            if (rangeZ < 0) rangeZ = -rangeZ;
            adjacent = Mathf.Sqrt(Mathf.Pow(rangeX, 2f) + Mathf.Pow(rangeZ, 2f));
            opposite = transform.position.y - hitzone.transform.position.y;
            height = transform.position.y - hitzone.transform.position.y;
            if (opposite < 0) opposite = -opposite;
            hypotenuse = Mathf.Sqrt(Mathf.Pow(adjacent, 2f) + Mathf.Pow(opposite, 2f));

            time = way / speed;

        }

        //projectile movement
        if (!collision) { transform.position += transform.forward * Time.deltaTime * speed; }
        if (hinged && !collision) 
        {
            if (this.transform.rotation.x < 45)
            { transform.Rotate((81f * Time.deltaTime) / time, 0, 0); }
        }
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 0.25f) && hit.transform.gameObject.layer == 8 && hit.transform.gameObject != gameObject && !collision)
        {
            if (hitPrefab != null) { Instantiate(hitPrefab, transform.position, Quaternion.identity); } //spawning area hit effect
            collision = true;
            Destroy(gameObject, 3);


        }
        if(collision)
        {
            //unparenting and deactivating all children particles
            Transform parentTransform = transform;
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform child = parentTransform.GetChild(i);
                GameObject part = child.gameObject;
                Destroy(part, 2);
                ParticleSystem particleSystem = part.GetComponent<ParticleSystem>();
                if (particleSystem != null) { particleSystem.Stop(); }
                child.parent = null;

            }

            //AoE effect in action
            if (range < AoE) { range += spread * Time.deltaTime; } else { range = AoE; }
            Collider[] colliders = Physics.OverlapSphere(transform.position, range); //looking for nearby units
            foreach (Collider col in colliders)
            {
                GameObject obj = col.gameObject;
                if(obj.layer == 6)
                {
                    curTarget = obj.GetComponent<UnitData>();
                    if (mask == 0)
                    {
                        if (!hitTargets.Contains(obj)) //spell acts on all units
                        {
                            hitTargets.Add(obj);
                            ChangeStats();

                        }
                    }
                    if (mask == 1)
                    {
                        if (!hitTargets.Contains(obj) && clan != curTarget.clan) //spell acts on hostile units
                        {
                            hitTargets.Add(obj);
                            ChangeStats();

                        }
                    }
                    if (mask == 2)
                    {
                        if (!hitTargets.Contains(obj) && clan == curTarget.clan) //spell acts on friendly units
                        {
                            hitTargets.Add(obj);
                            ChangeStats();

                        }
                    }
                }
            }






        }





    }

    void ChangeStats() //changing of stats during buffing
    {
        effect = UnityEngine.Random.Range(effect_min, effect_max);
        //row - �� ������ ����� ����, � column - ���� �������
        int rows = curTarget.effect.GetLength(0);
        int cols = curTarget.effect.GetLength(1);
        for (int row = 0; row < rows; row++) //checking the whole list of different buffs
        {
            for (int col = 0; col < cols; col++) //checking the dimension of same buffs
            {
                if (row == 3 && buff == "shieldfire") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("shieldfire"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.resist_fire += (effect / 100); } else { curTarget.resist_fire += result.y - result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 4 && buff == "shieldlighting") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("shieldlighting"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.resist_lighting += (effect / 100); } else { curTarget.resist_lighting += result.y - result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 5 && buff == "shieldacid") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("shieldacid"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.resist_acid += (effect / 100); } else { curTarget.resist_acid += result.y - result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 6 && buff == "shieldmagic") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("shieldmagic"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.resist_magic += (effect / 100); } else { curTarget.resist_magic += result.y - result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 7 && buff == "haste") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("haste"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.attack_speed += (effect / 100); } else { curTarget.attack_speed += result.y - result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 8 && buff == "slowdown") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("slowdown"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.attack_speed -= (effect / 100); } else { curTarget.attack_speed -= result.y + result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 9 && buff == "weaken") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("weaken"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.health_max -= (effect / 100); } else { curTarget.health_max -= result.y + result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 10 && buff == "strengthen") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("strengthen"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.health_max += (effect / 100); } else { curTarget.health_max += result.y - result.x; }
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 11 && buff == "regeneration") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("regeneration"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.regen_total += (effect / 100); } else { curTarget.regen_total += result.y - result.x; } //changing effect according to input data
                            break;
                        }
                        else { continue; }
                    }
                }
                //FIELFOFVIEW NEEDS SOME DIFFERENT TYPE OF CHECKING
                if (row == 13 && buff == "nightvision") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("nightvision"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.nightvision_change += (effect / 100); } else { curTarget.nightvision_change += result.y - result.x; } //changing effect according to input data
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 14 && buff == "silentstep") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("silentstep"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.noise_radius -= (effect / 100); } else { curTarget.noise_radius -= result.y + result.x; } //changing effect according to input data
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 15 && buff == "eaglesight") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("eaglesight"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.vision_range += (effect / 100); } else { curTarget.vision_range += result.y - result.x; } //changing effect according to input data
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 16 && buff == "invisibility") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("invisibility"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.look_radius -= (effect / 100); } else { curTarget.look_radius -= result.y + result.x; } //changing effect according to input data
                            break;
                        }
                        else { continue; }
                    }
                }
                if (row == 17 && buff == "deadsight") //blessing buff
                {
                    if (curTarget.effect[row, cols - 1] == 0) //if array of buffs if this type is not filled, we can add a new one
                    {
                        if (curTarget.effect[row, col] == 0)
                        {
                            if (!curTarget.buffVisual.Contains("deadsight"))
                            {
                                curTarget.buffVisual.Add(buff);
                                GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
                                VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
                                visualBuff.unitdata = curTarget;
                                visualBuff.castname = buff;
                                newBuff.transform.parent = curTarget.transform;
                            }
                            Vector2 result = Checker(row, rows, col, cols);
                            if (curTarget.effect[row, stuck] == 0) { curTarget.feeling_range += (effect / 100); } else { curTarget.feeling_range += result.y - result.x; } //changing effect according to input data
                            break;
                        }
                        else { continue; }
                    }
                }
                //UNDEAD NEEDS SOME DIFFERENT TYPE OF CHECKING
                //PARALIZE NEEDS SOME DIFFERENT TYPE OF CHECKING
            }
        }


        //EFFECTS WITHOUT BUFFS
        if (buff == "healing") //NO HEAL YET
        {
            GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
            VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
            visualBuff.unitdata = curTarget;
            visualBuff.castname = buff;
            newBuff.transform.parent = curTarget.transform;


            for (float heal = effect; heal > 0; heal--)
            {
                for (int i = 0; i < curTarget.bodyparts_health_display.Length; i++)
                {
                    if (i == 0 && curTarget.bodyparts_health_display[i] < curTarget.health_max) { curTarget.bodyparts_health_display[i] += 1 / (float)curTarget.damagedparts; }
                    if (i == 1) { if (curTarget.bodytype < 2 | curTarget.bodytype == 3) { if (curTarget.bodyparts_health_display[i] < curTarget.health_max) { curTarget.bodyparts_health_display[i] += 1 / (float)curTarget.damagedparts; } } }
                    if (i == 1 && curTarget.bodytype == 2) { if (curTarget.bodyparts_health_display[i] < curTarget.health_max / 3) { curTarget.bodyparts_health_display[i] += 1 / (float)curTarget.damagedparts; } }
                    if (i > 1) { if (curTarget.bodyparts_health_display[i] < curTarget.health_max / 3) { curTarget.bodyparts_health_display[i] += 1 / (float)curTarget.damagedparts; } }
                }
            }
        }
        if (buff == "firebolt")
        {
            GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
            VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
            visualBuff.unitdata = curTarget;
            visualBuff.castname = buff;
            newBuff.transform.parent = curTarget.transform;
            AllBodyDamage("fire");

        }
        if (buff == "acidclot")
        {
            GameObject newBuff = Instantiate(buffPrefab, curTarget.transform.position, Quaternion.identity);
            VisualBuff visualBuff = newBuff.GetComponent<VisualBuff>();
            visualBuff.unitdata = curTarget;
            visualBuff.castname = buff;
            newBuff.transform.parent = curTarget.transform;
            AllBodyDamage("acid");
        }



    }

    void AddBuff()
    {
        curTarget.buffName.Add(buff);
        curTarget.buffStuck.Add(stuck);
        curTarget.buffEffect.Add(effect);
        curTarget.buffTime.Add(duration);
    }

    Vector2 Checker(int row, int rows, int col, int cols)
    {
        Debug.Log("row: " + row + " rows: " + rows + " col: " + col + " cols: " + cols);
        float oldSum = 0;
        float newSum = 0;
        for (int i = 0; i < stuck; i++) { oldSum += curTarget.effect[row, i]; }//checking top old strongest effect
        curTarget.effect[row, col] = effect / 100; //putting new effect into array
        AddBuff(); //adding a new buff to list
        float[] targetArray = new float[cols]; //creating a new array to sort values of 2nd dimension
        for (int j = 0; j < cols; j++) { targetArray[j] = curTarget.effect[row, j]; } //filling new array with values of effect
        System.Array.Sort(targetArray, (a, b) => b.CompareTo(a)); //sorting
        for (int j = 0; j < cols; j++) { curTarget.effect[row, j] = targetArray[j]; } //refilling out 2-dimensional array with new values
        for (int i = 0; i < stuck; i++) { newSum += curTarget.effect[row, i]; }//checking top new strongest effect
        Vector2 result = new Vector2(oldSum, newSum); //result.x is out oldSum, result.y - newSum
        return result;
    }

    void AllBodyDamage(string type)//type - means type of damage, damage - effect, parts - body parts which health is > 0
    {
        float damage = 0;
        //counting the summary damage to unit
        if (type == "slashing")
        {
            if (curTarget.bodytype == 4) { damage = effect - curTarget.armor_body[0]; }
            if (curTarget.bodytype == 3) { damage = ((effect - curTarget.armor_body[0]) + (effect - curTarget.armor_head[0])) / (float)curTarget.bodyparts_name.Length; }
            if (curTarget.bodytype <= 2) { damage = ((effect - curTarget.armor_body[0]) + (effect - curTarget.armor_head[0]) + ((effect - curTarget.armor_legs[0]) * 2) + ((effect - curTarget.armor_arms[0]) * 2)) / (float)curTarget.bodyparts_name.Length; }
        }
        if (type == "piercing")
        {
            if (curTarget.bodytype == 4) { damage = effect - curTarget.armor_body[1]; }
            if (curTarget.bodytype == 3) { damage = ((effect - curTarget.armor_body[1]) + (effect - curTarget.armor_head[1])) / (float)curTarget.bodyparts_name.Length; }
            if (curTarget.bodytype <= 2) { damage = ((effect - curTarget.armor_body[1]) + (effect - curTarget.armor_head[1]) + ((effect - curTarget.armor_legs[1]) * 2) + ((effect - curTarget.armor_arms[1]) * 2)) / (float)curTarget.bodyparts_name.Length; }
        }
        if (type == "blunding")
        {
            if (curTarget.bodytype == 4) { damage = effect - curTarget.armor_body[2]; }
            if (curTarget.bodytype == 3) { damage = ((effect - curTarget.armor_body[2]) + (effect - curTarget.armor_head[2])) / (float)curTarget.bodyparts_name.Length; }
            if (curTarget.bodytype <= 2) { damage = ((effect - curTarget.armor_body[2]) + (effect - curTarget.armor_head[2]) + ((effect - curTarget.armor_legs[2]) * 2) + ((effect - curTarget.armor_arms[2]) * 2)) / (float)curTarget.bodyparts_name.Length; }
        }
        if (type == "fire")
        {
            if (curTarget.bodytype == 4) { damage = effect - curTarget.armor_body[3]; }
            if (curTarget.bodytype == 3) { damage = ((effect - curTarget.armor_body[3]) + (effect - curTarget.armor_head[3])) / (float)curTarget.bodyparts_name.Length; }
            if (curTarget.bodytype <= 2) { damage = ((effect - curTarget.armor_body[3]) + (effect - curTarget.armor_head[3]) + ((effect - curTarget.armor_legs[3]) * 2) + ((effect - curTarget.armor_arms[3]) * 2)) / (float)curTarget.bodyparts_name.Length; }
        }
        if (type == "lighting")
        {
            if (curTarget.bodytype == 4) { damage = effect - curTarget.armor_body[4]; }
            if (curTarget.bodytype == 3) { damage = ((effect - curTarget.armor_body[4]) + (effect - curTarget.armor_head[4])) / (float)curTarget.bodyparts_name.Length; }
            if (curTarget.bodytype <= 2) { damage = ((effect - curTarget.armor_body[4]) + (effect - curTarget.armor_head[4]) + ((effect - curTarget.armor_legs[4]) * 2) + ((effect - curTarget.armor_arms[4]) * 2)) / (float)curTarget.bodyparts_name.Length; }
        }
        if (type == "acid")
        {
            if (curTarget.bodytype == 4) { damage = effect - curTarget.armor_body[5]; }
            if (curTarget.bodytype == 3) { damage = ((effect - curTarget.armor_body[5]) + (effect - curTarget.armor_head[5])) / (float)curTarget.bodyparts_name.Length; }
            if (curTarget.bodytype <= 2) { damage = ((effect - curTarget.armor_body[5]) + (effect - curTarget.armor_head[5]) + ((effect - curTarget.armor_legs[5]) * 2) + ((effect - curTarget.armor_arms[5]) * 2)) / (float)curTarget.bodyparts_name.Length; }
        }

        curTarget.bodyparts_health_display[0] -= damage;
        instantiatedTextDamage = Instantiate(DamagePrefab, curTarget.transform.position, Quaternion.identity);
        TextMeshPro textMeshPro = instantiatedTextDamage.GetComponent<TextMeshPro>();
        textMeshPro.text = Mathf.RoundToInt(damage).ToString();


        /*
        for (float j = damage; j > 0; damage--)
        {
            for (int i = 0; i < curTarget.bodyparts_health_display.Length; i++)
            {
                if (i == 0 && curTarget.bodyparts_health_display[i] > 0) { curTarget.bodyparts_health_display[i] -= 1 / ((float)curTarget.bodyparts_name.Length - (float)curTarget.damagedparts); }
                if (i == 1 && curTarget.bodyparts_health_display[i] > 0) { curTarget.bodyparts_health_display[i] -= 1 / ((float)curTarget.bodyparts_name.Length - (float)curTarget.damagedparts); }
                if (i > 1 && i < 4) { if (curTarget.bodyparts_health_display[i] > 0) { curTarget.bodyparts_health_display[i] -= 1 / ((float)curTarget.bodyparts_name.Length - (float)curTarget.damagedparts); } }
                if (i > 3 && curTarget.bodyparts_health_display[i] > 0) { curTarget.bodyparts_health_display[i] -= 1 / ((float)curTarget.bodyparts_name.Length - (float)curTarget.damagedparts); }
            }
        }
        */
    }

}
    