using System;
using System.IO;

public class test
{
	public void @out()
	{
		Console.Write("{0,4}", elem);
	}
	public int elem;
	public test()
	{
		elem = RandomNumbers.NextNumber() % 90 + 10;
	}

}

public class List
{
	private bool InstanceFieldsInitialized = false;

	public List()
	{
		if (!InstanceFieldsInitialized)
		{
			InitializeInstanceFields();
			InstanceFieldsInitialized = true;
		}
	}

	private void InitializeInstanceFields()
	{
		quantity = line * collum;
	}

	private List head = null;
	private List tail = null;
	private List now = null;
	private List prenow = null;
	private List newHead = null;
	private test element = new test();
	private List next = null;
	private List prev = null;
	private List top = null;
	private List under = null;
	private int sum = 0;
	private double avarage = 0;
	public int line = 5;
	public int collum = 5;
	public int quantity;

	public void fill_from_file()
	{
		int j = 1;
		string filePath = "source.txt";
		int file = 0;
		int stroki = 0;
		int count = 0;
		int temp;
		string lines;
		StreamReader reader = new StreamReader(filePath);
		while (reader.ReadLine() != null)
		{
			stroki++;
		}

		reader.BaseStream.Seek(0, SeekOrigin.Begin); // Перемещение курсора чтения в начало файла

		while (reader.EndOfStream == false && int.TryParse(reader.ReadLine(), out temp))
		{
			count++;
		}

		int line = stroki;
		int column = count / stroki;
		int quantity = line * column;
		for (int i = 1; i <= quantity; i++)
		{
			if (head == null)	
			{
				head = new List();
				if (int.TryParse(reader.ReadLine(), out file))
				{
					head.element.elem = file;
				}
				now = head;
				prenow = head;
			}
			else if (i == line * collum)
			{
				tail = new List();
				if (int.TryParse(reader.ReadLine(), out file))
				{
					tail.element.elem = file;
				}
				now.next = tail;
				tail.prev = now;
				tail.top = prenow.next;
				now = now.next;
			}
			else if (j == collum)
			{
				newHead = new List();
				if (int.TryParse(reader.ReadLine(), out file))
				{
					newHead.element.elem = file;
				}
				now = newHead;
				now.top = prenow;
				prenow.under = now;
				j = 1;
			}
			else if (i > collum)
			{
				now.next = new List();
				if (int.TryParse(reader.ReadLine(), out file))
				{
					now.next.element.elem = file;
				}
				now.next.prev = now;
				prenow = prenow.next;
				now = now.next;
				now.top = prenow;
				prenow.under = now;
				if (j + 1 == collum)
				{
					prenow = newHead;
				}
				j++;
			}
			else
			{
				now.next = new List();
				if (int.TryParse(reader.ReadLine(), out file))
				{
					now.next.element.elem = file;
				}
				now.next.prev = now;
				now = now.next;
				j++;
			}
			sum += now.element.elem;
		}
		avarage = sum * 1.0 / quantity * 1.0;
		if (reader != null)
		{
			reader.Close();
		}
	}
	public void fill()
	{
		int j = 1;
		for (int i = 1; i <= quantity; i++)
		{
			if (head == null)
			{
				head = new List();
				now = head;
				prenow = head;
			}
			else if (i == line * collum)
			{
				tail = new List();
				now.next = tail;
				tail.prev = now;
				tail.top = prenow.next;
				now = now.next;
			}
			else if (j == collum)
			{
				newHead = new List();
				now = newHead;
				now.top = prenow;
				prenow.under = now;
				j = 1;
			}
			else if (i > collum)
			{
				now.next = new List();
				now.next.prev = now;
				prenow = prenow.next;
				now = now.next;
				now.top = prenow;
				prenow.under = now;
				if (j + 1 == collum)
				{
					prenow = newHead;
				}
				j++;
			}
			else
			{
				now.next = new List();
				now.next.prev = now;
				now = now.next;
				j++;
			}
			sum += now.element.elem;
		}
		avarage = sum * 1.0 / quantity * 1.0;
	}
	public void fill_concrete()
	{
		fill();
		int ans;
		int ans2;
		int h;
		int t;
		int temp;
		Console.Write("Линия элемента(максимум = ");
		Console.Write(line);
		Console.Write("): ");
		ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		if (ans > line || ans < 0)
		{
			Console.Write("Вы вышли за предел массива, автоматическое заполнение сработало\n");
			Console.ReadLine();
		}
		else
		{
			Console.Write("Колонка элемента:(максимум = ");
			Console.Write(collum);
			Console.Write("): ");
			ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			if (ans2 > collum || ans2 < 0)
			{
				Console.Write("Вы вышли за предел массива, автоматическое заполнение сработало\n");
				Console.ReadLine();
			}
			else
			{
				Console.Write("Элемент: ");
				temp = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

				h = ans - 1 + ans2 - 1;
				t = line - ans + collum - ans2;
				if (h <= t)
				{
					now = head;
					for (int i = 1; i < ans; i++)
					{
						now = now.under;
					}
					for (int i = 1; i < ans2; i++)
					{
						now = now.next;
					}
				}
				else
				{
					now = tail;
					for (int i = line; i > ans; i--)
					{
						now = now.top;
					}
					for (int i = collum; i > ans2; i--)
					{
						now = now.prev;
					}
				}
				now.element.elem = temp;
				now = head;
				sum = 0;
				for (int j = 1; j <= line; j++)
				{
					for (int i = 1; i <= collum; i++)
					{
						if (i == collum)
						{
							sum += now.element.elem;
						}
						else
						{
							sum += now.element.elem;
							now = now.next;
						}
					}
					for (int i = 1; i < collum; i++)
					{
						now = now.prev;
					}
					now = now.under;
					Console.Write("\n");
				};
				avarage = sum * 1.0 / quantity * 1.0;
			}
		}
	}
	public void change_concrete()
	{
		int ans;
		int ans2;
		int h;
		int t;
		int temp;
		Console.Write("Линия элемента(максимум = ");
		Console.Write(line);
		Console.Write("): ");
		ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		if (ans > line || ans < 0)
		{
			Console.Write("Вы вышли за предел массива, автоматическое заполнение сработало\n");
			Console.ReadLine();
		}
		else
		{
			Console.Write("Колонка элемента:(максимум = ");
			Console.Write(collum);
			Console.Write("): ");
			ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			if (ans2 > collum || ans2 < 0)
			{
				Console.Write("Вы вышли за предел массива, автоматическое заполнение сработало\n");
				Console.ReadLine();
			}
			else
			{
				Console.Write("Элемент: ");
				temp = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

				h = ans - 1 + ans2 - 1;
				t = line - ans + collum - ans2;
				if (h <= t)
				{
					now = head;
					for (int i = 1; i < ans; i++)
					{
						now = now.under;
					}
					for (int i = 1; i < ans2; i++)
					{
						now = now.next;
					}
				}
				else
				{
					now = tail;
					for (int i = line; i > ans; i--)
					{
						now = now.top;
					}
					for (int i = collum; i > ans2; i--)
					{
						now = now.prev;
					}
				}
				now.element.elem = temp;
				now = head;
				sum = 0;
				for (int j = 1; j <= line; j++)
				{
					for (int i = 1; i <= collum; i++)
					{
						if (i == collum)
						{
							sum += now.element.elem;
						}
						else
						{
							sum += now.element.elem;
							now = now.next;
						}
					}
					for (int i = 1; i < collum; i++)
					{
						now = now.prev;
					}
					now = now.under;
					Console.Write("\n");
				};
				avarage = sum * 1.0 / quantity * 1.0;
			}
		}
	}
	public void @out()
	{
		now = head;
		if (line == 0 || collum == 0)
		{
			Console.Write("Массив пустой\n\n");
		}
		else
		{
			for (int j = 1; j <= line; j++)
			{
				for (int i = 1; i <= collum; i++)
				{
					if (i == collum)
					{
						now.element.@out();
					}
					else
					{
						now.element.@out();
						now = now.next;
					}
				}
				for (int i = 1; i < collum; i++)
				{
					now = now.prev;
				}
				now = now.under;
				Console.Write("\n");
			};
			Console.Write("Сумма = ");
			Console.Write(sum);
			Console.Write("\n");
			Console.Write("Среднее арифметическое = ");
			Console.Write(avarage);
			Console.Write("\n");
			Console.Write("\n");
		}
	}
	public void show_concr()
	{
		int ans;
		int ans2;
		int h;
		int t;
		if (line == 0)
		{
			Console.Write("Извините массив пустой\n");
			Console.ReadLine();
		}
		else
		{
			Console.Write("Линия элемента(максимум = ");
			Console.Write(line);
			Console.Write("):");
			ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			if (ans > line || ans < 0)
			{
				Console.Write("Вы вышли за предел массива\n");
				Console.ReadLine();
			}
			else
			{
				Console.Write("Колонка элемента:(максимум = ");
				Console.Write(collum);
				Console.Write("):");
				ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				if (ans2 > collum || ans2 < 0)
				{
					Console.Write("Вы вышли за предел массива\n");
					Console.ReadLine();
				}
				else
				{
					h = ans - 1 + ans2 - 1;
					t = line - ans + collum - ans2;
					if (h <= t)
					{
						now = head;
						for (int i = 1; i < ans; i++)
						{
							now = now.under;
						}
						for (int i = 1; i < ans2; i++)
						{
							now = now.next;
						}
					}
					else
					{
						now = tail;
						for (int i = line; i > ans; i--)
						{
							now = now.top;
						}
						for (int i = collum; i > ans2; i--)
						{
							now = now.prev;
						}
					}
					Console.Write("Элемент: ");
					now.element.@out();
					Console.Write("\n");
				}
			}
		}
	}
	public void show_line(int lin = 1, int direcrion = 1)
	{
		if (line == 0)
		{
			Console.Write("Извините массив пустой\n");
			Console.ReadLine();
		}
		else
		{
			now = head;
			int sum = 0;
			int avarage = 0;
			switch (direcrion)
			{
			case 1:
				for (int i = 1; i < lin; i++)
				{
					now = now.under;
				}
				for (int j = 1; j <= collum; j++)
				{
					sum += now.element.elem;
					if (j == collum)
					{
						now.element.@out();
					}
					else
					{
						now.element.@out();
						now = now.next;
					}
				}
				break;
			case 2:
				for (int i = 1; i < lin; i++)
				{
					now = now.under;
				}
				for (int i = 1; i < collum; i++)
				{
					now = now.next;
				}
				for (int j = 1; j <= collum; j++)
				{
					sum += now.element.elem;
					if (j == collum)
					{
						now.element.@out();
					}
					else
					{
						now.element.@out();
						now = now.prev;
					}
				}
				break;
			default:
				break;
			}
		}
		Console.Write("\n");
		avarage = sum / collum;
		Console.Write("Сумма = ");
		Console.Write(sum);
		Console.Write("\n");
		Console.Write("Среднее арифметичекое = ");
		Console.Write(avarage);
		Console.Write("\n");
	}
	public void show_collum(int col = 1, int direcrion = 1)
	{
		if (line == 0)
		{
			Console.Write("Извините массив пустой\n");
			Console.ReadLine();
		}
		else
		{
			now = head;
			int sum = 0;
			int avarage = 0;
			switch (direcrion)
			{
			case 1:
				for (int i = 1; i < col; i++)
				{
					now = now.next;
				}
				for (int j = 1; j <= line; j++)
				{
					sum += now.element.elem;
					if (j == line)
					{
						now.element.@out();
						Console.Write("\n");
					}
					else
					{
						now.element.@out();
						Console.Write("\n");
						now = now.under;
					}
				}
				break;
			case 2:
				for (int i = 1; i < col; i++)
				{
					now = now.next;
				}
				for (int i = 1; i < line; i++)
				{
					now = now.under;
				}
				for (int j = 1; j <= line; j++)
				{
					sum += now.element.elem;
					if (j == collum)
					{
						now.element.@out();
						Console.Write("\n");
					}
					else
					{
						now.element.@out();
						Console.Write("\n");
						now = now.top;
					}

				}
				break;
			default:
				break;
			}
		}
		Console.Write("\n");
		avarage = sum / collum;
		Console.Write("Сумма = ");
		Console.Write(sum);
		Console.Write("\n");
		Console.Write("Среднее арифметичекое = ");
		Console.Write(avarage);
		Console.Write("\n");
	}
	public void filter()
	{
		if (line == 0)
		{
			Console.Write("Извините массив пустой\n");
			Console.ReadLine();
		}
		else
		{
			char condition;
			int ans;
			Console.Write("Введите условие: <,>,=, c(четное), n(нечетное)");
			condition = ConsoleInput.ReadToWhiteSpace(true)[0];
			switch (condition)
			{
			case '<':
				Console.Write("Число: ");
				ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				now = head;
				for (int j = 1; j <= line; j++)
				{
					for (int i = 1; i <= collum; i++)
					{
						if (now.element.elem < ans)
						{
							if (i == collum)
							{
								now.element.@out();
							}
							else
							{
								now.element.@out();
								now = now.next;
							}
						}
						else
						{
							if (i == collum)
							{
								Console.Write("    ");
							}
							else
							{
								Console.Write("    ");
								now = now.next;
							}

						}
					}
					for (int i = 1; i < collum; i++)
					{
						now = now.prev;
					}
					now = now.under;
					Console.Write("\n");
				};
				break;

			case '>':
				Console.Write("Число: ");
				ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				now = head;
				for (int j = 1; j <= line; j++)
				{
					for (int i = 1; i <= collum; i++)
					{
						if (now.element.elem > ans)
						{
							if (i == collum)
							{
								now.element.@out();
							}
							else
							{
								now.element.@out();
								now = now.next;
							}
						}
						else
						{
							if (i == collum)
							{
								Console.Write("    ");
							}
							else
							{
								Console.Write("    ");
								now = now.next;
							}

						}
					}
					for (int i = 1; i < collum; i++)
					{
						now = now.prev;
					}
					now = now.under;
					Console.Write("\n");
				};
				break;
			case '=':
				Console.Write("Число: ");
				ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				now = head;
				for (int j = 1; j <= line; j++)
				{
					for (int i = 1; i <= collum; i++)
					{
						if (now.element.elem == ans)
						{
							if (i == collum)
							{
								now.element.@out();
							}
							else
							{
								now.element.@out();
								now = now.next;
							}
						}
						else
						{
							if (i == collum)
							{
								Console.Write("    ");
							}
							else
							{
								Console.Write("    ");
								now = now.next;
							}

						}
					}
					for (int i = 1; i < collum; i++)
					{
						now = now.prev;
					}
					now = now.under;
					Console.Write("\n");
				};
				break;
			case 'c':
				now = head;
				for (int j = 1; j <= line; j++)
				{
					for (int i = 1; i <= collum; i++)
					{
						if ((now.element.elem % 2) == 0)
						{
							if (i == collum)
							{
								now.element.@out();
							}
							else
							{
								now.element.@out();
								now = now.next;
							}
						}
						else
						{
							if (i == collum)
							{
								Console.Write("    ");
							}
							else
							{
								Console.Write("    ");
								now = now.next;
							}

						}
					}
					for (int i = 1; i < collum; i++)
					{
						now = now.prev;
					}
					now = now.under;
					Console.Write("\n");
				};
				break;
			case 'n':
				now = head;
				for (int j = 1; j <= line; j++)
				{
					for (int i = 1; i <= collum; i++)
					{
						if ((now.element.elem % 2) != 0)
						{
							if (i == collum)
							{
								now.element.@out();
							}
							else
							{
								now.element.@out();
								now = now.next;
							}
						}
						else
						{
							if (i == collum)
							{
								Console.Write("    ");
							}
							else
							{
								Console.Write("    ");
								now = now.next;
							}

						}
					}
					for (int i = 1; i < collum; i++)
					{
						now = now.prev;
					}
					now = now.under;
					Console.Write("\n");
				};
				break;
			default:
				break;
			}
		}
	}
	public void find_path_to_file()
	{
		StreamWriter writer = new StreamWriter("path.txt");

		int ans;
		int ans2;
		int h;
		int t;
		if (line == 0)
		{
			Console.Write("Извините пустой\n");
			Console.ReadLine();
		}
		else
		{
			Console.Write("Линия элемента(максимум = ");
			Console.Write(line);
			Console.Write("): ");
			ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			if (ans > line || ans < 0)
			{
				Console.Write("Вы вышли за предел массива\n");
				Console.ReadLine();
			}
			else
			{
				Console.Write("Колонка элемента(максимум = ");
				Console.Write(collum);
				Console.Write("): ");
				ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				if (ans2 > collum || ans2 < 0)
				{
					Console.Write("Вы вышли за предел массива\n");
					Console.ReadLine();
				}
				else
				{
					h = ans - 1 + ans2 - 1;
					t = line - ans + collum - ans2;
					if (h <= t)
					{
						Console.WriteLine("От верхнего левого элемента");
						now = head;

						for (int i = 1; i < ans; i++)
						{
							Console.WriteLine(now.element.elem + "->");
							//@out << now.element.elem << "->";
							now = now.under;
						}
						for (int i = 1; i < ans2; i++)
						{
							Console.WriteLine(now.element.elem + "->");
							now = now.next;
						}
					}
					else
					{
						Console.WriteLine("От нижнего правого элемента");
						now = tail;
						for (int i = line; i > ans; i--)
						{
							Console.WriteLine(now.element.elem + "->");
							now = now.top;
						}
						for (int i = collum; i > ans2; i--)
						{
							Console.WriteLine(now.element.elem + "->");
							now = now.prev;
						}
					}
					Console.WriteLine(now.element.elem);
					//@out.close();
					writer.Close();
				}
			}
		}
	}
	public void find_path()
	{
		int ans;
		int ans2;
		int h;
		int t;
		int step = 0;
		if (line == 0)
		{
			Console.Write("Извините пустой\n");
			Console.ReadLine();
		}
		else
		{
			Console.Write("Линия элемента(максимум = ");
			Console.Write(line);
			Console.Write("): ");
			ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			if (ans > line || ans < 0)
			{
				Console.Write("Вы вышли за предел массива\n");
				Console.ReadLine();
			}
			else
			{
				Console.Write("Колонка элемента(максимум = ");
				Console.Write(collum);
				Console.Write("): ");
				ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				if (ans2 > collum || ans2 < 0)
				{
					Console.Write("Вы вышли за предел массива\n");
					Console.ReadLine();
				}
				else
				{
					h = ans - 1 + ans2 - 1;
					t = line - ans + collum - ans2;
					if (h <= t)
					{
						Console.Write("От верхнего левого элемента");
						Console.Write("\n");
						now = head;

						for (int i = 1; i < ans; i++)
						{
							Console.Write(now.element.elem);
							Console.Write("->");
							step++;
							now = now.under;
						}
						for (int i = 1; i < ans2; i++)
						{
							Console.Write(now.element.elem);
							Console.Write("->");
							step++;
							now = now.next;
						}
					}
					else
					{
						Console.Write("От нижнего правого элемента");
						Console.Write("\n");
						now = tail;
						for (int i = line; i > ans; i--)
						{
							Console.Write(now.element.elem);
							Console.Write("->");
							step++;
							now = now.top;
						}
						for (int i = collum; i > ans2; i--)
						{
							Console.Write(now.element.elem);
							Console.Write("->");
							step++;
							now = now.prev;
						}
					}
					Console.Write(now.element.elem);
					Console.Write("\n");
					Console.Write("Элемент найден за ");
					Console.Write(step);
					Console.Write(" шагa(ов)\n");
				}
			}
		}
		Console.ReadLine();
	}
	public void add_line()
	{
		int j = 1;
		line++;
		prenow = tail;
		now = tail;
		if (quantity != 0)
		{
			for (int i = 1; i < collum; i++)
			{
				prenow = prenow.prev;
			}
			j = collum;
		}
		quantity += collum;
		for (int i = quantity - collum + 1; i <= quantity; i++)
		{
			if (head == null)
			{
				head = new List();
				now = head;
				prenow = head;
			}
			else if (i == line * collum)
			{
				tail = new List();
				now.next = tail;
				tail.prev = now;
				tail.top = prenow.next;
				now = now.next;
			}
			else if (j == collum)
			{
				newHead = new List();
				now = newHead;
				now.top = prenow;
				prenow.under = now;
				j = 1;
			}
			else if (i > collum)
			{
				now.next = new List();
				now.next.prev = now;
				prenow = prenow.next;
				now = now.next;
				now.top = prenow;
				prenow.under = now;
				if (j + 1 == collum)
				{
					prenow = newHead;
				}
				j++;
			}
			else
			{
				now.next = new List();
				now.next.prev = now;
				now = now.next;
				j++;
			}
			sum += now.element.elem;
		}
		avarage = sum * 1.0 / quantity * 1.0;
	}
	public void remove_line()
	{
		if (line == 0)
		{
			Console.Write("Пустой\n");
			Console.ReadLine();
		}
		else
		{
			quantity -= collum;
			line--;
			now = tail;
			if (quantity == 0)
			{
				tail = null;
			}
			else
			{
				tail = tail.top;
			}
			List temp = null;
			for (int i = 1; i <= collum; i++)
			{
				sum -= now.element.elem;
				if (quantity == 0 && i == collum)
				{
					now = null;
					head = null;
					//collum = 0;
				}
				else if (i == collum)
				{
						now = null;
				}
					else
					{
						temp = now.prev;

						now = null;
						now = temp;
					}
			}
			avarage = sum * 1.0 / quantity * 1.0;
		}
	}
	public void delete_list()
	{
		now = head;
		List temp = null;
		List temp1 = null;
		for (int j = 1; j < line; j++)
		{
			for (int i = 1; i <= collum; i++)
			{
				if (i == 1)
				{
					temp1 = now.under;
				}
				else if (i == collum)
				{
					now = null;
					now = temp1;
				}
				else
				{
					temp = now.next;
					now = null;
					now = temp;
				}
			}
		};
	}
	public void add_col()
	{
		now = head;

		if (quantity != 0)
		{
			prenow = head.under;
		}
		else
		{
			prenow = null;
		}

		if (quantity == 0)
		{
		head = new List();
		now = head;
		prenow = head;
		sum += now.element.elem;
		for (int i = 1; i < line; i++)
		{
			now.under = new List();
			now.under.top = now;
			now = now.under;
			sum += now.element.elem;
		}
		}
		else
		{
			for (int i = 1; i <= line; i++)
			{

				for (int j = 1; j < collum; j++)
				{
					now = now.next;
				}
				if (i == 1)
				{
					now.next = new List();
					now.next.prev = now;
				}
				else if (i == line)
				{
					tail = new List();
					tail.prev = now;
					now.next = tail;
					tail.top = now.top.next;
					now.top.next.under = tail;
				}
				else
				{
					now.next = new List();
					now.next.prev = now;
					now = now.next;
					now.top = now.prev.top.next;
					now.top.under = now;
				}
				sum += now.element.elem;
				now = prenow;
				if (i + 1 != line)
				{
					prenow = now.under;
				}
			};
		}
		quantity += line;
		collum++;
		avarage = sum * 1.0 / quantity * 1.0;


	}
	public void remove_col()
	{
		if (collum == 0)
		{
			Console.Write("Пустой\n");
			Console.ReadLine();
		}
		else
		{
			quantity -= line;
			collum--;
			now = tail;
			if (quantity == 0)
			{
				tail = null;
			}
			else
			{
				tail = tail.prev;
			}
			List temp = null;
			for (int i = 1; i <= line; i++)
			{
				sum -= now.element.elem;
				if (quantity == 0 && i == line)
				{
					now = null;
					head = null;
				}
				else if (i == line)
				{
					now = null;
				}
				else
				{
					temp = now.top;
					now = null;
					now = temp;
				}
			}
			avarage = sum * 1.0 / quantity * 1.0;
		}
	}
public static void Menu(int pos)
	{
		string[] options = {
		"1)Конкретный элемент", "2)Конкретная линия", "3)Конкретная колонка", "4)Фильтр массива",
		"5)Кратчайший путь к элементу", "6)Путь к элементу в файл \"path.txt\"", "7)Изменить значение ячейки",
		"8)Добавить линию", "9)Удалить последнюю линию", "10)Добавить колонку", "11)Удалить последнюю колонку",
		"12)Выход", "13)Автор"
	};

		for (int i = 0; i < options.Length; i++)
		{
			if (i == pos)
			{
				Console.ForegroundColor = ConsoleColor.Green; // Цвет для выделения активной опции
				Console.WriteLine(options[i]);
				Console.ResetColor(); // Сброс цвета обратно на стандартный
			}
			else
			{
				Console.WriteLine(options[i]);
			}
		}
	}
}