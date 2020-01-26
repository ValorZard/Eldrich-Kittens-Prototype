using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer buttonSpriteRenderer;
    public Sprite defaultSprite;
    public Sprite pressedSprite;
    private bool currentlyPressed;
    public bool didNotMiss;
    private float multplier;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        buttonSpriteRenderer = GetComponent<SpriteRenderer>();
        currentlyPressed = false;
        multplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Design Philosophy: Make everything as functions, and make sure the code is reusable.
         * We want to work as little as possible.
         */
        if (Input.GetKeyDown(keyToPress))
        {
            buttonSpriteRenderer.sprite = pressedSprite;
            currentlyPressed = true;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            buttonSpriteRenderer.sprite = defaultSprite;
            currentlyPressed = false;
        }
    }

    private void OnTriggerStay2D(Collider2D noteCollider)
    {
        //print("hi");
        if (currentlyPressed)
        {
            NoteHit(noteCollider.gameObject);
        }
    }

    private void NoteHit(GameObject note)
    {
        /*
         * Function called whenever the note gets hit. Later one, we want this to play an animation of some sort.
         */
        print(note);
        //GameObject.Find("EventSystem").GetComponent<RhythmData>().SetScore(note.GetComponent<NoteScript>().GetNoteScore());
        gameObject.transform.parent.gameObject.GetComponent<PlayerData>().AddScore(note.GetComponent<NoteScript>().ScoreCalculator(transform));
        Destroy(note);
    }
}
