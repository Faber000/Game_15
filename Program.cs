using System.Globalization;

string[] array = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "#", "15" };  


bool isOrder () {

	bool isOrder = true;
	for(int i = 0; i < array.Length; i++)
	{
		if(i > 0)
		{
			if(array[i-1] == "#")
			{
				if (Int32.Parse(array[i]) < Int32.Parse(array[i-2]))
				{
					isOrder = false;
				} 
			} 

			else

			{
				if (array[i] != "#") {

                    if (Int32.Parse(array[i]) < Int32.Parse(array[i-1]))
                    {
                        isOrder = false;
                    }

                }
            }
		}
	}
	return isOrder;
}

void StampaArray(string[] array)
{
	int cont = 0;
	for (int i = 0; i < array.Length; i++)
	{
		if(cont == 4)
		{
			Console.Write("\r\n");
            Console.Write(array[i] + "   ");
            cont = 0;
		}

		else
		{
            Console.Write(array[i] + "   ");
        }
		cont++;
    }
}

void ChangeNumber(string number)
{
	int j;
	if (getIndex(number) != -1 & (getIndex(number) == getIndex("#") - 1 | getIndex(number) == getIndex("#") + 1 | getIndex(number) == getIndex("#") - 4 | getIndex(number) == getIndex("#") + 4))
	{
		j = getIndex(number);
		array[getIndex("#")] = number;
		array[j] = "#";
	} 
	else
	{
		Console.WriteLine("errore");
	}
}

int getIndex(string number)
{
	int index = -1;

	for(int i = 0; i < array.Length; i++)
	{
		if (number == array[i])
		{
			index = i;
		}
	}
	return index;
}

string number;
do
{
    StampaArray(array);
    Console.WriteLine("che numero vuoi scambiare?");
	number = Console.ReadLine();
	ChangeNumber(number);

} while ((getIndex("#") != array.Length-1) | isOrder()==false);

Console.WriteLine("hai vinto");
StampaArray(array);
