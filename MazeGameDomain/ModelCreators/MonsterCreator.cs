using MazeGameDomain.Interfaces.Monsters;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models.Monsters;

namespace MazeGameDomain.ModelCreators
{
    public abstract class MonsterCreator
    {
        public abstract IMonster CreateMonster(object parameters);

    }

    public class IceCavernMonsterCreator : MonsterCreator
    {
        public override IMonster CreateMonster(object parameters)
        {
            IceCavernMonsterParameter iceCavernMonsterParameter = parameters as IceCavernMonsterParameter ?? throw new ArgumentException();

            IceCavernMonster iceCavernMonster = new IceCavernMonster(iceCavernMonsterParameter.Name, iceCavernMonsterParameter.Health,
                            iceCavernMonsterParameter.MP, iceCavernMonsterParameter.Type, iceCavernMonsterParameter.MonsterSkills);

            return iceCavernMonster;
        }
    }

    public class FireCavernMonsterCreator : MonsterCreator
    {
        public override IMonster CreateMonster(object parameters)
        {
            FireCavernMonsterParameter fireCavernMonsterParameter = parameters as FireCavernMonsterParameter ?? throw new ArgumentException();

            FireCavernMonster fireCavernMonster = new FireCavernMonster(fireCavernMonsterParameter.Name, fireCavernMonsterParameter.Health,
                            fireCavernMonsterParameter.MP, fireCavernMonsterParameter.Type, fireCavernMonsterParameter.MonsterSkills);

            return fireCavernMonster;
        }
    }

    public class ThickForestMonsterCreator : MonsterCreator
    {
        public override IMonster CreateMonster(object parameters)
        {
            ThickForestMonsterParameter thickForestMonsterParameter = parameters as ThickForestMonsterParameter ?? throw new ArgumentException();

            ThickForestMonster thickForestMonster = new ThickForestMonster(thickForestMonsterParameter.Name, thickForestMonsterParameter.Health,
                            thickForestMonsterParameter.MP, thickForestMonsterParameter.Type, thickForestMonsterParameter.MonsterSkills);

            return thickForestMonster;
        }
    }

    public class SkyCastleMonsterCreator : MonsterCreator
    {
        public override IMonster CreateMonster(object parameters)
        {
            SkyCastleMonsterParameter skyCastleMonsterParameter = parameters as SkyCastleMonsterParameter ?? throw new ArgumentException();

            SkyCastleMonster skyCastleMonster = new SkyCastleMonster(skyCastleMonsterParameter.Name, skyCastleMonsterParameter.Health,
                            skyCastleMonsterParameter.MP, skyCastleMonsterParameter.Type, skyCastleMonsterParameter.MonsterSkills);

            return skyCastleMonster;
        }
    }
}
