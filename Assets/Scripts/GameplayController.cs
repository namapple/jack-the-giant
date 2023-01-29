using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    private Dictionary<PlayerActions, Action> playerActionHandlers;
    private Dictionary<string, string> heroInfo;

    public void ReturnToMenu() => SceneManager.LoadScene("MainMenu");

    private void Awake()
    {
        playerActionHandlers = new Dictionary<PlayerActions, Action>()
        {
            {PlayerActions.JUMP, HandleJump},
            {PlayerActions.ATTACK, HandleAttack}
        };

        heroInfo = new Dictionary<string, string>()
        {
            {"Abandon", "Support"},
            {"Sniper", "Carry"},
        };

        Debug.Log(heroInfo["Sniper"]);
    }

    private void HandleJump()
    {
        Debug.Log("JUMP");
    }

    private void HandleAttack()
    {
        Debug.Log("ATTACK");
    }

    public void OnNotify(PlayerActions playerAction)
    {
        if (playerActionHandlers.ContainsKey(playerAction))
        {
            playerActionHandlers[playerAction]();
        }
    }
}

public enum PlayerActions
{
    JUMP,
    ATTACK
} 
