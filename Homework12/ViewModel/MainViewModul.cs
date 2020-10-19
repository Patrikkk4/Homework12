using Homework12.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Homework12.Command;

namespace Homework12.ViewModel
{
    /// <summary>
    /// Класс View Model 
    /// </summary>
    class MainViewModul : MainVM
    {
        #region Поля

        /// <summary>
        /// Коллекия департаментов
        /// </summary>
        List<Worker> depCol = new List<Worker>();

        /// <summary>
        /// Коллекция отделов
        /// </summary>
        public static ObservableCollection<Worker> divCol = new ObservableCollection<Worker>();

        /// <summary>
        /// Коллекция директоров
        /// </summary>
        List<Worker> dirCol;

        /// <summary>
        /// Коллекция всех работников
        /// </summary>
        public static ObservableCollection<Worker> allPositions = new ObservableCollection<Worker>();

        /// <summary>
        /// Поле департамента для добавления сотрудника
        /// </summary>
        private string dep;

        /// <summary>
        /// Поле отдела для добавления сотрудника
        /// </summary>
        private string division;

        /// <summary>
        /// Поле имени сотрудника
        /// </summary>
        private string name;

        /// <summary>
        /// Поле должности
        /// </summary>
        private string position;

        /// <summary>
        /// Поле количества рабочих часов
        /// </summary>
        private double workHour;

        /// <summary>
        /// Поле количества рабочих дней
        /// </summary>
        private double workDays;

        /// <summary>
        /// Поле департаменда для вывода в таблицу
        /// </summary>
        private string depShow;

        /// <summary>
        /// Поле отдела для вывода в таблицу
        /// </summary>
        private string divisionShow;

        /// <summary>
        /// Вывод директора департамента
        /// </summary>
        private string txtDirector;

        /// <summary>
        /// Поле вывода зарплаты директора департамента
        /// </summary>
        private string txtDirectorSalary;

        /// <summary>
        /// Поле вывода имени директора департамента
        /// </summary>
        private string txtDirectorName;

        /// <summary>
        /// Поле выбранного работника в DataGrid allDepWorkers
        /// </summary>
        private Worker selectedWorker;

        #endregion

        #region Свойства

        /// <summary>
        /// Коллекция заполнения ComboBox cmbDep
        /// </summary>
        public List<string> DepCol { get; set; }

        /// <summary>
        /// Коллекция заполнения ComboBox cmbDivision
        /// </summary>
        public List<string> DivisionCol { get; set; }

        /// <summary>
        /// Свойство, содержащее всех работников
        /// </summary>
        public ObservableCollection<Worker> AllPositions
        {
            get { return allPositions; }
            set { allPositions = value; OnPropertyChanged(nameof(AllPositions)); }
        }

        /// <summary>
        /// Свойство, содержащее отделы департамента
        /// </summary>
        public ObservableCollection<Worker> DivCol
        {
            get { return divCol; }
            set { divCol = value; OnPropertyChanged(nameof(DivCol)); }
        }

        /// <summary>
        /// Свойство департамента для добавления сотрудника
        /// </summary>
        public string Dep 
        { 
            get { return dep; }
            set { dep = value; OnPropertyChanged(nameof(Dep)); }
        }

        /// <summary>
        /// Свойство отдела для добавления сотрудника
        /// </summary>
        public string Division
        {
            get { return division; }
            set { division = value; OnPropertyChanged(nameof(Division)); }
        }

        /// <summary>
        /// Свойство имени для добавления сотрудника
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        /// <summary>
        /// Свойство должности для добавления сотрудника
        /// </summary>
        public string Position
        {
            get { return position; }
            set { position = value; OnPropertyChanged(nameof(Position)); }
        }

        /// <summary>
        /// Свойство количества рабочих часов в день для добавления сотрудника
        /// </summary>
        public double WorkHour
        {
            get { return workHour; }
            set { workHour = value; OnPropertyChanged(nameof(WorkHour)); }
        }

        /// <summary>
        /// Свойство количества рабочих дней для добавления сотрудника
        /// </summary>
        public double WorkDays
        {
            get { return workDays; }
            set { workDays = value; OnPropertyChanged(nameof(WorkDays)); }
        }

        /// <summary>
        /// Свойство департамента для вывода сотрудника
        /// </summary>
        public string DepShow
        {
            get { return depShow; }
            set { depShow = value; OnPropertyChanged(nameof(DepShow)); }
        }

        /// <summary>
        /// Свойство отдела для вывода сотрудника
        /// </summary>
        public string DivisionShow
        {
            get { return divisionShow; }
            set { divisionShow = value; OnPropertyChanged(nameof(DivisionShow)); }
        }

        /// <summary>
        /// Свойство для вывода директора
        /// </summary>
        public string TxtDirector
        {
            get { return txtDirector; }
            set { txtDirector = value; OnPropertyChanged(nameof(TxtDirector)); }
        }

        /// <summary>
        /// Свойство для вывода зарплаты директора
        /// </summary>
        public string TxtDirectorSalary
        {
            get { return txtDirectorSalary; }
            set { txtDirectorSalary = value; OnPropertyChanged(nameof(TxtDirectorSalary)); }
        }

        /// <summary>
        /// Свойство для вывода имени директора
        /// </summary>
        public string TxtDirectorName
        {
            get { return txtDirectorName; }
            set { txtDirectorName = value; OnPropertyChanged(nameof(TxtDirectorName)); }
        }

        /// <summary>
        /// Свойство выбранного сотрудника в таблице DataGrid allDepWorkers
        /// </summary>
        public Worker SelectedWorker 
        {
            get { return selectedWorker; }
            set { selectedWorker = value; OnPropertyChanged(nameof(SelectedWorker)); }
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда добавления сотрудника
        /// </summary>
        public ICommand AddNewWorker
        {
            get
            {
                return new RelayCommand<object>(obj =>
                    {
                        AllPositions = AddWorker();
                    }
                    );
            }
        }

        /// <summary>
        /// Команда вывода сотрудников
        /// </summary>
        public ICommand ShowWorker
        {
            get
            {
                return new RelayCommand<object>(obj =>
                   {
                       ShowWorkers();
                   });
            }
        }

        /// <summary>
        /// Команда сохранения файла JSON
        /// </summary>
        public ICommand SaveFile
        {
            get
            {
                return new RelayCommand<object>(obj =>
                {
                    HelpClass.SaveCollection();
                });
            }
        }

        /// <summary>
        /// Команда удаления сотрудника
        /// </summary>
        public ICommand DeleteWorker
        {
            get
            {
                return new RelayCommand<object>(obj =>
                {
                    DelWorker();
                });
            }
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор заполнения View Model
        /// </summary>
        public MainViewModul()
        {
            // заполнение коллеции источника cmbDep и cmbDepShow
            DepCol = new List<string>() { "Департамент 1", "Департамент 2", "Департамент 3", "Департамент 4" };

            // заполнение коллеции источника cmbDivision и cmbDivisionShow
            DivisionCol = new List<string>() { "Отдел 1", "Отдел 2", "Отдел 3", "Отдел 4" };

            // Проверка наличия файла в папке с программой
            if (File.Exists("saveAll.json"))
            {
                // Заполнение коллекции из файла
                AllPositions = HelpClass.LoadFile();
            }
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод добавления сотрудника
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Worker> AddWorker()
        {
            // Условие добавления директора
            if (Position.Contains("директор"))
            {
                try
                {
                    // Заполнение конструктора добавления директора
                    Director addDirector = new Director(Name, Dep, Position);

                    // Извлечение департамента соответственно выбору cmbDep для проверки наличия директора
                    depCol = AllPositions.Where(x => x.Dep == Dep).ToList();

                    // Условие проверки наличия директора в департаменте
                    if (depCol.Where(x => x.Position.Contains("директор")).Count() == 0)
                    {
                        // Добавление в коллекцию нового директора
                        allPositions.Add(addDirector);
                    }
                    else
                    {
                        MessageBox.Show("Директор уже назначен");
                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность заполнения необходимых полей");
                }

                return allPositions;
            }
            // Условие добавления стажера
            else if (Position.Contains("стажер") || Position.Contains("интерн"))
            {
                try
                {
                    // Заполнение конструктора добавления интерна\стажера
                    Intern intern = new Intern(Name, Dep, Division, Position, 0, 0);

                    // Добавление в коллекцию нового сотрудника
                    allPositions.Add(intern);
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность заполнения необходимых полей");
                }

                return AllPositions;
            }
            // Условие добавления сотрудника
            else
            {
                try
                {
                    // Заполнение конструктора добавления сотрудника
                    Employee addEmploee = new Employee(Name, Dep, Division, Position, WorkHour, WorkDays);

                    // Добавление в коллекцию нового сотрудника
                    allPositions.Add(addEmploee);
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность заполнения необходимых полей");
                }

                return allPositions;
            }
        }      

        /// <summary>
        /// Метод вывода добавленных работников в таблицу
        /// </summary>
        public void ShowWorkers()
        {
            // Извлечение департамента соответственно выбору cmbDepShow
            depCol = AllPositions.Where(x => x.Dep == DepShow).ToList();

            // // Извлечение отделов соответственно выбору cmbDepShow (Цикл нужен, чтобы тип данных DivCol оставался ObservationCollection)
            foreach (var t in depCol)
            {
                if (t.Division == DivisionShow)
                {
                    divCol.Add(t);
                }
            }

            // Извлечение директора соответственно выбору cmbDepShow
            dirCol = AllPositions.Where(x => x.Position == "директор").ToList();

            try
            {
                // Источник вывода работников в таблицу DataGrid allDepWorkers
                DivCol = divCol;

                //Источник вывода директора
               TxtDirector = dirCol.Where(x => x.Dep == DepShow.ToString()).First().Position +
                   " " + DepShow;

                Director director = new Director();

                // Источник вывода зарплаты директора
                TxtDirectorSalary = director.SalaryCalculation(0).ToString() + "$";

                // Вывод имени директора департамента
                TxtDirectorName = dirCol.First().Name;
            }
            catch
            {
                TxtDirector = "Директор не назначен";

                TxtDirectorSalary = null;

                TxtDirectorName = null;
            }
        }
        
        /// <summary>
        /// Метод удаления работника
        /// </summary>
        void DelWorker()
        {
            // Удаление выбранного работника из общей коллекции
            AllPositions.Remove(SelectedWorker);

            // Удаление выбранного работника из коллекции вывода отдела
            DivCol.Remove(SelectedWorker);
        }

        #endregion
    }
}
