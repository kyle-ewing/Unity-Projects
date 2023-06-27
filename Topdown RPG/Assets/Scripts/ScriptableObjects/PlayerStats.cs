using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject {
    [SerializeField]
    private int hp = 100;
    [SerializeField]
    private float stamina = 100;
    [SerializeField]
    private int level;
    [SerializeField]
    private int xp;

    private float maxStamina = 100;
    private float minStamina = 0f;
    private bool sprinting = false;

    public int Hp {
        get => hp;
        set => hp = value;
    }

    public float Stamina {
        get => stamina;
        set {
            stamina = value;
            EventManager.FireEvent(new CurrentStaminaEvent(){CurrentStamina = stamina});
        } 
    }

    public int Level {
        get => level;
        set => level = value;
    }

    public int Xp {
        get => xp;
        set => xp = value;
    }
    
    public bool Sprinting {
        get => sprinting;
        set => sprinting = value;
    }
    
    public float MaxStamina {
        get => maxStamina;
        set => maxStamina = value;
    }

    public float MinStamina {
        get => minStamina;
        set => minStamina = value;
    }
}
