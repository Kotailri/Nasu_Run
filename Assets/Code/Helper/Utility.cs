using UnityEngine;
using System;
using System.Collections;

public static class Utility
{
    public static void PrintCol(string print, string hexkey)
    {
        Debug.Log("<color=#" + hexkey + ">" + print + "</color>");
    }

    public static void PrintCol(string print, Color color)
    {
        PrintCol(print, ColorUtility.ToHtmlStringRGB(color));
    }

    public static void PrintWarn(string print)
    {
        PrintCol(print, "FFA500");
    }

    public static void PrintErr(string print)
    {
        PrintCol(print, "FF0000");
        Time.timeScale = 0;
    }

    public static void InvokeLambda(Action action, float time)
    {
        MonoBehaviour script = new GameObject().AddComponent<Invoker>();
        script.StartCoroutine(script.GetComponent<Invoker>().InvokeCoroutine(action, time));
    }

    private class Invoker : MonoBehaviour
    {
        public IEnumerator InvokeCoroutine(Action action, float time)
        {
            yield return new WaitForSeconds(time);
            action.Invoke();
            Destroy(gameObject);
        }
    }
}