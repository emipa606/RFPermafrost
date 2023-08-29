using RimWorld;
using Verse;

namespace RPF_Code;

[StaticConstructorOnStartup]
internal static class RPF_Initializer
{
    static RPF_Initializer()
    {
        foreach (var current in DefDatabase<ThingDef>.AllDefsListForReading)
        {
            if (current.plant?.wildBiomes == null)
            {
                continue;
            }

            for (var j = 0; j < current.plant.wildBiomes.Count; j++)
            {
                if (current.plant.wildBiomes[j].biome.defName != "Tundra")
                {
                    continue;
                }

                var newRecord = new PlantBiomeRecord
                {
                    biome = BiomeDef.Named("Permafrost"),
                    commonality = current.plant.wildBiomes[j].commonality / 2
                };
                current.plant.wildBiomes.Add(newRecord);
            }
        }

        foreach (var current in DefDatabase<PawnKindDef>.AllDefs)
        {
            if (current.RaceProps.wildBiomes == null)
            {
                continue;
            }

            for (var j = 0; j < current.RaceProps.wildBiomes.Count; j++)
            {
                if (current.RaceProps.wildBiomes[j].biome.defName != "Tundra")
                {
                    continue;
                }

                var newRecord = new AnimalBiomeRecord
                {
                    biome = BiomeDef.Named("Permafrost"),
                    commonality = current.RaceProps.wildBiomes[j].commonality / 2
                };
                current.RaceProps.wildBiomes.Add(newRecord);
            }
        }
    }
}