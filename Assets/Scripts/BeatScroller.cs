using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    /*
     * TODO: Change this code. We want to make sure that each player has a copy of this class.
     * Spawns notes for the player this script is binded to
     * Should only move the player's notes, not all of the notes in the scene
     * The beat rate and unit of movement should be consistent for all players, so that information
     * should come from a shared class, maybe called MusicData or something.
     * We might still want to keep this classes unique beat and movement data, 
     * in case for whatever reason we want this player's beat to move faster or slower than the other 
     * player.
     */
    public int beatRate; //beats per minute
    private List<GameObject> noteList;
    private float timeSinceLastBeatHit; //this is for spawning notes at a consistent rate
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.noteList = GetNotesInScene();
        this.timeSinceLastBeatHit = 0;
    }

    private List<GameObject> GetNotesInScene()
    {
        /*
         * Since the amount of notes in the scene will change every frame, we want to make sure to call this function so that we keep these notes up to date
         * We could maybe later turn the array into a list so that its much easier to add and remove notes from the list and so 
         * we don't have to call this function every time.
         * Actually, since we want this class to also spawn notes, maybe its better to merge this with the start function
         */
        GameObject[] noteArray = GameObject.FindGameObjectsWithTag("Notes");
        List<GameObject> list = new List<GameObject>(noteArray);
        return list;
    }

    private float GetBeatsPerSec()
    {
        return (float) (beatRate / 60);
    }

    private void SpawnNotes()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
    }

    private void MoveNotes(List<GameObject> noteList)
    {
        /*
         * Moves the notes down at the speed of beats per second.
         */
        foreach(GameObject note in noteList)
        {
            note.transform.position = note.transform.position + new Vector3(0, - (this.GetBeatsPerSec() * Time.deltaTime));
        }
        timeSinceLastBeatHit = 0;
    }

    // Update is called once per frame
    void Update() 
    {
        noteList = GetNotesInScene();
        MoveNotes(this.noteList);
        timeSinceLastBeatHit += Time.deltaTime;
    }


    
}
