namespace Bakery.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.BakedFoods;
    using Models.BakedFoods.Contracts;
    using Models.Drinks;
    using Models.Drinks.Contracts;
    using Models.Tables;
    using Models.Tables.Contracts;
    using Utilities.Messages;

    public class Controller :IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }


        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;
            if (type == nameof(Bread))
            {
                bakedFood  = new Bread(name, price);
            }
            else if (type == nameof(Cake))
            {
                bakedFood = new Cake(name, price);
            }

            if (bakedFood != null)
            {
                bakedFoods.Add(bakedFood);
                return string.Format(OutputMessages.FoodAdded, name, type);
            }
            return null;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }

            if (drink != null)
            {
                drinks.Add(drink);
                return string.Format(OutputMessages.DrinkAdded, name, brand);
            }
            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            if (table != null)
            {
                tables.Add(table);
                return string.Format(OutputMessages.TableAdded, tableNumber);
            }
            return null;
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.FirstOrDefault(x => x.Capacity >= numberOfPeople && x.IsReserved == false);
            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood bakedFood = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (bakedFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(bakedFood);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName);
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}"; 
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal price = table.GetBill();
            totalIncome += price;
            table.Clear();
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {price:f2}");
            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();
            foreach (var table in tables.Where(x => !x.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }
    }
}
