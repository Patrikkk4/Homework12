using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using Homework12.ViewModel;

namespace Homework12.Model
{
    /// <summary>
    /// Вспомогательный класс для загрузки информации из файла json
    /// </summary>
    class HelpClass : Worker
    {
        #region Конструктор

        public HelpClass(double Id, string Name, string Dep, string Division, string Position, double WorkHour, double WorkDays)
            : base(Name, Dep, Division, Position, WorkHour, WorkDays)
        {
        }

        #endregion

        #region Методы

        /// <summary>
        /// Загрузка из файла Json
        /// </summary>
        public static ObservableCollection<Worker> LoadFile()
        {
            // Инициализация считывания json файла
            string loadJson = File.ReadAllText(@"saveAll.json");

            // Заполненение временной коллекции из файла json
            var temp = JsonConvert.DeserializeObject<ObservableCollection<HelpClass>>(loadJson);

            // заполнение общей коллекции
            foreach (var t in temp)
            {
                MainViewModul.allPositions.Add(t);
            }
            
            return MainViewModul.allPositions;
        }

        /// <summary>
        /// Метод сохранения всех работников в Json
        /// </summary>
        public static void SaveCollection()
        {
            // Сериализация в файл json
            string json = JsonConvert.SerializeObject(MainViewModul.allPositions);

            // Запись в файл по выбранному пути
            File.WriteAllText(@"saveAll.json", json);
        }

        #endregion
    }
}
