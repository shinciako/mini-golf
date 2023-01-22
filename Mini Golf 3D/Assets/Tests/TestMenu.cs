using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestMenu
{
    [Test]
    public void ActiveOnEscape_ObjectSetActive()
    {
      GameObject testObject = new GameObject();
      MenuPause menuPauseScript = testObject.AddComponent<MenuPause>();
      menuPauseScript.menu = testObject;
      menuPauseScript.stopMenu();
      GameObject testedObject = menuPauseScript.menu;
      Assert.IsTrue(testedObject.activeSelf);
    }

    [Test]
    public void DeactiveOnEscape_ObjectSetInactive()
    {
      GameObject testObject = new GameObject();
      MenuPause menuPauseScript = testObject.AddComponent<MenuPause>();
      menuPauseScript.menu = new GameObject();
      menuPauseScript.resume();
      GameObject testedObject = menuPauseScript.menu;
      Assert.IsFalse(testedObject.activeSelf);
    }
}
