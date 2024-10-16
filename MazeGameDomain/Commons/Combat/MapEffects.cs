using MazeGameDomain.Constants;
using MazeGameDomain.Enums;

namespace MazeGameDomain.Commons.Combat
{
    public static class MapEffects
    {
        public static decimal ComputeActualDamageBasedOnMapEffects(decimal initialDamage, int mapType, int attackType)
        {
            MapType actualMapType = (MapType)mapType;
            decimal actualDamage = initialDamage;

            switch(actualMapType)
            {
                case MapType.Tight:
                    actualDamage = ComputeActualDamageForTightMaps(initialDamage, mapType, attackType);
                    break;

                case MapType.Wide:
                    actualDamage = ComputeActualDamageForWideMaps(initialDamage, mapType, attackType);
                    break;
            }

            return actualDamage;
        }

        private static decimal ComputeActualDamageForTightMaps(decimal initialDamage, int mapType, int attackType)
        {
            if (attackType != (int)AttackType.Ranged)
            {
                return initialDamage;
            }

            return ComputeNerfedDamage(initialDamage, mapType, attackType);
        }

        private static decimal ComputeActualDamageForWideMaps(decimal initialDamage, int mapType, int attackType)
        {
            if (attackType != (int)AttackType.Melee)
            {
                return initialDamage;
            }

            return ComputeNerfedDamage(initialDamage, mapType, attackType);
        }

        private static decimal ComputeNerfedDamage(decimal initialDamage, int mapType, int attackType)
        {
            Random random = new Random();
            int randomProbability = random.Next(0, 100);

            // 25% chance to blunder an attack, 75% chance to deal 1/2 damage.

            if (randomProbability < 25)
            {
                Console.WriteLine(InGameMessage.AttackMissDueToMapTypeMismatch());
                return 0;
            }
            else
            {
                Console.WriteLine(InGameMessage.AttackDamageNerfedDueToMapTypeMismatch());
                return initialDamage / 2;
            }
        }
    }
}
