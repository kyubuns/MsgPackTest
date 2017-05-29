using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;

public class Test : MonoBehaviour
{
	void Start()
	{
		Test01();
		// Success

		Test02();
		// Success

		MessagePack.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
			MessagePack.Resolvers.GeneratedResolver.Instance,
			MessagePack.Resolvers.BuiltinResolver.Instance,
			MessagePack.Resolvers.PrimitiveObjectResolver.Instance
		);

        Test01();
		// InvalidCastException: Cannot cast from source type to destination type.
		// MessagePack.Resolvers.GeneratedResolver+FormatterCache`1[SampleEnum[,]]..cctor() (at Assets/Generated.cs:34)

		Test02();
		// FormatterNotRegisteredException: GenericTest`1[[System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] is not registered in this resolver. resolver:CompositeResolver
	}

	private void Test01()
	{
		var data = new SampleClass { Value = new SampleEnum[,] { { SampleEnum.A, SampleEnum.B }, { SampleEnum.C, SampleEnum.A } } };
		var msg = MessagePackSerializer.Serialize(data);
		UnityEngine.Debug.Log(msg);
	}

	private void Test02()
	{
		var data = new GenericTest<int> { Value = 5 };
		var msg = MessagePackSerializer.Serialize(data);
		UnityEngine.Debug.Log(msg);
	}
}
