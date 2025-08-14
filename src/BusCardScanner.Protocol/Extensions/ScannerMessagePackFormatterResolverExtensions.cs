using Scanner.Protocol.Formatters;
using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;
using Scanner.Protocol.Interfaces;
using Scanner.Protocol.MessagePack;

namespace Scanner.Protocol.Extensions
{
    /// <summary>
    /// 
    /// ref http://adamsitnik.com/Span/#span-must-not-be-a-generic-type-argument
    /// ref http://adamsitnik.com/Span/
    /// ref:MessagePack.Formatters.DynamicObjectTypeFallbackFormatter
    /// </summary>
    public static class ScannerMessagePackFormatterResolverExtensions
    {
        delegate void ScannerSerializeMethod(object dynamicFormatter, ref ScannerMessagePackWriter writer,object value, IScannerConfig config);

        delegate dynamic ScannerDeserializeMethod(object dynamicFormatter, ref ScannerMessagePackReader reader, IScannerConfig config);

        static readonly ConcurrentDictionary<Type, (object Value, ScannerSerializeMethod SerializeMethod)> scannerSerializers = new ConcurrentDictionary<Type, (object Value, ScannerSerializeMethod SerializeMethod)>();
        
        static readonly ConcurrentDictionary<Type, (object Value, ScannerDeserializeMethod DeserializeMethod)> scannerDeserializes = new ConcurrentDictionary<Type, (object Value, ScannerDeserializeMethod DeserializeMethod)>();
        /// <summary>
        /// Scanner动态序列化
        /// </summary>
        /// <param name="objFormatter"></param>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public static void ScannerDynamicSerialize(object objFormatter, ref ScannerMessagePackWriter writer, object value, IScannerConfig config)
        {
            Type type = value.GetType();
            var ti = type.GetTypeInfo();
          //  (object Value, ScannerSerializeMethod SerializeMethod) formatterAndDelegate;
            if (!scannerSerializers.TryGetValue(type, out var formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IScannerMessagePackFormatter<>).MakeGenericType(t);
                    var param0 = Expression.Parameter(typeof(object), "formatter");
                    var param1 = Expression.Parameter(typeof(ScannerMessagePackWriter).MakeByRefType(), "writer");
                    var param2 = Expression.Parameter(typeof(object), "value");
                    var param3 = Expression.Parameter(typeof(IScannerConfig), "config");
                    var serializeMethodInfo = formatterType.GetRuntimeMethod("Serialize", new[] { typeof(ScannerMessagePackWriter).MakeByRefType(), t, typeof(IScannerConfig) });
                    var body = Expression.Call(
                        Expression.Convert(param0, formatterType),
                        serializeMethodInfo,
                        param1,
                        ti.IsValueType ? Expression.Unbox(param2, t) : Expression.Convert(param2, t),
                        param3);
                    var lambda = Expression.Lambda<ScannerSerializeMethod>(body, param0, param1, param2, param3).Compile();
                    formatterAndDelegate = (objFormatter, lambda);
                }
                scannerSerializers.TryAdd(t, formatterAndDelegate);
            }
            formatterAndDelegate.SerializeMethod(formatterAndDelegate.Value, ref writer, value, config);
        }
        /// <summary>
        /// Scanner动态反序列化
        /// </summary>
        /// <param name="objFormatter"></param>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static dynamic ScannerDynamicDeserialize(object objFormatter, ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            var type = objFormatter.GetType();
         //   (object Value, ScannerDeserializeMethod DeserializeMethod) formatterAndDelegate;
            if (!scannerDeserializes.TryGetValue(type, out var formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IScannerMessagePackFormatter<>).MakeGenericType(t);
                    ParameterExpression param0 = Expression.Parameter(typeof(object), "formatter");
                    ParameterExpression param1 = Expression.Parameter(typeof(ScannerMessagePackReader).MakeByRefType(), "reader");
                    ParameterExpression param2 = Expression.Parameter(typeof(IScannerConfig), "config");
                    var deserializeMethodInfo = type.GetRuntimeMethod("Deserialize", new[] { typeof(ScannerMessagePackReader).MakeByRefType(), typeof(IScannerConfig) });
                    var body = Expression.Call(
                        Expression.Convert(param0, type),
                        deserializeMethodInfo,
                        param1,
                        param2
                        );
                    var lambda = Expression.Lambda<ScannerDeserializeMethod>(body, param0, param1, param2).Compile();
                    formatterAndDelegate = (objFormatter, lambda);
                }
                scannerDeserializes.TryAdd(t, formatterAndDelegate);
            }
            return formatterAndDelegate.DeserializeMethod(formatterAndDelegate.Value,ref reader, config);
        }
    }
}
