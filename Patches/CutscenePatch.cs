using System;
using System.Reflection;
using HarmonyLib;
using Kuro;
using OrcMassage.Manga;
using Pineapler.Utils;
using UnityEngine;

namespace OrcSkip.Patches;

[HarmonyPatch]
public class CutscenePatch {
    
    // ===========
    // INTRO MOVIE
    // ===========
    [HarmonyPostfix]
    [HarmonyPatch(typeof(LogoPage), "Start")]
    private static void SkipLogoPage(LogoPage __instance) {
        if (!Plugin.Config.SkipIntro.Value) return;
        
        Log.Info("Skipping intro movie");
        __instance.ToGameScene();
    }
    
    
    // ================
    // PERFECT CUTSCENE
    // ================
    [HarmonyPrefix]
    [HarmonyPatch(typeof(HokutoPanelUI), "GetSelectedHokuto")]
    private static bool SkipPerfectCutscene(HokutoPanelUI __instance, ref ItemData __result) {
        if (!Plugin.Config.SkipPerfect.Value) return true;
        
        // The actual animation happens in CharacterReactionUI.cs, but fudging this value causes the cutscene to not play.
        // This method is only used for the cutscene currently, so it should be safe.
        // TODO: if hokutos get extra functionality, revisit this approach.
        
        Log.Info("Skipping perfect cutscene");
        __result = null;
        return false;
    }
    
    // ==============
    // STORY CUTSCENE
    // ==============
    [HarmonyPostfix]
    [HarmonyPatch(typeof(MangaSystem), "StartManga", new[] {typeof(MangaPage), typeof(bool)})]
    private static void SkipStoryCutscene(MangaSystem __instance) {
        if (!Plugin.Config.SkipStory.Value) return;
        
        Log.Warning("Story cutscene skip not implemented!");
        
        // Log.Info("Skipping story cutscene");
        // __instance.StopManga(1f);
    }
}