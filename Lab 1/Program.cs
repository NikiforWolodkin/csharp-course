using System;
using System.Text;
using System.Linq;

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
			int?[] nullableIntArray = { 32, null };
			foreach (var variable in nullableIntArray)
			{
				if (variable.HasValue == true)
				{
					Console.WriteLine($"{variable}");
				}
				else
				{
					Console.WriteLine("Переменная - null");
				}
			}
			Console.WriteLine("");


			//var failTest = 16;
			//failTest = "String";


			Console.WriteLine("Строковый литерал:");
			Console.WriteLine("Hello World!");
			Console.WriteLine("Строковый литерал:" == "Hello World!" ? "Равны\n" : "Не равны\n");


			Console.WriteLine("String:");
			string name1 = "Joel Omans";
			string name2 = "Mark Holocomb";
			string name3 = "Aaron Kitcher";
			Console.WriteLine(string.Concat(name1, name2));
			string name3Copy = string.Copy(name3);
			Console.WriteLine(name3Copy);
			Console.WriteLine(name1.Substring(name1.IndexOf("Omans")));
			string[] name2Split = name2.Split(' ');
			foreach (var word in name2Split)
			{
				Console.WriteLine($"{word}");
			}
			Console.WriteLine(name2.Insert(4, " " + name1));
			Console.WriteLine(name1.Replace("Joel ", null));
			Console.WriteLine($"Интерполирование строк: {10 + 9}\n");


			Console.WriteLine("Null строки:");
			string?[] nullableStringArray = { "", null, "Hello" };
			foreach (var nullString in nullableStringArray)
            {
				if (String.IsNullOrEmpty(nullString))
				{
					Console.WriteLine("Null или пустая");
				}
				else
                {
					Console.WriteLine(nullString);
                }
            }
			nullableStringArray[1] = "Not null";
			Console.WriteLine(nullableStringArray[1]);
			Console.WriteLine("");


			Console.WriteLine("StringBuilder:");
			StringBuilder stringSB = new StringBuilder("Hello World!");
			stringSB.Remove(6, 6);
			Console.WriteLine(stringSB);
			stringSB.Append("World!");
			Console.WriteLine(stringSB);
			stringSB.Insert(0, "Greetings/");
			Console.WriteLine(stringSB);
			Console.WriteLine("");


			Console.WriteLine("Матрица:");
			int[,] matrix = { { 5, 5, 9 }, { 2, 7, 12 }, { 11, 4, 0 } };
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write("{0}\t", matrix[i, j]);
				}
				Console.WriteLine("");
			}
			Console.WriteLine("");


			Console.WriteLine("Массив строк:");
			string[] stringArray = { "James Hetfield", "Lars Ulrich", "Jason Newsted", "Kirk Hammet" };
			foreach (var nameFromArray in stringArray)
            {
				Console.WriteLine(nameFromArray);
            }
			Console.WriteLine($"Длина массива: {stringArray.Length}\nВведите индекс изменяемого элемента и сам элемент:");
			int choice = Convert.ToInt32(Console.ReadLine());
			stringArray[choice] = Console.ReadLine();
			foreach (var nameFromArray in stringArray)
			{
				Console.WriteLine(nameFromArray);
			}
			Console.WriteLine("");


			Console.WriteLine("Ступенчатый массив:");
			int[][] jaggedArray = new int[3][];
			jaggedArray[0] = new int[2];
			jaggedArray[1] = new int[3];
			jaggedArray[2] = new int[4];
			foreach (var arrayElement in jaggedArray)
            {
				for (int i = 0; i < arrayElement.Length; i++)
                {
					arrayElement[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < jaggedArray[i].Length; j++)
				{
					Console.Write("{0}\t", jaggedArray[i][j]);
				}
				Console.WriteLine("");
			}
			Console.WriteLine("");


			Console.WriteLine("Неявно типизированные переменные для массивов:");
			var stringVar = "Hello World!";
			var arrayVar = new int[] { 2, 3 };
			Console.WriteLine(stringVar);
			for (int i = 0; i < 2; i++)
            {
				Console.WriteLine(arrayVar[i]);
			}
			Console.WriteLine("");


			Console.WriteLine("Кортеж:");
			(int, string, char, string, ulong) tuple = (16, "George", 'A', "Fisher", 1024);
			Console.WriteLine(tuple);
			Console.WriteLine(tuple.Item1);
			Console.WriteLine(tuple.Item3);
			Console.WriteLine(tuple.Item4);
			Console.WriteLine("");


			(string, int) person = ("John", 32);
			(string personName1, int personAge1) = person;
			var (personName2, personAge2) = person;
			string personName3;
			int personAge3;
			(personName3, personAge3) = person;
			Console.WriteLine($"{personName1} {personAge1} {personName2} {personAge2} {personName3} {personAge3}");


			(string, int) person2 = ("Kirk", 32);
			Console.WriteLine(person == person2 ? "Кортежи равны\n" : "Кортежи не равны\n");


			Console.WriteLine("Локальные функции:");
			(int, int, int, char) LocalFunction(int[] array, string str)
            {
				return (array.Max(), array.Min(), array.Sum(), str[0]);
            }
			Console.WriteLine(LocalFunction( new int[] { 2, 10, 8 }, "Hello World!" ));
			Console.WriteLine("");


			Console.WriteLine("Checked/unchecked:");
			int functionChecked()
            {
                checked
                {
					int intChecked = int.MaxValue;
					return intChecked + 1;
				}
			}
			int functionUnchecked()
			{
				unchecked
				{
					int intUnchecked = int.MaxValue;
					return intUnchecked + 1;
				}
			}
			Console.WriteLine(functionUnchecked());
			//Console.WriteLine(functionChecked());
		}	
	}
}
