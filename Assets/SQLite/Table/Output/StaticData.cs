using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

public static class StaticData
{
	private const string MemberDataPath = @"E:\Project\Study\Assets\SQLite\Table\Output\Binary\Member.bytes";
	private const string FamilyDataPath = @"E:\Project\Study\Assets\SQLite\Table\Output\Binary\Family.bytes";
	private const string StudentDataPath = @"E:\Project\Study\Assets\SQLite\Table\Output\Binary\Student.bytes";

	public static async void LoadAllData(Action onComplete)
	{
		await Task.Run(() =>
		{
			LoadOneData<Member>(MemberDataPath);
			LoadOneData<Family>(FamilyDataPath);
			LoadOneData<Student>(StudentDataPath);
		});
		onComplete?.Invoke();
	}

	public static void LoadOneData<T>(string filePath) where T : DataRowBase, new()
	{
		ParseData<T>(File.ReadAllBytes(filePath));
	}

	public static async void LoadOneData<T>(string filePath, Action onComplete) where T : DataRowBase, new()
	{
		await Task.Run(() =>
		{
			LoadOneData<T>(filePath);
		});
		onComplete?.Invoke();
	}

	private static void ParseData<T>(byte[] buffer) where T : DataRowBase, new()
	{
		using MemoryStream memoryStream = new(buffer);
		using BinaryReader binaryReader = new(memoryStream);
		int count = binaryReader.ReadInt32();
		for (int i = 0; i < count; i++)
		{
			T data = new();
			data.ParseData(binaryReader);
		}
	}	
	private static int[] ReadInt32Array(this BinaryReader binaryReader)
	{
		int length = binaryReader.ReadInt32();
		int[] intArray = new int[length];
		for (int i = 0; i < length; i++)
		{
			intArray[i] = binaryReader.ReadInt32();
		}
		return intArray;
	}

	public class DataRowBase
	{
		protected int _id;
		public int Id
		{
			get
			{
				return _id;
			}
		}

		public void ParseData(byte[] dataBytes)
		{
			using MemoryStream memoryStream = new(dataBytes);
			using BinaryReader binaryReader = new(memoryStream);
			_id = binaryReader.ReadInt32();
			ParseData(binaryReader);
		}

		public virtual void ParseData(BinaryReader binaryReader) { }
	}

	/// <summary>
	/// Member
	/// </summary>
	public class Member : DataRowBase
	{
		public static IReadOnlyDictionary<int, Member> Data { get; private set; } = DataDictionary = new();
		public static IReadOnlyDictionary<string, Member> NameToData { get; private set; } = NameToDataDictionary = new();

		private static Dictionary<int, Member> DataDictionary;
		private static Dictionary<string, Member> NameToDataDictionary;

		/// <summary>
		/// 名字
		/// #标记属性名设置多主键
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// 年龄
		/// </summary>
		public int Age
		{
			get;
			private set;
		}

		/// <summary>
		/// 身高
		/// </summary>
		public float Stature
		{
			get;
			private set;
		}

		/// <summary>
		/// 是否已婚
		/// 0 = false
		/// 1 = true
		/// </summary>
		public bool Married
		{
			get;
			private set;
		}

		public override void ParseData(BinaryReader binaryReader)
		{
			_id = binaryReader.ReadInt32();
			Name = binaryReader.ReadString();
			Age = binaryReader.ReadInt32();
			Stature = binaryReader.ReadSingle();
			Married = binaryReader.ReadBoolean();
			DataDictionary[_id] = this;
			NameToDataDictionary[Name] = this;
		}
	}

	/// <summary>
	/// Family
	/// </summary>
	public class Family : DataRowBase
	{
		public static IReadOnlyDictionary<int, Family> Data { get; private set; } = DataDictionary = new();

		private static Dictionary<int, Family> DataDictionary;

		/// <summary>
		/// 名字
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// 地址
		/// </summary>
		public string Path
		{
			get;
			private set;
		}

		/// <summary>
		/// 家庭成员
		/// </summary>
		public int[] Members
		{
			get;
			private set;
		}

		public override void ParseData(BinaryReader binaryReader)
		{
			_id = binaryReader.ReadInt32();
			Name = binaryReader.ReadString();
			Path = binaryReader.ReadString();
			Members = binaryReader.ReadInt32Array();
			DataDictionary[_id] = this;
		}
	}

	/// <summary>
	/// Student
	/// </summary>
	public class Student : DataRowBase
	{
		public static IReadOnlyDictionary<int, Student> Data { get; private set; } = DataDictionary = new();
		public static IReadOnlyDictionary<string, Student> NameToData { get; private set; } = NameToDataDictionary = new();

		private static Dictionary<int, Student> DataDictionary;
		private static Dictionary<string, Student> NameToDataDictionary;

		/// <summary>
		/// Name
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// Age
		/// </summary>
		public int Age
		{
			get;
			private set;
		}

		public override void ParseData(BinaryReader binaryReader)
		{
			_id = binaryReader.ReadInt32();
			Name = binaryReader.ReadString();
			Age = binaryReader.ReadInt32();
			DataDictionary[_id] = this;
			NameToDataDictionary[Name] = this;
		}
	}

}

