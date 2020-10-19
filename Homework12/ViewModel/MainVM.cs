using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework12.ViewModel
{
    /// <summary>
    /// Наследуемый класс, который в свою очередь наследует интерфейс изменения свойств
    /// </summary>
    class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Обработчик события изменения свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод обработки изменения свойств
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
