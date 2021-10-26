using System;
using System.IO;

namespace spellsProject
{
    enum Columns //Просто для удобства. Код читается лучше(как по мне), да и не нужно городить лишний огород
    {
        Label = 1,
        ImpactScript = 9,
        Bard = 10,
        Cleric = 11,
        Druid = 12,
        Paladin = 13,
        Ranger = 14,
        Wiz_Sorc = 15,
        ImmunityType = 37,
    }
    class Program
    {
        static void Main(string[] args)
        {
            var spellsFile = File.ReadAllLines("spells.2da.txt");
            Directory.CreateDirectory("ProjectFiles");
            File.Create(@"ProjectFiles\AcidSpells.txt").Close();
            File.AppendAllLines(@"ProjectFiles\AcidSpells.txt", spellsFile[0..3]);

            for(int i = 10; i <= 15; i++) //Создание файлов с названиями классов
            {
                string path = @"ProjectFiles\" + (Columns)i + ".txt";
                File.Create(path).Close();
                File.AppendAllLines(path, spellsFile[0..3]);
            }

            for (int i = 3; i < spellsFile.Length; i++)
            {
                var line = spellsFile[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (line[(int)Columns.Paladin] != "****") //Задание 1. Я так понял вывести - это в консоль?
                {
                    Console.WriteLine($"Label:\t{line[(int)Columns.Label]}");
                    Console.WriteLine($"Impact Script:\t{line[(int)Columns.ImpactScript]}\n");
                }

                if (line[(int)Columns.ImmunityType] == "Acid") //Задание 2
                    File.AppendAllText(@"ProjectFiles\AcidSpells.txt", spellsFile[i] + "\n");

                for (int x = 10; x <= 15; x++) //Задание 3
                    if (line[x] != "****") //А если число равно нулю? По логике считать не должно, но мало ли..
                        File.AppendAllText(@"ProjectFiles\" + (Columns)x + ".txt", spellsFile[i] + "\n");
            }
        }
    }
}
