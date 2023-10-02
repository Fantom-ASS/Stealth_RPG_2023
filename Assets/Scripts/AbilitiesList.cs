using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesList : MonoBehaviour
{
    //0-18 - base attacks, 19-42 - special attacks, 43+ cooldown abilities
    public string[] skills_name; //displayed name
    public string[] skills_description; //displayed description
    public string[][] skills_targetstats; //which stats they're changing
    public float[] skills_mana; //mana required to cast
    public float[] skills_complex; //complexity for casting
    public float[] skills_effect; //effect that skill has
    public float[] skills_duration; //duration of effect
    public float[] skills_charges; //quantity of charges
    public float[] skills_targets; //quantity of charges
    public float[] skills_area; //area of effect
    public float[] skills_distance; //maximum distance to cast
    public float[] skills_cd; //cooldown time
    public int[] skills_school; //which skill branch is used
    public bool[] percentage; //skill effect percentage of flat

    
    public float[] step_effect; //effect that skill has
    public float[] step_duration; //duration of effect
    public float[] step_charges; //quantity of targets or charges
    public float[] step_area; //area of effect
    public float[] step_distance; //maximum distance to cast
    public string[] runes_list; //ef - effect, dur - duration, ch - charges, aoe - area, dis - distance, mp - mana

    public string[] buffs;


    // Start is called before the first frame update
    void Start()
    {
        FillData();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillData()
    {
        for(int i = 0; i < skills_name.Length; i++)
        {
        //base attacks
        skills_name[0] = "Base attack";
        skills_description[0] = "Common attack with used weapon";

        skills_name[1] = "Fireball";
        skills_description[1] = "Flaming missile with direct trajectory that hits enemies with fire";
        skills_complex[1] = 5;
        skills_effect[1] = 10;
        skills_duration[1] = 0;
        skills_targets[1] = 1;
        skills_area[1] = 0;
        skills_distance[2] = 20;

        skills_name[2] = "Whirl";
        skills_description[2] = "Tree roots attacking enemies from underground";
        skills_complex[2] = 5;
        skills_effect[2] = 10;
        skills_duration[2] = 0;
        skills_targets[2] = 1;
        skills_area[2] = 0;
        skills_distance[2] = 20;

        skills_name[3] = "Tree wrath";
        skills_description[3] = "Tree roots attacking enemies from underground";
        skills_complex[3] = 5;
        skills_effect[3] = 10;
        skills_duration[3] = 0;
        skills_targets[3] = 1;
        skills_area[3] = 0;
        skills_distance[3] = 20;

        skills_name[4] = "Lighting";
        skills_description[4] = "Lighting that flies in a direct trajectory, can hit multiple enemies";
        skills_complex[4] = 5;
        skills_effect[4] = 10;
        skills_duration[4] = 0;
        skills_targets[4] = 2;
        skills_area[4] = 0;
        skills_distance[4] = 20;

        skills_name[5] = "Glacial spike";
        skills_description[5] = "Ice bolt that glaciate enemy";
        skills_complex[5] = 5;
        skills_effect[5] = 10;
        skills_duration[5] = 1;
        skills_targets[5] = 1;
        skills_area[5] = 0;
        skills_distance[5] = 20;

        skills_name[6] = "Acid clot";
        skills_description[6] = "Poisonous bolt with direct trajectory, damages enemy with acid";
        skills_complex[6] = 5;
        skills_effect[6] = 10;
        skills_duration[6] = 1;
        skills_targets[6] = 1;
        skills_area[6] = 0;
        skills_distance[6] = 20;

        skills_name[7] = "Concentration";
        skills_description[7] = "Increases the defense during attack";
        skills_complex[7] = 5;
        skills_effect[7] = 15;
        skills_duration[7] = 0;
        skills_targets[7] = 1;
        skills_area[7] = 0;
        skills_distance[7] = 0;

        skills_name[8] = "Bash";
        skills_description[8] = "Increases damage during the attack";
        skills_complex[8] = 5;
        skills_effect[8] = 15;
        skills_duration[8] = 0;
        skills_targets[8] = 1;
        skills_area[8] = 0;
        skills_distance[8] = 0;


        skills_name[9] = "Lunge";
        skills_description[9] = "Quick attack with rapprochement with the enemy";
        skills_complex[9] = 5;
        skills_effect[9] = 15;
        skills_duration[9] = 0;
        skills_targets[9] = 1;
        skills_area[9] = 0;
        skills_distance[9] = 0;

        skills_name[10] = "Fury";
        skills_description[10] = "Increased attack speed with each successful hit";
        skills_complex[10] = 5;
        skills_effect[10] = 15;
        skills_duration[10] = 5;
        skills_targets[10] = 1;
        skills_charges[10] = 5;
        skills_area[10] = 0;
        skills_distance[10] = 0;

        skills_name[11] = "Exhaustion";
        skills_description[11] = "Reduced enemy attack speed with each missed hit";
        skills_complex[11] = 5;
        skills_effect[11] = 15;
        skills_duration[11] = 5;
        skills_targets[11] = 1;
        skills_charges[11] = 5;
        skills_area[11] = 0;
        skills_distance[11] = 0;

        skills_name[12] = "Counterattack";
        skills_description[12] = "Increased damage on next attack with each missed hit";
        skills_complex[12] = 5;
        skills_effect[12] = 15;
        skills_duration[12] = 5;
        skills_targets[12] = 1;
        skills_charges[12] = 5;
        skills_area[12] = 0;
        skills_distance[12] = 0;

        skills_name[13] = "Zeroing";
        skills_description[13] = "Each successive shot on the same target deals more damage";
        skills_complex[13] = 5;
        skills_effect[13] = 15;
        skills_duration[13] = 5;
        skills_targets[13] = 1;
        skills_charges[13] = 5;
        skills_area[13] = 0;
        skills_distance[13] = 0;

        skills_name[14] = "Fabrication";
        skills_description[14] = "Increases damage when paused between shots";
        skills_complex[14] = 5;
        skills_effect[14] = 15;
        skills_duration[14] = 5;
        skills_targets[14] = 1;
        skills_area[14] = 0;
        skills_distance[14] = 0;

        skills_name[15] = "Preemption";
        skills_description[15] = "Shot taking into account the range, speed and trajectory of the target";
        skills_complex[15] = 5;
        skills_effect[15] = 15;
        skills_duration[15] = 0;
        skills_targets[15] = 1;
        skills_area[15] = 0;
        skills_distance[15] = 0;

        skills_name[16] = "Hardened tips";
        skills_description[16] = "Darts and arrows pierce enemies through";
        skills_complex[16] = 5;
        skills_effect[16] = 15;
        skills_duration[16] = 0;
        skills_targets[16] = 2;
        skills_area[16] = 0;
        skills_distance[16] = 0;

        skills_name[17] = "Twisted throw";
        skills_description[17] = "Thrown knives and axes ricochet off enemies";
        skills_complex[17] = 5;
        skills_effect[17] = 15;
        skills_duration[17] = 0;
        skills_targets[17] = 2;
        skills_area[17] = 0;
        skills_distance[17] = 0;

        skills_name[18] = "Serrated blades";
        skills_description[18] = "Extra damage and bleeding chance";
        skills_complex[18] = 5;
        skills_effect[18] = 15;
        skills_duration[18] = 5;
        skills_targets[18] = 1;
        skills_area[18] = 0;
        skills_distance[18] = 0;


        //special attacks
        skills_name[19] = "Flame";
        skills_description[19] = "Stream of flame that burns enemies in its path";
        skills_complex[19] = 10;
        skills_mana[19] = 5;
        skills_effect[19] = 15;
        skills_duration[19] = 1;
        skills_targets[19] = 0;
        skills_area[19] = 2;
        skills_distance[19] = 10;

        skills_name[20] = "Tornado";
        skills_description[20] = "Whirlwind that injures and scatters enemies in its path";
        skills_complex[20] = 10;
        skills_mana[20] = 5;
        skills_effect[20] = 15;
        skills_duration[20] = 3;
        skills_targets[20] = 0;
        skills_area[20] = 2;
        skills_distance[20] = 20;

        skills_name[21] = "Landslide";
        skills_description[21] = "Shaking the ground, deals damage and scatters enemies at the target location";
        skills_complex[21] = 10;
        skills_mana[21] = 5;
        skills_effect[21] = 15;
        skills_duration[21] = 1;
        skills_targets[21] = 0;
        skills_area[21] = 2;
        skills_distance[21] = 10;

        skills_name[22] = "Lighting charges";
        skills_description[22] = "Lightning bolt that strikes all enemies in the area of impact";
        skills_complex[22] = 10;
        skills_mana[22] = 5;
        skills_effect[22] = 15;
        skills_duration[22] = 3;
        skills_targets[22] = 3;
        skills_area[22] = 2;
        skills_distance[22] = 20;

        skills_name[23] = "Frozen orb";
        skills_description[23] = "Fires an icy sphere that shatters into many shards of ice damaging nearby enemies";
        skills_complex[23] = 10;
        skills_mana[23] = 5;
        skills_effect[23] = 15;
        skills_duration[23] = 3;
        skills_targets[23] = 8;
        skills_area[23] = 5;
        skills_distance[23] = 20;

        skills_name[24] = "Acid breath";
        skills_description[24] = "Releases a wave of acid that poisons enemies in its path";
        skills_complex[24] = 10;
        skills_mana[24] = 5;
        skills_effect[24] = 15;
        skills_duration[24] = 3;
        skills_targets[24] = 0;
        skills_area[24] = 2;
        skills_distance[24] = 10;

        skills_name[25] = "Defence";
        skills_description[25] = "Closes with a shield, reducing damage from frontal attacks";
        skills_complex[25] = 10;
        skills_mana[25] = 5;
        skills_effect[25] = 15;
        skills_duration[25] = 0;
        skills_targets[25] = 0;
        skills_area[25] = 0;
        skills_distance[25] = 0;

        skills_name[26] = "Smite";
        skills_description[26] = "Hits enemies with a shield, stunning and knocking them back";
        skills_complex[26] = 10;
        skills_mana[26] = 5;
        skills_effect[26] = 15;
        skills_duration[26] = 1;
        skills_targets[26] = 1;
        skills_area[26] = 1;
        skills_distance[26] = 1;

        skills_name[27] = "Crush";
        skills_description[27] = "Strong attack, bonus depends on weapon";
        skills_complex[27] = 10;
        skills_mana[27] = 5;
        skills_effect[27] = 15;
        skills_duration[27] = 0;
        skills_targets[27] = 1;
        skills_area[27] = 0;
        skills_distance[27] = 0;

        skills_name[28] = "Dougle swing";
        skills_description[28] = "Two quick weapon strikes with both hands";
        skills_complex[28] = 10;
        skills_mana[28] = 5;
        skills_effect[28] = 15;
        skills_duration[28] = 0;
        skills_targets[28] = 0;
        skills_area[28] = 1;
        skills_distance[28] = 0;

        skills_name[29] = "Whirldwind";
        skills_description[29] = "The hero spins, dealing physical damage to enemies around every second";
        skills_complex[29] = 10;
        skills_mana[29] = 5;
        skills_effect[29] = 15;
        skills_duration[29] = 0;
        skills_targets[29] = 0;
        skills_area[29] = 0;
        skills_distance[29] = 0;

        skills_name[30] = "Ringing cry";
        skills_description[30] = "Screams, damaging enemies in front of him";
        skills_complex[30] = 10;
        skills_mana[30] = 5;
        skills_effect[30] = 15;
        skills_duration[30] = 1;
        skills_targets[30] = 0;
        skills_area[30] = 2;
        skills_distance[30] = 10;

        skills_name[31] = "Shadow strike";
        skills_description[31] = "Attack with a stealth projectile, especially effective from an ambush";
        skills_complex[31] = 10;
        skills_mana[31] = 5;
        skills_effect[31] = 15;
        skills_duration[31] = 0;
        skills_targets[31] = 1;
        skills_area[31] = 0;
        skills_distance[31] = 0;

        skills_name[32] = "Enchant";
        skills_description[32] = "Increased flight speed, damage and attack";
        skills_complex[32] = 10;
        skills_mana[32] = 5;
        skills_effect[32] = 15;
        skills_duration[32] = 0;
        skills_targets[32] = 1;
        skills_area[32] = 0;
        skills_distance[32] = 0;

        skills_name[33] = "Homing";
        skills_description[33] = "The projectile itself aims at the target, it is very difficult to dodge";
        skills_complex[33] = 10;
        skills_mana[33] = 5;
        skills_effect[33] = 15;
        skills_duration[33] = 0;
        skills_targets[33] = 1;
        skills_area[33] = 0;
        skills_distance[33] = 0;


        skills_name[34] = "Double throw";
        skills_description[34] = "Quick throw with both hands at once";
        skills_complex[34] = 10;
        skills_mana[34] = 5;
        skills_effect[34] = 15;
        skills_duration[34] = 0;
        skills_targets[34] = 1;
        skills_area[34] = 0;
        skills_distance[34] = 0;

        skills_name[35] = "Cutting thread";
        skills_description[35] = "Throwing two projectiles connected by a thread. When they hit an enemy, they spin around, dealing damage to everyone around them";
        skills_complex[35] = 10;
        skills_mana[35] = 5;
        skills_effect[35] = 15;
        skills_duration[35] = 0;
        skills_targets[35] = 0;
        skills_area[35] = 2;
        skills_distance[35] = 0;

        skills_name[36] = "Fan attack";
        skills_description[36] = "Multiple projectiles instead of just one";
        skills_complex[36] = 10;
        skills_mana[36] = 5;
        skills_effect[36] = 15;
        skills_duration[36] = 0;
        skills_targets[36] = 3;
        skills_area[36] = 1;
        skills_distance[36] = 0;

        skills_name[37] = "Holy light";
        skills_description[37] = "Stream of positive energy that heals the living and damages the undead";
        skills_complex[37] = 10;
        skills_mana[37] = 5;
        skills_effect[37] = 15;
        skills_duration[37] = 0;
        skills_targets[37] = 1;
        skills_area[37] = 0;
        skills_distance[37] = 0;

        skills_name[38] = "Death coil";
        skills_description[38] = "Stream of negative energy that heals the undead and damages the living";
        skills_complex[38] = 10;
        skills_mana[38] = 5;
        skills_effect[38] = 15;
        skills_duration[38] = 0;
        skills_targets[38] = 1;
        skills_area[38] = 0;
        skills_distance[38] = 0;

        skills_name[39] = "Spiritual spear";
        skills_description[39] = "A bunch of magical energy that strikes enemies with astral magic";
        skills_complex[39] = 10;
        skills_mana[39] = 5;
        skills_effect[39] = 15;
        skills_duration[39] = 0;
        skills_targets[39] = 1;
        skills_area[39] = 0;
        skills_distance[39] = 0;

        skills_name[40] = "Magic burn";
        skills_description[40] = "Damage to the enemy due to burning his mana";
        skills_complex[40] = 10;
        skills_mana[40] = 5;
        skills_effect[40] = 15;
        skills_duration[40] = 0;
        skills_targets[40] = 1;
        skills_area[40] = 0;
        skills_distance[40] = 0;

        skills_name[41] = "Blood syphon";
        skills_description[41] = "Magical bond, allows you to steal health from an enemy or transfer it to an ally";
        skills_complex[41] = 10;
        skills_mana[41] = 5;
        skills_effect[41] = 15;
        skills_duration[41] = 0;
        skills_targets[41] = 1;
        skills_area[41] = 0;
        skills_distance[41] = 0;

        skills_name[42] = "Astral rift";
        skills_description[42] = "Creates a reality rift that deals damage to anyone in its area of effect";
        skills_complex[42] = 10;
        skills_mana[42] = 5;
        skills_effect[42] = 15;
        skills_duration[42] = 5;
        skills_targets[42] = 0;
        skills_area[42] = 2;
        skills_distance[42] = 0;

        //battle elemental magic
        skills_name[43] = "Meteor";
        skills_description[43] = "Huge burning boulder that falls from the heavens and deals on-hit and burning damage to enemies";
        skills_complex[43] = 20;
        skills_mana[43] = 15;
        skills_effect[43] = 15;
        skills_duration[43] = 5;
        skills_targets[43] = 0;
        skills_area[43] = 4;
        skills_distance[43] = 0;
        skills_cd[43] = 10;

        skills_name[44] = "Hurricane";
        skills_description[44] = "Summons a hurricane that deals damage every second to nearby enemies";
        skills_complex[44] = 20;
        skills_mana[44] = 15;
        skills_effect[44] = 15;
        skills_duration[44] = 5;
        skills_targets[44] = 0;
        skills_area[44] = 4;
        skills_distance[44] = 0;
        skills_cd[44] = 10;

        skills_name[45] = "Earthquake";
        skills_description[45] = "Splits the ground, dealing damage to all who are near the epicenter";
        skills_complex[45] = 20;
        skills_mana[45] = 15;
        skills_effect[45] = 15;
        skills_duration[45] = 5;
        skills_targets[45] = 0;
        skills_area[45] = 4;
        skills_distance[45] = 0;
        skills_cd[45] = 20;

        skills_name[46] = "Healenly lighting";
        skills_description[46] = "A lightning bolt that strikes all enemies in the area of impact";
        skills_complex[46] = 20;
        skills_mana[46] = 15;
        skills_effect[46] = 15;
        skills_duration[46] = 0;
        skills_targets[46] = 0;
        skills_area[46] = 4;
        skills_distance[46] = 0;
        skills_cd[46] = 15;

        skills_name[47] = "Blizzard";
        skills_description[47] = "Storm from the sky that deals damage in the target area with spikes and stars";
        skills_complex[47] = 20;
        skills_mana[47] = 15;
        skills_effect[47] = 15;
        skills_duration[47] = 5;
        skills_targets[47] = 0;
        skills_area[47] = 4;
        skills_distance[47] = 0;
        skills_cd[47] = 25;

        skills_name[48] = "Acid fog";
        skills_description[48] = "Creates an acid mist at the target location, poisoning everyone around";
        skills_complex[48] = 20;
        skills_mana[48] = 15;
        skills_effect[48] = 15;
        skills_duration[48] = 5;
        skills_targets[48] = 0;
        skills_area[48] = 4;
        skills_distance[48] = 0;
        skills_cd[48] = 10;

        //defencive elemental magic
        skills_name[49] = "Warmth";
        skills_description[49] = "Increases the speed of mana recovery for the hero and his allies";
        skills_complex[49] = 20;
        skills_mana[49] = 15;
        skills_effect[49] = 15;
        skills_duration[49] = 10;
        skills_targets[49] = 0;
        skills_area[49] = 2;
        skills_distance[49] = 0;
        skills_cd[49] = 10;

        skills_name[50] = "Cyclone shield";
        skills_description[50] = "Creates whirling currents around the mage, increasing the chance to reflect enemy projectiles and spells";
        skills_complex[50] = 20;
        skills_mana[50] = 15;
        skills_effect[50] = 15;
        skills_duration[50] = 10;
        skills_targets[50] = 0;
        skills_area[50] = 0;
        skills_distance[50] = 0;
        skills_cd[50] = 10;

        skills_name[51] = "Stone armor";
        skills_description[51] = "Creates a shield of stones and branches around the mage, absorbing physical damage";
        skills_complex[51] = 20;
        skills_mana[51] = 15;
        skills_effect[51] = 15;
        skills_duration[51] = 10;
        skills_targets[51] = 0;
        skills_area[51] = 0;
        skills_distance[51] = 0;
        skills_cd[51] = 10;

        skills_name[52] = "Static field";
        skills_description[52] = "Anyone attacking the target takes lightning damage with a chance to be stunned";
        skills_complex[52] = 20;
        skills_mana[52] = 15;
        skills_effect[52] = 15;
        skills_duration[52] = 10;
        skills_targets[52] = 0;
        skills_area[52] = 2;
        skills_distance[52] = 0;
        skills_cd[52] = 10;

        skills_name[53] = "Frozen protection";
        skills_description[53] = "Surrounds the target with a stream of cold air. Reduces damage taken by freezing";
        skills_complex[53] = 20;
        skills_mana[53] = 15;
        skills_effect[53] = 15;
        skills_duration[53] = 10;
        skills_targets[53] = 0;
        skills_area[53] = 2;
        skills_distance[53] = 0;
        skills_cd[53] = 10;

        skills_name[54] = "Oxidation";
        skills_description[54] = "Anyone who attacks the target of the spell becomes poisoned";
        skills_complex[54] = 20;
        skills_mana[54] = 15;
        skills_effect[54] = 15;
        skills_duration[54] = 10;
        skills_targets[54] = 0;
        skills_area[54] = 2;
        skills_distance[54] = 0;
        skills_cd[54] = 10;

        //secondary elemental magic
        skills_name[55] = "Phoenix";
        skills_description[55] = "Call of a phoenix that attacks the enemies of the magician. Phoenix periodically dies, if his egg survives, he will be reborn himself";
        skills_complex[55] = 20;
        skills_mana[55] = 15;
        skills_effect[55] = 15;
        skills_duration[55] = 10;
        skills_targets[55] = 0;
        skills_area[55] = 0;
        skills_distance[55] = 0;
        skills_cd[55] = 10;

        skills_name[56] = "Telekinesis";
        skills_description[56] = "Moving objects with the force of air. Allows to pick up trophies, open and close doors, throw environmental objects at enemies";
        skills_complex[56] = 20;
        skills_mana[56] = 15;
        skills_effect[56] = 15;
        skills_duration[56] = 0;
        skills_targets[56] = 0;
        skills_area[56] = 0;
        skills_distance[56] = 0;
        skills_cd[56] = 10;

        skills_name[57] = "Wall";
        skills_description[57] = "A stone wall that blocks the path and projectiles flying at you. Could be destroyed";
        skills_complex[57] = 20;
        skills_mana[57] = 15;
        skills_effect[57] = 15;
        skills_duration[57] = 10;
        skills_targets[57] = 0;
        skills_area[57] = 4;
        skills_distance[57] = 0;
        skills_cd[57] = 10;

        skills_name[58] = "Lighting orb";
        skills_description[58] = "Creates a lighting that swirls around the mage and strikes his enemies";
        skills_complex[58] = 20;
        skills_mana[58] = 15;
        skills_effect[58] = 15;
        skills_duration[58] = 10;
        skills_targets[58] = 0;
        skills_area[58] = 4;
        skills_distance[58] = 0;
        skills_cd[58] = 10;

        skills_name[59] = "Sarcophagus";
        skills_description[59] = "Covers the target with ice, on the one hand, immobilizing, on the other hand, increasing its defense, regeneration of health and mana";
        skills_complex[59] = 20;
        skills_mana[59] = 15;
        skills_effect[59] = 15;
        skills_duration[59] = 10;
        skills_targets[59] = 0;
        skills_area[59] = 0;
        skills_distance[59] = 0;
        skills_cd[59] = 10;

        skills_name[60] = "Hydra";
        skills_description[60] = "Summons a Hydra at the target location, spitting acid at enemies. The more damage the hydra does, the more heads it grows";
        skills_complex[60] = 20;
        skills_mana[60] = 15;
        skills_effect[60] = 15;
        skills_duration[60] = 10;
        skills_targets[60] = 0;
        skills_area[60] = 10;
        skills_distance[60] = 0;
        skills_cd[60] = 10;

        //battle astral magic
        skills_name[61] = "Rupture";
        skills_description[61] = "Deals damage to an enemy in an attempt to tear them apart, on a success, deal half as much damage to nearby enemies";
        skills_complex[61] = 20;
        skills_mana[61] = 15;
        skills_effect[61] = 15;
        skills_duration[61] = 0;
        skills_targets[61] = 1;
        skills_area[61] = 2;
        skills_distance[61] = 0;
        skills_cd[61] = 10;

        skills_name[62] = "Corpse explosion";
        skills_description[62] = "Explodes the body, dealing damage to nearby enemies";
        skills_complex[62] = 20;
        skills_mana[62] = 15;
        skills_effect[62] = 15;
        skills_duration[62] = 0;
        skills_targets[62] = 1;
        skills_area[62] = 2;
        skills_distance[62] = 0;
        skills_cd[62] = 10;

        skills_name[63] = "Astral storm";
        skills_description[63] = "Creates a stream of magic in the specified place, injuring everyone who is nearby";
        skills_complex[63] = 20;
        skills_mana[63] = 15;
        skills_effect[63] = 15;
        skills_duration[63] = 10;
        skills_targets[63] = 0;
        skills_area[63] = 4;
        skills_distance[63] = 0;
        skills_cd[63] = 10;

        skills_name[64] = "Devastation";
        skills_description[64] = "Sets fire to the soul of the enemy, dealing damage to him for each missing point of mana. If he dies, burns the mana and health of nearby enemies";
        skills_complex[64] = 20;
        skills_mana[64] = 15;
        skills_effect[64] = 15;
        skills_duration[64] = 0;
        skills_targets[64] = 1;
        skills_area[64] = 0;
        skills_distance[64] = 0;
        skills_cd[64] = 10;

        skills_name[65] = "Spirits rage";
        skills_description[65] = "Releases a swarm of evil spirits at the enemy, pursuing random targets";
        skills_complex[65] = 20;
        skills_mana[65] = 15;
        skills_effect[65] = 15;
        skills_duration[65] = 0;
        skills_targets[65] = 3;
        skills_area[65] = 1;
        skills_distance[65] = 0;
        skills_cd[65] = 10;

        skills_name[66] = "Heavenly fire";
        skills_description[66] = "Sets an enemy on fire, dealing damage every second, while the spell is in effect, no useful enchantment can be cast on the enemy";
        skills_complex[66] = 20;
        skills_mana[66] = 15;
        skills_effect[66] = 15;
        skills_duration[66] = 10;
        skills_targets[66] = 1;
        skills_area[66] = 0;
        skills_distance[66] = 0;
        skills_cd[66] = 10;

        //summon magic
        skills_name[67] = "Crows flock";
        skills_description[67] = "A flock of crows to help him, pecking at the enemy";
        skills_complex[67] = 20;
        skills_mana[67] = 15;
        skills_effect[67] = 15;
        skills_duration[67] = 10;
        skills_targets[67] = 3;
        skills_area[67] = 0;
        skills_distance[67] = 0;
        skills_cd[67] = 10;

        skills_name[68] = "Wild pack";
        skills_description[68] = "A pack of wild animals to help you in battle";
        skills_complex[68] = 20;
        skills_mana[68] = 15;
        skills_effect[68] = 15;
        skills_duration[68] = 10;
        skills_targets[68] = 2;
        skills_area[68] = 0;
        skills_distance[68] = 0;
        skills_cd[68] = 10;

        skills_name[69] = "Liveliness";
        skills_description[69] = "Allows to animate objects by turning them into your servants";
        skills_complex[69] = 20;
        skills_mana[69] = 15;
        skills_effect[69] = 15;
        skills_duration[69] = 10;
        skills_targets[69] = 1;
        skills_area[69] = 0;
        skills_distance[69] = 0;
        skills_cd[69] = 10;

        skills_name[70] = "Shadow";
        skills_description[70] = "Summons a shadow, it does not fight, but strengthens you and your summons";
        skills_complex[70] = 20;
        skills_mana[70] = 15;
        skills_effect[70] = 15;
        skills_duration[70] = 10;
        skills_targets[70] = 1;
        skills_area[70] = 0;
        skills_distance[70] = 0;
        skills_cd[70] = 10;

        skills_name[71] = "Raise skeleton";
        skills_description[71] = "Turns the body of a slain enemy into a skeleton that fights by your side";
        skills_complex[71] = 20;
        skills_mana[71] = 15;
        skills_effect[71] = 15;
        skills_duration[71] = 20;
        skills_targets[71] = 1;
        skills_area[71] = 0;
        skills_distance[71] = 0;
        skills_cd[71] = 10;

        skills_name[72] = "Golem";
        skills_description[72] = "Creation of a golem that takes on the properties of the bodies or objects from which it was created";
        skills_complex[72] = 20;
        skills_mana[72] = 15;
        skills_effect[72] = 15;
        skills_duration[72] = 20;
        skills_targets[72] = 1;
        skills_area[72] = 0;
        skills_distance[72] = 0;
        skills_cd[72] = 10;

        //support magic
        skills_name[73] = "Healing";
        skills_description[73] = "Restores the health of all living creatures near the target, increasing their regeneration";
        skills_complex[73] = 20;
        skills_mana[73] = 15;
        skills_effect[73] = 15;
        skills_duration[73] = 10;
        skills_targets[73] = 0;
        skills_area[73] = 1;
        skills_distance[73] = 0;
        skills_cd[73] = 10;

        skills_name[74] = "Purge";
        skills_description[74] = "Dispels all magic cast on targets";
        skills_complex[74] = 20;
        skills_mana[74] = 15;
        skills_effect[74] = 15;
        skills_duration[74] = 0;
        skills_targets[74] = 0;
        skills_area[74] = 1;
        skills_distance[74] = 0;
        skills_cd[74] = 10;

        skills_name[75] = "Blessing";
        skills_description[75] = "Enchanting targets' weapons, increasing the effectiveness of their attacks";
        skills_complex[75] = 20;
        skills_mana[0] = 15;
        skills_effect[0] = 15;
        skills_duration[0] = 10;
        skills_targets[0] = 0;
        skills_area[0] = 1;
        skills_distance[0] = 0;
        skills_cd[0] = 10;

        skills_name[76] = "Sanctuary";
        skills_description[76] = "Creates a protective dome around the target that reduces magic damage and the duration of harmful spells, repels and injures demons and undead that come close";
        skills_complex[76] = 20;
        skills_mana[76] = 15;
        skills_effect[76] = 15;
        skills_duration[76] = 10;
        skills_targets[76] = 0;
        skills_area[76] = 2;
        skills_distance[76] = 0;
        skills_cd[76] = 10;

        skills_name[77] = "Immortality";
        skills_description[77] = "Allows target to stay alive when receiving fatal damage";
        skills_complex[77] = 20;
        skills_mana[77] = 15;
        skills_effect[77] = 15;
        skills_duration[77] = 10;
        skills_targets[77] = 1;
        skills_area[77] = 1;
        skills_distance[77] = 0;
        skills_cd[77] = 10;

        skills_name[78] = "Resurrection";
        skills_description[78] = "Brings back a dead ally";
        skills_complex[78] = 20;
        skills_mana[78] = 15;
        skills_effect[78] = 15;
        skills_duration[78] = 10;
        skills_targets[78] = 1;
        skills_area[78] = 1;
        skills_distance[78] = 0;
        skills_cd[78] = 10;

        //curse magic
        skills_name[79] = "Decrepify";
        skills_description[79] = "Reduces physical resistance and physical damage dealt by enemies";
        skills_complex[79] = 20;
        skills_mana[79] = 15;
        skills_effect[79] = 15;
        skills_duration[79] = 10;
        skills_targets[79] = 0;
        skills_area[79] = 1;
        skills_distance[79] = 0;
        skills_cd[79] = 10;

        skills_name[80] = "Anathem";
        skills_description[80] = "Reduces magical resistance, prolongs the duration of curses placed on enemies";
        skills_complex[80] = 20;
        skills_mana[80] = 15;
        skills_effect[80] = 15;
        skills_duration[80] = 10;
        skills_targets[80] = 0;
        skills_area[80] = 1;
        skills_distance[80] = 0;
        skills_cd[80] = 10;

        skills_name[81] = "Blood call";
        skills_description[81] = "Anyone who deals physical damage to the target will steal some of its health";
        skills_complex[81] = 20;
        skills_mana[81] = 15;
        skills_effect[81] = 15;
        skills_duration[81] = 10;
        skills_targets[81] = 0;
        skills_area[81] = 1;
        skills_distance[81] = 0;
        skills_cd[81] = 10;

        skills_name[82] = "Iron maiden";
        skills_description[82] = "Returns a portion of the physical damage dealt to the target";
        skills_complex[82] = 20;
        skills_mana[82] = 15;
        skills_effect[82] = 15;
        skills_duration[82] = 10;
        skills_targets[82] = 0;
        skills_area[82] = 1;
        skills_distance[82] = 0;
        skills_cd[82] = 10;

        skills_name[83] = "Paralysis";
        skills_description[83] = "Ñompletely immobilizes the target for a while";
        skills_complex[83] = 20;
        skills_mana[83] = 15;
        skills_effect[83] = 15;
        skills_duration[83] = 10;
        skills_targets[83] = 0;
        skills_area[83] = 1;
        skills_distance[83] = 0;
        skills_cd[83] = 10;

        skills_name[84] = "Dementia";
        skills_description[84] = "Reduces the mental abilities of the target, thereby weakening its magic";
        skills_complex[84] = 20;
        skills_mana[84] = 15;
        skills_effect[84] = 15;
        skills_duration[84] = 10;
        skills_targets[84] = 0;
        skills_area[84] = 1;
        skills_distance[84] = 0;
        skills_cd[84] = 10;

        //scout magic
        skills_name[85] = "Eagle sight";
        skills_description[85] = "Increases the range of vision";
        skills_complex[85] = 20;
        skills_mana[85] = 15;
        skills_effect[85] = 15;
        skills_duration[85] = 10;
        skills_targets[85] = 0;
        skills_area[85] = 1;
        skills_distance[85] = 0;
        skills_cd[85] = 10;

        skills_name[86] = "Night vision";
        skills_description[86] = "Reduces vision range penalty at night and in dungeons";
        skills_complex[86] = 20;
        skills_mana[86] = 15;
        skills_effect[86] = 15;
        skills_duration[86] = 10;
        skills_targets[86] = 0;
        skills_area[86] = 1;
        skills_distance[86] = 0;
        skills_cd[86] = 10;

        skills_name[87] = "Field of view";
        skills_description[87] = "Allows  to see the field of view of the enemy";
        skills_complex[87] = 20;
        skills_mana[87] = 15;
        skills_effect[87] = 15;
        skills_duration[87] = 10;
        skills_targets[87] = 0;
        skills_area[87] = 1;
        skills_distance[87] = 0;
        skills_cd[87] = 10;

        skills_name[88] = "Clairvoyance";
        skills_description[88] = "Shows invisible enemies, traps and caches in the specified area";
        skills_complex[88] = 20;
        skills_mana[88] = 15;
        skills_effect[88] = 15;
        skills_duration[88] = 10;
        skills_targets[88] = 0;
        skills_area[88] = 1;
        skills_distance[88] = 0;
        skills_cd[88] = 10;

        skills_name[89] = "Sixth sence";
        skills_description[89] = "Indicates the enemy's next destination";
        skills_complex[89] = 20;
        skills_mana[89] = 15;
        skills_effect[89] = 15;
        skills_duration[89] = 10;
        skills_targets[89] = 0;
        skills_area[89] = 1;
        skills_distance[89] = 0;
        skills_cd[89] = 10;

        skills_name[90] = "Inner eye";
        skills_description[90] = "Highlights all enemies around, allows you to ignore part of their defense";
        skills_complex[90] = 20;
        skills_mana[90] = 15;
        skills_effect[90] = 15;
        skills_duration[90] = 10;
        skills_targets[90] = 0;
        skills_area[90] = 4;
        skills_distance[90] = 0;
        skills_cd[90] = 10;

        //hiding magic
        skills_name[91] = "Silent step";
        skills_description[91] = "Reduces the noise that the hero makes when moving";
        skills_complex[91] = 20;
        skills_mana[91] = 15;
        skills_effect[91] = 15;
        skills_duration[91] = 10;
        skills_targets[91] = 0;
        skills_area[91] = 1;
        skills_distance[91] = 0;
        skills_cd[91] = 10;

        skills_name[92] = "Invisibility";
        skills_description[92] = "Makes the hero less visible to enemies";
        skills_complex[92] = 20;
        skills_mana[92] = 15;
        skills_effect[92] = 15;
        skills_duration[92] = 10;
        skills_targets[92] = 0;
        skills_area[92] = 1;
        skills_distance[92] = 0;
        skills_cd[92] = 10;

        skills_name[93] = "Undead deception";
        skills_description[93] = "The undead stop seeing you from behind";
        skills_complex[93] = 20;
        skills_mana[93] = 15;
        skills_effect[93] = 15;
        skills_duration[93] = 10;
        skills_targets[93] = 0;
        skills_area[93] = 1;
        skills_distance[93] = 0;
        skills_cd[93] = 10;

        skills_name[94] = "Illusion";
        skills_description[94] = "Creates double, capable of distracting the enemy";
        skills_complex[94] = 20;
        skills_mana[94] = 15;
        skills_effect[94] = 15;
        skills_duration[94] = 10;
        skills_targets[94] = 1;
        skills_area[94] = 1;
        skills_distance[94] = 0;
        skills_cd[94] = 10;

        skills_name[95] = "Obscurity";
        skills_description[95] = "Taking on the appearance of the enemy, thereby masquerading as him";
        skills_complex[95] = 20;
        skills_mana[95] = 15;
        skills_effect[95] = 15;
        skills_duration[95] = 10;
        skills_targets[95] = 0;
        skills_area[95] = 1;
        skills_distance[95] = 0;
        skills_cd[95] = 10;

        skills_name[96] = "Light refraction";
        skills_description[96] = "Creating an area where become less visible to enemies";
        skills_complex[96] = 20;
        skills_mana[96] = 15;
        skills_effect[96] = 15;
        skills_duration[96] = 10;
        skills_targets[96] = 0;
        skills_area[96] = 2;
        skills_distance[96] = 0;
        skills_cd[96] = 10;

        //distract magic
        skills_name[97] = "Fireworks";
        skills_description[97] = "Creating magical sparks that attract enemies with their flicker and sounds";
        skills_complex[97] = 20;
        skills_mana[97] = 15;
        skills_effect[97] = 15;
        skills_duration[97] = 10;
        skills_targets[97] = 0;
        skills_area[97] = 1;
        skills_distance[97] = 0;
        skills_cd[97] = 10;

        skills_name[98] = "Dim vision";
        skills_description[98] = "Reduces the range of vision of enemies";
        skills_complex[98] = 20;
        skills_mana[98] = 15;
        skills_effect[98] = 15;
        skills_duration[98] = 10;
        skills_targets[98] = 0;
        skills_area[98] = 1;
        skills_distance[98] = 0;
        skills_cd[98] = 10;

        skills_name[99] = "Delusion";
        skills_description[99] = "Enemy starts to attack random targets";
        skills_complex[99] = 20;
        skills_mana[99] = 15;
        skills_effect[99] = 0;
        skills_duration[99] = 10;
        skills_targets[99] = 0;
        skills_area[99] = 1;
        skills_distance[99] = 0;
        skills_cd[99] = 10;

        skills_name[100] = "Lethargy";
        skills_description[100] = "Makes an enemy to sleep, in case of damage he wakes up";
        skills_complex[100] = 20;
        skills_mana[100] = 15;
        skills_effect[100] = 0;
        skills_duration[100] = 10;
        skills_targets[100] = 0;
        skills_area[100] = 1;
        skills_distance[100] = 0;
        skills_cd[100] = 10;

        skills_name[101] = "Hypnosis";
        skills_description[101] = "Hypnotizes the enemy into fighting for you";
        skills_complex[101] = 20;
        skills_mana[101] = 15;
        skills_effect[101] = 0;
        skills_duration[101] = 10;
        skills_targets[101] = 1;
        skills_area[101] = 1;
        skills_distance[101] = 0;
        skills_cd[101] = 10;

        skills_name[102] = "Black label";
        skills_description[102] = "The enemy becomes the number one target for his comrades";
        skills_complex[102] = 20;
        skills_mana[102] = 15;
        skills_effect[102] = 0;
        skills_duration[102] = 10;
        skills_targets[102] = 1;
        skills_area[102] = 1;
        skills_distance[102] = 0;
        skills_cd[102] = 10;

        //instinct magic
        skills_name[103] = "Sharpened reflexes";
        skills_description[103] = "Increases attack speed, movement speed and dodge chance";
        skills_complex[103] = 20;
        skills_mana[103] = 15;
        skills_effect[103] = 15;
        skills_duration[103] = 10;
        skills_targets[103] = 0;
        skills_area[103] = 1;
        skills_distance[103] = 0;
        skills_cd[103] = 10;

        skills_name[104] = "Spiritual chains";
        skills_description[104] = "Creates a spiritual bond between targets, distributing damage received";
        skills_complex[104] = 20;
        skills_mana[104] = 15;
        skills_effect[104] = 15;
        skills_duration[104] = 10;
        skills_targets[104] = 2;
        skills_area[104] = 2;
        skills_distance[104] = 0;
        skills_cd[104] = 10;

        skills_name[105] = "Ignoring";
        skills_description[105] = "Allows to temporarily ignore all harmful effects";
        skills_complex[105] = 20;
        skills_mana[105] = 15;
        skills_effect[105] = 15;
        skills_duration[105] = 10;
        skills_targets[105] = 0;
        skills_area[105] = 1;
        skills_distance[105] = 0;
        skills_cd[105] = 10;

        skills_name[106] = "Despair";
        skills_description[106] = "Increased damage dealt and chance to crit as health drops";
        skills_complex[106] = 20;
        skills_mana[106] = 15;
        skills_effect[106] = 15;
        skills_duration[106] = 10;
        skills_targets[106] = 0;
        skills_area[106] = 1;
        skills_distance[106] = 0;
        skills_cd[106] = 10;

        skills_name[107] = "Insane fury";
        skills_description[107] = "Increases attack power at the cost of losing health every second";
        skills_complex[107] = 20;
        skills_mana[107] = 15;
        skills_effect[107] = 15;
        skills_duration[107] = 10;
        skills_targets[107] = 0;
        skills_area[107] = 1;
        skills_distance[107] = 0;
        skills_cd[107] = 10;

        skills_name[108] = "Shadowdancer";
        skills_description[108] = "Increases movement speed and dodge chance as health drops";
        skills_complex[108] = 20;
        skills_mana[108] = 15;
        skills_effect[108] = 15;
        skills_duration[108] = 10;
        skills_targets[108] = 0;
        skills_area[108] = 1;
        skills_distance[108] = 0;
        skills_cd[108] = 10;

        //control magic
        skills_name[109] = "Taunt";
        skills_description[109] = "Provokes the enemies to attack";
        skills_complex[109] = 20;
        skills_mana[109] = 15;
        skills_effect[109] = 15;
        skills_duration[109] = 10;
        skills_targets[109] = 1;
        skills_area[109] = 2;
        skills_distance[109] = 0;
        skills_cd[109] = 10;

        skills_name[110] = "Horror";
        skills_description[110] = "Frightens the enemies, forcing them to flee";
        skills_complex[110] = 20;
        skills_mana[110] = 15;
        skills_effect[110] = 15;
        skills_duration[110] = 10;
        skills_targets[110] = 1;
        skills_area[110] = 2;
        skills_distance[110] = 0;
        skills_cd[110] = 10;

        skills_name[111] = "Silence";
        skills_description[111] = "Deprives the enemy of the ability to use abilities";
        skills_complex[111] = 20;
        skills_mana[111] = 15;
        skills_effect[111] = 15;
        skills_duration[111] = 10;
        skills_targets[111] = 1;
        skills_area[111] = 2;
        skills_distance[111] = 0;
        skills_cd[111] = 10;

        skills_name[112] = "Fatigue";
        skills_description[112] = "Increases the enemy's mana cost when using spells";
        skills_complex[112] = 20;
        skills_mana[112] = 15;
        skills_effect[112] = 15;
        skills_duration[112] = 10;
        skills_targets[112] = 1;
        skills_area[112] = 2;
        skills_distance[112] = 0;
        skills_cd[112] = 10;

        skills_name[113] = "Agony";
        skills_description[113] = "Every second decrease in health for each missing hitpoint";
        skills_complex[113] = 20;
        skills_mana[113] = 15;
        skills_effect[113] = 15;
        skills_duration[113] = 10;
        skills_targets[113] = 1;
        skills_area[113] = 2;
        skills_distance[113] = 0;
        skills_cd[113] = 10;


        skills_name[114] = "Soul exchange";
        skills_description[114] = "Allows you to exchange souls with the enemy, thereby changing the ratio of his health";
        skills_complex[114] = 20;
        skills_mana[114] = 15;
        skills_effect[114] = 15;
        skills_duration[114] = 10;
        skills_targets[114] = 1;
        skills_area[114] = 2;
        skills_distance[114] = 0;
        skills_cd[114] = 10;

        //melee combat skills
        skills_name[115] = "Ram";
        skills_description[115] = "Breaks through the crowd of enemies, causing damage to everyone in the way";
        skills_complex[115] = 20;
        skills_mana[115] = 15;
        skills_effect[115] = 15;
        skills_duration[115] = 0;
        skills_targets[115] = 0;
        skills_area[115] = 1;
        skills_distance[115] = 10;

        skills_name[116] = "Leap";
        skills_description[116] = "Jumps to the specified area while attacking the nearest target";
        skills_complex[116] = 20;
        skills_mana[116] = 15;
        skills_effect[116] = 15;
        skills_duration[116] = 0;
        skills_targets[116] = 0;
        skills_area[116] = 1;
        skills_distance[116] = 5;
        skills_cd[116] = 10;

        skills_name[117] = "Massacre";
        skills_description[117] = "A series of fast and powerful blows with a change of position after each";
        skills_complex[117] = 20;
        skills_mana[117] = 15;
        skills_effect[117] = 15;
        skills_duration[117] = 0;
        skills_targets[117] = 3;
        skills_area[117] = 2;
        skills_distance[117] = 5;
        skills_cd[117] = 10;

        skills_name[118] = "Kick";
        skills_description[118] = "Kick that knocks the enemy back";
        skills_complex[118] = 20;
        skills_mana[118] = 15;
        skills_effect[118] = 15;
        skills_duration[118] = 1;
        skills_targets[118] = 0;
        skills_area[118] = 1;
        skills_distance[118] = 5;
        skills_cd[118] = 10;

        skills_name[119] = "Revenge";
        skills_description[119] = "Returns some of the damage to enemies that attacked the hero in melee";
        skills_complex[119] = 20;
        skills_mana[119] = 15;
        skills_effect[119] = 15;
        skills_duration[119] = 10;
        skills_targets[119] = 0;
        skills_area[119] = 1;
        skills_distance[119] = 0;
        skills_cd[119] = 10;

        skills_name[120] = "Defiance";
        skills_description[120] = "Increases defense, health and block chance of the hero";
        skills_complex[120] = 20;
        skills_mana[120] = 15;
        skills_effect[120] = 15;
        skills_duration[120] = 10;
        skills_targets[120] = 0;
        skills_area[120] = 0;
        skills_distance[120] = 0;
        skills_cd[120] = 10;

        //battlecries
        skills_name[121] = "Battle cry";
        skills_description[121] = "Increases the physical damage dealt by the hero and allies";
        skills_complex[121] = 20;
        skills_mana[121] = 15;
        skills_effect[121] = 15;
        skills_duration[121] = 10;
        skills_targets[121] = 0;
        skills_area[121] = 4;
        skills_distance[121] = 0;
        skills_cd[121] = 10;

        skills_name[122] = "Admonition";
        skills_description[122] = "Increases the protection of hero and allies from physical damage";
        skills_complex[122] = 20;
        skills_mana[122] = 15;
        skills_effect[122] = 15;
        skills_duration[122] = 10;
        skills_targets[122] = 0;
        skills_area[122] = 4;
        skills_distance[122] = 0;
        skills_cd[122] = 10;

        skills_name[123] = "Provocation";
        skills_description[123] = "Forces nearby enemies to attack the hero, reducing their physical damage inflicted";
        skills_complex[123] = 20;
        skills_mana[123] = 15;
        skills_effect[123] = 15;
        skills_duration[123] = 10;
        skills_targets[123] = 0;
        skills_area[123] = 4;
        skills_distance[123] = 0;
        skills_cd[123] = 10;

        skills_name[124] = "Terrifying howl";
        skills_description[124] = "Shout that makes enemies flee and reduces their physical resistance";
        skills_complex[124] = 20;
        skills_mana[124] = 15;
        skills_effect[124] = 15;
        skills_duration[124] = 10;
        skills_targets[124] = 0;
        skills_area[124] = 4;
        skills_distance[124] = 0;
        skills_cd[124] = 10;

        skills_name[125] = "Berserker rage";
        skills_description[125] = "Hero deals more physical damage and regenerates mana faster";
        skills_complex[125] = 20;
        skills_mana[125] = 15;
        skills_effect[125] = 15;
        skills_duration[125] = 10;
        skills_targets[125] = 0;
        skills_area[125] = 4;
        skills_distance[125] = 0;
        skills_cd[125] = 10;

        skills_name[126] = "Deafening roar";
        skills_description[126] = "Hero hurts and stuns enemies around with his scream";
        skills_complex[126] = 20;
        skills_mana[126] = 15;
        skills_effect[126] = 15;
        skills_duration[126] = 10;
        skills_targets[126] = 0;
        skills_area[126] = 2;
        skills_distance[126] = 0;
        skills_cd[126] = 10;

        //auxiliary melee skills
        skills_name[127] = "Unstoppable";
        skills_description[127] = "Allows you to ignore the effect of all negative effects";
        skills_complex[127] = 20;
        skills_mana[127] = 15;
        skills_effect[127] = 15;
        skills_duration[127] = 5;
        skills_targets[127] = 0;
        skills_area[127] = 0;
        skills_distance[127] = 0;
        skills_cd[127] = 10;

        skills_name[128] = "Vandalism";
        skills_description[128] = "Mutilation of a corpse to intimidate enemies";
        skills_complex[128] = 20;
        skills_mana[128] = 15;
        skills_effect[128] = 15;
        skills_duration[128] = 10;
        skills_targets[128] = 1;
        skills_area[128] = 4;
        skills_distance[128] = 0;
        skills_cd[128] = 10;

        skills_name[129] = "Reposing";
        skills_description[129] = "Makes the corpse unusable for rituals by restoring some of the mana and health";
        skills_complex[129] = 20;
        skills_mana[129] = 15;
        skills_effect[129] = 15;
        skills_duration[129] = 10;
        skills_targets[129] = 1;
        skills_area[129] = 4;
        skills_distance[129] = 0;
        skills_cd[129] = 10;

        skills_name[130] = "Strength cumulation";
        skills_description[130] = "Increases the damage dealt by the hero after a pause between hits";
        skills_complex[130] = 20;
        skills_mana[130] = 15;
        skills_effect[130] = 15;
        skills_duration[130] = 10;
        skills_targets[130] = 0;
        skills_area[130] = 0;
        skills_distance[130] = 0;
        skills_cd[130] = 10;

        skills_name[131] = "Intended victim";
        skills_description[131] = "Increases the damage dealt by the hero when attacking the selected target";
        skills_complex[131] = 20;
        skills_mana[131] = 15;
        skills_effect[131] = 15;
        skills_duration[131] = 10;
        skills_targets[131] = 1;
        skills_area[131] = 0;
        skills_distance[131] = 0;
        skills_cd[13] = 10;


        skills_name[132] = "Bloody list";
        skills_description[132] = "Marks a group of targets of the hero, when killing each target, the next one will receive more damage when attacking";
        skills_complex[132] = 20;
        skills_mana[132] = 15;
        skills_effect[132] = 15;
        skills_duration[132] = 10;
        skills_targets[132] = 2;
        skills_area[132] = 4;
        skills_distance[132] = 0;
        skills_cd[132] = 10;

        //ranged battle skills
        skills_name[133] = "Poison imbue";
        skills_description[133] = "Adds poison damage to subsequent attacks";
        skills_complex[133] = 20;
        skills_mana[133] = 15;
        skills_effect[133] = 15;
        skills_duration[133] = 30;
        skills_targets[133] = 3;
        skills_area[133] = 0;
        skills_distance[133] = 0;
        skills_cd[133] = 10;

        skills_name[134] = "Fire imbue";
        skills_description[134] = "Adds fire damage to subsequent attacks";
        skills_complex[134] = 20;
        skills_mana[134] = 15;
        skills_effect[134] = 15;
        skills_duration[134] = 30;
        skills_targets[134] = 3;
        skills_area[134] = 0;
        skills_distance[134] = 0;
        skills_cd[134] = 10;

        skills_name[135] = "Curse imbue";
        skills_description[135] = "Adds random curse effect to subsequent attacks";
        skills_complex[135] = 20;
        skills_mana[135] = 15;
        skills_effect[135] = 15;
        skills_duration[135] = 30;
        skills_targets[135] = 3;
        skills_area[135] = 0;
        skills_distance[135] = 0;
        skills_cd[135] = 10;

        skills_name[136] = "Harpoon";
        skills_description[136] = "Allows you to pull the hero to the right place, or vice versa - pull the target to the hero"; 
        skills_complex[136] = 20;
        skills_mana[136] = 15;
        skills_effect[136] = 15;
        skills_duration[136] = 0;
        skills_targets[136] = 1;
        skills_area[136] = 0;
        skills_distance[136] = 0;
        skills_cd[136] = 10;

        skills_name[137] = "Shock web";
        skills_description[137] = "Throws a web at enemies, immobilizing them for a short time";
        skills_complex[137] = 20;
        skills_mana[137] = 15;
        skills_effect[137] = 0;
        skills_duration[137] = 5;
        skills_targets[137] = 0;
        skills_area[137] = 1;
        skills_distance[137] = 0;
        skills_cd[137] = 10;

        skills_name[138] = "Slowing missiles";
        skills_description[138] = "Slows down and deflects projectiles flying at the hero";
        skills_complex[138] = 20;
        skills_mana[138] = 15;
        skills_effect[138] = 15;
        skills_duration[138] = 10;
        skills_targets[138] = 0;
        skills_area[138] = 4;
        skills_distance[138] = 0;
        skills_cd[138] = 10;

        //Alchemistry
        skills_name[139] = "Fire grenade";
        skills_description[139] = "Throws a fire potion at the target location, dealing fire and explosion damage";
        skills_complex[139] = 20;
        skills_mana[139] = 15;
        skills_effect[139] = 15;
        skills_duration[139] = 2;
        skills_targets[139] = 0;
        skills_area[139] = 1;
        skills_distance[139] = 0;
        skills_cd[139] = 10;

        skills_name[140] = "Poison grenade";
        skills_description[140] = "Throws a potion at the target location that creates a poisonous cloud";
        skills_complex[140] = 20;
        skills_mana[140] = 15;
        skills_effect[140] = 15;
        skills_duration[140] = 2;
        skills_targets[140] = 0;
        skills_area[140] = 1;
        skills_distance[140] = 0;
        skills_cd[140] = 10;

        skills_name[141] = "Freezing potion";
        skills_description[141] = "Throws a potion at the target location that freezes enemies";
        skills_complex[141] = 20;
        skills_mana[141] = 15;
        skills_effect[141] = 15;
        skills_duration[141] = 2;
        skills_targets[141] = 0;
        skills_area[141] = 1;
        skills_distance[141] = 0;
        skills_cd[141] = 10;

        skills_name[142] = "Discord potion";
        skills_description[142] = "Throws a potion at the target location that drives enemies insane";
        skills_complex[142] = 20;
        skills_mana[142] = 15;
        skills_effect[142] = 15;
        skills_duration[142] = 2;
        skills_targets[142] = 0;
        skills_area[142] = 1;
        skills_distance[142] = 0;
        skills_cd[142] = 10;

        skills_name[143] = "Blinding powder";
        skills_description[143] = "Throws a powder at the target location that blinds enemies";
        skills_complex[143] = 20;
        skills_mana[143] = 15;
        skills_effect[143] = 15;
        skills_duration[143] = 2;
        skills_targets[143] = 0;
        skills_area[143] = 1;
        skills_distance[143] = 0;
        skills_cd[143] = 10;

        skills_name[144] = "Healing powder";
        skills_description[144] = "Throws a powder at the target location that heals allies";
        skills_complex[144] = 20;
        skills_mana[144] = 15;
        skills_effect[144] = 15;
        skills_duration[144] = 2;
        skills_targets[144] = 0;
        skills_area[144] = 1;
        skills_distance[144] = 0;
        skills_cd[144] = 10;


        buffs[0] = "burn";
        buffs[1] = "ensnare";
        buffs[2] = "freeze";
        buffs[3] = "poison";
        buffs[4] = "stun";
        buffs[5] = "contusion";
        buffs[6] = "exhaustion";
        buffs[7] = "cumulation";
        buffs[8] = "bloodlist";
        buffs[9] = "fury";
        buffs[10] = "counterattack";
        buffs[11] = "zeroing";
        buffs[12] = "preparation";
        buffs[13] = "oxidation";
        buffs[14] = "frostarmor";
        buffs[15] = "staticfield";
        buffs[16] = "eartharmor";
        buffs[17] = "cycloneshield";
        buffs[18] = "warmth";
        buffs[19] = "lightingorb";
        buffs[20] = "sarcophagus";
        buffs[21] = "healing";
        buffs[22] = "blessing";
        buffs[23] = "sanctuary";
        buffs[24] = "immortality";
        buffs[25] = "eaglesight";
        buffs[26] = "nightvision";
        buffs[27] = "fov";
        buffs[28] = "sixthsence";
        buffs[29] = "silentstep";
        buffs[30] = "invisibility";
        buffs[31] = "deadblind";
        buffs[32] = "transmute";
        buffs[33] = "reflex";
        buffs[34] = "spiritchain";
        buffs[35] = "ignoring";
        buffs[36] = "despair";
        buffs[37] = "insanefury";
        buffs[38] = "shadowdancer";
        buffs[39] = "concentration";
        buffs[40] = "revenge";
        buffs[41] = "defiance";
        buffs[42] = "battlecry";
        buffs[43] = "warning";
        buffs[44] = "berserker";
        buffs[45] = "unstoppable";
        buffs[46] = "slowmissiles";
        buffs[47] = "heavenfire";
        buffs[48] = "decrepify";
        buffs[49] = "anathem";
        buffs[50] = "bloodcall";
        buffs[51] = "ironmaiden";
        buffs[52] = "paralysis";
        buffs[53] = "dementia";
        buffs[54] = "innersight";
        buffs[55] = "blinding";
        buffs[56] = "discord";
        buffs[57] = "lethargy";
        buffs[58] = "hypnosis";
        buffs[59] = "blackmark";
        buffs[60] = "taunt";
        buffs[61] = "terror";
        buffs[62] = "silence";
        buffs[63] = "tired";
        buffs[64] = "agony";
        buffs[65] = "vandalism";
        buffs[66] = "victim";
        buffs[67] = "shockweb";
        buffs[68] = "";
        buffs[69] = "";
        buffs[70] = "";
        buffs[71] = "";
        buffs[72] = "";

            //UNKNOWN




            //skills_name[0] = "Base attack";
            // skills_name[0] = "Base attack";
            //skills_name[0] = "Base attack";
            //skills_name[0] = "Base attack";
            //skills_name[0] = "Base attack";
            // skills_name[0] = "Base attack";


        }


    }
}
