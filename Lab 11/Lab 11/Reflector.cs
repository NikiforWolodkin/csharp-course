using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.Remoting;

namespace Lab_11
{
    public static class Reflector
    {
        public static Assembly GetAssembly(string className)
        {
            return Type.GetType(className, true, true).Assembly;
        }

        public static bool ContainsConstructors(string className)
        {
            if (Type.GetType(className, true, true).GetConstructors().Length == 0)
            {
                return false;
            }

            return true;
        }

        public static IEnumerable<string> GetMethods(string className)
        {
            var methods = Type.GetType(className, true, true).GetMethods();
            List<string> methodDefinitions = new List<string>();
            for (int i = 0; i < methods.Length; i++)
            {
                methodDefinitions.Add(Convert.ToString(methods[i]));
            }

            return methodDefinitions;
        }

        public static IEnumerable<string> GetProperties(string className)
        {
            var property = Type.GetType(className, true, true).GetProperties();
            List<string> methodDefinitions = new List<string>();
            for (int i = 0; i < property.Length; i++)
            {
                methodDefinitions.Add(Convert.ToString(property[i]));
            }

            return methodDefinitions;
        }

        public static IEnumerable<string> GetInterfaces(string className)
        {
            var iface = Type.GetType(className, true, true).GetInterfaces();
            List<string> methodDefinitions = new List<string>();
            for (int i = 0; i < iface.Length; i++)
            {
                methodDefinitions.Add(Convert.ToString(iface[i]));
            }

            return methodDefinitions;
        }

        public static IEnumerable<string> GetMethodsWithParameters(string className, string parameterName)
        {
            var methods = Type.GetType(className, true, true).GetMethods();
            List<string> methodDefinitions = new List<string>();

            Type parameter = Type.GetType(parameterName, true, true);

            for (int i = 0; i < methods.Length; i++)
            {
                bool containsParameter = false;
                foreach (var methodParameter in methods[i].GetParameters())
                {
                    if (methodParameter.ParameterType == parameter)
                    {
                        containsParameter = true;
                    }
                }

                if (containsParameter)
                {
                    methodDefinitions.Add(Convert.ToString(methods[i]));
                }
            }

            return methodDefinitions;
        }

        public static object Invoke(object obj, string methodName)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName);
            ParameterInfo[] parameters = method.GetParameters();
            object[] arguments = new object[parameters.Length];

            if (method.GetParameters().Length == 0)
            {
                return method.Invoke(obj, parameters);
            }
            
            Random random = new Random();
            for (int i = 0; i < parameters.Length;  i++)
            {
                if (parameters[i].ParameterType == typeof(object) || parameters[i].ParameterType.IsClass == true)
                {
                    arguments[i] = new object();
                }
                else if (parameters[i].ParameterType == typeof(string))
                {
                    arguments[i] = Convert.ToString(random.Next(1, 1000));
                }
                else
                {
                    arguments[i] = random.Next(1, 1000);
                }
            }

            return method.Invoke(obj, parameters);
        }

        public static object Invoke(object obj, string methodName, string path)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName);

            string json = File.ReadAllText(path);
            object[] arguemnts = JsonSerializer.Deserialize<object[]>(json);

            return method.Invoke(obj, arguemnts);
        }

        public static void SerializeArguments(object[] array, string path)
        {
            string json = JsonSerializer.Serialize(array);
            File.WriteAllText(path, json);
        }

        public static void SerializeType(string className, string path)
        {
            Type type = Type.GetType(className, true, true);

            List<string> members = new List<string>();
            foreach (var member in type.GetMembers())
            {
                members.Add(Convert.ToString(member));
            }

            SerializedType serializedType = new SerializedType(className, Convert.ToString(type.Assembly), members.ToArray());

            string json = JsonSerializer.Serialize(serializedType);
            File.WriteAllText(path, json);
        }

        public class SerializedType
        {
            public string Name { get; set; }
            public string Assembly { get; set; }
            public string[] Members { get; set; }

            public SerializedType(string name, string assembly, string[] members)
            {
                Name = name;
                Assembly = assembly;
                Members = members;
            }
        }
    }

    public static class Reflector<T>
    {
        public static T Create()
        {
            Type type = typeof(T);
            Object obj = Activator.CreateInstance(type);
            return (T)obj;
        }

        public static T Create(object[] arguments)
        {
            Type type = typeof(T);
            Object obj = Activator.CreateInstance(type, arguments);
            return (T)obj;
        }
    }
}
