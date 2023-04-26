using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BeamSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject beam;

    public float activationDistance;
    private bool beamSpawnerActive = false;

    public float comboActivationDistance;
    private bool comboSpawnerActive = false;

    private float beamTimerMin = 1f;
    private float beamTimerCurrent = 8f;

    private float comboTimerMin = 5f;
    private float comboTimerCurrent = 8f;

    private List<IEnumerator> comboList = new List<IEnumerator>();

    private void Start()
    {
        comboList.Add(RightLeftVertCombo());
        comboList.Add(LeftRightVertCombo());
        comboList.Add(TopBotHoriCombo());
        comboList.Add(BotTopHoriCombo());
    }

    public void SpawnBeam()
    {
        GameObject beam_obj = Instantiate(beam, player.transform.position, Quaternion.identity);
        float angle = Random.Range(0f, 360f);
        beam_obj.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void SpawnCombo()
    {
        if (Random.Range(0,2) == 0)
        {
            StartCoroutine(comboList[Random.Range(0, comboList.Count)]);
        }
    }

    private IEnumerator RightLeftVertCombo()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject beam_obj = Instantiate(beam, new Vector2(6 - (i*4), 0), Quaternion.identity);
            beam_obj.transform.rotation = Quaternion.Euler(0, 0, 90);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator LeftRightVertCombo()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject beam_obj = Instantiate(beam, new Vector2(-6 + (i * 4), 0), Quaternion.identity);
            beam_obj.transform.rotation = Quaternion.Euler(0, 0, 90);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator TopBotHoriCombo()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject beam_obj = Instantiate(beam, new Vector2(0, 3.5f - (i * 4f)), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator BotTopHoriCombo()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject beam_obj = Instantiate(beam, new Vector2(0, -3.5f + (i * 4f)), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Update()
    {
        if (!beamSpawnerActive && Managers.distanceManager.GetDistance() >= activationDistance)
        {
            beamSpawnerActive = true;
            StartCoroutine(BeamTimer());
            InvokeRepeating(nameof(DecreaseBeamTime), 1.0f, 8.0f);
            InvokeRepeating(nameof(DecreaseComboTime), 1.0f, 15.0f);
        }

        if (!comboSpawnerActive && Managers.distanceManager.GetDistance() >= comboActivationDistance)
        {
            comboSpawnerActive = true;
            StartCoroutine(ComboTimer());
        }
    }


    private void DecreaseBeamTime()
    {
        if (beamTimerCurrent > beamTimerMin)
        {
            beamTimerCurrent -= 0.5f;
        }
    }
    private void DecreaseComboTime()
    {
        if (comboTimerCurrent > comboTimerMin)
        {
            comboTimerCurrent -= 0.7f;
        }
    }

    private IEnumerator ComboTimer()
    {
        yield return new WaitForSeconds(comboTimerCurrent);
        SpawnCombo();
        StartCoroutine(ComboTimer());
    }

    private IEnumerator BeamTimer()
    {
        yield return new WaitForSeconds(beamTimerCurrent);
        
        SpawnBeam();
        StartCoroutine(BeamTimer());
    }
}
