using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : Manager
{
    [System.Serializable]
    public class RoomSection
    {
        public string name;
        public List<GameObject> Rooms;
        public bool randomize;
        public void ShuffleRoomList()
        {
            if (randomize)
                Rooms = Rooms.OrderBy(x => Random.value).ToList();
        }
    }

    public List<RoomSection> RoomSections;

    private int currentRoomIndex = 0;
    private GameObject currentRoom;

    private int currentRoomSectionIndex = 0;
    private RoomSection currentRoomSection;

    public Transform roomSpawnLocation;

    [Space(15.0f)]
    public float roomSpeedIncrement;
    public float roomSpeedIncrementTimer;

    protected override void SetManager()
    {
        Managers.roomManager = this;
    }

    private void Start()
    {
        //currentRoomSection = RoomSections[currentRoomSectionIndex];
        //currentRoomSection.ShuffleRoomList();
        //currentRoom = currentRoomSection.Rooms[currentRoomIndex];
        //Instantiate(currentRoom, roomSpawnLocation.position, Quaternion.identity);
        StartCoroutine(IncrementSpeed());
    }

    private IEnumerator IncrementSpeed()
    {
        yield return new WaitForSeconds(roomSpeedIncrementTimer);
        Global.RoomSpeed += roomSpeedIncrement;
        StartCoroutine(IncrementSpeed());
    }

    public void CreateNextRoom()
    {
        if (currentRoomIndex + 1 >= currentRoomSection.Rooms.Count)
        {
            if (currentRoomSectionIndex + 1 >= RoomSections.Count)
            {
                currentRoomSectionIndex = 0;
            }
            else
            {
                currentRoomSectionIndex++;
            }

            currentRoomSection = RoomSections[currentRoomSectionIndex];

            currentRoomIndex = 0;
            currentRoomSection.ShuffleRoomList();
            currentRoom = currentRoomSection.Rooms[currentRoomIndex];
            
        }
        else
        {
            currentRoomIndex++;
            currentRoom = currentRoomSection.Rooms[currentRoomIndex];
        }
    }
}
