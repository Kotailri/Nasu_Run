using System.Collections;
using TMPro;
using UnityEngine;

public class SpawnText : MonoBehaviour
{
    private void Start()
    {
        Managers.textSpawnerManager = this;
    }

    public void SpawnTextObject(string text, Vector3 spawnPosition, bool followPlayer, float time)
    {

        GameObject textPrefabCanvas = Instantiate(Resources.Load<GameObject>("TextObject"), spawnPosition, Quaternion.identity);
        GameObject textPrefab = textPrefabCanvas.transform.GetChild(0).gameObject;

        if (followPlayer)
        {
            FollowPlayer fp = textPrefabCanvas.AddComponent<FollowPlayer>();
            fp.offset = new Vector3(0.2f, 1.25f, 0);
        }

        TextMeshProUGUI textObj = textPrefab.GetComponent<TextMeshProUGUI>();
        textObj.text = text;

        Destroy(textPrefabCanvas, time);
    }
}
