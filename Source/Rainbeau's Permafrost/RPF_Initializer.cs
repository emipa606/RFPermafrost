using System.Linq;
using RimWorld;
using Verse;

namespace RPF_Code;

[StaticConstructorOnStartup]
internal static class RPF_Initializer
{
    static RPF_Initializer()
    {
        foreach (var plant in DefDatabase<ThingDef>.AllDefsListForReading.Select(def => def.plant))
        {
            if (plant?.wildBiomes == null)
            {
                continue;
            }

            for (var j = 0; j < plant.wildBiomes.Count; j++)
            {
                if (plant.wildBiomes[j].biome.defName != "Tundra")
                {
                    continue;
                }

                var newRecord = new PlantBiomeRecord
                {
                    biome = BiomeDef.Named("Permafrost"),
                    commonality = plant.wildBiomes[j].commonality / 2
                };
                plant.wildBiomes.Add(newRecord);
            }
        }

        foreach (var wildBiomes in DefDatabase<PawnKindDef>.AllDefs.Select(def => def.RaceProps.wildBiomes))
        {
            if (wildBiomes == null)
            {
                continue;
            }

            for (var j = 0; j < wildBiomes.Count; j++)
            {
                if (wildBiomes[j].biome.defName != "Tundra")
                {
                    continue;
                }

                var newRecord = new AnimalBiomeRecord
                {
                    biome = BiomeDef.Named("Permafrost"),
                    commonality = wildBiomes[j].commonality / 2
                };
                wildBiomes.Add(newRecord);
            }
        }
    }
}