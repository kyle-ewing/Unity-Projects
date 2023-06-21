using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject {
    [SerializeField]
    private int hp = 100;
    [SerializeField]
    private int stamina = 100;
    [SerializeField]
    private int level;
    [SerializeField]
    private int xp;

    public int Hp {
        get => hp;
        set => hp = value;
    }

    public int Stamina {
        get => stamina;
        set => stamina = value;
    }

    public int Level {
        get => level;
        set => level = value;
    }

    public int Xp {
        get => xp;
        set => xp = value;
    }
}
