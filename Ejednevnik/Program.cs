using Ejednevnik;
using System.Diagnostics.Metrics;
using System.Threading.Channels;
void rabotaipj()
{
    DateTime date = DateTime.Now;
    Console.WriteLine("Текущая дата: " + date.Date.ToString("D"));
    ConsoleKeyInfo cursor = Console.ReadKey();
    int position = 1;
    List<Zametki> day = new List<Zametki>();
    strelkarl(cursor);



    void note(ConsoleKeyInfo cursor, int position)
    {
        Zametki note = new Zametki();
        note.NameOfNote = "  1. Покушать";
        note.description = "Позавтракать на кухне";
        note.data = new DateTime(2023, 10, 12);



        Zametki note1 = new Zametki();
        note1.NameOfNote = "  2. Собраться на пары";
        note1.description = "Собрать рюкзак и выйти из дома на пары";
        note1.data = new DateTime(2023, 10, 12);



        Zametki note2 = new Zametki();
        note2.NameOfNote = "  1. Погулять";
        note2.description = "Погулять с 14:00 до 18:00";
        note2.data = new DateTime(2023, 10, 15);



        Zametki note3 = new Zametki();
        note3.NameOfNote = "  2. Купить хлеба";
        note3.description = "Сходить в магазин и купить хлеба";
        note3.data = new DateTime(2023, 10, 15);



        Zametki note4 = new Zametki();
        note4.NameOfNote = "  1. Проспать до обеда";
        note4.description = "Спать до обеда, а затем смотреть ютуб и играть в резидент до часу ночи";
        note4.data = new DateTime(2023, 10, 8);



        day.Add(note);
        day.Add(note1);
        day.Add(note2);
        day.Add(note3);
        day.Add(note4);



        for (int i = 0; i < day.Count; i++)
        {

            if (date.Date == day[i].data.Date)
            {

                Console.WriteLine(day[i].NameOfNote);

            }

        }
    }


    ConsoleKeyInfo newkey = Console.ReadKey();

    if (newkey.Key == ConsoleKey.Escape)
    {
        Console.WriteLine("Текущая дата: " + date.Date.ToString("D"));
        Console.Clear();
        rabotaipj();

    }




    void strelkarl(ConsoleKeyInfo cursor)
    {
        while (cursor.Key != ConsoleKey.Enter)
        {
            if (cursor.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
                date = date.AddDays(1);
                Console.WriteLine("Текущая дата: " + date.ToString("D"));

            }

            if (cursor.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                date = date.AddDays(-1);
                Console.WriteLine("Текущая дата: " + date.ToString("D"));
            }
            
            cursor = Console.ReadKey();
        }
        strelkaud(cursor, position);
    }

    



    void strelkaud(ConsoleKeyInfo kluch, int position)
    {
        note(cursor, position);
        do
        {

            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");

            kluch = Console.ReadKey();

            Console.SetCursorPosition(0, position);
            Console.WriteLine("  ");
            if (kluch.Key == ConsoleKey.DownArrow && position != 2)
            {
                position++;
            }

            if (kluch.Key == ConsoleKey.UpArrow && position != 1)
            {
                position--;
            }
            Console.SetCursorPosition(0, 4);

        } while ( kluch.Key != ConsoleKey.Enter && kluch.Key != ConsoleKey.Escape );


        if (kluch.Key == ConsoleKey.Escape)
        {
            strelkarl(cursor);
        }
        if (kluch.Key == ConsoleKey.Enter)
        {
            int NewPosAdd = 0;
            for (int i = 0; i < day.Count; i++)
            {
                if (day[i].data.Date == date.Date)
                {
                    NewPosAdd = i;
                    Console.Clear();
                    break;
                }
            }
            Console.WriteLine(day[position - 1 + NewPosAdd].description);
            Console.WriteLine(day[position - 1 + NewPosAdd].data.Date.ToString("D"));
        }

        
    }
}
rabotaipj();