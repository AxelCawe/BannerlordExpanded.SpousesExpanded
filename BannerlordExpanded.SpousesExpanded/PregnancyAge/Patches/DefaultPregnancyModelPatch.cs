using BannerlordExpanded.SpousesExpanded.Settings;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Library;

namespace BannerlordExpanded.SpousesExpanded.PregnancyAge.Patches
{
    [HarmonyPatchCategory("PregnancyAge")]
    [HarmonyPatch]
    public static class DefaultPregnancyModelPatch
    {
        static bool firstPatchPatched = false;
        static bool secondPatchPatched = false;

        [HarmonyPatch(typeof(DefaultPregnancyModel), "GetDailyChanceOfPregnancyForHero")]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (!firstPatchPatched)
            {
                foreach (var instruction in instructions)
                    yield return instruction;
            }
            else
            {
                bool patch1 = false, patch2 = false;
                foreach (var instruction in instructions)
                {
                    if (instruction.opcode == OpCodes.Ldc_R4)
                    {
                        float value = (float)instruction.operand;
                        if (value == 1.2f)
                        {
                            instruction.operand = GetMagicNumber();
                            yield return instruction;
                            patch1 = true;
                            //InformationManager.DisplayMessage(new InformationMessage("Patched magic number"));
                        }
                        else if (value == 18f)
                        {
                            instruction.operand = minAge;
                            yield return instruction;
                            patch2 = true;
                            //InformationManager.DisplayMessage(new InformationMessage("Patched min age;"));
                        }
                        else yield return instruction;
                    }
                    else
                        yield return instruction;
                }

                if (!patch1 || !patch2)
                {
                    InformationManager.DisplayMessage(new InformationMessage("[BE - Spouses Expanded] ERROR: Failed to patch Pregnancy Ages!\nPossible mod conflict or this mod is outdated."));
                }
                else
                    firstPatchPatched = true;
            }
        }

        [HarmonyPatch(typeof(DefaultPregnancyModel), "IsHeroAgeSuitableForPregnancy")]
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler2(IEnumerable<CodeInstruction> instructions)
        {
            if (!secondPatchPatched)
            {
                foreach (var instruction in instructions)
                    yield return instruction;
            }
            else
            {


                bool patch1 = false, patch2 = false;
                foreach (var instruction in instructions)
                {
                    if (instruction.opcode == OpCodes.Ldc_R4)
                    {
                        float value = (float)instruction.operand;
                        if (EqualFloat(value, 45f))
                        {
                            instruction.operand = maxAge;
                            yield return instruction;
                            patch1 = true;
                            //InformationManager.DisplayMessage(new InformationMessage("Patched magic number"));
                        }
                        else if (EqualFloat(value, 18f))
                        {
                            instruction.operand = minAge;
                            yield return instruction;
                            patch2 = true;
                            //InformationManager.DisplayMessage(new InformationMessage("Patched min age;"));
                        }
                        else yield return instruction;
                    }
                    else
                        yield return instruction;
                }
                if (!patch1 || !patch2)
                {
                    InformationManager.DisplayMessage(new InformationMessage("[BE - Spouses Expanded] ERROR: Failed to patch Pregnancy Ages!\nPossible mod conflict or this mod is outdated."));
                }
                else
                    secondPatchPatched = true;
            }
        }

        static float GetMagicNumber()
        {
            return (maxAge - minAge) * 0.04f + 0.12f;
        }

        static float maxAge { get { return MCMSettings.Instance.PregnancyAgeMax; } }
        static float minAge { get { return MCMSettings.Instance.PregnancyAgeMin; } }

        static bool EqualFloat(float a, float b)
        {
            //if (a == b) return true;

            //return Mathf.Abs(a - b) < float.Epsilon;
            return NearlyEqual(a, b, 0.01f);
        }

        public static bool NearlyEqual(float a, float b, float epsilon)
        {
            const float MinNormal = 2.2250738585072014E-308f;
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);

            if (a.Equals(b))
            { // shortcut, handles infinities
                return true;
            }
            else if (a == 0 || b == 0 || absA + absB < MinNormal)
            {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < (epsilon * MinNormal);
            }
            else
            { // use relative error
                return diff / (absA + absB) < epsilon;
            }
        }
    }
}
