using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lock
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : Attribute { }

    public sealed class Singleton {

        public static object CallMethod(MethodInfo method, params object[] input) {
            ParameterInfo[] parameters = method.GetParameters();
            bool hasParams = false;
            if (parameters.Length > 0)
                hasParams = parameters[parameters.Length - 1].GetCustomAttributes(typeof(ParamArrayAttribute), false).Count() > 0;

            if (hasParams) {
                int lastParamPosition = parameters.Length - 1;

                object[] realParams = new object[parameters.Length];
                for (int i = 0; i < lastParamPosition; i++)
                    realParams[i] = input[i];

                Type paramsType = parameters[lastParamPosition].ParameterType.GetElementType();
                Array extra = Array.CreateInstance(paramsType, input.Length - lastParamPosition);
                for (int i = 0; i < extra.Length; i++)
                    extra.SetValue(input[i + lastParamPosition], i);

                realParams[lastParamPosition] = extra;

                input = realParams;
            }

            return method.Invoke(null, input);
        }

        public static object GetInstance(Type type, params object[] parameters) {

            var method = typeof(Singleton<>).MakeGenericType(type).GetRuntimeMethod(nameof(Singleton<object>.GetInstance), new Type[] { });


            return CallMethod(method, parameters);


            // return method.Invoke((object)null, parameters);  
        }
    }
    public class Singleton<T> where T : class {
        static T instance;
        public static T GetInstance(params object[] parameters) {
            var tempParams = new List<object>();
            tempParams.Add(new LockToken());
            tempParams.AddRange(parameters);


            // var singleTonAttribute = typeof(T).GetCustomAttributes(true).FirstOrDefault(n => n.GetType() == typeof(SingletonAttribute)) as SingletonAttribute;
            // var whiteListAttribute = typeof(T).GetCustomAttributes(true).FirstOrDefault(n => n.GetType() == typeof(InstantiatorWhiteListAttribute)) as InstantiatorWhiteListAttribute;

            //if (singleTonAttribute != null) {

            //if (whiteListAttribute != null) {
            //    if (instance == null) {
            //        instance = WhiteListInstantiator<T>.NewInstance(parameters);
            //    }
            //    return instance;
            //}
            //else
            //{
            if (instance == null) { instance = (T)Activator.CreateInstance(typeof(T), tempParams.ToArray()); }
            return instance;
            //}
            //} else {
            //    throw new ApplicationException($"{typeof(T).FullName} is not annotated as a singleton!");
            //}
        }

        public static bool HasInstance => instance != null;

    }


    /// <summary>
    /// Blocks of Instantiation to the Omnicatz.AccessDenied Assembly allowing for greater control over instansiation
    /// </summary>
    public class LockToken {
        internal LockToken() {
        }

        public class LockTokenIsNullException : InvalidOperationException {
            public string message = "";
            public override string Message {
                get {
                    return message;
                }
            }
            public LockTokenIsNullException(Type type) {



                var singleTonAttribute = type.GetTypeInfo().GetCustomAttributes(true).FirstOrDefault(n => n.GetType() == typeof(SingletonAttribute)) as SingletonAttribute;
                //  var whiteListAttribute = type.GetCustomAttributes(true).FirstOrDefault(n => n.GetType() == typeof(InstantiatorWhiteListAttribute)) as InstantiatorWhiteListAttribute;

                if (singleTonAttribute != null) {
                    //if (whiteListAttribute != null)
                    //{
                    //    message = $"{type} may only be instantiated with the Omnicatz.AccessDenied.Singleton or Singleton<{type}> class inside of any of the white listed classes {whiteListAttribute.AllowedTypes.Select(n => n.Name).ToString()}";
                    //}
                    //else
                    //{
                    message = $"{type} may only be instantiated with the Omnicatz.AccessDenied.Singleton or Singleton<{type}> class";
                    //}
                }
                //else
                //{
                //    message = $"{type} may only be instantiated with the Omnicatz.AccessDenied.WhiteListInstantiator<{type}> class inside of any of the white listed classes {whiteListAttribute.AllowedTypes.Select(n => n.Name).ToString()}";

                //}


            }
        }

        public static void Enforce<T>(LockToken source) {
            if (source == null) {
                throw new LockTokenIsNullException(typeof(T));
            }
        }
    }
}
