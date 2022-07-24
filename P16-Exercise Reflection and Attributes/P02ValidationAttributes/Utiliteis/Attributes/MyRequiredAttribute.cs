namespace ValidationAttributes.Utiliteis.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
            => obj != null;
    }
}
