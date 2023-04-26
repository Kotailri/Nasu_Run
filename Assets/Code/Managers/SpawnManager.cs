using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Manager
{
    public Transform spawnTop;
    public Transform spawnBot;

    protected override void SetManager()
    {
        Managers.spawnManager = this;
    }

    public void InstantiateRoomObject(GameObject g)
    {
        GameObject obj = Instantiate(g, new Vector3(-100, -100, 0), Quaternion.identity);
        if (obj.TryGetComponent(out SpriteRenderer sr))
        {
            Vector3 spriteBounds = sr.sprite.bounds.size;
            obj.transform.position = new Vector2(spawnTop.position.x - spriteBounds.x / 2, Random.Range(spawnBot.position.y + spriteBounds.y / 2, spawnTop.position.y - spriteBounds.y / 2));
        }
        else if (obj.TryGetComponent(out BoxCollider2D bc))
        {
            Vector3 spriteBounds = bc.bounds.size;
            obj.transform.position = new Vector2(spawnTop.position.x - spriteBounds.x / 2, Random.Range(spawnBot.position.y + spriteBounds.y / 2, spawnTop.position.y - spriteBounds.y / 2));

        }
        else
        {
            Utility.PrintWarn(g.name + " does not have a spriterenderer or hitbox and is trying to be instantiated!");
            Destroy(obj);
        }
        
    }
}
