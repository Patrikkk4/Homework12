using Homework12.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12.Model
{
    /// <summary>
    /// Абстрактныый класс добавления сотрудника
    /// </summary>
    abstract class Worker
    {
        #region Поля

        //protected double id;

        /// <summary>
        /// Поле стандартной зарплаты сотрудника
        /// </summary>
        protected double standartSalary = 15;

        /// <summary>
        /// Поле имени
        /// </summary>
        protected string name;

        /// <summary>
        /// Поле департамента
        /// </summary>
        protected string dep;

        /// <summary>
        /// Поле отдела
        /// </summary>
        protected string division;

        /// <summary>
        /// Поле Должности
        /// </summary>
        protected string position;

        /// <summary>
        /// Поле зарплаты
        /// </summary>
        protected double salary;

        /// <summary>
        /// Поле количества рабочих часов (в день)
        /// </summary>
        protected double workHour;

        /// <summary>
        /// Количество рабочих дней (в месяц)
        /// </summary>
        protected double workDays;

        /// <summary>
        /// Зарплата за месяц
        /// </summary>
        protected double monthSalary;

        #endregion

        #region Свойства

        //public double Id { get { return id; } set { id = value; } }

        /// <summary>
        /// Свойство "Департамент"
        /// </summary>
        public string Dep { get { return this.dep; } set { dep = value; } }

        /// <summary>
        /// Свойство "Отдел"
        /// </summary>
        public string Division { get { return this.division; } set { division = value; } }

        /// <summary>
        /// Свойство "Должность"
        /// </summary>
        public string Position { get { return this.position; } set { position = value; } }

        /// <summary>
        /// Свойство "имя"
        /// </summary>
        public string Name { get { return this.name; } set { name = value; } }

        /// <summary>
        /// Свойство "Зарплата"
        /// </summary>
        public double Salary { get { return this.salary; } set { salary = value; } }

        /// <summary>
        /// Свойство "Рабочие часы" (в день)
        /// </summary>
        public double WorkHour { get { return this.workHour; } set { workHour = value; } }

        /// <summary>
        /// Свойство "Рабочие дни" (в месяц)
        /// </summary>
        public double WorkDays { get { return this.workDays; } set { workDays = value; } }

        /// <summary>
        /// Поле зарплаты за месяц
        /// </summary>
        public double MonthSalary { get { return monthSalary; } set { monthSalary = value; } }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор добавления нового работника
        /// </summary>
        /// <param name="Dep"></param>
        /// <param name="Division"></param>
        /// <param name="Position"></param>
        /// <param name="WorkHour"></param>
        public Worker(string Name, string Dep, string Division, string Position, double WorkHour, double WorkDays)
        {
            this.name = Name;
            this.dep = Dep;
            this.division = Division;
            this.position = Position;
            this.salary = SalaryCalculation(WorkHour);
            this.workHour = WorkHour;
            this.workDays = WorkDays;
            if (Position == "интерн" || Position == "стажер")
            {
                this.monthSalary = 500;
            }
            else
            {
                // Расчет зарплаты работника
                this.monthSalary = SalaryCalculation(WorkHour) * WorkDays;
            }

        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Worker()
        {
        }

        #endregion

        #region Методы

        /// <summary>
        /// Виртуальный метод расчета зарплаты
        /// </summary>
        /// <param name="WorkHour"></param>
        /// <returns></returns>
        public virtual double SalaryCalculation(double WorkHour)
        {
            double daySalary = standartSalary * WorkHour;

            return daySalary;
        }

        #endregion
    }
}
