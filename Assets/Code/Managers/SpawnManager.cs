using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Manager
{
    private Vector2 spawnTop;
    private Vector2 spawnBot;

    protected override void SetManager()
    {
        Managers.spawnManager = this;
    }

    private void Start()
    {
        spawnTop = Global.boundsRefManager.GetBoundsRefTop();
        spawnBot = Global.boundsRefManager.GetBoundsRefBot();
    }

    public void InstantiateRoomObject(GameObject g)
    {
        GameObject obj = Instantiate(g, new Vector3(-100, -100, 0), Quaternion.identity);
        if (obj.TryGetComponent(out SpriteRenderer sr))
        {
            Vector3 spriteBounds = sr.sprite.bounds.size;
            obj.transform.position = new Vector2(spawnTop.x - spriteBounds.x / 2, 
                Random.Range(spawnBot.y + spriteBounds.y / 2, spawnTop.y - spriteBounds.y / 2));
        }
        else if (obj.TryGetComponent(out BoxCollider2D bc))
        {
            Vector3 spriteBounds = bc.bounds.size;
            obj.transform.position = new Vector2(spawnTop.x - spriteBounds.x / 2, 
                Random.Range(spawnBot.y + spriteBounds.y / 2, spawnTop.y - spriteBounds.y / 2));

        }
        else
        {
            Utility.PrintWarn(g.name + " does not have a spriterenderer or hitbox and is trying to be instantiated!");
            Destroy(obj);
        }
        
    }
}
