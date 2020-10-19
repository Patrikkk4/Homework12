using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12.Model
{
    class Intern : Worker
    {
        /// <summary>
        /// Поле зарплаты за месяц
        /// </summary>
        new public double MonthSalary { get; set; } = 500;

        #region Конструкторы

        /// <summary>
        /// Конструктор добавления интерна
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Dep"></param>
        /// <param name="Division"></param>
        /// <param name="Position"></param>
        /// <param name="WorkHour"></param>
        public Intern(string Name, string Dep, string Division, string Position, int WorkHour, double WorkDays)
            : base(Name, Dep, Division, Position, WorkHour, WorkDays)
        {

        }
        #endregion
    }
}
