using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;

public class Test : MonoBehaviour
{
	void Start()
	{
		Test01();
		Test02();

		MessagePack.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
			MessagePack.Resolvers.GeneratedResolver.Instance,
			MessagePack.Resolvers.BuiltinResolver.Instance,
			MessagePack.Resolvers.PrimitiveObjectResolver.Instance
		);

		Test01();
		Test02();
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
