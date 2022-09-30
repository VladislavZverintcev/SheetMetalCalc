using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetMetalCalc.Models
{
    //Наследуемся потому что видимо изменение свойств модели тоже должны вызывать PropertyChanged, подразумевается что тут всё таки возможно редактировать элемент из списка
    public class Part : ViewModels.Base.ModelView
    {

        #region Fields
        private int count;
        private double weight;
        private Models.TypeOfPart partType;
        private bool isEnabled;
        #endregion Fields

        #region Properties
        public int Count
        {
            get => count;
            set => Set(ref count, value);
        }
        public double Weight
        {
            get => weight;
            set => Set(ref weight, value);
        }
        public Models.TypeOfPart PartType
        {
            get => partType;
            set => Set(ref partType, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => Set(ref isEnabled, value);
        }

        #endregion Properties

        #region Events

        #endregion Events

        #region Constructors

        #endregion Constructors

        #region Methods

        #region Privates

        #endregion Privates	

        #region Public

        #endregion Public

        #endregion Methods
    }
}
