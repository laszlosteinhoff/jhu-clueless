using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Card
{
    public Location location;
    public Vector3 locationOffset; // So they won't overlap when in the same room

    public override void Start()
    {
        base.Start();

        // Move the character to their starting location at the beginning of the game
        Move(location);
    }

    public void Move(Location location)
    {
        this.location = location;
        transform.position = location.transform.position + locationOffset;
    }
}
