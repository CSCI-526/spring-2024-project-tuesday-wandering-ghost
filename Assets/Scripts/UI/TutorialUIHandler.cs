using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUIHandler : MonoBehaviour
{
    
    
    public GameObject movementTextUI;
    // public GameObject visionTextUI;
    public GameObject enterPossessionTextUI;
    public GameObject useAbilityTextUI;
    public GameObject inAbilityTextUI;
    public GameObject quitPossessionTextUI;
    public GameObject goalTextUI;

    private GameObject ghost;
    private GameObject rat;
    
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("Ghost");
        rat = GameObject.Find("Rat");
        // init hide all tutorial text
        HideAll();
    }

    // Update is called once per frame
    void Update()
    {
        //show relevant textUI depend on ghost position
        Vector2 ghostPosition = ghost.transform.position;

        if (IsWithin(ghostPosition, 0.54f, 6.5f) && ghostPosition.y < 0.7f)
        {
            MovementShow();
        }
        if (ghostPosition.y > 0.7f || IsWithin(ghostPosition, 6.5f, 11.2f))
        {
            HideAll();
        }
        if (rat.transform.childCount==0 && IsWithin(ghostPosition, 11.2f, 13.1f))
        {
            EnterPossessionShow();
        }
        if (rat.transform.childCount>0)
        {
            UseAbilityShow();
        }
        if (IsWithin(ghostPosition, 14.0f, 22.7f))
        {
            InAbilityShow();
        }
        if (IsWithin(ghostPosition, 22.7f,27.0f))
        {
            QuitPossessionShow();
        }
        if (IsWithin(ghostPosition, 27.0f, 28.5f))
        {
            GoalShow();
        }
    }
    
    private bool IsWithin(Vector2 position, float left, float right)
    {
        //checks if ghost position is within the range
        //map is straight line, only check left and right
        return position.x >= left && position.x <= right;
    }

    void HideAll()
    {
        movementTextUI.SetActive(false);
        // visionTextUI.SetActive(false);
        enterPossessionTextUI.SetActive(false);
        useAbilityTextUI.SetActive(false);
        inAbilityTextUI.SetActive(false);
        quitPossessionTextUI.SetActive(false);
        goalTextUI.SetActive(false);
    }
    void MovementShow()
    {
        movementTextUI.SetActive(true);
        // visionTextUI.SetActive(false);
        enterPossessionTextUI.SetActive(false);
        useAbilityTextUI.SetActive(false);
        inAbilityTextUI.SetActive(false);
        quitPossessionTextUI.SetActive(false);
        goalTextUI.SetActive(false);
    }
    void EnterPossessionShow()
    {
        movementTextUI.SetActive(false);
        // visionTextUI.SetActive(false);
        enterPossessionTextUI.SetActive(true);
        useAbilityTextUI.SetActive(false);
        inAbilityTextUI.SetActive(false);
        quitPossessionTextUI.SetActive(false);
        goalTextUI.SetActive(false);
    }
    void UseAbilityShow()
    {
        movementTextUI.SetActive(false);
        // visionTextUI.SetActive(false);
        enterPossessionTextUI.SetActive(false);
        useAbilityTextUI.SetActive(true);
        inAbilityTextUI.SetActive(false);
        quitPossessionTextUI.SetActive(false);
        goalTextUI.SetActive(false);
    }
    
    void InAbilityShow()
    {
        movementTextUI.SetActive(false);
        // visionTextUI.SetActive(false);
        enterPossessionTextUI.SetActive(false);
        useAbilityTextUI.SetActive(false);
        inAbilityTextUI.SetActive(true);
        quitPossessionTextUI.SetActive(false);
        goalTextUI.SetActive(false);
    }
    void QuitPossessionShow()
    {
        movementTextUI.SetActive(false);
        // visionTextUI.SetActive(false);
        enterPossessionTextUI.SetActive(false);
        useAbilityTextUI.SetActive(false);
        inAbilityTextUI.SetActive(false);
        quitPossessionTextUI.SetActive(true);
        goalTextUI.SetActive(false);
    }
    void GoalShow()
    {
        movementTextUI.SetActive(false);
        // visionTextUI.SetActive(false);
        enterPossessionTextUI.SetActive(false);
        useAbilityTextUI.SetActive(false);
        inAbilityTextUI.SetActive(false);
        quitPossessionTextUI.SetActive(false);
        goalTextUI.SetActive(true);
    }
}
