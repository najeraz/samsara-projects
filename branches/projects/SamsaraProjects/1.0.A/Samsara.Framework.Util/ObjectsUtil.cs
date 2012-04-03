
using System;
using System.Reflection;

namespace Samsara.Support.Util
{
    public class ObjectsUtil
    {
        public static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }


        public static void CopyProperties(object Dest, object Src)
        {
            foreach (PropertyInfo objSrcPI in Src.GetType().GetProperties())
            {
                PropertyInfo objDestPI = Dest.GetType().GetProperty(objSrcPI.Name);
                Object Val = null;

                if (objDestPI != null)
                {
                    if (objDestPI.PropertyType.BaseType == typeof(Enum))
                    {
                        Val = (int)objSrcPI.GetValue(Src, null);
                        Dest.GetType().GetProperty(objSrcPI.Name).SetValue(Dest, Val, null);
                    }
                    else if (objDestPI.PropertyType == objSrcPI.PropertyType)
                    {
                        Val = objSrcPI.GetValue(Src, null);
                        Dest.GetType().GetProperty(objSrcPI.Name).SetValue(Dest, Val, null);
                    }
                    else if (objDestPI.PropertyType != objSrcPI.PropertyType)
                    {
                        if (!objDestPI.PropertyType.IsValueType &&
                            !objDestPI.PropertyType.IsPrimitive &&
                            objSrcPI.GetValue(Src, null) != null)
                        {
                            Type objDestType = objDestPI.PropertyType;
                            Object objDest = Activator.CreateInstance(objDestType);
                            Val = objSrcPI.GetValue(Src, null);
                            CopyProperties(Val, objDest);
                            Dest.GetType().GetProperty(objSrcPI.Name).SetValue(Dest, objDest, null);
                        }
                    }
                }
            }
        }

    }
}
