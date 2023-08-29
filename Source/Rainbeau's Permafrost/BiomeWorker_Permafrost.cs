using RimWorld;
using RimWorld.Planet;

namespace RPF_Code;

public class BiomeWorker_Permafrost : BiomeWorker
{
    public override float GetScore(Tile tile, int tileID)
    {
        if (tile.WaterCovered)
        {
            return -100f;
        }

        return tile.temperature is < -18f and > -24f ? 100f : 0f;
    }
}