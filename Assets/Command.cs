using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    KeyInput key;
    protected abstract void Behave(Player player);
    public void Press(Player player)
    {
        if(key != null && key.Key()) {
            Behave(player);
        }
    }
    public void Set(KeyInput set)
    {
        key = set;
    }
}

public class Left : Command
{
    protected override void Behave(Player player)
    {
        player.body.AddForce(new Vector2(-2500f*Time.deltaTime, 0f));
    }
}

public class Right : Command
{
    protected override void Behave(Player player)
    {
        player.body.AddForce(new Vector2(2500f*Time.deltaTime, 0f));
    }
}

public class Up : Command
{
    protected override void Behave(Player player)
    {
        player.body.AddForce(new Vector2(0f, 2500f*Time.deltaTime));

    }
}

public class Down : Command
{
    protected override void Behave(Player player)
    {        
        player.body.AddForce(new Vector2(0f, -2500f*Time.deltaTime));
    }
}

public class Attack : Command
{
    public Attack () {
    }
    protected override void Behave(Player player)
    {
        player.shoot.FireUp();
    }
}