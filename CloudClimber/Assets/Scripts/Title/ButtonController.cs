using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ButtonController: MonoBehaviour
{
    public static ButtonController Current { get; private set; }

    private static ButtonEventTrigger currentButton = null;

    public static void SetCurrent(ButtonEventTrigger button)
    {
        if (currentButton == button) return;

        if (currentButton != null)
        {
            currentButton.Deselect();
        }

        currentButton = button;
        button.Select();
    }

    public static void Move(Vector2 dir)
    {
        if (currentButton == null) return;

        var next = currentButton.GetDestination(dir);

        if (next == null) return;

        SetCurrent(next);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Vector2.up);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector2.down);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector2.left);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector2.right);
        }

        if (Input.GetButtonDown("Submit") && currentButton)
        {
            currentButton.Click();
        }
    }

    private void Awake()
    {
        if(Current != null)
        {
            Destroy(gameObject);
            return;
        }

        Current = this;
    }
}
