using BannerlordExpanded.SpousesExpanded.Settings;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Library;

namespace BannerlordExpanded.SpousesExpanded.StillBirth.Patches
{
    [HarmonyPatchCategory("StillBirth")]
    [HarmonyPatch(typeof(DefaultPregnancyModel), "get_StillbirthProbability")]
    public static class DefaultPregnancyModelPatch_StillBirth
    {
        static bool firstPatchPatched = false;
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (firstPatchPatched)
            {
                foreach (var instruction in instructions)
                    yield return instruction;
            }
            else
            {
                bool patch1 = false;
                foreach (var instruction in instructions)
                {
                    if (instruction.opcode == OpCodes.Ldc_R4)
                    {
                        float value = (float)instruction.operand;
                        if (value == 0.01f)
                        {
                            instruction.operand = MCMSettings.Instance.StillBirthChance;
                            yield return instruction;
                            patch1 = true;
                            //InformationManager.DisplayMessage(new InformationMessage("Patched magic number"));
                        }
                        else yield return instruction;
                    }
                    else
                        yield return instruction;
                }

                if (!patch1)
                {
                    InformationManager.DisplayMessage(new InformationMessage("[BE - Spouses Expanded] ERROR: Failed to patch Still Birth!\nPossible mod conflict or this mod is outdated."));
                }
                else
                    firstPatchPatched = true;
            }
        }



    }
}
