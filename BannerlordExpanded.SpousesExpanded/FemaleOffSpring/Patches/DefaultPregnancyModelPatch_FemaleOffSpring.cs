using BannerlordExpanded.SpousesExpanded.Settings;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Library;

namespace BannerlordExpanded.SpousesExpanded.FemaleOffSpring.Patches
{
    [HarmonyPatchCategory("FemaleOffSpring")]
    [HarmonyPatch(typeof(DefaultPregnancyModel), "get_DeliveringFemaleOffspringProbability")]
    public static class DefaultPregnancyModelPatch_FemaleOffSpring
    {
        static bool firstPatchPatched = false;
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (!firstPatchPatched)
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
                        if (value == 0.51f)
                        {
                            instruction.operand = MCMSettings.Instance.FemaleOffSpringChance;
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
                    InformationManager.DisplayMessage(new InformationMessage("[BE - Spouses Expanded] ERROR: Failed to patch Female OffSpring!\nPossible mod conflict or this mod is outdated."));
                }
                else
                    firstPatchPatched = true;
            }
        }



    }
}
