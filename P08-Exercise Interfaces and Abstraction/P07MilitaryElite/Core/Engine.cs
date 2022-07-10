
namespace MilitaryElite.Core
{
    using MilitaryElite.IO.Models.Contracts;
    using MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Engine : IEngine
    {
        private List<ISoldier> soldiersList;
        public Engine()
        {
            this.soldiersList = new List<ISoldier>();
        }


        public void Start()
        {
            string token = string.Empty;
            while ((token = Console.ReadLine()) != "End")
            {
                string[] tokens = token.Split();
                string type = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];
                decimal salary = decimal.Parse(tokens[4]);

                if (type == "Private")
                {
                    ISoldier @private = new Private(id, firstName, lastName, salary);
                    this.soldiersList.Add(@private);
                }
                else if (type == "LieutenantGeneral")
                {
                    LieutenantGeneral leutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    string[] prvateIds = tokens.Skip(5).ToArray();
                    foreach (var item in prvateIds)
                    {
                        ISoldier currentPrivate= this.soldiersList.FirstOrDefault(x => x.Id == item);
                        leutenantGeneral.AddPrivate(currentPrivate);
                    }
                    this.soldiersList.Add(leutenantGeneral);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = tokens[5];
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        string[] repairs = tokens.Skip(6).ToArray();
                        for (int i = 0; i < repairs.Length; i += 2)
                        {
                            string repairPart = repairs[i];
                            int hourRepair = int.Parse(repairs[i + 1]);
                            IRepair repair = new Repair(repairPart, hourRepair);
                            engineer.AddRepair(repair);
                        }
                        this.soldiersList.Add(engineer);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = tokens[5];
                        Commando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] infoMission = tokens.Skip(6).ToArray();
                        for (int i = 0; i < infoMission.Length; i += 2)
                        {
                            string missionName = infoMission[i];
                            string state = infoMission[i + 1];
                            IMission mission;
                            
                            try
                            {
                                mission = new Mission(missionName, state);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            commando.AddMission(mission);
                        }
                        this.soldiersList.Add(commando);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    
                }
                else if (type == "Spy")
                {
                    int codeNumnber = (int)salary;
                    ISpy spy = new Spy(id, firstName, lastName, codeNumnber);
                    this.soldiersList.Add(spy);
                }
            }
            foreach (var soldier in soldiersList)
            {
                Type type = soldier.GetType();
                Object currentSoldier = Convert.ChangeType(soldier, type);
                Console.WriteLine(currentSoldier);
            }
        }
    }
}
