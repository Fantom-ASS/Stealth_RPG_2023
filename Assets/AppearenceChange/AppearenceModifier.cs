using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearenceModifier : MonoBehaviour
{
    public MainHeroStats stats;
    public SkinnedMeshRenderer bodySkinnedMeshRenderer;
    public SkinnedMeshRenderer pantsSkinnedMeshRenderer;



    public GameObject tester;

    public Material bodyModifier;

    //
    public float strengthMod;
    public float agilityMod;
    public float intelligenceMod;
    public float heightMod;
    public float dex1;
    public float dex2;


    public bool strong;
    public bool weak;

    //scalable bones
    public GameObject Head;
    public GameObject Neck;
    public GameObject Breast;
    public GameObject Body;
    public GameObject HipL;
    public GameObject HipR;
    public GameObject FootL;
    public GameObject FootR;
    public GameObject ShoulderL;
    public GameObject ShoulderR;


    // Start is called before the first frame update
    void Start()
    {
        bodySkinnedMeshRenderer = tester.GetComponent<SkinnedMeshRenderer>();
        //bodyModifier = gameObject.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        bodyModifier.SetFloat("_Fat", (35 - (float)stats.agility) / 16);
        bodyModifier.SetFloat("_Agility", ((float)stats.agility - 15) / 25);
        bodyModifier.SetFloat("_Intelligence", ((float)stats.intelligence - 15) / 20);


        strengthMod = Mathf.Pow((float)stats.strength / 25, 1f / 3f);
        agilityMod = Mathf.Pow((float)stats.agility / 25, 1f / 3f);

        bodySkinnedMeshRenderer.SetBlendShapeWeight(1, dex1+dex2);
        pantsSkinnedMeshRenderer.SetBlendShapeWeight(1, dex1 + dex2);

        if (stats.strength > 25)
        {
            dex1 = 0;
            bodySkinnedMeshRenderer.SetBlendShapeWeight(2, (stats.strength - 25) * 5f);
            pantsSkinnedMeshRenderer.SetBlendShapeWeight(2, (stats.strength - 25) * 5f);
        } else if (stats.strength < 25)
        {
            dex1 = (stats.strength - 25) * -5;
        } else {
            dex1 = 0;
            bodySkinnedMeshRenderer.SetBlendShapeWeight(2, 0);
            pantsSkinnedMeshRenderer.SetBlendShapeWeight(2, 0);
        }

        if(stats.agility < 25)
        {
            dex2 = 0;
            bodySkinnedMeshRenderer.SetBlendShapeWeight(0, (stats.agility - 25) * -5f);
            pantsSkinnedMeshRenderer.SetBlendShapeWeight(0, (stats.agility - 25) * -5f);
        } else if (stats.agility > 25)
        {
            bodySkinnedMeshRenderer.SetBlendShapeWeight(0, 0);
            pantsSkinnedMeshRenderer.SetBlendShapeWeight(0, 0);
            dex2 = (stats.agility - 25) * 5;
        }
        else {
            dex2 = 0;
            bodySkinnedMeshRenderer.SetBlendShapeWeight(0, 0);
            pantsSkinnedMeshRenderer.SetBlendShapeWeight(0, 0);
        }

        Vector3 BodyScale = Body.transform.localScale;
        Body.transform.localScale = new Vector3(BodyScale.x = 1 / agilityMod, BodyScale.y, BodyScale.z = 1 / agilityMod);
        Vector3 ShoulderLScale = ShoulderL.transform.localScale;
        ShoulderL.transform.localScale = new Vector3(ShoulderLScale.x = 1 * agilityMod, ShoulderLScale.y, ShoulderLScale.z);
        Vector3 ShoulderRScale = ShoulderR.transform.localScale;
        ShoulderR.transform.localScale = new Vector3(ShoulderRScale.x = 1 * agilityMod, ShoulderRScale.y, ShoulderRScale.z);
        Vector3 HeadScale = Head.transform.localScale;
        Head.transform.localScale = new Vector3(HeadScale.x = 1 * agilityMod, HeadScale.y, HeadScale.z = 1 * agilityMod);
        Vector3 FootLeft = FootL.transform.localScale;
        FootL.transform.localScale = new Vector3(FootLeft.x, FootLeft.y, FootLeft.z = 1 / agilityMod);
        Vector3 FootRight = FootR.transform.localScale;
        FootR.transform.localScale = new Vector3(FootRight.x, FootRight.y, FootRight.z = 1 / agilityMod);


        Vector3 Chest = Breast.transform.localScale;
        Breast.transform.localScale = new Vector3(Chest.x = 1 * strengthMod, Chest.y, Chest.z = 1 * strengthMod);
        Vector3 NeckScale = Neck.transform.localScale;
        Neck.transform.localScale = new Vector3(NeckScale.x = 1 / strengthMod, NeckScale.y, NeckScale.z = 1 / strengthMod);
        Vector3 HipLeftScale = HipL.transform.localScale;
        HipL.transform.localScale = new Vector3(HipLeftScale.x = 1 * strengthMod, HipLeftScale.y, HipLeftScale.z = 1 * strengthMod);
        Vector3 HipRightScale = HipR.transform.localScale;
        HipR.transform.localScale = new Vector3(HipRightScale.x = 1 * strengthMod, HipRightScale.y, HipRightScale.z = 1 * strengthMod);
        Vector3 ShoulderLeftScale = ShoulderL.transform.localScale;
        ShoulderL.transform.localScale = new Vector3(ShoulderLeftScale.x = 1 / strengthMod, ShoulderLeftScale.y = 1 * strengthMod, ShoulderLeftScale.z);
        Vector3 ShoulderRightScale = ShoulderR.transform.localScale;
        ShoulderR.transform.localScale = new Vector3(ShoulderRightScale.x = 1 / strengthMod, ShoulderRightScale.y = 1 * strengthMod, ShoulderRightScale.z);
        Vector3 FootLeft2 = FootL.transform.localScale;
        FootL.transform.localScale = new Vector3(FootLeft2.x, FootLeft2.y, FootLeft2.z = 1 / strengthMod);
        Vector3 FootRight2 = FootR.transform.localScale;
        FootR.transform.localScale = new Vector3(FootRight2.x, FootRight2.y, FootRight2.z = 1 / strengthMod);
        
    }
}
