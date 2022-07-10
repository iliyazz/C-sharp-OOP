using MilitaryElite.Enum;

namespace MilitaryElite.IO.Models.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }
        
        State State { get; }
        public void CompleteMission();
    }
}
