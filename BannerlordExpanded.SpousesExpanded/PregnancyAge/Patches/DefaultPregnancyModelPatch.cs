using BannerlordExpanded.SpousesExpanded.Settings;
using HarmonyLib;
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
        [HarmonyPatch(typeof(DefaultPregnancyModel), "GetDailyChanceOfPregnancyForHero")]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
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
        }

        [HarmonyPatch(typeof(DefaultPregnancyModel), "IsHeroAgeSuitableForPregnancy")]
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler2(IEnumerable<CodeInstruction> instructions)
        {
            InformationManager.DisplayMessage(new InformationMessage("[BE - Spouses Expanded] Patching in progress..."));
            bool patch1 = false, patch2 = false;
            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4)
                {
                    float value = (float)instruction.operand;
                    if (value == 45f)
                    {
                        instruction.operand = maxAge;
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
        }

        static float GetMagicNumber()
        {
            return (maxAge - minAge) * 0.04f + 0.12f;
        }

        static float maxAge { get { return MCMSettings.Instance.PregnancyAgeMax; } }
        static float minAge { get { return MCMSettings.Instance.PregnancyAgeMin; } }
    }
}
