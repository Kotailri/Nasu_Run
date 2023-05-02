using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollComboBonus : MonoBehaviour
{
    private int combo = 0;
    private bool isRolling = false;

    public void AddRollKill()
    {
        if (isRolling)
            combo++;
    }

    private void GiveComboReward()
    {
        if (combo <= 1)
            return;

        Managers.audioManager.PlaySound("combo");

        for (int i = 2; i < combo; i++)
        {
            GetComponent<SpawnClefBurst>().ClefBurst();
        }

        string comboText = "Combo " + combo + "x!";
        Managers.textSpawnerManager.SpawnTextObject(comboText, transform.position, false, 1);
    }

    public void StartRollCombo()
    {
        isRolling = true;
    }

    public void EndRollCombo()
    {
        GiveComboReward();
        isRolling = false;
        combo = 0;
    }
}
