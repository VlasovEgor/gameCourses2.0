using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static IGameContext instance;

    static ServiceLocator()
    {
        instance = new GameContext();
    }

    public static void SetContext(IGameContext context)
    {
        instance = context;
    }
}
