using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SheetMetalCalc.ViewModels
{
    public class MaterialManagerWindowModelView : Base.ModelView
    {

        #region Fields
        private ObservableCollection<Models.Material> listOfMaterials = new ObservableCollection<Models.Material>();

        private string nameOfMaterial;
        private double density;
        #endregion Fields

        #region Properties
        public double Density
        {
            get => density;
            set => Set(ref density, value);
        }
        public string NameOfMaterial
        {
            get => nameOfMaterial;
            set => Set(ref nameOfMaterial, value);
        }

        public ObservableCollection<Models.Material> ListOfMaterials
        {
            get => listOfMaterials;
            set => Set(ref listOfMaterials, value);
        }
        #endregion Properties

        #region Events

        #endregion Events

        #region Constructors

        #endregion Constructors

        #region Methods

        #region Privates
        bool IsNameOfMaterialExist(string name)
        {
            if (listOfMaterials != null)
            {
                var existElement = listOfMaterials.Where(x => x.Name == name).FirstOrDefault();
                if (existElement != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        bool IsNewMaterialCorrect()
        {
            if (!string.IsNullOrEmpty(NameOfMaterial) && Density > 0)
            {
                if(!string.IsNullOrWhiteSpace(NameOfMaterial))
                {
                    if (!IsNameOfMaterialExist(NameOfMaterial))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        void LoadModel()
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Открыть документ с материалами:";
            ofd.Filter = "Документ материалов(*.dm)|*.dm";
            ofd.DefaultExt = "dm";
            var result = ofd.ShowDialog();
            if (result == true)
            {
                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    string content;
                    using (var reader = new StreamReader(ofd.FileName))
                    {
                        content = reader.ReadToEnd();
                    }
                    if(!string.IsNullOrEmpty(content))
                    {
                        ListOfMaterials = new ObservableCollection<Models.Material>(Support.JsonWorker.GetDeserializedListString(content));
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Не удалось загрузить файл материалов, возможно файл повреждён", "Менеджер материалов", 
                            System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    }
                }
            }
        }
        void SaveModel()
        {
            var sfd = new SaveFileDialog();
            sfd.Title = "Сохранить документ с материалами:";
            sfd.Filter = "Документ материалов(*.dm)|*.dm";
            sfd.DefaultExt = "dm";
            var result = sfd.ShowDialog();
            if (result == true)
            {
                if (!string.IsNullOrEmpty(sfd.FileName))
                {
                    var content = Support.JsonWorker.GetSerializedObj(ListOfMaterials);
                    using (var writer = new StreamWriter(sfd.FileName, false))
                    {
                        writer.WriteLine(content);
                    }
                }
            }
        }
        #endregion Privates	

        #region Public

        #endregion Public

        #endregion Methods
        public ICommand DeleteMaterialComm
        {
            get
            {
                return new Commands.VMCommands(parameter =>
                {
                    if (parameter is Models.Material)
                    {
                        ListOfMaterials.Remove(parameter as Models.Material);
                    }
                }, (obj) => true);
            }
        }
        public ICommand OpenFileComm
        {
            get
            {
                return new Commands.VMCommands((obj) =>
                {
                    LoadModel();
                }, (obj) => { return true; });
            }
        }
        public ICommand SaveFileComm
        {
            get
            {
                return new Commands.VMCommands((obj) =>
                {
                    SaveModel();
                }, (obj) => { return true; });
            }
        }
        public ICommand AddMaterialComm
        {
            get
            {
                return new Commands.VMCommands((obj) =>
                {
                    var newMat = new Models.Material
                    {
                        Name = NameOfMaterial,
                        Density = this.Density
                    };
                    ListOfMaterials.Add(newMat);
                }, (obj) => { return IsNewMaterialCorrect();});
            }
        }
    }
}
