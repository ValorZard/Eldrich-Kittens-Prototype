using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private float noteScore; //the amount of points this note is worth
    public string ownedBy; //which player the note corresponds to.
    public string currentButton; //which button the note corresponds to. (Equal to the name of the button for ease of access)s

    // Start is called before the first frame update
    void Start()
    {
        noteScore = 10;
    }

    public float GetNoteScore()
    {
        return noteScore;
    }

    public void SetNoteScore(float noteScore)
    {
        this.noteScore = noteScore;
    }

    public float ScoreCalculator(Transform button)
    {
        /*
         * Calculates score by first calculating distance between the note and the
         * bar, and then using funky math stuff to return the score the player 
         * deserves. Later on we want to have little pop offs showing how well
         * the player did, like "Good!", "Great!", "Awesome!" etc.
         */
        float distance = transform.position.y - button.position.y;
        return (float) Mathf.Ceil(Mathf.Abs(noteScore / distance) + 0.001f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
