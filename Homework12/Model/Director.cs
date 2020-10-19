using Homework12.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12.Model
{
    class Director : Worker
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор ввода директора
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Dep"></param>
        /// <param name="Position"></param>
        public Director(string Name, string Dep, string Position)
        {
            this.name = Name;
            this.dep = Dep;
            this.position = Position;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Director()
        {
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод расчета зарплаты директора (Доработать)
        /// </summary>
        /// <param name="WorkHour"></param>
        /// <returns></returns>
        public override double SalaryCalculation(double WorkHour)
        {
            // Временная переменная зарплаты директора
            double Salary = 0;

            // Цикл расчета зарплаты диретора
            foreach (var s in MainViewModul.divCol)
            {
                Salary = Salary + s.MonthSalary;
            }

            // Расчет зарплаты директора департамента из расчета суммы зарплат всех сотрудников отдела всех сотрудников умноженная на 15%
            Salary = Salary * 0.15;

            // Определение минимальной зарплаты директора департамента
            Salary = Salary > 1300 ? Salary : 1300;

            return Salary;
        }

        #endregion

    }
}
