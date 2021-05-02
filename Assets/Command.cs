using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    KeyInput key;
    public abstract void Behave(Player player);
    public void Act(Player player)
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

public class One : Command
{
    Vector3 set;
    public One()
    {
        set = new Vector3(131f, 80f, 0f);
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("1번 행동", set);
    }
}

public class Two : Command
{
    Vector3 set;
    public Two()
    {
        set = new Vector3(150f, 70f, 0f);
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("2번 행동", set);
    }
}

public class Three : Command
{
    Vector3 set;
    public Three()
    {
        set = new Vector3(71f, 100f, 0f);
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("3번 행동", set);
    }
}

public class Four : Command
{
    Vector3 set;
    public Four()
    {
        set = new Vector3(100f, 150f, 0f);
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("4번 행동", set);
    }
}

public class Five : Command
{
    Vector3 set;
    public Five()
    {
        set = new Vector3(131f, 90f, 0f);
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("5번 행동", set);
    }
}

public class Six : Command
{
    Vector3 set;
    public Six()
    {
        set = new Vector3(131f, 80f, 0f);
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("6번 행동", set);
        set.y += (150f - set.y)*0.1f;
    }
}

public class Seven : Command
{
    Vector3 set;
    bool go;
    public Seven()
    {
        set = new Vector3(131f, 50f, 0f);
        go = true;
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("7번 행동", set);
        if(set.x > 150f) {
            go = false;
        } else if(set.x < 130f) { 
            go = true;
        }
        if (go) { 
            set.x += 10f;
        } else {
            set.x -= 10f;
        }
    }
}

public class Eight : Command
{
    Vector3 set;
    public Eight()
    {
        set = new Vector3(201f, 60f, 0f);
    }
    public override void Behave(Player player)
    {
        player.bubble.Show("8번 행동", set);
    }
}