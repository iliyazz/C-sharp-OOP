namespace ValidationAttributes.Utiliteis.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int min;
        private readonly int max;
        public MyRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public override bool IsValid(object obj)
        {
            int currenValue = (int)obj;
            return currenValue >= min && currenValue <= max;
        }
    }
}
