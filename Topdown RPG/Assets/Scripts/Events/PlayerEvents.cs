using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents {

    public static UnityAction<Transform> onPlayerSpawned;
    public static UnityAction onPlayerDespawned;
    public static UnityAction<Transform> onHealthChange;
    public static UnityAction onStaminaChange;
}
