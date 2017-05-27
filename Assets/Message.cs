using MessagePack;

[MessagePackObject]
public class SampleClass
{
	[Key(0)]
	public SampleEnum[,] Value { get; set; }
}

public enum SampleEnum
{
	A,
	B,
	C,
}

[MessagePackObject]
public class GenericTest<T>
{
	[Key(0)]
	public T Value { get; set; }
}
