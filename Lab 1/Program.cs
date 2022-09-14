using System;

namespace Lab_1
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Показать первое задание?");
			Console.WriteLine("1 - д, /= 1 - н");
			int showTask = Convert.ToInt32(Console.ReadLine());
			if (showTask == 1)
			{
				Console.WriteLine("Примитивные типы:");
				Console.Write("bool: ");
				bool booleanVariable = Convert.ToBoolean(Console.ReadLine());
				Console.WriteLine($"{booleanVariable}");
				Console.Write("byte: ");
				byte byteVariable = Convert.ToByte(Console.ReadLine());
				Console.WriteLine($"{byteVariable}");
				Console.Write("sbyte: ");
				sbyte sbyteVariable = Convert.ToSByte(Console.ReadLine());
				Console.WriteLine($"{sbyteVariable}");
				Console.Write("char: ");
				char charVariable = Convert.ToChar(Console.ReadLine());
				Console.WriteLine($"{charVariable}");
				Console.Write("decimal: ");
				decimal decimalVariable = Convert.ToDecimal(Console.ReadLine());
				Console.WriteLine($"{decimalVariable}");
				Console.Write("double: ");
				double doubleVariable = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine($"{doubleVariable}");
				Console.Write("float: ");
				float floatVariable = (float)Convert.ToDouble(Console.ReadLine());
				Console.WriteLine($"{floatVariable}");
				Console.Write("int: ");
				int intVariable = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine($"{intVariable}");
				Console.Write("uint: ");
				uint uintVariable = Convert.ToUInt32(Console.ReadLine());
				Console.WriteLine($"{uintVariable}");
				//Console.Write("nint: ");
				//nint nintVariable = (nint)Convert.ToInt32(Console.ReadLine());
				//Console.WriteLine($"{nintVariable}");
				//Console.Write("nuint: ");
				//nuint nuintVariable = (nuint)Convert.ToUInt32(Console.ReadLine());
				//.WriteLine($"{nuintVariable}");
				Console.Write("long: ");
				long longVariable = Convert.ToInt64(Console.ReadLine());
				Console.WriteLine($"{longVariable}");
				Console.Write("ulong: ");
				ulong ulongVariable = Convert.ToUInt64(Console.ReadLine());
				Console.WriteLine($"{ulongVariable}");
				Console.Write("short: ");
				short shortVariable = Convert.ToInt16(Console.ReadLine());
				Console.WriteLine($"{shortVariable}");
				Console.Write("ushort: ");
				ushort ushortVariable = Convert.ToUInt16(Console.ReadLine());
				Console.WriteLine($"{ushortVariable}");
			}
			Console.WriteLine("");


			Console.WriteLine("Приведение типов:");
			byte number = 16;
			short numberInt16 = number;
			int numberInt32 = numberInt16;
			long numberInt64 = numberInt32;
			ushort numberUInt16 = 32;
			uint numberUInt32 = numberUInt16;
			ulong numberUInt64 = numberUInt32;
			Console.WriteLine($"{numberInt16} {numberInt32} {numberInt64} {numberUInt32} {numberUInt64}");
			char symbol = 'A';
			string symbolString = Convert.ToString(symbol);
			float numberFloat = (float)numberInt32;
			double numberDouble = (double)numberInt32;
			decimal numberDecimal = (decimal)numberInt32;
			numberUInt32 = (uint)numberInt32;
			Console.WriteLine($"{symbolString} {numberFloat} {numberDouble} {numberDecimal} {numberUInt32}\n");


			Console.WriteLine("Распаковка значимых типов:");
			object numberObject = numberInt32;
			int numberObjectUnboxed = (int)numberObject;
			object numberFloatObject = numberFloat;
			float numberFloatObjectUnboxed = (float)numberFloatObject;
			object numberDecimalObject = numberDecimal;
			decimal numberDecimalObjectUnboxed = (decimal)numberDecimalObject;
			object symbolObject = symbol;
			char symbolObjectUnboxed = (char)symbolObject;
			bool boolean = true;
			object booleanObject = boolean;
			bool booleanObjectUnboxed = (bool)booleanObject;
			Console.WriteLine($"{numberObjectUnboxed} {numberFloatObjectUnboxed} {numberDecimalObjectUnboxed} {symbolObjectUnboxed} {booleanObjectUnboxed}\n");


			Console.WriteLine("Использование var:");
			var name = "Lucas Mann";
			Console.WriteLine(name.GetType());
			var letter = 'A';
			Console.WriteLine(letter.GetType());
			var age = 32;
			Console.WriteLine(age.GetType());
			var balance = 800.99;
			Console.WriteLine(balance.GetType());
			Console.WriteLine("");


			Console.WriteLine("Использование Nullable:");
			int?[] nullableIntArray = {32, null};
			for (int i = 0; i < nullableIntArray.Length; i++)
            {
				if (nullableIntArray[i].HasValue == true)
				{
					Console.WriteLine($"{nullableIntArray[i]}");
				}
				else
				{
					Console.WriteLine("Переменная - null");
				}
			}
		}
	}
}
