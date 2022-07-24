namespace Stealer.Models
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            StringBuilder sbGet = new StringBuilder();
            StringBuilder sbSet = new StringBuilder();
            foreach (MethodInfo method in methodInfos)
            {
                string result = $"{method.Name} will return {method.ReturnType}";
                if (method.Name.StartsWith("get"))
                {
                    sbGet.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    sbSet.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }

            }
            return sbGet.AppendLine(sbSet.ToString().Trim()).ToString().Trim();
        }
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance );
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo method in methodInfos)
            {
                bool isPrivate = method.IsPrivate;
                if (isPrivate)
                {
                    sb.AppendLine($"{method.Name}");
                }
            }
            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            PropertyInfo[] propertiesInfo = classType.GetProperties(BindingFlags.Public |BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbGetters = new StringBuilder();
            StringBuilder sbSetters = new StringBuilder();
            sbFields.AppendLine("Fields");
            foreach (FieldInfo field in fieldsInfo)
            {
                bool isPublic = field.IsPublic;
                if (isPublic)
                {
                    sbFields.AppendLine($"{field.Name} must be private!");
                }
            }

            sbSetters.AppendLine("Setters");
            sbGetters.AppendLine("Getters");

            foreach (PropertyInfo property in propertiesInfo)
            {
                bool isGetterPrivate = property.GetMethod.IsPrivate;
                if (isGetterPrivate)
                {
                    sbGetters.AppendLine($"{property.Name} have to be public!");
                }

            }
            foreach (PropertyInfo property in propertiesInfo)
            {

                bool isSetterPublic = property.SetMethod.IsPublic;
                if (isSetterPublic)
                {
                    sbSetters.AppendLine($"{property.Name} have to be private!");
                }
            }


            sbFields.AppendLine(sbGetters.ToString().Trim());
            sbFields.AppendLine(sbSetters.ToString().Trim());

            return sbFields.ToString().Trim();
        }
        public string StealFieldInfo(string nameOfTheClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(nameOfTheClass);
            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(classType, new object[] {});
            sb.AppendLine($"Class under investigation: {nameOfTheClass}");
            foreach (var field in fieldInfo.Where(fi => requestedFields.Contains(fi.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
