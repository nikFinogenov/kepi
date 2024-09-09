using System;

public static class GlobalMembers
{
	static void Main()
	{
		//CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
		Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
		List a = new List();
		int ans = 0;
		int direction;
		int pos = 0;
		bool flag = true;

		Console.Write("Как определить размер массива:\n1)(автоматически 5x5)\n2)(вручную, максимум 10x10)\nОтвет: ");
		pos = 0;
		while (ans != 1 && ans != 2)
		{
			while (!int.TryParse(Console.ReadLine(), out ans))
			{
				Console.Write("Ответ неверен, пожалуйста введите еще раз\n");
				Console.Read();
			}
			int ans2;
			switch (ans)
			{
			case 1:
				break;
			case 2:
				Console.Write("Количество линий:");
				ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				while (ans2 > 10 || ans2 <= 0)
				{
					Console.Write("Извините, минимум 1, максимум 10\nОтвет:");
					ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Console.Write("\n");
				}
				a.line = ans2;

				Console.Write("Количество колонок:");
				ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				while (ans2 > 10 || ans2 <= 0)
				{
					Console.Write("Извините, минимум 1, максимум 10\nОтвет:");
					ans2 = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					Console.Write("\n");
				}
				a.collum = ans2;
				a.quantity = a.collum * a.line;
				break;
			default:
				Console.Write("Ответ неверен, пожалуйста введите еще раз\n");
				break;
			}
		}
		ans = 0;
		Console.Write("Как заполнить массив:\n1(автоматически)\n2(1 элемент на ваш выбор, остальные автоматически)\nОтвет:");
		while (ans != 1 && ans != 2)
		{
			while (!int.TryParse(Console.ReadLine(), out ans))
			{
				Console.Write("Ответ неверен, пожалуйста введите еще раз\n");
				Console.Read();
			}

			switch (ans)
			{
			case 1:
					Console.Write("1)Автоматически заполнить\n2)Взять из файла\nОтвет:");
					while (!int.TryParse(Console.ReadLine(), out ans))
					{
						Console.Write("Ответ неверен, пожалуйста введите еще раз\n");
						Console.Read();
					}
					switch (ans)
					{
					case 1:
					{
						a.fill();
						break;
					}
					case 2:
						a.fill_from_file();
						break;
					default:
						Console.Write("Ответ неверен, пожалуйста введите еще раз\n");
						break;
					}
				break;
			case 2:
				a.fill_concrete();
				break;
			default:
				Console.Write("Ответ неверен, пожалуйста введите еще раз\n");
				break;
			}
		}
		while (flag)
		{
			Console.Clear();
			a.@out();
			List.Menu(pos);
			ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
			ConsoleKey key = keyInfo.Key;
			char keyPressed = keyInfo.KeyChar;
			switch (key)
			{
			case ConsoleKey.UpArrow:
				if (pos != 0)
				{
					pos--;
				}
				break;
			case ConsoleKey.DownArrow:
				if (pos != 12)
				{
					pos++;
				}
				break;
			case ConsoleKey.Enter:
				switch (pos + 1)
				{
				case 1:
					a.show_concr();
					Console.ReadLine();
					break;
				case 2:
					Console.Write("Какая линия?\nОтвет:");
					ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					if (ans > a.line || ans < 0)
					{
						Console.Write("За пределами массива\n");
					}
					else
					{
						Console.Write("1)Слево направо\n2)Справо налево\nОтвет: ");
						direction = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
						a.show_line(ans, direction);
						Console.ReadLine();
					}
					break;
				case 3:
					Console.Write("Какая колонка?\nОтвет:");
					ans = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
					if (ans > a.collum || ans < 0)
					{
						Console.Write("За пределами массива\n");
					}
					else
					{
						Console.Write("1)Сверху вниз, 2)Снизу вверх\nОтвет:");
						direction = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
						a.show_collum(ans, direction);
						Console.ReadLine();
					}
					break;
				case 4:
					a.filter();
					Console.ReadLine();
					break;
				case 5:
					a.find_path();
					break;
				case 6:
					a.find_path_to_file();
					break;
				case 7:
					a.change_concrete();
					break;
				case 8:
					a.add_line();
					break;
				case 9:
					a.remove_line();
					break;
				case 10:
					a.add_col();
					break;
				case 11:
					a.remove_col();
					break;
				case 12:
					flag = !flag;
					break;
				case 13:
					Console.Write("Работа выполнена студентом Финогенов Н.М.\n");
					Console.Write("Группа: ОПК-319\n");
					Console.ReadLine();
					break;
				default:
					break;
				}
				break;
			default:
				break;
			}
		}
		a.delete_list();
	}
}