namespace MilitaryElite.Models
{
    using MilitaryElite.Enum;
    using MilitaryElite.IO.Models.Contracts;
    using System;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.ParseState(state);
        }
        public void ParseState(string stateString)
        {
            State state;
            bool isParsed = Enum.TryParse<State>(stateString, out state);
            if (!isParsed)
            {
                throw new ArgumentException("Invalid Mission");
            }
            this.State = state;
        }
        public string CodeName { get; private set; }
        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidOperationException("Mission alreadi finished");
            }
            this.State = State.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }


    }
}
