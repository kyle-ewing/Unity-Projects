using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIManager", menuName = "UIManager")]
public class UIManager : ScriptableObject {
    
    public GameState gameState { get; set; }

    [SerializeField] 
    private GameObject hudPrefab;

    private void OnEnable() {
        UIEvents.loadHUD += AddUI;
    }

    private void AddUI() {
        Instantiate(hudPrefab, hudPrefab.transform.position, Quaternion.identity);
    }

    private void OnDisable() {
        UIEvents.loadHUD -= AddUI;
    }
}
