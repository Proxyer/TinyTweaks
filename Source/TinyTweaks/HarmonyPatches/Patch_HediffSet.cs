﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;

namespace TinyTweaks
{

    public static class Patch_HediffSet
    {

        [HarmonyPatch(typeof(HediffSet), "CalculateBleedRate")]
        public static class CalculateBleedRate
        {

            public static void Postfix(HediffSet __instance, ref float __result)
            {
                // Scale bleeding rate based on blood pumping
                if (TinyTweaksSettings.bloodPumpingAffectsBleeding)
                    __result *= __instance.pawn.health.capacities.GetLevel(PawnCapacityDefOf.BloodPumping);
            }

        }

    }

}
