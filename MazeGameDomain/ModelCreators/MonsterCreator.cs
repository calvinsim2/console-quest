using MazeGameDomain.Interfaces.Monsters;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models.Monsters;

namespace MazeGameDomain.ModelCreators
{

    public abstract class MonsterCreator<TParameter, TMonster> where TParameter : MonsterParameter where TMonster : IMonster
    {
        public abstract TMonster CreateMonster(TParameter parameter);
    }

    public class IceCavernMonsterCreator : MonsterCreator<IceCavernMonsterParameter, IceCavernMonster>
    {
        public override IceCavernMonster CreateMonster(IceCavernMonsterParameter parameter)
        {
            return new IceCavernMonster(parameter.Name, parameter.Health, parameter.MP, parameter.Type, parameter.MonsterSkills);
        }
    }

    public class FireCavernMonsterCreator : MonsterCreator<FireCavernMonsterParameter, FireCavernMonster>
    {
        public override FireCavernMonster CreateMonster(FireCavernMonsterParameter parameter)
        {
            return new FireCavernMonster(parameter.Name, parameter.Health, parameter.MP, parameter.Type, parameter.MonsterSkills);
        }
    }

    public class ThickForestMonsterCreator : MonsterCreator<ThickForestMonsterParameter, ThickForestMonster>
    {
        public override ThickForestMonster CreateMonster(ThickForestMonsterParameter parameter)
        {
            return new ThickForestMonster(parameter.Name, parameter.Health, parameter.MP, parameter.Type, parameter.MonsterSkills);
        }
    }
    public class SkyCastleMonsterCreator : MonsterCreator<SkyCastleMonsterParameter, SkyCastleMonster>
    {
        public override SkyCastleMonster CreateMonster(SkyCastleMonsterParameter parameter)
        {
            return new SkyCastleMonster(parameter.Name, parameter.Health, parameter.MP, parameter.Type, parameter.MonsterSkills);
        }
    }
}
