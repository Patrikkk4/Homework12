using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12.Model
{
    class Employee : Worker
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор добавления сотрудника
        /// </summary>
        /// <param name="Dep"></param>
        /// <param name="Division"></param>
        /// <param name="Position"></param>
        /// <param name="WorkHour"></param>
        public Employee(string Name, string Dep, string Division, string Position, double WorkHour, double WorkDays)
            : base( Name, Dep, Division, Position, WorkHour, WorkDays)
        {

        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод расчета зарплаты сотрудника
        /// </summary>
        /// <param name="WorkHour"></param>
        /// <returns></returns>
        public override double SalaryCalculation(double WorkHour)
        {
            // Расчет зарплаты сотрудника
            var salary = standartSalary * WorkHour;

            return salary;
        }

        #endregion
    }
}
