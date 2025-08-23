using UnityEngine;

[CreateAssetMenu(fileName = "BaseAction", menuName = "Scriptable Objects/BaseAction")]
public class BaseAction : ScriptableObject
{
    public float    baseDifficultyModifier  = 0f;
    public float    staminaCost             = 0f;
    public float    healthCost              = 0f;
    public float    manaCost                = 0f;
    public float    timeUnitCost            = 0f;
    public float    baseMaxRange            = 0f;
    public float    baseMinRange            = 0f;
    public float    baseMinRadius           = 0f;
    public float    distanceTargetIsMoved   = 0f;
    public float    cooldown                = 0f;
    public bool     canOverexertStamina     = false;
    public bool     canOverexertHealth      = false;
    public bool     canOverexertMana        = false;
    public bool     canTargetAllies         = false;
    public bool     canTargetEnemies        = false;
    public bool     canTargetGround         = false;
    public bool     canTargetNonCharacters  = false;
    public bool     canTargetDeadCharacters = false;
    public bool     requiresLineOfSight     = false;
    public bool     canTriggerReactions     = false;
    public bool     canBeUsedAsReaction     = false;
    public bool     mustBeFacingTarget      = false;
    public bool     hasCooldown             = false;


    public Sprite userInterfaceIcon;

    public RequiredGearType requiredGearType;
    public enum RequiredGearType
    {
        OneFreeHand,
        TwoFreeHands,
        Shield,
        TwoHander,
        OneHander,
        Crossbow,
        Bow,
        Armatube
    }


    // What circumstances the action can be used in
    public ActionVariety actionVariety;
    public enum ActionVariety
    {
        Not_Applicable,
        Obtuse,
        Acute,
        Free
    }

    // Type of weapon being used
    public AttackType attackType;
    public enum AttackType
    {
        Not_Applicable,
        Ranged_Weapon,
        Melee_Weapon,
        AOE_Weapon,
        AOE_Spell,
        Ranged_Spell,
        Melee_Spell
    }
    // the primary skill to modify the action skill check
    public ResponsibleSkill responsibleSkill;
    public enum ResponsibleSkill
    {
        Not_Applicable,
        Melee,
        Wrestling,
        Ranged,
        Footwork,
        Theory,
        Method,
        Deduction,
        Manipulate,
        Perception,
        Dexterity,
        Reflexes,
        Intuition,
        Tenacity,
        Love,
        Doubt,
        Identity
    }
    // For if an action equires a second skill as a modifier
    public SecondarySkill secondarySkill;
    public enum SecondarySkill
    {
        Not_Applicable,
        Melee,
        Wrestling,
        Ranged,
        Footwork,
        Theory,
        Method,
        Deduction,
        Manipulate,
        Perception,
        Dexterity,
        Reflexes,
        Intuition,
        Tenacity,
        Love,
        Doubt,
        Identity
    }

    //For if we want to do skill checks using points invested in an entire category instead of a specific skill
    public CategorySkillCheck categorySkillCheck;
    public enum CategorySkillCheck
    {
        Not_Applicable,
        Combat,
        Brains,
        Senses,
        Soul
    }

    //Tags to describe the action so AI can use it for decision making
    // EG: "healing" "adjacent" "disengage"
    public string[] tagsForAI;

}
